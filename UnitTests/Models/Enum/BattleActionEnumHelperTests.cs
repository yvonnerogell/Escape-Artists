using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class BattleActionEnumHelperTests
	{
        [Test]
        public void BattleActionEnumHelperTests_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleActionEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 3);
            Assert.Contains("Default", result);
            Assert.Contains("Off", result);
            Assert.Contains("On", result);
        }

        [Test]
        public void BattleActionEnumHelperTests_ConvertStringToEnum_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleActionEnumHelper.ConvertStringToEnum("Default");

            // Reset

            // Assert
            Assert.AreEqual(BattleActionEnum.Default, result);
        }

        [Test]
        public void BattleActionEnumHelperTests_ConvertStringToEnum_Off_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleActionEnumHelper.ConvertStringToEnum("Off");

            // Reset

            // Assert
            Assert.AreEqual(BattleActionEnum.Off, result);
        }

        [Test]
        public void BattleActionEnumHelperTests_ConvertStringToEnum_On_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleActionEnumHelper.ConvertStringToEnum("On");

            // Reset

            // Assert
            Assert.AreEqual(BattleActionEnum.On, result);
        }
    }
}
