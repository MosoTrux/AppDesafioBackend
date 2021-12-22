using AppDesafio.Application.Dtos;
using AppDesafio.Domain.Entities;
using AutoMapper;

namespace AppDesafio.Application.Mapping.Profiles
{
    public class TipoCambioProfile : Profile
    {
        public TipoCambioProfile()
        {
            CreateMap<TipoCambio, ListarTipoCambioDto>();
            CreateMap<TipoCambio, TipoCambioDto>();
        }
    }
}
