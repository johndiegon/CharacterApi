using Infrastructure.Data.Entity;

namespace Infrastructure.Data.Interfaces
{
    public interface ICharacaterRepository
    {
        Task<CharacterEntity> Get(string name);
        Task<List<CharacterEntity>> Get();
        Task Crete(CharacterEntity character);
        Task Delete(string name);
        Task Update(CharacterEntity character);
    }
}
