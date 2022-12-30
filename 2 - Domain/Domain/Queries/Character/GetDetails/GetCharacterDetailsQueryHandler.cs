using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Application.Helpers;
using Infrastructure.Data.Interfaces;
using MediatR;

namespace Domain.Queries.Character.GetDetails
{
    public class GetCharacterDetailsQueryHandler : IRequestHandler<GetCharacterDetailsQuery, GetCharacterDetailsResponse>
    {
        public readonly ICharacaterRepository _characaterRepository;
        public readonly IMapper _mapper;

        public GetCharacterDetailsQueryHandler(ICharacaterRepository characaterRepository,
                                     IMapper mapper
                                   )
        {
            _characaterRepository = characaterRepository;
            _mapper = mapper;
        }

        public async Task<GetCharacterDetailsResponse> Handle(GetCharacterDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Name.IsValidName())
                {
                    var character = await _characaterRepository.Get(request.Name);
                 
                    return new GetCharacterDetailsResponse
                    {
                        Data = character == null ? null : _mapper.Map<CharacterModel>(character),
                        Status = StatusRequest.Sucessed
                    };
                }
                else
                {
                    return new GetCharacterDetailsResponse
                    {
                        Status = StatusRequest.Error,
                        Message = "The name  is not valid."
                    };
                }

            }
            catch (Exception ex)
            {
                return new GetCharacterDetailsResponse
                {
                    Status = StatusRequest.Error,
                    Message = $"Forgive me for the unforeseen, but an internal error occurred: {ex.Message}.",
                };
            }
        }
    }
}
