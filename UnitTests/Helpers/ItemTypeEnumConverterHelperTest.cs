using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class ItemTypeEnumHelperTests
    {
        [Test]
        public void ItemTypeEnumHelper_ItemTypeEnum_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemTypeEnumHelper_GetListAll_Should_Pass()
        {
            // Arrange

            // Instantiate a new ItemType Base, should have default of 1 for all values
            var myDataList = ItemTypeEnumHelper.GetListAll;

            // Get Expected set
            var myExpectedList = Enum.GetNames(typeof(ItemTypeEnum)).ToList();
            

            // Act

            // Make sure each item is in the list
            foreach (var item in myDataList)
            {
                var found = false;
                foreach (var expected in myExpectedList)
                {
                    if (item == expected)
                    {
                        found = true;
                        break;
                    }
                }

                // Assert
                Assert.AreEqual(true, found, "item : " + item + TestContext.CurrentContext.Test.Name);
            }

            // reverse it, to make sure the list has each item
            // Make sure each item is in the list
            foreach (var expected in myExpectedList)
            {
                var found = false;
                {
                    foreach (var item in myDataList)
                        if (item == expected)
                        {
                            found = true;
                            break;
                        }
                }

                // Assert
                Assert.AreEqual(true, found, "expected : " + expected + TestContext.CurrentContext.Test.Name);
            }

        }


        [Test]
        public void ItemTypeEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(ItemTypeEnum)).ToList();

            ItemTypeEnum myActual;
            ItemTypeEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = ItemTypeEnumHelper.ConvertStringToEnum(item);
                myExpected = (ItemTypeEnum)Enum.Parse(typeof(ItemTypeEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }

        [Test]
        public void ItemTypeEnumHelper_GetLocationByPosition_1_Should_Pass()
        {
            // Arrange

            var item = ItemTypeEnum.PencilEraser;

            // Act
            var Actual = ItemTypeEnumHelper.GetLocationFromItemType(item);
            var Expected = ItemLocationEnum.PrimaryHand;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        

        #region ItemTypeEnumConverter

        [Test]
        public void ItemTypeEnumConvert_String_Should_Pass()
        {
            var myConverter = new ItemTypeEnumConverter();

            var myObject = "Calculator";
            var Result = myConverter.Convert(myObject, typeof(ItemTypeEnum), null, null);
            var Expected = ItemTypeEnum.Calculator.ToMessage();

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConvert_Enum_Should_Pass()
        {
            var myConverter = new ItemTypeEnumConverter();

            var myObject = ItemTypeEnum.Calculator;
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = "Calculator";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConvert_Other_Should_Skip()
        {
            var myConverter = new ItemTypeEnumConverter();

            var myObject = new ItemModel();
            var Result = myConverter.Convert(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void ItemTypeEnumConvertBack_Should_Skip()
        {
            var myConverter = new ItemTypeEnumConverter();

            var myObject = "Bogus";
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = ItemTypeEnum.Unknown;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        // Convert Back
        [Test]
        public void IntEnumConvertBack_Int_Should_Pass()
        {
            var myConverter = new IntEnumConverter();

            int myObject = 40;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemTypeEnum), null, null);
            var Expected = "Laptop";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConvertBack_String_Should_Pass()
        {
            var myConverter = new ItemTypeEnumConverter();

            var myObject = "Calculator";
            var Result = myConverter.ConvertBack(myObject, typeof(ItemTypeEnum), null, null);
            var Expected = ItemTypeEnum.Calculator;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConvertBack_Enum_Should_Skip()
        {
            var myConverter = new ItemTypeEnumConverter();

            var myObject = ItemTypeEnum.Calculator;
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConvertBack_Other_Should_Skip()
        {
            var myConverter = new ItemLocationEnumConverter();

            var myObject = new ItemModel();
            var Result = myConverter.ConvertBack(myObject, null, null, null);
            var Expected = 0;

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemTypeEnumConvertBack_Int_Should_Pass()
        {
            var myConverter = new ItemTypeEnumConverter();

            int myObject = 25;
            var Result = myConverter.ConvertBack(myObject, typeof(ItemTypeEnum), null, null);
            var Expected = "Calculator";

            Assert.AreEqual(Expected, Result, TestContext.CurrentContext.Test.Name);
        }
        #endregion ItemLocationEnumConverter

        #region ConvertMessageToEnum
        /*
        [Test]
        public void ConvertMessageToEnum_Valid_Feet_Should_Return_Enum()
        {

            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertMessageToEnum("Feet");

            // Assert
            Assert.AreEqual(ItemLocationEnum.Feet, result);
        }

        [Test]
        public void ConvertMessageToEnum_InValid_Bogus_Should_Return_Unknown()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.ConvertMessageToEnum("bogus");

            // Assert
            Assert.AreEqual(ItemLocationEnum.Unknown, result);
        }

        #endregion ConvertMessageToEnum

        #region GetListMessageCharacter
        [Test]
        public void GetListMessageCharacter_Valid_Default_Should_Return_List()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetListMessageCharacter;

            // Assert
            Assert.AreEqual(7, result.Count());
        }
        */
        #endregion GetListMessageCharacter
    }
}
