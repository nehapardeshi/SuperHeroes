using HeroApp.Common;
using HeroApp.Exceptions;
using HeroApp.Items;
using System.Text;

namespace HeroApp.Heros
{
    /// <summary>
    /// Represents abstract Hero class that serves as base class for all heros. This class cannot be used to create objects
    /// </summary>
    public abstract class Hero
    {
        public abstract string HeroType { get; }
        public string Name { get; internal set; }
        public int Level { get; set; } = 1;
        public HeroAttribute LevelAttribtues { get; set; }
        public Dictionary<Slot, Item> Equipment { get; set; }
        public readonly List<ArmorType> AllowedArmorTypes = new List<ArmorType>();
        public readonly List<WeaponType> AllowedWeaponTypes = new List<WeaponType>();

        /// <summary>
        /// Initializes base hero class with given hero name, strength, dexterity and intelligence
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strength"></param>
        /// <param name="dexterity"></param>
        /// <param name="intelligence"></param>
        public Hero(string name, int strength, int dexterity, int intelligence)
        {
            Name = name;
            Level = 1;
            LevelAttribtues = new HeroAttribute()
            {
                Strength = strength,
                Dexterity = dexterity,
                Intelligence = intelligence
            };
            Equipment = new Dictionary<Slot, Item>();
        }

        /// <summary>
        /// Levels up the Hero by 1
        /// </summary>
        public virtual void LevelUp() => Level++;

        /// <summary>
        /// Equips hero object with the new weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        /// <exception cref="InvalidLevelException"></exception>
        /// <exception cref="InvalidWeaponException"></exception>
        public virtual string Equip(Weapon weapon)
        {
            if (weapon.RequiredLevel > Level)
            {
                throw new InvalidLevelException(Level, weapon.RequiredLevel, HeroType);
            }

            if (!AllowedWeaponTypes.Contains(weapon.WeaponType))
            {
                throw new InvalidWeaponException(weapon, HeroType);
            }

            Equipment[weapon.Slot] = weapon;

            return $"New weapon {weapon.WeaponType} equipped!";
        }

        /// <summary>
        /// Equips hero object with the new armor
        /// </summary>
        /// <param name="armor"></param>
        /// <returns></returns>
        /// <exception cref="InvalidLevelException"></exception>
        /// <exception cref="InvalidArmorException"></exception>
        public virtual string Equip(Armor armor)
        {
            if (armor.RequiredLevel > Level)
            {
                throw new InvalidLevelException(Level, armor.RequiredLevel, HeroType);
            }

            if (!AllowedArmorTypes.Contains(armor.ArmorType))
            {
                throw new InvalidArmorException(armor, HeroType);
            }

            Equipment[armor.Slot] = armor;

            return $"New armor {armor.ArmorType} equipped!";
        }

        public abstract double Damage { get; }

        /// <summary>
        /// Calculate total attributes of the hero
        /// </summary>
        public virtual HeroAttribute TotalAttributes
        {
            get
            {
                var total = LevelAttribtues;
                var nonWeaponEquipments = Equipment.Where(e => e.Key != Slot.Weapon);

                if (nonWeaponEquipments.Any())
                {
                    foreach (var item in nonWeaponEquipments)
                    {
                        if (item.Value is Armor armor)
                        {
                            total += armor.ArmorAttribute;
                        }
                    }
                }

                return total;
            }
        }

        /// <summary>
        /// Displays information of the hero
        /// </summary>
        /// <returns>Hero information as string</returns>
        public virtual string Display()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Name: {Name}");
            message.AppendLine($"Class: {HeroType}");
            message.AppendLine($"Level: {Level}");
            message.AppendLine($"Total strength: {TotalAttributes.Strength}");
            message.AppendLine($"Total dexterity: {TotalAttributes.Dexterity}");
            message.AppendLine($"Total intelligence: {TotalAttributes.Intelligence}");
            message.AppendLine($"Damage: {Damage}");
            return message.ToString();
        }

        /// <summary>
        /// Gets weapon damage of the hero
        /// </summary>
        /// <returns>Weapon damage</returns>
        private double GetWeaponDamage()
        {
            double? weaponDamage = 1;

            if (Equipment != null && Equipment.ContainsKey(Slot.Weapon))
            {
                var weapon = (Weapon?)Equipment[Slot.Weapon];
                weaponDamage = weapon?.WeaponDamage;
            }
            return weaponDamage ?? 1;
        }

        /// <summary>
        /// Returns damage of the hero
        /// </summary>
        /// <param name="damageAttribute"></param>
        /// <returns></returns>
        public virtual double CalculateDamage(double damageAttribute)
        {
            var weaponDamage = GetWeaponDamage();
            return weaponDamage * (1 + (double)(damageAttribute / 100));
        }
    }
}
