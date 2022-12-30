using Domain.Enums;
using Domain.Models.Command;
using Infrastructure.Application.Helpers;
using Infrastructure.Data.Interfaces;
using MediatR;

namespace Domain.Commands.Character.Delete
{

    public class DeleteCharacterHandler : IRequestHandler<DeleteCharacterCommand, CommandResponse<object>>
    {
        public readonly ICharacaterRepository _characaterRepository;

        public DeleteCharacterHandler(ICharacaterRepository characaterRepository)
        {
            _characaterRepository = characaterRepository;
        }

        public async Task<CommandResponse<object>> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Name.IsValidName())
                {
                    await _characaterRepository.Delete(request.Name);

                    return new CommandResponse<object>
                    {
                        Status = StatusRequest.Sucessed,
                        Message = "The character was delete.",
                    };
                }
                else
                {
                    return new CommandResponse<object>
                    {
                        Status = StatusRequest.Error,
                        Message = "This name is invalid.",
                    };
                }
            }
            catch (Exception ex)
            {

                return new CommandResponse<object>
                {
                    Status = StatusRequest.Error,
                    Message = $"Forgive me for the unforeseen, but an internal error occurred: {ex.Message}.",
                };
            }
        }
    }
}
