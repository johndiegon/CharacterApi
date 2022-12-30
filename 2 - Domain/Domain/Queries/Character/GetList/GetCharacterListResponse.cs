using Domain.Models;
using Domain.Models.Command;

namespace Domain.Queries.Character.GetList
{
    public class GetCharacterListResponse : CommandResponse<List<CharacterModelToList>>
    {
    }
}
