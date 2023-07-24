using HeroApp.Common;

namespace HeroApp.Items
{
    /// <summary>
    /// This class represents Armor equipment for all heroes. 
    /// </summary>
    public class Armor : Item
    {
        public Armor(string name, int requiredLevel, Slot slot, ArmorType armorType, HeroAttribute armorAttribute) : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorAttribute = armorAttribute;
        }

        public ArmorType ArmorType { get; set; }
        public HeroAttribute ArmorAttribute { get; set; }
    }
}
