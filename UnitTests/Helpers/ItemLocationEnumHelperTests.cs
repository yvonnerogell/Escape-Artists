using NUnit.Framework;

using Game.Services;
using Game.Models;
using Game.Helpers;
using System;
using System.Linq;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class ItemLocationEnumHelperTests
    {

        [Test]
        public void ItemLocationEnumHelper_ItemLocationEnum_Valid_1Time_6sided_Should_Between_1_and_6()
        {
            // Arrange

            // Act
            var result = ItemLocationEnumHelper.GetListItem;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemLocationEnumHelper_GetListCharacter_Should_Pass()
        {
            // Arrange

            // Instantiate a new ItemLocation Base, should have default of 1 for all values
            var myDataList = ItemLocationEnumHelper.GetListCharacter;

            // Get Expected set
            var myList = Enum.GetNames(typeof(BodyPartEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                          a.ToString() != BodyPartEnum.Unknown.ToString() &&
                                           a.ToString() != BodyPartEnum.Finger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();

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
        public void ItemLocationEnumHelper_GetListItem_Should_Pass()
        {
            // Arrange

            // Instantiate a new ItemLocation Base, should have default of 1 for all values
            var myDataList = ItemLocationEnumHelper.GetListItem;

            // Get Expected set
            var myList = Enum.GetNames(typeof(BodyPartEnum)).ToList();
            var myExpectedList = myList.Where(a =>
                                            a.ToString() != BodyPartEnum.Unknown.ToString() &&
                                            a.ToString() != BodyPartEnum.LeftFinger.ToString() &&
                                            a.ToString() != BodyPartEnum.RightFinger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();

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
        public void ItemLocationEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(BodyPartEnum)).ToList();

            BodyPartEnum myActual;
            BodyPartEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = ItemLocationEnumHelper.ConvertStringToEnum(item);
                myExpected = (BodyPartEnum)Enum.Parse(typeof(BodyPartEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_1_Should_Pass()
        {
            // Arrange

            var value = 3;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = BodyPartEnum.PrimaryHand;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_2_Should_Pass()
        {
            // Arrange

            var value = 2;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = BodyPartEnum.Necklace;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_3_Should_Pass()
        {
            // Arrange

            var value = 3;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = BodyPartEnum.PrimaryHand;

            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_4_Should_Pass()
        {
            // Arrange

            var value = 4;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = BodyPartEnum.OffHand;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_5_Should_Pass()
        {
            // Arrange

            var value = 5;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = BodyPartEnum.RightFinger;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_6_Should_Pass()
        {
            // Arrange

            var value = 6;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = BodyPartEnum.LeftFinger;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void ItemLocationEnumHelper_GetLocationByPosition_7_Should_Pass()
        {
            // Arrange

            var value = 7;

            // Act
            var Actual = ItemLocationEnumHelper.GetLocationByPosition(value);
            var Expected = BodyPartEnum.Feet;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }
    }
}