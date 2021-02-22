using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    class AbilityEnumConverterHelperTest
    {
        [Test]
        public void AbilityEnumConverterHelper_Should_Skip()
        {
            var myConverter = new AbilityEnumConverterHelper();

            var myObject = 10;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void AbilityEnumConverterHelper_Should_Pass()
        {
            var myConverter = new AbilityEnumConverterHelper();

            var myObject = AbilityEnum.Extension;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = "Extension";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void AbilityEnumConverterHelper_String_Should_Pass()
        {
            var myConverter = new AbilityEnumConverterHelper();

            var myObject = "Extension";
            var Result = myConverter.Convert(myObject, typeof(AbilityEnum), null, null);
            var Expected = "Extension";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void AbilityEnumConverterHelper_Other_Should_Skip()
        {
            var myConverter = new AbilityEnumConverterHelper();

            var myObject = new ItemModel();
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void AbilityEnumConverterHelper_ConvertBack_Should_Skip()
        {
            var myConverter = new AbilityEnumConverterHelper();

            var myObject = AbilityEnum.Extension;
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void AbilityEnumConverterHelper_ConvertBack_Int_Should_Pass()
        {
            var myConverter = new AbilityEnumConverterHelper();

            int myObject = 110;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemLocationEnum), null, null);
            var Expected = "Extra credit";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void AbilityEnumConverterHelper_ConvertBack_String_Should_Pass()
        {
            var myConverter = new AbilityEnumConverterHelper();

            string myObject = "Extra credit";
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = AbilityEnum.ExtraCredit;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}