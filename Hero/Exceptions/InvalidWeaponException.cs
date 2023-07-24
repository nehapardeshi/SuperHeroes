using HeroApp.Items;

namespace HeroApp.Exceptions
{
    /// <summary>
    /// This class represents exception of invalid weapon for all heroes. 
    /// </summary>
    public class InvalidWeaponException : Exception
    {
        private Weapon _weapon;
        private string _heroType;

        /// <summary>
        /// Initializes a new exception of inavalid weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="heroType"></param>
        public InvalidWeaponException(Weapon weapon, string heroType)
        {
            _weapon = weapon;
            _heroType = heroType;
        }

        public override string Message => $"{_heroType} can't equip weapon {_weapon.WeaponType}";
    }
}
