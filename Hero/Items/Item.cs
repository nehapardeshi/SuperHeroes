namespace HeroApp.Items
{   
    /// <summary>
    /// This class represents abstract class of item for all heroes.
    /// </summary>
    public abstract class Item
    {
        public Item(string name, int requiredLevel)
        {
            Name = name;
            RequiredLevel = requiredLevel;
        }

        /// <summary>
        /// Initializes item class with name, required level and slot.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="slot"></param>
        public Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }

        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }
    }
}
