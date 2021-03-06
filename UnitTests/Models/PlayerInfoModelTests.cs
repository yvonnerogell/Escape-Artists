﻿using NUnit.Framework;

using Game.Models;
using System.Collections.Generic;
using Game.ViewModels;

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
        public void PlayerInfoModel_Constructor_Monster_Max_Level_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel();
            data.Level = 50;

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
        public void PlayerInfoModel_IsSpecialAbilityAvailable_Unknown_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { SpecialAbility = AbilityEnum.Unknown });

            // Act
            var result = data.IsSpecialAbilityAvailable();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_IsSpecialAbilityAvailable_None_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { SpecialAbility = AbilityEnum.None });

            // Act
            var result = data.IsSpecialAbilityAvailable();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_IsSpecialAbilityAvailable_Not_Available_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { SpecialAbility = AbilityEnum.Extension });
            data.AbilityUsedInCurrentRound = true;

            // Act
            var result = data.IsSpecialAbilityAvailable();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_IsSpecialAbilityAvailable_Available_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { SpecialAbility = AbilityEnum.Extension });

            // Act
            var result = data.IsSpecialAbilityAvailable();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
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
        public void PlayerInfoModel_SelectHealingAbility_Cleric_Heal_Not_Available_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.Heal] = 0;
            data.AbilityTracker[AbilityEnum.Bandage] = 0;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
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
            data.AbilityTracker[AbilityEnum.Heal] = 0;
            data.AbilityTracker[AbilityEnum.Bandage] = 1;

            data.CurrentHealth = 1;
            data.MaxHealth = 100;

            // Act
            var result = data.SelectHealingAbility();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bandage, result);
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

        [Test]
        public void PlayerInfoModel_SelectSpecialAbilityToUse_Fighter_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Fighter });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 1;

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bandage, result);
        }

        [Test]
        public void PlayerInfoModel_SelectSpecialAbilityToUse_None_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel ());
            data.AbilityTracker = new Dictionary<AbilityEnum, int>();

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.None, result);
        }

        [Test]
        public void PlayerInfoModel_SelectSpecialAbilityToUse_Cleric_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 1;

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bandage, result);
        }
        

        [Test]
        public void PlayerInfoModel_SelectSpecialAbilityToUse_Monster_Should_Return_False()
        {
            // Arrange
            var data = new PlayerInfoModel(new MonsterModel());

            // Act
            var result = data.SelectSpecialAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bandage, result);
        }

        [Test]
        public void PlayerInfoModel_SelectSpecialAbilityToUse_Cleric_Heal_Should_Skip()
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
        public void PlayerInfoModel_SelectAbilityToUse_Cleric_Avaiable_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 1;

            // Act
            var result = data.SelectAbilityToUse();

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
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Cleric_Should_Skip()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 0;
            data.AbilityTracker[AbilityEnum.Extension] = 0;
            data.AbilityTracker[AbilityEnum.FlashGenius] = 0;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void PlayerInfoModel_SelectAbilityToUse_Cleric_Heal_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            data.AbilityTracker[AbilityEnum.ExtraCredit] = 0;
            //data.AbilityTracker = new Dictionary<AbilityEnum, int>();
            data.AbilityTracker[AbilityEnum.Heal] = 1;

            // Act
            var result = data.SelectAbilityToUse();

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
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

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_ExtraCredit_Should_Pass()
        {
            // Arrange
            var data = new PlayerInfoModel(new CharacterModel());
            data.GPA = 100;
            data.EngineGameSpecialAbility = AbilityEnum.ExtraCredit;

            // Act
            data.UseSpecialAbility();

            // Reset

            // Assert
            Assert.AreEqual(true, data.AbilityUsedInCurrentRound);
            Assert.AreEqual(102, data.GPA);
        }

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_Bribes_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.Bribes;
            var data = new PlayerInfoModel(character);
            data.GPA = 100;

            // Act
            data.UseSpecialAbility();

            // Reset

            // Assert
            Assert.AreEqual(true, data.AbilityUsedInCurrentRound);
            Assert.AreEqual(110, data.GPA);
        }

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_Extension_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.Extension;
            var data = new PlayerInfoModel(character);
            data.GPA = 100;

            // Act
            data.UseSpecialAbility();

            // Reset

            // Assert
            Assert.AreEqual(true, data.AbilityUsedInCurrentRound);
            Assert.AreEqual(102, data.GPA);
        }

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_FlashGenius_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.FlashGenius;
            var data = new PlayerInfoModel(character);
            data.GPA = 100;

            // Act
            var result = data.UseSpecialAbility();

            // Reset

            // Assert
            Assert.AreEqual(true, data.AbilityUsedInCurrentRound);
            Assert.AreEqual(103, data.GPA);
        }

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_PayTuition_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.PayTuition;
            var data = new PlayerInfoModel(character);
            data.GPA = 100;

            // Act
            var result = data.UseSpecialAbility();

            // Reset

            // Assert
            Assert.AreEqual(true, data.AbilityUsedInCurrentRound);
            Assert.AreEqual(105, data.GPA);
        }

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_None_Remaining_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.None;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.UseSpecialAbility();

            // Reset

            // Assert
            Assert.AreEqual(false, data.AbilityUsedInCurrentRound);
            Assert.AreEqual(0, data.GPA);
        }

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_Default_Remaining_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.Unknown;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.UseSpecialAbility();

            // Reset

            // Assert
            Assert.AreEqual(false, data.AbilityUsedInCurrentRound);
            Assert.AreEqual(0, data.GPA);
        }

        [Test]
        public void PlayerInfoModel_UseSpecialAbility_0_Remaining_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.ExtraCredit;
            var data = new PlayerInfoModel(character);
            data.AbilityUsedInCurrentRound = true;

            // Act
            data.UseAbility(AbilityEnum.ExtraCredit);
            var result = data.UseSpecialAbility();

            // Reset
            data.AbilityUsedInCurrentRound = false;

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_IsAbilityAvailable_False_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.ExtraCredit;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.IsAbilityAvailable(AbilityEnum.Extension);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_UseAbility_False_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.SpecialAbility = AbilityEnum.ExtraCredit;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.UseAbility(AbilityEnum.Extension);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_FormatOutput_Default_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert
            Assert.AreEqual(true, result.Contains("Bobbet"));
        }

        [Test]
        public void PlayerInfoModel_HoldGraduationItem_False_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.Head = "nothing";
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.HoldGraduationItem();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_HoldGraduationItem_Null_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.Head = null;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.HoldGraduationItem();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_HoldGraduationItem_True_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            ItemIndexViewModel.Instance.LoadDatasetCommand.Execute(null);
            string itemId = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.GraduationCapAndRobe);
            character.Head = itemId;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.HoldGraduationItem();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PlayerInfoModel_HoldGraduationItem_Head_With_Item_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            ItemIndexViewModel.Instance.LoadDatasetCommand.Execute(null);
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);

            //put a primary hand item on head
            character.Head = item.Id;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.HoldGraduationItem();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_GraduateIfLevelAboveMaxLevel_True_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            ItemIndexViewModel.Instance.LoadDatasetCommand.Execute(null);
            string itemId = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.GraduationCapAndRobe);
            character.Head = itemId;
            character.Level = 20;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.GraduateIfLevelAboveMaxLevel();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void PlayerInfoModel_GraduateIfLevelAboveMaxLevel_LowerLevel_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            ItemIndexViewModel.Instance.LoadDatasetCommand.Execute(null);
            string itemId = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.GraduationCapAndRobe);
            character.Head = itemId;
            character.Level = 19;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.GraduateIfLevelAboveMaxLevel();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void PlayerInfoModel_GraduateIfLevelAboveMaxLevel_No_Item_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            character.Head = null;
            character.Level = 20;
            var data = new PlayerInfoModel(character);

            // Act
            var result = data.GraduateIfLevelAboveMaxLevel();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}