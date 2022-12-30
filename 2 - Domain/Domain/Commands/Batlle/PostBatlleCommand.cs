using Domain.Models.Command;
using Domain.Validators;
using MediatR;

namespace Domain.Commands.Batlle
{
    public class PostBatlleCommand : Validate, IRequest<PostBatlleCommandResponse>
    {
        public string CharacterOne { get; set; }
        public string CharacterTwo { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new PostBatlleCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
