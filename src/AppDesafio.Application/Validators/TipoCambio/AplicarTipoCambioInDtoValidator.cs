using AppDesafio.Application.Dtos;
using FluentValidation;

namespace AppDesafio.Application.Validators.TipoCambio
{
    public class AplicarTipoCambioInDtoValidator : AbstractValidator<AplicarTipoCambioInDto>
    {
        public AplicarTipoCambioInDtoValidator()
        {
            RuleFor(dto => dto.Monto)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
