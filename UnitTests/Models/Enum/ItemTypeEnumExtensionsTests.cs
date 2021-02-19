using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class ItemTypeEnumExtensionsTests
	{

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_Calculator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.Calculator);

            // Reset

            // Assert
            Assert.AreEqual("Calculator", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_Diploma_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.Diploma);

            // Reset

            // Assert
            Assert.AreEqual("Diploma", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_FinancialAid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.FinancialAid);

            // Reset

            // Assert
            Assert.AreEqual("Financial Aid", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_FoodCourtCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.FoodCourtCard);

            // Reset

            // Assert
            Assert.AreEqual("Food Court Card", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.GraduationCapAndRobe);

            // Reset

            // Assert
            Assert.AreEqual("Graduation Cap and Robe", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_IndexCards_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.IndexCards);

            // Reset

            // Assert
            Assert.AreEqual("Index Cards", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_Laptop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.Laptop);

            // Reset

            // Assert
            Assert.AreEqual("Laptop", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_LibraryCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.LibraryCard);

            // Reset

            // Assert
            Assert.AreEqual("Library Card", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_Notebook_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.Notebook);

            // Reset

            // Assert
            Assert.AreEqual("Notebook", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_PencilEraser_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.PencilEraser);

            // Reset

            // Assert
            Assert.AreEqual("Pencil Eraser", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_PrivateTutor_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.PrivateTutor);

            // Reset

            // Assert
            Assert.AreEqual("Private Tutor", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_Textbooks_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.Textbooks);

            // Reset

            // Assert
            Assert.AreEqual("Textbooks", result);
        }

        [Test]
        public void ItemTypeEnumExtensionsTests_ToMessage_Tuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumExtensions.ToMessage(ItemTypeEnum.Tuition);

            // Reset

            // Assert
            Assert.AreEqual("Tuition", result);
        }
    }
}
