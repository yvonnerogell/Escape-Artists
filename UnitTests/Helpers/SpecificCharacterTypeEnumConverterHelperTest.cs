using NUnit.Framework;

using Game.Models;
using Game.Helpers;
namespace UnitTests.Helpers
{
    [TestFixture]
    public class SpecificCharacterTypeEnumConverterHelperTest
    {
        [Test]
        public void SpecificCharacterTypeEnumConverterHelper_Should_Skip()
        {
            var myConverter = new SpecificCharacterTypeEnumConverter();

            var myObject = 10;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void AbilityEnumConverterHelper_Should_Pass()
        {
            var myConverter = new SpecificCharacterTypeEnumConverter();

            var myObject = SpecificCharacterTypeEnum.CoolParent;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = "Cool Parent";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void AbilityEnumConverterHelper_String_Should_Pass()
        {
            var myConverter = new SpecificCharacterTypeEnumConverter();

            var myObject = "Cool Parent";
            var Result = myConverter.Convert(myObject, typeof(SpecificCharacterTypeEnum), null, null);
            var Expected = "Cool Parent";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void AbilityEnumConverterHelper_Other_Should_Skip()
        {
            var myConverter = new SpecificCharacterTypeEnumConverter();

            var myObject = new ItemModel();
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void AbilityEnumConverterHelper_ConvertBack_Should_Skip()
        {
            var myConverter = new SpecificCharacterTypeEnumConverter();

            var myObject = SpecificCharacterTypeEnum.CoolParent;
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void AbilityEnumConverterHelper_ConvertBack_Int_Should_Pass()
        {
            var myConverter = new SpecificCharacterTypeEnumConverter();

            int myObject = 50;
            var Result = myConverter.ConvertBack(myObject, typeof(SpecificCharacterTypeEnum), null, null);
            var Expected = "Cool Parent";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void AbilityEnumConverterHelper_ConvertBack_String_Should_Pass()
        {
            var myConverter = new SpecificCharacterTypeEnumConverter();

            string myObject = "CoolParent";
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = SpecificCharacterTypeEnum.CoolParent;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}
