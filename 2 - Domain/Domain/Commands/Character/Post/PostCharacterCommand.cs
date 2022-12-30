using Domain.Models;
using Domain.Models.Command;
using Domain.Validators;
using MediatR;

namespace Domain.Commands.Character.Post
{
    public class PostCharacterCommand : Validate, IRequest<CommandResponse<CharacterModel>>
    {
        public CharacterModel Character { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CharacterValidator().Validate(this.Character);
            return ValidationResult.IsValid;
        }
    }
}
