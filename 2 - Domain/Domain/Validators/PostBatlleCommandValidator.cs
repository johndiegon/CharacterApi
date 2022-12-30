using Domain.Commands.Batlle;
using FluentValidation;
using Infrastructure.Application.Helpers;

namespace Domain.Validators
{
    public class PostBatlleCommandValidator : AbstractValidator<PostBatlleCommand>
    {
        public PostBatlleCommandValidator()
        {
            RuleFor(x => x.CharacterOne)
                 .Must(IsValidName)
                .WithMessage("{PropertyName} cannot be null");

            RuleFor(x => x.CharacterTwo)
                .Must(IsValidName)
                .WithMessage("{PropertyName} is not valid");

        }
        private bool IsValidName(string name)
        {
            return name.IsValidName();
        }

    }
}
