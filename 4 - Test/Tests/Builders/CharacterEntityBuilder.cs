using Infrastructure.Data.Entity;
using System.Collections.Generic;

namespace Tests.Builders
{
    public class CharacterEntityBuilder
    {
        private readonly List<CharacterEntity> _characterEntityBuilder;
        
        public CharacterEntityBuilder() => 
            _characterEntityBuilder = new List<CharacterEntity>();



        public CharacterEntityBuilder Warrior()
        {
            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "warriorName",
                HitPoints = 20,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 1
            });
            return this;
        }

        public CharacterEntityBuilder Thief()
        {
            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "ThiefName",
                HitPoints = 20,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 2
            });
            return this;
        }

        public CharacterEntityBuilder Mage()
        {
            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "MageName",
                HitPoints = 20,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 3
            });
            return this;
        }


        public CharacterEntityBuilder All()
        {
            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "MageName",
                HitPoints = 20,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 3
            });

            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "ThiefName",
                HitPoints = 20,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 2
            });

            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "warriorName",
                HitPoints = 20,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 1
            });


            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "warriorNameDead",
                HitPoints = 0,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 1
            });

            _characterEntityBuilder.Add(new CharacterEntity
            {
                Name = "mageNameDead",
                HitPoints = -10,
                Strength = 10,
                Dexterity = 5,
                Intelligence = 5,
                Profession = 1
            });

            return this;
        }


        public List<CharacterEntity> Build() =>
            _characterEntityBuilder;
    }
}
