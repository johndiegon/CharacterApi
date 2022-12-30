using Domain.Models;
using Domain.Models.Command;
using MediatR;

namespace Domain.Queries.Character.GetList
{
    public class GetCharacterListQuery : Validate, IRequest<GetCharacterListResponse>
    {
        public int Page { get; set; }
        public int Count { get; set; }
    }
}
