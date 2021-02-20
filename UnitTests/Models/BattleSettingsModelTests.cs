using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
	[TestFixture]
	class BattleSettingsModelTests
	{
        [Test]
        public void BattleSettingsModelTests_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleSettingsModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(false, result.AllowCriticalHit);
            Assert.AreEqual(false, result.AllowCriticalMiss);
            Assert.AreEqual(false, result.AllowMonsterItems);
            Assert.AreEqual(BattleModeEnum.SimpleNext, result.BattleModeEnum);
            Assert.AreEqual(HitStatusEnum.Default, result.CharacterHitEnum);
            Assert.AreEqual(HitStatusEnum.Default, result.MonsterHitEnum);
        }
    }
}
