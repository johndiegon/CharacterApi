using Domain.Enums;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class CharacterModelToList
    {
        public string Name { get; set; }

        public Profession Profession { get; set; }
        
        public StatusCharacter Status { get; set; } 
    }
}
