using System.ComponentModel;

namespace Domain.Enums
{
    public enum Profession
    {
        [Description("Warrior")]
        Warrior = 1,
        [Description("Thief")]
        Thief = 2,
        [Description("Mage")]
        Mage = 3
    }
}
