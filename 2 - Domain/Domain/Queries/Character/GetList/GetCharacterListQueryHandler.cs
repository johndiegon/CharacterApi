using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Data.Interfaces;
using MediatR;

namespace Domain.Queries.Character.GetList
{
    public class GetCharacterListQueryHandler : IRequestHandler<GetCharacterListQuery, GetCharacterListResponse>
    {
        public readonly ICharacaterRepository _characaterRepository;
        public readonly IMapper _mapper;

        public GetCharacterListQueryHandler( ICharacaterRepository characaterRepository,
                                             IMapper mapper
            )
        {
            _characaterRepository = characaterRepository;
            _mapper = mapper;
        }

        public async Task<GetCharacterListResponse> Handle(GetCharacterListQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var character = await _characaterRepository.Get();

                return new GetCharacterListResponse
                {
                    Data = character == null ? null : _mapper.Map<List<CharacterModelToList>>(character),
                    Status = StatusRequest.Sucessed
                };

            }
            catch (Exception ex)
            {
                return new GetCharacterListResponse
                {
                    Status = StatusRequest.Error,
                    Message = $"Forgive me for the unforeseen, but an internal error occurred: {ex.Message}.",
                };
            }
        }
    }
}
