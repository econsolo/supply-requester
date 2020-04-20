using FluentValidation;
using SupplyRequester.Model.DataTransferObjects;

namespace SupplyRequester.Model.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("É obrigatório informar o nome");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("É obrigatório informar o e-mail");

            RuleFor(user => user.Username)
                .NotEmpty()
                .WithMessage("É obrigatório informar o usuário");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty()
                .WithMessage("É obrigatório informar o número de celular");
        }
    }
}
