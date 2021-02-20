using NUnit.Framework;
using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class SpecificMonsterTypeEnumExtensionsTests
	{

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_TeachingAssistant_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.TeachingAssistant.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Teaching Assistant", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_AdjunctFaculty_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.AdjunctFaculty.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Adjunct Faculty", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_AssistantProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.AssistantProfessor.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Assistant Professor", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_AssociateProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.AssociateProfessor.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Associate Professor", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_Professor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.Professor.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Professor", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_HRAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.HRAdministrator.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("HR Administrator", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_RegistrationAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.RegistrationAdministrator.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Registration Administrator", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumExtensionsTests_ToMessage_GraduationOfficeAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnum.GraduationOfficeAdministrator.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Graduation Office Administrator", result);
        }
    }
}
