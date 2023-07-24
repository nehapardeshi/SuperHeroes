namespace HeroApp.Items
{
    /// <summary>
    /// Weapon class represents child class of item class.
    /// </summary>
    public class Weapon : Item
    {
        /// <summary>
        /// It initializes weapon object with name, required level, weapon type and damage.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="weaponType"></param>
        /// <param name="damage"></param>
        public Weapon(string name, int requiredLevel, WeaponType weaponType, double damage) : base(name, requiredLevel)
        {
            Slot = Slot.Weapon;
            WeaponType = weaponType;
            WeaponDamage = damage;
        }

        public WeaponType WeaponType { get; set; }
        public double WeaponDamage { get; set; }
    }
}
