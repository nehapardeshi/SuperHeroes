using HeroApp.Common;
using HeroApp.Items;

namespace HeroApp.Heros
{
    /// <summary>
    /// Represents Ranger hero class.
    /// </summary>
    public class Ranger : Hero
    {
        public override string HeroType => GetType().Name;
                
        /// <summary>
        /// Initializes Ranger hero with name.
        /// </summary>
        /// <param name="name"></param>
        public Ranger(string name) : base(name, 1, 7, 1)
        {
            AllowedWeaponTypes.Add(WeaponType.Bows);

            AllowedArmorTypes.AddRange(new List<ArmorType>()
            { 
                ArmorType.Leather,
                ArmorType.Mail
            });
        }
        
        /// <summary>
        /// Levels up Ranger hero by 1 and adds up hero attributes.
        /// </summary>
        public override void LevelUp()
        {
            base.LevelUp();

            LevelAttribtues += new HeroAttribute { Strength = 1, Dexterity = 5, Intelligence = 1 };
        }

        /// <summary>
        /// Calculates damage of Ranger hero.
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