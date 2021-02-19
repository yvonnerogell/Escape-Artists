using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models.Enum
{
    [TestFixture]
    class HitStatusEnumHelperTests
    {

        [Test]
        public void HitStatusEnumHelperTests_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.Contains("Unknown", result);
            Assert.Contains("Default", result);
            Assert.Contains("Miss", result);
            Assert.Contains("CriticalMiss", result);
            Assert.Contains("Hit", result);
            Assert.Contains("CriticalHit", result);
            Assert.AreEqual(result.Count, 6);
        }

        [Test]
        public void HitStatusEnumHelperTests_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.GetListMessageAll;

            // Reset

            // Assert
            Assert.Contains("Unknown", result);
            Assert.Contains(" hits ", result);
            Assert.Contains(" hits really hard ", result);
            Assert.Contains(" misses ", result);
            Assert.Contains(" misses really badly", result);
            Assert.AreEqual(result.Count, 6);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertStringToEnum_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertStringToEnum("Default");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Default, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertStringToEnum_Miss_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertStringToEnum("Miss");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertStringToEnum_CriticalMiss_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertStringToEnum("CriticalMiss");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalMiss, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertStringToEnum_Hit_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertStringToEnum("Hit");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertStringToEnum_CriticalHit_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertStringToEnum("CriticalHit");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalHit, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertMessageStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertMessageStringToEnum_BogusString_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum("This doesn't exist");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertMessageStringToEnum_hits_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum(" hits ");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertMessageStringToEnum_hits_really_hard_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum(" hits really hard ");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalHit, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertMessageStringToEnum_misses_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum(" misses ");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void HitStatusEnumHelperTests_ConvertMessageStringToEnum_misses_really_badly_Should_Pass()
        {
            // Arrange

            // Act
            var result = HitStatusEnumHelper.ConvertMessageStringToEnum(" misses really badly");

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalMiss, result);
        }
    }
}
