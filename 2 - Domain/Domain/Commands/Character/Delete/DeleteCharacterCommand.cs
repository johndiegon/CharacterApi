using Domain.Models.Command;
using MediatR;

namespace Domain.Commands.Character.Delete
{
    public class DeleteCharacterCommand : IRequest<CommandResponse<object>>
    {
        public string Name { get; set; }
    }
}
