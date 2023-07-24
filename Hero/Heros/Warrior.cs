using HeroApp.Common;
using HeroApp.Items;

namespace HeroApp.Heros
{
    /// <summary>
    /// Represents Warrior hero class.
    /// </summary>
    public class Warrior : Hero
    {
        public override string HeroType => GetType().Name;

        /// <summary>
        /// Initializes Warrior hero with name.
        /// </summary>
        /// <param name="name"></param>
        public Warrior(string name) : base(name, 5, 2, 1)
        {
            AllowedWeaponTypes.AddRange(new List<WeaponType>()
            {
                WeaponType.Axes,
                WeaponType.Hammers,
                WeaponType.Swords
            });

            AllowedArmorTypes.AddRange(new List<ArmorType>()
            {
                ArmorType.Mail,
                ArmorType.Plate
            });
        }

        /// <summary>
        /// Levels up Warrior hero by 1.
        /// </summary>
        public override void LevelUp()
        {
            base.LevelUp();

            LevelAttribtues += new HeroAttribute { Strength = 3, Dexterity = 2, Intelligence = 1 };
        }

        /// <summary>
        /// Calculates damage for Warrior hero.
        /// </summary>
        public override double Damage
        {
            get
            {
                return CalculateDamage(TotalAttributes.Strength);
            }
        }
    }
}
