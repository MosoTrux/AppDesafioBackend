using AppDesafio.Application.Dtos;
using FluentValidation;

namespace AppDesafio.Application.Validators.TipoCambio
{
    public class ActualizarTipoCambioDtoValidator : AbstractValidator<ActualizarTipoCambioDto>
    {
        public ActualizarTipoCambioDtoValidator()
        {
            RuleFor(dto => dto.Valor)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
