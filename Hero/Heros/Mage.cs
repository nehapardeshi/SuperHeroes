using HeroApp.Common;
using HeroApp.Items;

namespace HeroApp.Heros
{
    /// <summary>
    /// This class represents Mage hero.
    /// </summary>
    public class Mage : Hero
    {
        public override string HeroType => GetType().Name;

        /// <summary>
        /// Initializes Mage hero with name.
        /// </summary>
        /// <param name="name"></param>
        public Mage(string name) : base(name, 1, 1, 8)
        {
            AllowedWeaponTypes.AddRange(new List<WeaponType>()
            {
                WeaponType.Staffs,
                WeaponType.Wands
            });

            AllowedArmorTypes.Add(ArmorType.Cloth);
        }

        /// <summary>
        /// Levels up Mage hero by 1.
        /// </summary>

        public override void LevelUp()
        {
            base.LevelUp();

            LevelAttribtues += new HeroAttribute { Strength = 1, Dexterity = 1, Intelligence = 5 };
        }

        /// <summary>
        /// Calculates damage for Mage hero.
        /// </summary>
        public override double Damage
        {
            get
            {
                return CalculateDamage(TotalAttributes.Intelligence);
            }
        }
    }
}