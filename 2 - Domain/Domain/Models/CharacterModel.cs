using Domain.Enums;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class CharacterModel : Attribute
    {
        public CharacterModel(string name, Profession profession)
        {
            this.Name = name;
            this.Profession = profession;
            this._attackAttributes = GetAttackAttributes(profession);
            this._speedAttributes = GetSpeedAttributes(profession);
            SetCharacter(profession);
        }

        public CharacterModel()
        {
            this._attackAttributes = GetAttackAttributes(this.Profession);
            this._speedAttributes = GetSpeedAttributes(this.Profession);
        }

        private readonly Attribute _attackAttributes;
        private readonly Attribute _speedAttributes;

        public string Name { get; set; }
        public decimal HitPoints { get; set; }

        public Profession Profession { get; set; }

        public StatusCharacter Status 
        { 
            get 
            { 
                return this.HitPoints <= 0 ? StatusCharacter.Dead : StatusCharacter.Alive; 
            } 
        }
        
        public Attribute AttackAttributes { get {  return _attackAttributes; } }
        public Attribute SpeedAttributes { get { return _speedAttributes; } }

        private void SetCharacter(Profession profession) 
        {
            switch (profession)
            {
                case Profession.Warrior:
                    this.HitPoints = 20;
                    this.Strength = 10;
                    this.Dexterity = 5;
                    this.Intelligence = 5;
                    break;
                case Profession.Thief:
                    this.HitPoints = 20;
                    this.Strength = 10;
                    this.Dexterity = 5;
                    this.Intelligence = 5;
                    break;
                case Profession.Mage:
                    this.HitPoints = 20;
                    this.Strength = 10;
                    this.Dexterity = 5;
                    this.Intelligence = 5;
                    break;
                default:
                    new Exception("There is no configuration for this type.");
                    break;
            }
        }
        private Attribute GetAttackAttributes(Profession profession)
        {
            switch (profession)
            {
                case Profession.Warrior:
                    return new Attribute
                    {
                        Dexterity = 20,
                        Intelligence = 0,
                        Strength = 80,
                    };
                case Profession.Thief:
                    return new Attribute
                    {
                        Dexterity = 100,
                        Intelligence = 25,
                        Strength = 25,
                    };
                case Profession.Mage:
                    return new Attribute
                    {
                        Dexterity = 59,
                        Intelligence = 150,
                        Strength = 20,
                    };
                default:
                    new Exception("There is no configuration for this type.");
                    return new Attribute();
            }
        }
        private Attribute GetSpeedAttributes(Profession profession)
        {
            switch (profession)
            {
                case Profession.Warrior:
                    return new Attribute
                    {
                        Dexterity = 60,
                        Intelligence = 20,
                        Strength = 0,
                    };
                case Profession.Thief:
                    return new Attribute
                    {
                        Dexterity = 80,
                        Intelligence = 0,
                        Strength = 0,
                    };
                case Profession.Mage:
                    return new Attribute
                    {
                        Dexterity = 50,
                        Intelligence = 0,
                        Strength = 20,
                    };
                default:
                    new Exception("There is no configuration for this type.");
                    return new Attribute();
            }
        }
    
        public decimal CalculateSpeed() 
        { 
            var random = new Random();
            return random.Next(Convert.ToInt32(SpeedAttributes.Strength + SpeedAttributes.Intelligence + SpeedAttributes.Dexterity));
        }
        public decimal CalculateAtack() 
        {
            var random = new Random();
            return random.Next(Convert.ToInt32(AttackAttributes.Strength + AttackAttributes.Intelligence + AttackAttributes.Dexterity));
        }
    }
}
