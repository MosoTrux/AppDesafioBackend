using AppDesafio.Application.Dtos;
using FluentValidation;

namespace AppDesafio.Application.Validators.TipoCambio
{
    public class AgregarTipoCambioDtoValidator : AbstractValidator<AgregarTipoCambioDto>
    {
        public AgregarTipoCambioDtoValidator()
        {
            RuleFor(dto => dto.CodigoIso)
                .NotNull()
                .NotEmpty()
                .MaximumLength(3);

            RuleFor(dto => dto.Valor)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
