using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class AbilityEnumHelperTests
	{

        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_None_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("None");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.None, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_ExtraCredit_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("Extra credit");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.ExtraCredit, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_Extension_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("Extension");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Extension, result);
        }


        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_FlashGenius_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("Flash of genius");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.FlashGenius, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_Bribes_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("Bribes");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bribes, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_PayTuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("Pay tuition");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.PayTuition, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertMessageStringToEnum_Bogus_Should_Return_Unknown()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertMessageStringToEnum("This ability doesn't exist");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertStringToEnum_None_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertStringToEnum("None");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.None, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertStringToEnum_ExtraCredit_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertStringToEnum("ExtraCredit");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.ExtraCredit, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertStringToEnum_Extension_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertStringToEnum("Extension");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Extension, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertStringToEnum_FlashGenius_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertStringToEnum("FlashGenius");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.FlashGenius, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertStringToEnum_Bribes_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertStringToEnum("Bribes");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bribes, result);
        }

        [Test]
        public void AbilityEnumHelperTests_ConvertStringToEnum_PayTuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.ConvertStringToEnum("PayTuition");

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.PayTuition, result);
        }

        [Test]
        public void AbilityEnumHelperTests_GetFullAbilityEnumList_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetFullAbilityEnumList;

            // Reset

            // Assert
            Assert.Contains("Unknown", result);
            Assert.Contains("None", result);
            Assert.Contains("ExtraCredit", result);
            Assert.Contains("Extension", result);
            Assert.Contains("Bribes", result);
            Assert.Contains("FlashGenius", result);
            Assert.Contains("PayTuition", result);
            Assert.AreEqual(result.Count, 7);
        }

        [Test]
        public void AbilityEnumHelperTests_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListMessageAll;

            // Reset

            // Assert
            Assert.Contains("Unknown", result);
            Assert.Contains("None", result);
            Assert.Contains("Extra credit", result);
            Assert.Contains("Extension", result);
            Assert.Contains("Bribes", result);
            Assert.Contains("Flash of genius", result);
            Assert.Contains("Pay tuition", result);
            Assert.AreEqual(result.Count, 7);
        }
    }
}
