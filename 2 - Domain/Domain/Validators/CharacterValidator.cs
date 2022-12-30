using Domain.Enums;
using Domain.Models;
using FluentValidation;
using Infrastructure.Application.Helpers;

namespace Domain.Validators
{
    public class CharacterValidator : AbstractValidator<CharacterModel>
    {
        public CharacterValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null");

            RuleFor(x => x.Name)
                .Must(IsValidName)
                .WithMessage("{PropertyName} is not valid");

            RuleFor(x => (int)x.Profession)
                .Must(IsValidProfession)
                .WithMessage("{PropertyName} is not valid");

        }

        private bool IsValidName(string name)
        {
            return name.IsValidName();
        }

        private bool IsValidProfession(int profession)
        {
            return Enum.IsDefined(typeof(Profession), profession);
        }
    }
}
