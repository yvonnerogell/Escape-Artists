using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class BattleModeEnumHelperTests
	{

        [Test]
        public void BattleModeEnumHelperTests_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.AreEqual(6, result.Count);
            Assert.Contains("Unknown", result);
            Assert.Contains("SimpleNext", result);
            Assert.Contains("SimpleAbility", result);
            Assert.Contains("MapNext", result);
            Assert.Contains("MapAbility", result);
            Assert.Contains("MapFull", result);
        }

        [Test]
        public void BattleModeEnumHelperTests_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.GetListMessageAll;

            // Reset

            // Assert
            Assert.AreEqual(6, result.Count);
            Assert.Contains("Unknown", result);
            Assert.Contains("Simple Next", result);
            Assert.Contains("Simple Abilities", result);
            Assert.Contains("Map Next Button", result);
            Assert.Contains("Map Abilities", result);
            Assert.Contains("Map All Actions", result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.Unknown, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertStringToEnum_MapAbility_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertStringToEnum("MapAbility");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapAbility, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertStringToEnum_MapFull_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertStringToEnum("MapFull");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapFull, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertStringToEnum_MapNext_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertStringToEnum("MapNext");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapNext, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertStringToEnum_SimpleAbility_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertStringToEnum("SimpleAbility");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.SimpleAbility, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertStringToEnum_SimpleNext_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertStringToEnum("SimpleNext");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.SimpleNext, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertMessageStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.Unknown, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertMessageStringToEnum_MapAbility_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Map Abilities");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapAbility, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertMessageStringToEnum_MapFull_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Map All Actions");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapFull, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertMessageStringToEnum_MapNext_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Map Next Button");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.MapNext, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertMessageStringToEnum_SimpleAbility_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Simple Abilities");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.SimpleAbility, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertMessageStringToEnum_SimpleNext_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("Simple Next");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.SimpleNext, result);
        }

        [Test]
        public void BattleModeEnumHelperTests_ConvertMessageStringToEnum_BogusString_Should_Pass()
        {
            // Arrange

            // Act
            var result = BattleModeEnumHelper.ConvertMessageStringToEnum("This doesn't exist");

            // Reset

            // Assert
            Assert.AreEqual(BattleModeEnum.Unknown, result);
        }
    }
}
