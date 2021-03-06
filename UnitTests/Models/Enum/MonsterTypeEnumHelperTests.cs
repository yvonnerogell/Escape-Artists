using NUnit.Framework;
using Game.Models;
using Game;

namespace UnitTests.Models.Enum
{
    [TestFixture]
    class MonsterTypeEnumHelperTests
    {

        [Test]
        public void MonsterTypeEnumHelperTests_GetAttackMessage_Faculty_Attacks_Student_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty };
            var targetStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Student };

            // Act
            var result = MonsterTypeEnumHelper.GetAttackMessage(attackerFaculty.MonsterTypeEnum, targetStudent.CharacterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" gives an exam to ", result);
        }

        [Test]
        public void MonsterTypeEnumHelperTests_GetAttackMessage_Faculty_Attacks_Parent_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty };
            var targetStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Parent };

            // Act
            var result = MonsterTypeEnumHelper.GetAttackMessage(attackerFaculty.MonsterTypeEnum, targetStudent.CharacterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" calls parent in for parent-teacher conference ", result);
        }

        [Test]
        public void MonsterTypeEnumHelperTests_GetAttackMessage_Administrator_Attacks_Student_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Administrator };
            var targetStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Student };

            // Act
            var result = MonsterTypeEnumHelper.GetAttackMessage(attackerFaculty.MonsterTypeEnum, targetStudent.CharacterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" gives forms to fill out to ", result);
        }
        [Test]
        public void MonsterTypeEnumHelperTests_GetAttackMessage_Administrator_Attacks_Parent_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Administrator };
            var targetStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Parent };

            // Act
            var result = MonsterTypeEnumHelper.GetAttackMessage(attackerFaculty.MonsterTypeEnum, targetStudent.CharacterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" requests payment from ", result);
        }

        [Test]
        public void MonsterTypeEnumHelperTests_GetAttackMessage_Unknown_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Unknown };
            var targetStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Unknown };

            // Act
            var result = MonsterTypeEnumHelper.GetAttackMessage(attackerFaculty.MonsterTypeEnum, targetStudent.CharacterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
