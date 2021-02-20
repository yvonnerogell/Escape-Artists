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

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.Unknown, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_AdjunctFaculty_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("AdjunctFaculty");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.AdjunctFaculty, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_AssistantProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("AssistantProfessor");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.AssistantProfessor, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_AssociateProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("AssociateProfessor");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.AssociateProfessor, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_GraduationOfficeAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("GraduationOfficeAdministrator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.GraduationOfficeAdministrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_HRAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("HRAdministrator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.HRAdministrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_Professor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("Professor");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.Professor, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_RegistrationAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("RegistrationAdministrator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.RegistrationAdministrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertStringToEnum_TeachingAssistant_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertStringToEnum("TeachingAssistant");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.TeachingAssistant, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.Unknown, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_AdjunctFaculty_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Adjunct Faculty");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.AdjunctFaculty, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_AssistantProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Assistant Professor");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.AssistantProfessor, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_AssociateProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Associate Professor");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.AssociateProfessor, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_GraduationOfficeAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Graduation Office Administrator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.GraduationOfficeAdministrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_HRAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("HR Administrator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.HRAdministrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_Professor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Professor");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.Professor, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_RegistrationAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Registration Administrator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.RegistrationAdministrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_TeachingAssistant_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("Teaching Assistant");

            // Reset

            // Assert
            Assert.AreEqual(SpecificMonsterTypeEnum.TeachingAssistant, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Unknown, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_AdjunctFaculty_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.AdjunctFaculty);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Faculty, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_AssistantProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.AssistantProfessor);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Faculty, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_AssociateProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.AssociateProfessor);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Faculty, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_GraduationOfficeAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.GraduationOfficeAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Administrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_HRAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.HRAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Administrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_Professor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.Professor);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Faculty, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_RegistrationAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.RegistrationAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Administrator, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_GetMonsterTypeEnumFromSpecificMonsterTypeEnum_TeachingAssistant_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum.TeachingAssistant);

            // Reset

            // Assert
            Assert.AreEqual(MonsterTypeEnum.Faculty, result);
        }
    }
}
