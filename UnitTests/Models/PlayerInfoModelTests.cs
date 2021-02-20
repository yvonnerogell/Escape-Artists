using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class PlayerInfoModelTests
    {
        [Test]
        public void PlayerInfoModel_Constructor_Default_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Monster_Default_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Fighter_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Fighter };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Cleric_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Cleric };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_Constructor_Character_Unknown_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Job = CharacterJobEnum.Unknown };

            // Act
            var result = new PlayerInfoModel(data);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PlayerInfoModel_IsAbilityAvailable_Available_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

            // Act
            var result = data.IsAbilityAvailable(AbilityEnum.ExtraCredit);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PlayerInfoModel_IsAbilityAvailable_Available_Zero_Should_Fail()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Unknown] = 0;

            // Act
            var result = data.IsAbilityAvailable(AbilityEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        /*
        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Cleric_Heal_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Heal] = 1;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Heal, result);
        }
        
        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Cleric_Heal_Not_Needed_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Heal] = 1;

            data.CurrentHealth = 100;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }
        
        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Cleric_Heal_Not_Available_Should_Return_Unknown()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 0;
            data.AbilityTracker[AbilityEnum.Extension] = 0;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }
        
        [Test]
        public void PlayerInfoModel_SelectHealingAbility_Fighter_Bandage_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Fighter });
            data.AbilityTracker[AbilityEnum.Bandage] = 1;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bandage, result);
        }
        */

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Fighter_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Fighter });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 1;

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.ExtraCredit, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Cleric_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 1;

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.ExtraCredit, result);
        }
        

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Monster_Should_Return_False()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.None, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Cleric_Heal_Should_Skip()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 0;
            data.AbilityTracker[AbilityEnum.Extension] = 0;
            data.AbilityTracker[AbilityEnum.FlashGenius] = 0;

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.None, result);
        }

        [Test]
        public void PlayerInfoModel_AbilityUsedInCurrentRound_Get_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = data.AbilityUsedInCurrentRound;

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}