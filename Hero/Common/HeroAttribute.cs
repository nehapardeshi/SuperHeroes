namespace HeroApp.Common
{
    /// <summary>
    /// This class represents 3 attributes of a hero - Strength, Dexterity and Intelligence.
    /// </summary>
    public class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        /// <summary>
        /// It initializes heroattribute by strength. dexterity and intelligence.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static HeroAttribute operator +(HeroAttribute a, HeroAttribute b) => new()
        {
            Strength = a.Strength + b.Strength,
            Dexterity = a.Dexterity + b.Dexterity,
            Intelligence = a.Intelligence + b.Intelligence
        };
    }
}