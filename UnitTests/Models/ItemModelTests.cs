﻿using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Models
{
    [TestFixture]
    public class ItemModelTests
    {
        [Test]
        public void ItemModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BodyPartModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemModel_Constructor_New_Item_Should_Copy()
        {
            // Arrange
            var dataNew = new BodyPartModel();
            dataNew.Value = 2;
            dataNew.Id = "oldID";

            // Act
            var result = new BodyPartModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

        [Test]
        public void ItemModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BodyPartModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.Value);
            Assert.IsNotNull(result.Range);
            Assert.IsNotNull(result.Damage);
            Assert.IsNotNull(result.Attribute);
            Assert.IsNotNull(result.Location);
        }

        [Test]
        public void ItemModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BodyPartModel();
            result.Value = 6;
            result.Range = 7;
            result.Damage = 8;
            result.Attribute = AttributeEnum.Attack;
            result.Location = BodyPartEnum.Feet;

            // Reset

            // Assert 
            Assert.AreEqual(6, result.Value);
            Assert.AreEqual(7, result.Range);
            Assert.AreEqual(8, result.Damage);
            Assert.AreEqual(AttributeEnum.Attack, result.Attribute);
            Assert.AreEqual(BodyPartEnum.Feet, result.Location);
        }

        [Test]
        public void ItemModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new BodyPartModel();
            dataOriginal.Value = 1;

            var dataNew = new BodyPartModel();
            dataNew.Value = 2;

            // Act
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Value);
        }

        [Test]
        public void ItemModel_Update_InValid_Null_Should_Fail()
        {
            // Arrange
            var dataOriginal = new BodyPartModel();
            dataOriginal.Value = 2;

            // Act
            var result = dataOriginal.Update(null);

            // Reset

            // Assert 
            Assert.AreEqual(2, dataOriginal.Value);
        }

        [Test]
        public void ItemModel_FormatOuput_Default_Should_Pass()
        {
            // Arrange
            var data  = new BodyPartModel();

            // Act
            var result = data.FormatOutput();

            // Reset

            // Assert 
            Assert.AreEqual("This is an Item , Item Description for Unknown with Unknown+0 , Damage : 0 , Range : 0", result);
        }

        [Test]
        public void ItemModel_ScaleLevel_Default_Should_Pass()
        {
            // Arrange
            var data = new BodyPartModel();

            // Act
            var result = data.ScaleLevel(1);

            // Reset

            // Assert 
            Assert.AreEqual(1,result);
        }

        [Test]
        public void ItemModel_ScaleLevel_ForcedVaue_Should_Pass()
        {
            // Arrange
            var data = new BodyPartModel();

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            // Act
            var result = data.ScaleLevel(1);

            // Reset
            DiceHelper.DisableForcedRolls();
            
            // Assert 
            Assert.AreEqual(1, result);
        }
    }
}