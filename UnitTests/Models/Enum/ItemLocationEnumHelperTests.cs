using NUnit.Framework;

using Game.Models;
namespace UnitTests.Models.Enum
{
	[TestFixture]
	class ItemLocationEnumHelperTests
	{

        [Test]
        public void ItemLocationEnumHelperTests_GetListItem_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetListItem;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 6);
            Assert.Contains("Head", result);
            Assert.Contains("Necklace", result);
            Assert.Contains("PrimaryHand", result);
            Assert.Contains("OffHand", result);
            Assert.Contains("Finger", result);
            Assert.Contains("Feet", result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetListCharacter_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetListCharacter;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 7);
            Assert.Contains("Head", result);
            Assert.Contains("Necklace", result);
            Assert.Contains("PrimaryHand", result);
            Assert.Contains("OffHand", result);
            Assert.Contains("RightFinger", result);
            Assert.Contains("LeftFinger", result);
            Assert.Contains("Feet", result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Unknown, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_Head_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("Head");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Head, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_Necklace_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("Necklace");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Necklace, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_PrimaryHand_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("PrimaryHand");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_OffHand_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("OffHand");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.OffHand, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_RightFinger_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("RightFinger");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.RightFinger, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_LeftFinger_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("LeftFinger");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.LeftFinger, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_Finger_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("Finger");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Finger, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_ConvertStringToEnum_Feet_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertStringToEnum("Feet");

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Feet, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_1_Should_Return_Head()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(1);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Head, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_2_Should_Return_Necklace()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(2);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Necklace, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_3_Should_Return_PrimaryHand()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(3);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_4_Should_Return_OffHand()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(4);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.OffHand, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_5_Should_Return_RightFinger()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(5);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.RightFinger, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_6_Should_Return_LeftFinger()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(6);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.LeftFinger, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_7_Should_Return_Feet()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(7);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Feet, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetLocationByPosition_8_Should_Return_Feet()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetLocationByPosition(8);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Feet, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetItemFromLocationType_Head_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetItemFromLocationType(ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 1);
            Assert.Contains(ItemTypeEnum.GraduationCapAndRobe, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetItemFromLocationType_Necklace_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetItemFromLocationType(ItemLocationEnum.Necklace);

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 3);
            Assert.Contains(ItemTypeEnum.LibraryCard, result);
            Assert.Contains(ItemTypeEnum.FoodCourtCard, result);
            Assert.Contains(ItemTypeEnum.PrivateTutor, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetItemFromLocationType_PrimaryHand_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetItemFromLocationType(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 5);
            Assert.Contains(ItemTypeEnum.PencilEraser, result);
            Assert.Contains(ItemTypeEnum.Notebook, result);
            Assert.Contains(ItemTypeEnum.Textbooks, result);
            Assert.Contains(ItemTypeEnum.Laptop, result);
            Assert.Contains(ItemTypeEnum.Tuition, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetItemFromLocationType_OffHand_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetItemFromLocationType(ItemLocationEnum.OffHand);

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 1);
            Assert.Contains(ItemTypeEnum.FinancialAid, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetItemFromLocationType_RightFinger_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetItemFromLocationType(ItemLocationEnum.RightFinger);

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 1);
            Assert.Contains(ItemTypeEnum.IndexCards, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetItemFromLocationType_LeftFinger_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetItemFromLocationType(ItemLocationEnum.LeftFinger);

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 1);
            Assert.Contains(ItemTypeEnum.Calculator, result);
        }

        [Test]
        public void ItemLocationEnumHelperTests_GetItemFromLocationType_Feet_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetItemFromLocationType(ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 0);
        }
    }
}
