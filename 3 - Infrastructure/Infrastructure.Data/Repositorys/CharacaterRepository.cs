using Infrastructure.Data.Entity;
using Infrastructure.Data.Interfaces;
using Newtonsoft.Json;
using System.Runtime.Caching;

namespace Infrastructure.Data.Repositorys
{
    public class CharacaterRepository : ICharacaterRepository
    {
        public async Task Crete(CharacterEntity character)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Add(character.Name, JsonConvert.SerializeObject(character), null);
        }

        public async Task Delete(string name)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(name);
        }

        public async Task<CharacterEntity> Get(string name)
        {
            ObjectCache cache = MemoryCache.Default;
            
            foreach( var item in cache)
            {
                if (item.Key == name.ToUpper())
                    return JsonConvert.DeserializeObject<CharacterEntity>((string)item.Value);
            }

            return null; 
        }

        public async Task<List<CharacterEntity>> Get()
        {
            ObjectCache cache = MemoryCache.Default;
            var itens = new List<CharacterEntity>();

            foreach (var item in cache)
            {
                itens.Add(JsonConvert.DeserializeObject<CharacterEntity>((string)item.Value));
            }
            
            return itens;
        }

        public async Task Update(CharacterEntity character)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Set(character.Name, JsonConvert.SerializeObject(character), null);
        }
    }
}
