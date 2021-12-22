using AppDesafio.Application.Dtos;
using AppDesafio.Domain.Entities;
using AppDesafio.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDesafio.Application.Services
{
    public class TipoCambioService : ITipoCambioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TipoCambioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponseDto<string>> Actualizar(string codigoIso, ActualizarTipoCambioDto dto)
        {
            try
            {
                var Messages = new List<string>();
                var (existe, entity) = await ExisteTipoCambio(codigoIso);
                if (!existe) Messages.Add("El tipo de cambio no existe.");

                if (Messages.Count > 0) return new ServiceResponseDto<string>() { IsSuccess = false, Messages = Messages };

                //Actualización de la entidad
                entity.Divisa = dto.Divisa;
                entity.Valor = dto.Valor;
                _unitOfWork.TipoCambioRepository.Update(entity);

                //Confirmación de cambios
                await _unitOfWork.SaveChangesAsync();

                return new ServiceResponseDto<string>()
                {
                    IsSuccess = true,
                    Data = "OK"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceResponseDto<string>> Agregar(AgregarTipoCambioDto dto)
        {
            try
            {
                var Messages = new List<string>();
                var tipoCambio = await ExisteTipoCambio(dto.CodigoIso);
                if (tipoCambio.existe) Messages.Add("El tipo de cambio ya fue registrado.");

                if (Messages.Count > 0) return new ServiceResponseDto<string>() { IsSuccess = false, Messages = Messages };

                var entity = new TipoCambio()
                {
                    CodigoIso = dto.CodigoIso,
                    Divisa = dto.Divisa,
                    Fecha = DateTime.Now,
                    Valor = dto.Valor
                };

                await _unitOfWork.TipoCambioRepository.Add(entity);
                await _unitOfWork.SaveChangesAsync();

                return new ServiceResponseDto<string>()
                {
                    IsSuccess = true,
                    Data = "OK"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceResponseDto<AplicarTipoCambioDto>> Aplicar(AplicarTipoCambioInDto dto)
        {
            try
            {
                var Messages = new List<string>();
                var tipoCambioOrigen = await _unitOfWork.TipoCambioRepository.GetBy(d => d.CodigoIso.Equals(dto.MonedaOrigen)).FirstOrDefaultAsync().ConfigureAwait(false);
                if (tipoCambioOrigen == null) Messages.Add("El tipo de cambio origen no existe.");

                var tipoCambioDestino = await _unitOfWork.TipoCambioRepository.GetBy(d => d.CodigoIso.Equals(dto.MonedaDestino)).FirstOrDefaultAsync().ConfigureAwait(false);
                if (tipoCambioDestino == null) Messages.Add("El tipo de cambio destino no existe.");

                if (Messages.Count > 0) return new ServiceResponseDto<AplicarTipoCambioDto>() { IsSuccess = false, Messages = Messages };

                return new ServiceResponseDto<AplicarTipoCambioDto>()
                {
                    IsSuccess = true,
                    Data = new AplicarTipoCambioDto()
                    {
                        Monto = dto.Monto,
                        MontoConTipoCambio = dto.Monto * (tipoCambioDestino.Valor / tipoCambioOrigen.Valor),
                        MonedaOrigen = tipoCambioOrigen.Divisa,
                        MonedaDestino = tipoCambioDestino.Divisa,
                        TipoCambio = (tipoCambioOrigen.Valor / tipoCambioDestino.Valor)
                    }
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(bool existe, TipoCambio entity)> ExisteTipoCambio(string codigoISO)
        {
            var entity = await _unitOfWork.TipoCambioRepository.GetBy(d => d.CodigoIso.Equals(codigoISO)).FirstOrDefaultAsync().ConfigureAwait(false);
            if (entity == null) return (false, entity);
            return (true, entity);
        }

        public async Task<ServiceResponseDto<IEnumerable<ListarTipoCambioDto>>> Listar()
        {
            try
            {
                return new ServiceResponseDto<IEnumerable<ListarTipoCambioDto>>()
                {
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<ListarTipoCambioDto>>(await _unitOfWork.TipoCambioRepository.GetAll().ToListAsync().ConfigureAwait(false))
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ServiceResponseDto<TipoCambioDto>> ObtenerPorCodigo(string codigo)
        {
            try
            {
                return new ServiceResponseDto<TipoCambioDto>()
                {
                    IsSuccess = true,
                    Data = _mapper.Map<TipoCambioDto>(await _unitOfWork.TipoCambioRepository.GetBy(d => d.CodigoIso.Equals(codigo)).FirstOrDefaultAsync().ConfigureAwait(false))
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
