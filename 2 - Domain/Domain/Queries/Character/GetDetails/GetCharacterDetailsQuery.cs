using MediatR;

namespace Domain.Queries.Character.GetDetails
{
    public class GetCharacterDetailsQuery : IRequest<GetCharacterDetailsResponse>
    {
        public string Name { get; set; }   
    }
}
