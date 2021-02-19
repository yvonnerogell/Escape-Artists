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
    }
}
