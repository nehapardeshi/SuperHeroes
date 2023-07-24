namespace HeroApp.Exceptions
{
    /// <summary>
    /// This class represents exception for invalid level of a hero.
    /// </summary>
    public class InvalidLevelException : Exception
    {
        private int _heroLevel;
        private int _requiredLevel;
        private string _heroType;

        /// <summary>
        /// Initializes a new exception of invalid level.
        /// </summary>
        /// <param name="heroLevel"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="heroType"></param>
        public InvalidLevelException(int heroLevel, int requiredLevel, string heroType)
        {
            _heroLevel = heroLevel;
            _requiredLevel = requiredLevel;
            _heroType = heroType;
        }

        public override string Message => $"{_heroType} needs to be level {_requiredLevel} to equip this item. Current level is {_heroLevel}";
    }
}
