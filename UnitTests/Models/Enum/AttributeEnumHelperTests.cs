using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class AttributeEnumHelperTests
	{

        [Test]
        public void AttributeEnumHelperTests_GetListItem_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.GetListItem;

            // Reset

            // Assert
            Assert.Contains("Unknown", result);
            Assert.Contains("Attack", result);
            Assert.Contains("CurrentHealth", result);
            Assert.Contains("Defense", result);
            Assert.Contains("MaxHealth", result);
            Assert.Contains("Speed", result);
            Assert.AreEqual(result.Count, 6);
        }

        [Test]
        public void AttributeEnumHelperTests_GetListCharacter_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.GetListCharacter;

            // Reset

            // Assert
            Assert.Contains("Attack", result);
            Assert.Contains("CurrentHealth", result);
            Assert.Contains("Defense", result);
            Assert.Contains("MaxHealth", result);
            Assert.Contains("Speed", result);
            Assert.AreEqual(result.Count, 5);
        }

        [Test]
        public void AttributeEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(AttributeEnum.Unknown, result);
        }

        [Test]
        public void AttributeEnumHelperTests_ConvertStringToEnum_Speed_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.ConvertStringToEnum("Speed");

            // Reset

            // Assert
            Assert.AreEqual(AttributeEnum.Speed, result);
        }

        [Test]
        public void AttributeEnumHelperTests_ConvertStringToEnum_Defense_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.ConvertStringToEnum("Defense");

            // Reset

            // Assert
            Assert.AreEqual(AttributeEnum.Defense, result);
        }

        [Test]
        public void AttributeEnumHelperTests_ConvertStringToEnum_Attack_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.ConvertStringToEnum("Attack");

            // Reset

            // Assert
            Assert.AreEqual(AttributeEnum.Attack, result);
        }

        [Test]
        public void AttributeEnumHelperTests_ConvertStringToEnum_CurrentHealth_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.ConvertStringToEnum("CurrentHealth");

            // Reset

            // Assert
            Assert.AreEqual(AttributeEnum.CurrentHealth, result);
        }

        [Test]
        public void AttributeEnumHelperTests_ConvertStringToEnum_MaxHealth_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnumHelper.ConvertStringToEnum("MaxHealth");

            // Reset

            // Assert
            Assert.AreEqual(AttributeEnum.MaxHealth, result);
        }
    }
}
