using NUnit.Framework;
using Game.Models;
using Game;

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
        public void SpecificMonsterTypeEnumHelperTests_ConvertMessageStringToEnum_BogusString_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ConvertMessageStringToEnum("This doesn't exist");

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

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeDefaultImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_AdjunctFaculty_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.AdjunctFaculty);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeAdjunctFacultyImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_AssistantProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.AssistantProfessor);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeAssistantProfessorImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_AssociateProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.AssociateProfessor);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeAssociateProfessorImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_GraduationOfficeAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.GraduationOfficeAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_HRAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.HRAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeHRAdministratorImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_Professor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.Professor);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeProfessorImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_RegistrationAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.RegistrationAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeRegistrationAdministratorImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToImageURI_TeachingAssistant_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum.TeachingAssistant);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeTeachingAssistantImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeDefaultTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_AdjunctFaculty_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.AdjunctFaculty);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeAdjunctFacultyTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_AssistantProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.AssistantProfessor);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeAssistantProfessorTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_AssociateProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.AssociateProfessor);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeAssociateProfessorTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_GraduationOfficeAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.GraduationOfficeAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeGraduationOfficeAdministratorTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_HRAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.HRAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeHRAdministratorTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_Professor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.Professor);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeProfessorTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_RegistrationAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.RegistrationAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeRegistrationAdministratorTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToTileImageURI_TeachingAssistant_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToTileImageURI(SpecificMonsterTypeEnum.TeachingAssistant);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificMonsterTypeTeachingAssistantTileImageURI, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_AdjunctFaculty_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.AdjunctFaculty);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_AssistantProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.AssistantProfessor);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_AssociateProfessor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.AssociateProfessor);

            // Reset

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_GraduationOfficeAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.GraduationOfficeAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_HRAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.HRAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_Professor_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.Professor);

            // Reset

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_RegistrationAdministrator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.RegistrationAdministrator);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void SpecificMonsterTypeEnumHelperTests_ToRange_TeachingAssistant_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificMonsterTypeEnumHelper.ToRange(SpecificMonsterTypeEnum.TeachingAssistant);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
