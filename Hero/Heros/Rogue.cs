using HeroApp.Common;
using HeroApp.Items;

namespace HeroApp.Heros
{
    /// <summary>
    /// This class represents Hero Rogue.
    /// </summary>
    public class Rogue : Hero
    {
        public override string HeroType => GetType().Name;

        /// <summary>
        /// Initializes Rogue hero object with name.
        /// </summary>
        /// <param name="name"></param>
        public Rogue(string name) : base(name, 2, 6, 1)
        {
            AllowedWeaponTypes.AddRange(new List<WeaponType>()
            {
                WeaponType.Daggers,
                WeaponType.Swords
            });

            AllowedArmorTypes.AddRange(new List<ArmorType>()
            {
                ArmorType.Leather,
                ArmorType.Mail
            });
        }

        /// <summary>
        /// Levels up Rogue hero by 1.
        /// </summary>
        public override void LevelUp()
        {
            base.LevelUp();

            LevelAttribtues += new HeroAttribute { Strength = 1, Dexterity = 4, Intelligence = 1 };
        }

        /// <summary>
        /// Calculates damage for Rogue hero.
        /// </summary>
        public override double Damage
        {
            get
            {
                return CalculateDamage(TotalAttributes.Dexterity);
            }
        }
    }
}