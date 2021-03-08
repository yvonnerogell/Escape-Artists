using NUnit.Framework;
using Game.Models;
using Game;

namespace UnitTests.Models.Enum
{
	[TestFixture]
	class SpecificCharacterTypeEnumHelperTests
	{
        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 10);
            Assert.Contains("Unknown", result);
            Assert.Contains("SmartyPants", result);
            Assert.Contains("Overachiever", result);
            Assert.Contains("InternationalStudent", result);
            Assert.Contains("Prodigy", result);
            Assert.Contains("SecondCareer", result);
            Assert.Contains("Slacker", result);
            Assert.Contains("Procrastinator", result);
            Assert.Contains("HelicopterParent", result);
            Assert.Contains("CoolParent", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetListMessageAll;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 10);
            Assert.Contains("Unknown", result);
            Assert.Contains("Smarty Pants", result);
            Assert.Contains("Overachiever", result);
            Assert.Contains("International Student", result);
            Assert.Contains("Prodigy", result);
            Assert.Contains("Second Career", result);
            Assert.Contains("Slacker", result);
            Assert.Contains("Procrastinator", result);
            Assert.Contains("Helicopter Parent", result);
            Assert.Contains("Cool Parent", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetListMessageAllNoUnknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetListMessageAllNoUnknown;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 9);
            Assert.Contains("Smarty Pants", result);
            Assert.Contains("Overachiever", result);
            Assert.Contains("International Student", result);
            Assert.Contains("Prodigy", result);
            Assert.Contains("Second Career", result);
            Assert.Contains("Slacker", result);
            Assert.Contains("Procrastinator", result);
            Assert.Contains("Helicopter Parent", result);
            Assert.Contains("Cool Parent", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetStudentList_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetStudentList;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 8);
            Assert.Contains("Unknown", result);
            Assert.Contains("SmartyPants", result);
            Assert.Contains("Overachiever", result);
            Assert.Contains("InternationalStudent", result);
            Assert.Contains("Prodigy", result);
            Assert.Contains("SecondCareer", result);
            Assert.Contains("Slacker", result);
            Assert.Contains("Procrastinator", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetStudentListMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetStudentListMessage;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 8);
            Assert.Contains("Unknown", result);
            Assert.Contains("Smarty Pants", result);
            Assert.Contains("Overachiever", result);
            Assert.Contains("International Student", result);
            Assert.Contains("Prodigy", result);
            Assert.Contains("Second Career", result);
            Assert.Contains("Slacker", result);
            Assert.Contains("Procrastinator", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetParentList_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetParentList;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 2);
            Assert.Contains("HelicopterParent", result);
            Assert.Contains("CoolParent", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetParentListMessage_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetParentListMessage;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 2);
            Assert.Contains("Helicopter Parent", result);
            Assert.Contains("Cool Parent", result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Unknown, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_BogusString_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("This doesn't exist");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Unknown, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Cool Parent");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.CoolParent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Helicopter Parent");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.HelicopterParent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("International Student");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.InternationalStudent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Overachiever");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Overachiever, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Procrastinator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Procrastinator, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Prodigy");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Prodigy, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Second Career");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.SecondCareer, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Slacker");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Slacker, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertMessageStringToEnum_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertMessageStringToEnum("Smarty Pants");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.SmartyPants, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Unknown, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("CoolParent");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.CoolParent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("HelicopterParent");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.HelicopterParent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("InternationalStudent");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.InternationalStudent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("Overachiever");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Overachiever, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("Procrastinator");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Procrastinator, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnumm_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("Prodigy");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Prodigy, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("SecondCareer");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.SecondCareer, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("Slacker");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.Slacker, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ConvertStringToEnum_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ConvertStringToEnum("SmartyPants");

            // Reset

            // Assert
            Assert.AreEqual(SpecificCharacterTypeEnum.SmartyPants, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.CoolParent);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Parent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.HelicopterParent);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Parent, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.InternationalStudent);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Student, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.Overachiever);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Student, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.Procrastinator);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Student, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.Prodigy);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Student, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.SecondCareer);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Student, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.Slacker);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Student, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.SmartyPants);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Student, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_GetCharacterTypeEnumFromSpecificCharacterTypeEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(CharacterTypeEnum.Unknown, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.SmartyPants);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.ExtraCredit, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.Slacker);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Extension, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.SecondCareer);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Extension, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.Prodigy);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.ExtraCredit, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.Procrastinator);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Extension, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.Overachiever);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.FlashGenius, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.InternationalStudent);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.FlashGenius, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.HelicopterParent);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Bribes, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.CoolParent);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.PayTuition, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToAbility_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(AbilityEnum.Unknown, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeDefaultImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.CoolParent);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeCoolParentImageURI, result);
        }


        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.HelicopterParent);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeHelicopterParentImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.InternationalStudent);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeInternationalStudentImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.Overachiever);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeOverachieverImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.Procrastinator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeProcrastinatorImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.Prodigy);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeProdigyImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.SecondCareer);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeSecondCareerImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.Slacker);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeSlackerImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToImageURI_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum.SmartyPants);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeSmartyPantsImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeDefaultTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.CoolParent);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeCoolParentTileImageURI, result);
        }


        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.HelicopterParent);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeHelicopterParentTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.InternationalStudent);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeInternationalStudentTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.Overachiever);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeOverachieverTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.Procrastinator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeProcrastinatorTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.Prodigy);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeProdigyTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.SecondCareer);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeSecondCareerTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.Slacker);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeSlackerTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToTileImageURI_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToTileImageURI(SpecificCharacterTypeEnum.SmartyPants);

            // Reset

            // Assert
            Assert.AreEqual(Constants.SpecificCharacterTypeSmartyPantsTileImageURI, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_CoolParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.CoolParent);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }


        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_HelicopterParent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.HelicopterParent);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_InternationalStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.InternationalStudent);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_Overachiever_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.Overachiever);

            // Reset

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_Procrastinator_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.Procrastinator);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_Prodigy_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.Prodigy);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_SecondCareer_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.SecondCareer);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_Slacker_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.Slacker);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void SpecificCharacterTypeEnumHelperTests_ToRange_SmartyPants_Should_Pass()
        {
            // Arrange

            // Act
            var result = SpecificCharacterTypeEnumHelper.ToRange(SpecificCharacterTypeEnum.SmartyPants);

            // Reset

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}
