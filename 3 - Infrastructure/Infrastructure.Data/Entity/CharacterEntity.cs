namespace Infrastructure.Data.Entity
{
    public class CharacterEntity
    {
        public string Name { get; set; }
        public int Profession { get; set; } 
        public int Status { get; set; }
        public decimal HitPoints { get; set; }
        public decimal Strength { get; set; }
        public decimal Dexterity { get; set; }
        public decimal Intelligence { get; set; }
    }
}
