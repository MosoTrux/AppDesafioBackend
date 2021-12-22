using AppDesafio.Application.Dtos;
using AppDesafio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDesafio.Application.Services
{
    public interface ITipoCambioService
    {
        Task<ServiceResponseDto<string>> Actualizar(string codigoIso, ActualizarTipoCambioDto dto);
        Task<ServiceResponseDto<string>> Agregar(AgregarTipoCambioDto dto);
        Task<ServiceResponseDto<AplicarTipoCambioDto>> Aplicar(AplicarTipoCambioInDto dto);
        Task<(bool existe, TipoCambio entity)> ExisteTipoCambio(string codigoISO);
        Task<ServiceResponseDto<IEnumerable<ListarTipoCambioDto>>> Listar();
        Task<ServiceResponseDto<TipoCambioDto>> ObtenerPorCodigo(string codigo);
    }
}
