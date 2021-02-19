using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models.Enum
{
    [TestFixture]
	class DifficultyEnumHelperTests
	{

        [Test]
        public void DifficultyEnumHelperTests_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.Contains("Easy", result);
            Assert.Contains("Average", result);
            Assert.Contains("Hard", result);
            Assert.Contains("Difficult", result);
            Assert.Contains("Impossible", result);
            Assert.Contains("Unknown", result);
            Assert.AreEqual(result.Count, 6);
        }

        [Test]
        public void DifficultyEnumHelperTests_GetListAllExceptUnknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.GetListAllExceptUnknown;

            // Reset

            // Assert
            Assert.Contains("Easy", result);
            Assert.Contains("Average", result);
            Assert.Contains("Hard", result);
            Assert.Contains("Difficult", result);
            Assert.Contains("Impossible", result);
            Assert.AreEqual(result.Count, 5);
        }

        [Test]
        public void DifficultyEnumHelperTests_GetListMonster_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.GetListMonster;

            // Reset

            // Assert
            Assert.Contains("Easy", result);
            Assert.Contains("Average", result);
            Assert.Contains("Hard", result);
            Assert.Contains("Difficult", result);
            Assert.Contains("Impossible", result);
            Assert.AreEqual(result.Count, 5);
        }

        [Test]
        public void DifficultyEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(DifficultyEnum.Unknown, result);
        }

        [Test]
        public void DifficultyEnumHelperTests_ConvertStringToEnum_Easy_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.ConvertStringToEnum("Easy");

            // Reset

            // Assert
            Assert.AreEqual(DifficultyEnum.Easy, result);
        }

        [Test]
        public void DifficultyEnumHelperTests_ConvertStringToEnum_Average_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.ConvertStringToEnum("Average");

            // Reset

            // Assert
            Assert.AreEqual(DifficultyEnum.Average, result);
        }

        [Test]
        public void DifficultyEnumHelperTests_ConvertStringToEnum_Hard_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.ConvertStringToEnum("Hard");

            // Reset

            // Assert
            Assert.AreEqual(DifficultyEnum.Hard, result);
        }

        [Test]
        public void DifficultyEnumHelperTests_ConvertStringToEnum_Difficult_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.ConvertStringToEnum("Difficult");

            // Reset

            // Assert
            Assert.AreEqual(DifficultyEnum.Difficult, result);
        }

        [Test]
        public void DifficultyEnumHelperTests_ConvertStringToEnum_Impossible_Should_Pass()
        {
            // Arrange

            // Act
            var result = DifficultyEnumHelper.ConvertStringToEnum("Impossible");

            // Reset

            // Assert
            Assert.AreEqual(DifficultyEnum.Impossible, result);
        }
    }
}
