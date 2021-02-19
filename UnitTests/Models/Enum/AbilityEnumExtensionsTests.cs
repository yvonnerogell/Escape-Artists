using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class AbilityEnumExtensionsTests
    {
        [Test]
        public void AbilityEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_None_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.None.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_ExtraCredit_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.ExtraCredit.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Extra credit", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Extension_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Extension.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Extension", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_FlashGenius_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.FlashGenius.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Flash of genius", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Bribes_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Bribes.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Bribes", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_PayTuition_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.PayTuition.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Pay tuition", result);
        }
    }
}