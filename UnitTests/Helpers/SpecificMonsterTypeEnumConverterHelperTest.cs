using System;
using NUnit.Framework;

using Game.Models;
using Game.Helpers;
namespace UnitTests.Helpers
{
    [TestFixture]
    public class SpecificMonsterTypeEnumConverterHelperTest
    {
        [Test]
        public void SpecificMonsterTypeEnumConverterHelper_Should_Skip()
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
            var myConverter = new SpecificMonsterTypeEnumConverter();

            var myObject = SpecificMonsterTypeEnum.AssistantProfessor;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = "Assistant Professor";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void SpecificMonsterTypeEnumConverterHelper_String_Should_Pass()
        {
            var myConverter = new SpecificMonsterTypeEnumConverter();

            var myObject = "Associate Professor";
            var Result = myConverter.Convert(myObject, typeof(SpecificMonsterTypeEnum), null, null);
            var Expected = "Associate Professor";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void SpecificMonsterTypeEnumConverterHelper_Other_Should_Skip()
        {
            var myConverter = new SpecificMonsterTypeEnumConverter();

            var myObject = new ItemModel();
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void SpecificMonsterTypeEnumConverterHelper_ConvertBack_Should_Skip()
        {
            var myConverter = new SpecificMonsterTypeEnumConverter();

            var myObject = SpecificMonsterTypeEnum.AssociateProfessor;
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void SpecificMonsterTypeEnumConverterHelper_ConvertBack_Int_Should_Pass()
        {
            var myConverter = new SpecificMonsterTypeEnumConverter();

            int myObject = 40;
            var Result = myConverter.ConvertBack(myObject, typeof(SpecificMonsterTypeEnum), null, null);
            var Expected = "Associate Professor";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void SpecificMonsterTypeEnumConverterHelper_ConvertBack_String_Should_Pass()
        {
            var myConverter = new SpecificMonsterTypeEnumConverter();

            string myObject = "AssociateProfessor";
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = SpecificMonsterTypeEnum.AssociateProfessor;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
    }
}
