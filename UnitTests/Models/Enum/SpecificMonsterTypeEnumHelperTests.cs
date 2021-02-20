using NUnit.Framework;
using Game.Models;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class SpecificMonsterTypeEnumHelperTests
	{

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.AreEqual(9, result.Count);
            Assert.Contains("Unknown", result);
            Assert.Contains("TeachingAssistant", result);
            Assert.Contains("AdjunctFaculty", result);
            Assert.Contains("AssistantProfessor", result);
            Assert.Contains("AssociateProfessor", result);
            Assert.Contains("Professor", result);
            Assert.Contains("HRAdministrator", result);
            Assert.Contains("RegistrationAdministrator", result);
            Assert.Contains("GraduationOfficeAdministrator", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetListMessageAll;

            // Reset

            // Assert
            Assert.AreEqual(9, result.Count);
            Assert.Contains("Unknown", result);
            Assert.Contains("Teaching Assistant", result);
            Assert.Contains("Adjunct Faculty", result);
            Assert.Contains("Assistant Professor", result);
            Assert.Contains("Associate Professor", result);
            Assert.Contains("Professor", result);
            Assert.Contains("HR Administrator", result);
            Assert.Contains("Registration Administrator", result);
            Assert.Contains("Graduation Office Administrator", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetListMessageAllNoUnknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetListMessageAllNoUnknown;

            // Reset

            // Assert
            Assert.AreEqual(8, result.Count);
            Assert.Contains("Teaching Assistant", result);
            Assert.Contains("Adjunct Faculty", result);
            Assert.Contains("Assistant Professor", result);
            Assert.Contains("Associate Professor", result);
            Assert.Contains("Professor", result);
            Assert.Contains("HR Administrator", result);
            Assert.Contains("Registration Administrator", result);
            Assert.Contains("Graduation Office Administrator", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetFacultyList_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetFacultyList;

            // Reset

            // Assert
            Assert.AreEqual(5, result.Count);
            Assert.Contains("TeachingAssistant", result);
            Assert.Contains("AdjunctFaculty", result);
            Assert.Contains("AssistantProfessor", result);
            Assert.Contains("AssociateProfessor", result);
            Assert.Contains("Professor", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetFacultyListMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetFacultyListMessage;

            // Reset

            // Assert
            Assert.AreEqual(5, result.Count);
            Assert.Contains("Teaching Assistant", result);
            Assert.Contains("Adjunct Faculty", result);
            Assert.Contains("Assistant Professor", result);
            Assert.Contains("Associate Professor", result);
            Assert.Contains("Professor", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetAdministratorList_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetAdministratorList;

            // Reset

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.Contains("HRAdministrator", result);
            Assert.Contains("RegistrationAdministrator", result);
            Assert.Contains("GraduationOfficeAdministrator", result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetAdministratorListMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetAdministratorListMessage;

            // Reset

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.Contains("HR Administrator", result);
            Assert.Contains("Registration Administrator", result);
            Assert.Contains("Graduation Office Administrator", result);
        }
    }
}
