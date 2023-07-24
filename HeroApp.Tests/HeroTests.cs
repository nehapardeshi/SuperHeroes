using HeroApp.Common;
using HeroApp.Heros;
using HeroApp.Items;

namespace HeroApp.Tests
{
    /// <summary>
    /// This class represents for heroes.
    /// </summary>
    public class HeroTests
    {
       
        [Fact]
        public void Create_Hero_Mage()
        {
            // Arrange
            var name = "BestMageEver";
            HeroAttribute expectedLevelAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 8
            };

            // Act
            Mage mage = new Mage(name);

            // Assert
            Assert.Equal(name, mage.Name);
            Assert.Equal(1, mage.Level);
            AssertHeroAttributesAreEqual(expectedLevelAttribute, mage.LevelAttribtues);
        }

        [Fact]
        
        public void LevelUp_Hero_Mage()
        {
            // Arrange
            var name = "BestMageEver";
            HeroAttribute expectedLevelAttribute = new HeroAttribute()
            {
                Strength = 2,
                Dexterity = 2,
                Intelligence = 13
            };

            // Act
            Mage mage = new Mage(name);
            mage.LevelUp();

            // Assert
            Assert.Equal(name, mage.Name);
            Assert.Equal(2, mage.Level);
            AssertHeroAttributesAreEqual(expectedLevelAttribute, mage.LevelAttribtues);
        }

        [Fact]
        public void EquipWeapon_Hero_Mage()
        {
            // Arrange
            var name = "BestMageEver";

            var weaponName = "IKEA Wand";
            var requiredLevel = 1;
            Slot slot = Slot.Weapon;
            WeaponType weaponType = WeaponType.Wands;
            double damage = 2;

            // Act
            Mage mage = new Mage(name);
            Weapon weapon = new Weapon(weaponName, requiredLevel, weaponType, damage);
            mage.Equip(weapon);

            // Assert
            Assert.NotNull(mage.Equipment);
            Assert.Equal(1, mage.Equipment.Count);
            Assert.True(mage.Equipment.ContainsKey(slot));
            Assert.Equal(weapon, mage.Equipment[slot] as Weapon);
        }

        [Fact]
        public void EquipWeapon_Hero_Mage_Negative_RequiredLevel()
        {
            // Arrange
            var name = "BestMageEver";
            var expectedErrorMessage = "Mage needs to be level 2 to equip this item. Current level is 1";
            string actualErrorMessage = "";

            var weaponName = "IKEA Wand";
            var requiredLevel = 2;
            WeaponType weaponType = WeaponType.Wands;
            double damage = 2;


            // Act
            Mage mage = new Mage(name);
            Weapon weapon = new Weapon(weaponName, requiredLevel, weaponType, damage);


            try
            {
                mage.Equip(weapon);
            }
            catch (Exception ex)
            {
                actualErrorMessage = ex.Message;
            }

            // Assert
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
            Assert.NotNull(mage.Equipment);
            Assert.Equal(0, mage.Equipment.Count);
        }

        [Fact]
        public void EquipWeapon_Hero_Mage_Negative_InValidType()
        {
            // Arrange
            var name = "BestMageEver";
            var expectedErrorMessage = "Mage can't equip weapon Daggers";
            string actualErrorMessage = "";

            var weaponName = "IKEA Wand";
            var requiredLevel = 1;
            WeaponType weaponType = WeaponType.Daggers;
            double damage = 2;

            // Act
            Mage mage = new Mage(name);
            Weapon weapon = new Weapon(weaponName, requiredLevel, weaponType, damage);

            try
            {
                mage.Equip(weapon);
            }
            catch (Exception ex)
            {
                actualErrorMessage = ex.Message;
            }

            // Assert
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
            Assert.NotNull(mage.Equipment);
            Assert.Equal(0, mage.Equipment.Count);
        }

        [Fact]
        public void EquipArmor_Hero_Mage()
        {
            // Arrange
            var name = "BestMageEver";
            HeroAttribute expectedHeroAttribute = new HeroAttribute()
            {
                Strength = 2,
                Dexterity = 1,
                Intelligence = 8
            };

            var armorName = "Common Plate Chest";
            var requiredLevel = 1;
            Slot slot = Slot.Body;
            ArmorType armorType = ArmorType.Cloth;
            HeroAttribute armorAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 0,
                Intelligence = 0
            };

            // Act
            Mage mage = new Mage(name);
            Armor armor = new Armor(armorName, requiredLevel, slot, armorType, armorAttribute);
            mage.Equip(armor);

            // Assert
            Assert.NotNull(mage.Equipment);
            Assert.Equal(1, mage.Equipment.Count);
            Assert.True(mage.Equipment.ContainsKey(slot));
            Assert.Equal(armor, mage.Equipment[slot] as Armor);
            AssertHeroAttributesAreEqual(expectedHeroAttribute, mage.TotalAttributes);
        }

        [Fact]
        public void Equip_2_Armors_Hero_Mage()
        {
            // Arrange
            var name = "BestMageEver";
            HeroAttribute expectedHeroAttribute = new HeroAttribute()
            {
                Strength = 3,
                Dexterity = 4,
                Intelligence = 16
            };

            // Armor 1
            var armorName = "Common Plate Chest";
            var requiredLevel = 1;
            Slot slot = Slot.Body;
            ArmorType armorType = ArmorType.Cloth;
            HeroAttribute armorAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 0,
                Intelligence = 3
            };

            // Armor 2
            var armorName2 = "Common Plate Hat";
            var requiredLevel2 = 1;
            Slot slot2 = Slot.Head;
            ArmorType armorType2 = ArmorType.Cloth;
            HeroAttribute armorAttribute2 = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 3,
                Intelligence = 5
            };

            // Act
            Mage mage = new Mage(name);
            Armor armor = new Armor(armorName, requiredLevel, slot, armorType, armorAttribute);
            mage.Equip(armor);

            Armor armor2 = new Armor(armorName2, requiredLevel2, slot2, armorType2, armorAttribute2);
            mage.Equip(armor2);

            // Assert
            Assert.NotNull(mage.Equipment);
            Assert.Equal(2, mage.Equipment.Count);
            Assert.True(mage.Equipment.ContainsKey(slot));
            Assert.Equal(armor, mage.Equipment[slot] as Armor);
            Assert.Equal(armor2, mage.Equipment[slot2] as Armor);
            AssertHeroAttributesAreEqual(expectedHeroAttribute, mage.TotalAttributes);
        }

        [Fact]
        public void Equip_Replace_Armor_Hero_Mage()
        {
            // Arrange
            var name = "BestMageEver";
            HeroAttribute expectedHeroAttribute = new HeroAttribute()
            {
                Strength = 2,
                Dexterity = 4,
                Intelligence = 13
            };

            // Armor 1
            var armorName = "Common Plate Chest";
            var requiredLevel = 1;
            Slot slot = Slot.Body;
            ArmorType armorType = ArmorType.Cloth;
            HeroAttribute armorAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 0,
                Intelligence = 3
            };

            // Armor 2 - Replace with Armor 1
            var armorName2 = "Common Plate Chest";
            var requiredLevel2 = 1;
            Slot slot2 = Slot.Body;
            ArmorType armorType2 = ArmorType.Cloth;
            HeroAttribute armorAttribute2 = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 3,
                Intelligence = 5
            };

            // Act
            Mage mage = new Mage(name);
            Armor armor = new Armor(armorName, requiredLevel, slot, armorType, armorAttribute);
            mage.Equip(armor);

            Armor armor2 = new Armor(armorName2, requiredLevel2, slot2, armorType2, armorAttribute2);
            mage.Equip(armor2);

            // Assert
            Assert.NotNull(mage.Equipment);
            Assert.Equal(1, mage.Equipment.Count);
            Assert.True(mage.Equipment.ContainsKey(slot));
            Assert.Equal(armor2, mage.Equipment[slot] as Armor); //Replaced one
            AssertHeroAttributesAreEqual(expectedHeroAttribute, mage.TotalAttributes);
        }

        [Fact]
        public void EquipArmor_Hero_Mage_Negative_RequiredLevel()
        {
            // Arrange
            var name = "BestMageEver";
            var expectedErrorMessage = "Mage needs to be level 2 to equip this item. Current level is 1";
            var actualErrorMessage = "";

            var armorName = "Common Plate Chest";
            var requiredLevel = 2;
            Slot slot = Slot.Body;
            ArmorType armorType = ArmorType.Cloth;
            HeroAttribute armorAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 0,
                Intelligence = 0
            };

            // Act
            Mage mage = new Mage(name);
            Armor armor = new Armor(armorName, requiredLevel, slot, armorType, armorAttribute);

            try
            {
                mage.Equip(armor);
            }
            catch (Exception ex)
            {
                actualErrorMessage = ex.Message;
            }

            // Assert
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
            Assert.NotNull(mage.Equipment);
            Assert.Equal(0, mage.Equipment.Count);
        }

        [Fact]
        public void EquipArmor_Hero_Mage_Negative_InValidType()
        {
            // Arrange
            var name = "BestMageEver";
            var expectedErrorMessage = "Mage can't equip armor Plate";
            var actualErrorMessage = "";

            var armorName = "Common Plate Chest";
            var requiredLevel = 1;
            Slot slot = Slot.Body;
            ArmorType armorType = ArmorType.Plate;
            HeroAttribute armorAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 0,
                Intelligence = 0
            };

            // Act
            Mage mage = new Mage(name);
            Armor armor = new Armor(armorName, requiredLevel, slot, armorType, armorAttribute);

            try
            {
                mage.Equip(armor);
            }
            catch (Exception ex)
            {
                actualErrorMessage = ex.Message;
            }

            // Assert
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
            Assert.NotNull(mage.Equipment);
            Assert.Equal(0, mage.Equipment.Count);
        }

        [Fact]
        public void Damage_Hero_Mage_NoWeapon()
        {
            // Arrange
            var name = "BestMageEver";
            double expectedDamage = 1.08;
            HeroAttribute expectedLevelAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 1,
                Intelligence = 8
            };

            // Act
            Mage mage = new Mage(name);

            // Assert
            AssertHeroAttributesAreEqual(expectedLevelAttribute, mage.LevelAttribtues);
            Assert.Equal(expectedDamage, mage.Damage);
        }

        [Fact]
        public void Damage_Hero_Mage_WithWeapon()
        {
            // Arrange
            var name = "BestMageEver";
            double expectedDamage = 2.16;

            var weaponName = "IKEA Wand";
            var requiredLevel = 1;
            Slot slot = Slot.Weapon;
            WeaponType weaponType = WeaponType.Wands;
            double damage = 2;

            // Act
            Mage mage = new Mage(name);
            Weapon weapon = new Weapon(weaponName, requiredLevel, weaponType, damage);
            mage.Equip(weapon);

            // Assert
            Assert.NotNull(mage.Equipment);
            Assert.Equal(1, mage.Equipment.Count);
            Assert.True(mage.Equipment.ContainsKey(slot));
            Assert.Equal(weapon, mage.Equipment[slot] as Weapon);
            Assert.Equal(expectedDamage, mage.Damage);
        }

        [Fact]
        public void Damage_Hero_Warrior_NoWeapon()
        {
            // Act
            var name = "BestWarriorEver";
            double expectedDamage = 1.05;

            // Arrange
            Warrior warrier = new Warrior(name);

            // Assert
            Assert.Equal(expectedDamage, warrier.Damage);
        }

        [Fact]
        public void Damage_Hero_Warrior_WithWeapon()
        {
            // Act
            var name = "BestWarriorEver";
            double expectedDamage = 2.10;

            var weaponName = "Common Axe";
            var requiredLevel = 1;
            WeaponType weaponType = WeaponType.Axes;
            double damage = 2;

            // Arrange
            Warrior warrier = new Warrior(name);
            Weapon weapon = new Weapon(weaponName, requiredLevel, weaponType, damage);
            warrier.Equip(weapon);

            // Assert
            Assert.Equal(expectedDamage, warrier.Damage);
        }

        [Fact]
        public void Damage_Hero_Warrior_WithWeapon_And_Armor()
        {
            // Act
            var name = "BestWarriorEver";
            double expectedDamage = 2.12;

            var weaponName = "Common Axe";
            var requiredLevel = 1;
            WeaponType weaponType = WeaponType.Axes;
            double damage = 2;

            var armorName = "Common Plate Chest";
            var armorRequiredLevel = 1;
            Slot slot = Slot.Body;
            ArmorType armorType = ArmorType.Plate;
            HeroAttribute armorAttribute = new HeroAttribute()
            {
                Strength = 1,
                Dexterity = 0,
                Intelligence = 0
            };

            // Arrange
            Warrior warrier = new Warrior(name);

            Weapon weapon = new Weapon(weaponName, requiredLevel, weaponType, damage);
            warrier.Equip(weapon);

            Armor armor = new Armor(armorName, armorRequiredLevel, slot, armorType, armorAttribute);
            warrier.Equip(armor);

            // Assert
            Assert.Equal(expectedDamage, warrier.Damage);
        }

        [Fact]
        public void Create_Hero_Mage_Display_Test()
        {
            // Arrange
            var name = "BestMageEver";
            var expectedDisplay = "Name: BestMageEver\r\nClass: Mage\r\nLevel: 1\r\nTotal strength: 1\r\nTotal dexterity: 1\r\nTotal intelligence: 8\r\nDamage: 1,08\r\n";

            // Act
            Mage mage = new Mage(name);

            // Assert
            Assert.Equal(expectedDisplay, mage.Display());
        }

        public static void AssertHeroAttributesAreEqual(HeroAttribute expected, HeroAttribute actual)
        {
            Assert.Equal(expected.Strength, actual.Strength);
            Assert.Equal(expected.Dexterity, actual.Dexterity);
            Assert.Equal(expected.Intelligence, actual.Intelligence);
        }
    }
}