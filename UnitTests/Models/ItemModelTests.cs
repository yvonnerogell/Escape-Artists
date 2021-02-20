using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game;

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
            var result = new ItemModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemModel_Constructor_Item_Type_Should_Pass()
        {
            // Arrange


            // Act
            var dataNew = new ItemModel(ItemTypeEnum.Laptop);

            // Reset

            // Assert 
            Assert.AreEqual(ItemTypeEnum.Laptop, dataNew.ItemType);
            Assert.AreEqual(AttributeEnum.Attack, dataNew.Attribute);
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, dataNew.Location);
            Assert.AreEqual(Constants.ItemTypeLaptopImageURI, dataNew.ImageURI);
            Assert.AreEqual(20, dataNew.Damage);
            Assert.AreEqual("Complete your assignments faster with a laptop.", dataNew.Description);
        }

        [Test]
        public void ItemModel_Copy_Should_Pass()
        {
            // Arrange
            var dataOriginal = new ItemModel();

            // Act
            var result = new ItemModel(dataOriginal);

            // Reset

            // Assert 
            Assert.AreEqual(dataOriginal.Name, result.Name);
            Assert.AreEqual(dataOriginal.Description, result.Description);
            Assert.AreEqual(dataOriginal.Damage, result.Damage);
            Assert.AreEqual(dataOriginal.Value, result.Value);
            Assert.AreEqual(dataOriginal.ImageURI, result.ImageURI);
            Assert.AreEqual(dataOriginal.ItemType, result.ItemType);
        }

        [Test]
        public void ItemModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();

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
            var result = new ItemModel();
            result.Value = 6;
            result.Range = 7;
            result.Damage = 8;
            result.Attribute = AttributeEnum.Attack;
            result.Location = ItemLocationEnum.Feet;

            // Reset

            // Assert 
            Assert.AreEqual(6, result.Value);
            Assert.AreEqual(7, result.Range);
            Assert.AreEqual(8, result.Damage);
            Assert.AreEqual(AttributeEnum.Attack, result.Attribute);
            Assert.AreEqual(ItemLocationEnum.Feet, result.Location);
        }

        [Test]
        public void ItemModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new ItemModel();
            dataOriginal.Value = 1;

            var dataNew = new ItemModel();
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
            var dataOriginal = new ItemModel();
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
            var data = new ItemModel();

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
            var data = new ItemModel();

            // Act
            var result = data.ScaleLevel(1);

            // Reset

            // Assert 
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ItemModel_ScaleLevel_ForcedVaue_Should_Pass()
        {
            // Arrange
            var data = new ItemModel();

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
