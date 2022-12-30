using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Models.Command;
using Infrastructure.Data.Entity;
using Infrastructure.Data.Interfaces;
using MediatR;

namespace Domain.Commands.Character.Post
{
    public class PostCharacterHandler : IRequestHandler<PostCharacterCommand, CommandResponse<CharacterModel>>
    {
        public readonly ICharacaterRepository _characaterRepository;
        public readonly IMapper _mapper;

        public PostCharacterHandler( ICharacaterRepository characaterRepository,
                                     IMapper mapper
                                   )
        {
            _characaterRepository = characaterRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse<CharacterModel>> Handle(PostCharacterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IsValid())
                {
                    var charater = await _characaterRepository.Get(request.Character.Name);

                    if(charater == null || charater.Name != request.Character.Name)
                    {
                        await _characaterRepository.Crete(_mapper.Map<CharacterEntity>(request.Character));
                       
                        return new CommandResponse<CharacterModel>
                        {
                            Data= request.Character,
                            Status = StatusRequest.Sucessed,
                            Message = "The was created.",
                        };
                    }
                    else
                    {
                        return new CommandResponse<CharacterModel>
                        {
                            Status = StatusRequest.Error,
                            Message = "The character already exists.",
                        };
                    }
                }
                else
                {
                    return new CommandResponse<CharacterModel>
                    {
                        Status = StatusRequest.Error,
                        Message = "The request is not valid.",
                        Notification = request.Notifications()
                    };
                }

            }
            catch (Exception ex)
            {
                return new CommandResponse<CharacterModel>
                {
                    Status = StatusRequest.Error,
                    Message = $"Forgive me for the unforeseen, but an internal error occurred: {ex.Message}.",
                };
            }
        }
    }
}
