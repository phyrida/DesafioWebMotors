using DesafioWebMotors.Domain.Dto;
using FluentValidation;

namespace DesafioWebMotors.Service.Validators
{
    public class AnuncioWebmotorsValidator : AbstractValidator<AnuncioWebmotorsDto>
    {
        public AnuncioWebmotorsValidator()
        {
            RuleFor(x => x.Ano).NotNull().NotEmpty().WithMessage("O campo ano é obrigatório");
            RuleFor(x => x.Observacao).NotNull().NotEmpty().WithMessage("O campo Observação é obrigatório");
            RuleFor(x => x.Marca).NotNull().NotEmpty().WithMessage("O campo Marca é obrigatório");
            RuleFor(x => x.Versao).NotNull().NotEmpty().WithMessage("O campo Versao é obrigatório");
            RuleFor(x => x.Quilometragem).NotNull().NotEmpty().WithMessage("O campo Quilometragem é obrigatório");
            RuleFor(x => x.Modelo).NotNull().NotEmpty().WithMessage("O campo Modelo é obrigatório");
        }
    }
}
