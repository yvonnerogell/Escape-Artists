using NUnit.Framework;
using System.Collections.Generic;
using Game.Models;
using Game;


namespace UnitTests.Models.Enum
{
	[TestFixture]
	class ItemTypeEnumHelperTests
	{
        [Test]
        public void ItemTypeEnumHelperTests_GetListAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetListAll;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 14);
            Assert.Contains("Unknown", result);
            Assert.Contains("IndexCards", result);
            Assert.Contains("PencilEraser", result);
            Assert.Contains("Textbooks", result);
            Assert.Contains("Notebook", result);
            Assert.Contains("Calculator", result);
            Assert.Contains("LibraryCard", result);
            Assert.Contains("FoodCourtCard", result);
            Assert.Contains("Laptop", result);
            Assert.Contains("PrivateTutor", result);
            Assert.Contains("FinancialAid", result);
            Assert.Contains("Tuition", result);
            Assert.Contains("GraduationCapAndRobe", result);
            Assert.Contains("Diploma", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetListMessageAll_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetListMessageAll;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 14);
            Assert.Contains("Unknown", result);
            Assert.Contains("Index Cards", result);
            Assert.Contains("Pencil Eraser", result);
            Assert.Contains("Textbooks", result);
            Assert.Contains("Notebook", result);
            Assert.Contains("Calculator", result);
            Assert.Contains("Library Card", result);
            Assert.Contains("Food Court Card", result);
            Assert.Contains("Laptop", result);
            Assert.Contains("Private Tutor", result);
            Assert.Contains("Financial Aid", result);
            Assert.Contains("Tuition", result);
            Assert.Contains("Graduation Cap and Robe", result);
            Assert.Contains("Diploma", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetListMessageAllNoUnknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetListMessageAllNoUnknown;

            // Reset

            // Assert
            Assert.AreEqual(result.Count, 13);
            Assert.Contains("Index Cards", result);
            Assert.Contains("Pencil Eraser", result);
            Assert.Contains("Textbooks", result);
            Assert.Contains("Notebook", result);
            Assert.Contains("Calculator", result);
            Assert.Contains("Library Card", result);
            Assert.Contains("Food Court Card", result);
            Assert.Contains("Laptop", result);
            Assert.Contains("Private Tutor", result);
            Assert.Contains("Financial Aid", result);
            Assert.Contains("Tuition", result);
            Assert.Contains("Graduation Cap and Robe", result);
            Assert.Contains("Diploma", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Unknown, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_Calculator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("Calculator");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Calculator, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_Diploma_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("Diploma");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Diploma, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_FinancialAid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("FinancialAid");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.FinancialAid, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_FoodCourtCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("FoodCourtCard");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.FoodCourtCard, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("GraduationCapAndRobe");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.GraduationCapAndRobe, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_IndexCards_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("IndexCards");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.IndexCards, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_Laptop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("Laptop");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Laptop, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_LibraryCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("LibraryCard");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.LibraryCard, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_Notebook_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("Notebook");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Notebook, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_PencilEraser_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("PencilEraser");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.PencilEraser, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_PrivateTutor_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("PrivateTutor");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.PrivateTutor, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_Textbooks_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("Textbooks");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Textbooks, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertStringToEnum_Tuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertStringToEnum("Tuition");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Tuition, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Unknown");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Unknown, result);
        }


        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_BogusString_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("This doesn't exist");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Unknown, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_Calculator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Calculator");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Calculator, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_Diploma_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Diploma");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Diploma, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_FinancialAid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Financial Aid");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.FinancialAid, result);
        }


        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_FoodCourtCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Food Court Card");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.FoodCourtCard, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Graduation Cap and Robe");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.GraduationCapAndRobe, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_IndexCards_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Index Cards");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.IndexCards, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_Laptop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Laptop");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Laptop, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_LibraryCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Library Card");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.LibraryCard, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_Notebook_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Notebook");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Notebook, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_PencilEraser_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Pencil Eraser");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.PencilEraser, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_PrivateTutor_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Private Tutor");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.PrivateTutor, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_Textbooks_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Textbooks");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Textbooks, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_ConvertMessageStringToEnum_Tuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.ConvertMessageStringToEnum("Tuition");

            // Reset

            // Assert
            Assert.AreEqual(ItemTypeEnum.Tuition, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Unknown, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_Tuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.Tuition);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_Textbooks_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.Textbooks);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_PrivateTutor_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.PrivateTutor);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Necklace, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_PencilEraser_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.PencilEraser);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_Notebook_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.Notebook);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_LibraryCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.LibraryCard);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Necklace, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_Laptop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.Laptop);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.PrimaryHand, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_IndexCards_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.IndexCards);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.RightFinger, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.GraduationCapAndRobe);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Head, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_FoodCourtCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.FoodCourtCard);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.Necklace, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_FinancialAid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.FinancialAid);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.OffHand, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_Diploma_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.Diploma);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.OffHand, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetLocationFromItemType_Calculator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetLocationFromItemType(ItemTypeEnum.Calculator);

            // Reset

            // Assert
            Assert.AreEqual(ItemLocationEnum.LeftFinger, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_Tuition_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Masters Tuition");
            possibleValues.Add("Undergraduate Tuition");
            possibleValues.Add("Certificate Tuition");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.Tuition);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_Textbooks_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Math Textbooks");
            possibleValues.Add("English Textbooks");
            possibleValues.Add("Science Textbooks");
            possibleValues.Add("Chemistry Textbooks");
            possibleValues.Add("Art Textbooks");
            possibleValues.Add("Gym Textbooks");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.Textbooks);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_PrivateTutor_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Math Private Tutor");
            possibleValues.Add("English Private Tutor");
            possibleValues.Add("Science Private Tutor");
            possibleValues.Add("Chemistry Private Tutor");
            possibleValues.Add("Art Private Tutor");
            possibleValues.Add("Gym Private Tutor");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.PrivateTutor);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_PencilEraser_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Math Pencil Eraser");
            possibleValues.Add("English Pencil Eraser");
            possibleValues.Add("Science Pencil Eraser");
            possibleValues.Add("Chemistry Pencil Eraser");
            possibleValues.Add("Art Pencil Eraser");
            possibleValues.Add("Gym Pencil Eraser");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.PencilEraser);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_Notebook_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Math Notebook");
            possibleValues.Add("English Notebook");
            possibleValues.Add("Science Notebook");
            possibleValues.Add("Chemistry Notebook");
            possibleValues.Add("Art Notebook");
            possibleValues.Add("Gym Notebook");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.Notebook);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_LibraryCard_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Red Library Card");
            possibleValues.Add("White Library Card");
            possibleValues.Add("Blue Library Card");
            possibleValues.Add("Yellow Library Card");
            possibleValues.Add("Pink Library Card");
            possibleValues.Add("Green Library Card");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.LibraryCard);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }


        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_Laptop_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Mac Laptop");
            possibleValues.Add("Windows Laptop");
            possibleValues.Add("Chrome Laptop");
            possibleValues.Add("Asus Laptop");
            possibleValues.Add("Acer Laptop");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.Laptop);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_IndexCards_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Math Index Cards");
            possibleValues.Add("English Index Cards");
            possibleValues.Add("Science Index Cards");
            possibleValues.Add("Chemistry Index Cards");
            possibleValues.Add("Art Index Cards");
            possibleValues.Add("Gym Index Cards");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.IndexCards);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Masters Graduation Cap and Robe");
            possibleValues.Add("Undergraduate Graduation Cap and Robe");
            possibleValues.Add("Certificate Graduation Cap and Robe");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.GraduationCapAndRobe);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_FoodCourtCard_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Red Food Court Card");
            possibleValues.Add("White Food Court Card");
            possibleValues.Add("Blue Food Court Card");
            possibleValues.Add("Yellow Food Court Card");
            possibleValues.Add("Pink Food Court Card");
            possibleValues.Add("Green Food Court Card");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.FoodCourtCard);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_FinancialAid_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Masters Financial Aid");
            possibleValues.Add("Undergraduate Financial Aid");
            possibleValues.Add("Certificate Financial Aid");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.FinancialAid);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_Diploma_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Masters Diploma");
            possibleValues.Add("Undergraduate Diploma");
            possibleValues.Add("Certificate Diploma");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.Diploma);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getRandomeNameBasedOnType_Calculator_Should_Pass()
        {
            // Arrange
            List<string> possibleValues = new List<string>();
            possibleValues.Add("Red Calculator");
            possibleValues.Add("White Calculator");
            possibleValues.Add("Blue Calculator");
            possibleValues.Add("Yellow Calculator");
            possibleValues.Add("Pink Calculator");
            possibleValues.Add("Green Calculator");

            // Act
            var result = ItemTypeEnumHelper.getRandomeNameBasedOnType(ItemTypeEnum.Calculator);

            // Reset

            // Assert
            Assert.Contains(result, possibleValues);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_Tuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.Tuition);

            // Reset

            // Assert
            Assert.AreEqual("Pay your way through college.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_Textbooks_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.Textbooks);

            // Reset

            // Assert
            Assert.AreEqual("Reference course literature effectively.", result);
        }


        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_PrivateTutor_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.PrivateTutor);

            // Reset

            // Assert
            Assert.AreEqual("Get expert homework help.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_PencilEraser_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.PencilEraser);

            // Reset

            // Assert
            Assert.AreEqual("Forget about your mistakes.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_Notebook_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.Notebook);

            // Reset

            // Assert
            Assert.AreEqual("Keep track of the most crucial things to know.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_LibraryCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.LibraryCard);

            // Reset

            // Assert
            Assert.AreEqual("Get your textbooks for free.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_Laptop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.Laptop);

            // Reset

            // Assert
            Assert.AreEqual("Complete your assignments faster with a laptop.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_IndexCards_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.IndexCards);

            // Reset

            // Assert
            Assert.AreEqual("Memorize your homework.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.GraduationCapAndRobe);

            // Reset

            // Assert
            Assert.AreEqual("The cap will help you feel closer to graduation.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_FoodCourtCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.FoodCourtCard);

            // Reset

            // Assert
            Assert.AreEqual("Don’t run out of fuel." , result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_FinancialAid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.FinancialAid);

            // Reset

            // Assert
            Assert.AreEqual("Get some financial help.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_Diploma_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.Diploma);

            // Reset

            // Assert
            Assert.AreEqual("A diploma is the (almost) final step before graduation.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_getDescriptionBasedOnType_Calculator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.getDescriptionBasedOnType(ItemTypeEnum.Calculator);

            // Reset

            // Assert
            Assert.AreEqual("Avoid doing math in your head.", result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_IndexCards_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.IndexCards);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeIndexCardsImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_PencilEraser_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.PencilEraser);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypePencilEraserImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_Textbooks_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.Textbooks);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeTextbooksImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_Notebook_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.Notebook);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeNotebookImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_Calculator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.Calculator);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeCalculatorImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_LibraryCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.LibraryCard);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeLibraryCardImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_FoodCourtCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.FoodCourtCard);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeFoodCourtCardImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_Laptop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.Laptop);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeLaptopImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_PrivateTutor_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.PrivateTutor);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypePrivateTutorImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_FinancialAid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.FinancialAid);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeFinancialAidImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_Tuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.Tuition);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeTuitionImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.GraduationCapAndRobe);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeGraduationCapAndRobeImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_Diploma_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.Diploma);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeDiplomaImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetImageURIFromItemType_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetImageURIFromItemType(ItemTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(Constants.ItemTypeDefaultImageURI, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_IndexCards_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.IndexCards);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_PencilEraser_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.PencilEraser);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_Textbooks_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.Textbooks);

            // Reset

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_Notebook_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.Notebook);

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_Calculator_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.Calculator);

            // Reset

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_LibraryCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.LibraryCard);

            // Reset

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_FoodCourtCard_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.FoodCourtCard);

            // Reset

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_Laptop_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.Laptop);

            // Reset

            // Assert
            Assert.AreEqual(20, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_PrivateTutor_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.PrivateTutor);

            // Reset

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_FinancialAid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.FinancialAid);

            // Reset

            // Assert
            Assert.AreEqual(40, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_Tuition_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.Tuition);

            // Reset

            // Assert
            Assert.AreEqual(50, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_GraduationCapAndRobe_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.GraduationCapAndRobe);

            // Reset

            // Assert
            Assert.AreEqual(200, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_Diploma_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.Diploma);

            // Reset

            // Assert
            Assert.AreEqual(1000, result);
        }

        [Test]
        public void ItemTypeEnumHelperTests_GetDamageFromItemType_Unknown_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemTypeEnumHelper.GetDamageFromItemType(ItemTypeEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
