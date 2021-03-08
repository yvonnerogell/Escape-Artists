using NUnit.Framework;
using Game.Models;
using Game;

namespace UnitTests.Models.Enum
{
    [TestFixture]
    class CharacterTypeEnumHelperTests
    {

        [Test]
        public void CharacterTypeEnumHelperTests_GetAttackMessage_Student_Attacks_Faculty_Should_Pass()
        {
            // Arrange
            var attackerStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Student };
            var targetFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty };

            // Act
            var result = CharacterTypeEnumHelper.getAttackMessage(attackerStudent.CharacterTypeEnum, targetFaculty.MonsterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" pass an exam from ", result);
        }

        [Test]
        public void CharacterTypeEnumHelperTests_GetAttackMessage_Student_Attacks_Administrator_Should_Pass()
        {
            // Arrange
            var attackerStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Student };
            var targetFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Administrator };

            // Act
            var result = CharacterTypeEnumHelper.getAttackMessage(attackerStudent.CharacterTypeEnum, targetFaculty.MonsterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" finished the paper work from ", result);
        }

        [Test]
        public void CharacterTypeEnumHelperTests_GetAttackMessage_Parent_Attacks_Faculty_Should_Pass()
        {
            // Arrange
            var attackerStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Parent };
            var targetFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty };

            // Act
            var result = CharacterTypeEnumHelper.getAttackMessage(attackerStudent.CharacterTypeEnum, targetFaculty.MonsterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" puts pressure to make exam easier on ", result);
        }

        [Test]
        public void CharacterTypeEnumHelperTests_GetAttackMessage_Parent_Attacks_Administrator_Should_Pass()
        {
            // Arrange
            var attackerStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Parent };
            var targetFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Administrator };

            // Act
            var result = CharacterTypeEnumHelper.getAttackMessage(attackerStudent.CharacterTypeEnum, targetFaculty.MonsterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual(" complain about time needed to process paperwork from ", result);
        }

        [Test]
        public void CharacterTypeEnumHelperTests_GetAttackMessage_Unknown_Attacks_Administrator_Should_Pass()
        {
            // Arrange
            var attackerStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Unknown };
            var targetFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Administrator };

            // Act
            var result = CharacterTypeEnumHelper.getAttackMessage(attackerStudent.CharacterTypeEnum, targetFaculty.MonsterTypeEnum);

            // Reset

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
