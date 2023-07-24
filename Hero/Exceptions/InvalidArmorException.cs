using HeroApp.Items;

namespace HeroApp.Exceptions
{
    /// <summary>
    /// This class represents exception for invalid armors.
    /// </summary>
    public class InvalidArmorException : Exception
    {
        private Armor _armor;
        private string _heroType;

        /// <summary>
        /// initializes a new invalid armor exception.
        /// </summary>
        /// <param name="armor"></param>
        /// <param name="heroType"></param>
        public InvalidArmorException(Armor armor, string heroType)
        {
            _armor = armor;
            _heroType = heroType;
        }

        public override string Message => $"{_heroType} can't equip armor {_armor.ArmorType}";
    }
}
