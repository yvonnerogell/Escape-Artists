using NUnit.Framework;
using Game.Models;

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
    }
}
