using NUnit.Framework;
using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class SpecificCharacterTypeEnumExtensionsTests
	{

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.SmartyPants.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Smarty Pants", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.Overachiever.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Overachiever", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.InternationalStudent.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("International Student", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.Prodigy.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Prodigy", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.SecondCareer.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Second Career", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.Slacker.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Slacker", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.Procrastinator.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Procrastinator", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.HelicopterParent.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Helicopter Parent", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumExtensionsTests_ToMessage_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnum.CoolParent.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Cool Parent", result);
        }
    }
}
