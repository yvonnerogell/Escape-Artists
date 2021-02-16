using System.Collections.Generic;
using System;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The specific Item enum type.  
    /// </summary>
    public enum ItemTypeEnum
    {
        // Not specified
        Unknown = 0,

        // Memorize your homework.
        IndexCards = 5,

        // Forget about your mistakes.
        PencilEraser = 10,

        // Reference course literature effectively.
        Textbooks = 15,

        // Keep track of the most crucial things to know.
        Notebook = 20,

        // Avoid doing math in your head. 
        Calculator = 25, 

        // Get your textbooks for free.
        LibraryCard = 30, 

        // Don't run out of fuel. 
        FoodCourtCard = 35, 

        // Complete your assignments faster with a laptop. 
        Laptop = 40, 

        // Get expert homework help. 
        PrivateTutor = 45, 

        // Get some financial help.
        FinancialAid = 50, 

        // Pay your way through college. 
        Tuition = 55, 

        // The cap will help you feel closer to graduation!
        GraduationCapAndRobe = 60,

        // A diploma is the (almost) final step before graduation.
        Diploma = 65
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class ItemTypeEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this ItemTypeEnum value)
        {
            // Default String
            var Message = "Unknown";

            switch (value)
            {

                case ItemTypeEnum.IndexCards:
                    Message = "Index Cards";
                    break;
                
                case ItemTypeEnum.PencilEraser:
                    Message = "Pencil Eraser";
                    break;

                case ItemTypeEnum.Textbooks:
                    Message = "Textbooks";
                    break;

                case ItemTypeEnum.Notebook:
                    Message = "Notebook";
                    break;

                case ItemTypeEnum.Calculator:
                    Message = "Calculator";
                    break;

                case ItemTypeEnum.LibraryCard:
                    Message = "Library Card";
                    break;

                case ItemTypeEnum.FoodCourtCard:
                    Message = "Food Court Card";
                    break;

                case ItemTypeEnum.Laptop:
                    Message = "Laptop";
                    break;

                case ItemTypeEnum.PrivateTutor:
                    Message = "Private Tutor";
                    break;

                case ItemTypeEnum.FinancialAid:
                    Message = "Financial Aid";
                    break;

                case ItemTypeEnum.Tuition:
                    Message = "Tuition";
                    break;

                case ItemTypeEnum.GraduationCapAndRobe:
                    Message = "Graduation Cap and Robe";
                    break;

                case ItemTypeEnum.Diploma:
                    Message = "Diploma";
                    break;

                case ItemTypeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Enum Class
    /// </summary>
    public static class ItemTypeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for ItemTypeEnum
        /// </summary>
        public static List<string> GetListAll
        {
            get
            {
                var myList = Enum.GetNames(typeof(ItemTypeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Full strings of the enum for ItemTypeEnum
        /// </summary>
        public static List<string> GetListMessageAll
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(ItemTypeEnum)))
                {
                    list.Add(((ItemTypeEnum)item).ToMessage());
                }
                return list;
            }
        }

        /// <summary>
        /// Returns a list of Full strings of the enum for ItemTypeEnum
        /// </summary>
        public static List<string> GetListMessageAllNoUnknown
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(ItemTypeEnum)))
                {
                    list.Add(((ItemTypeEnum)item).ToMessage());
                }
                list.Remove(ItemTypeEnum.Unknown.ToMessage());
                return list;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ItemTypeEnum ConvertStringToEnum(string value)
        {
            return (ItemTypeEnum)Enum.Parse(typeof(ItemTypeEnum), value);
        }

        /// <summary>
        /// Given the Full String for an enum, return its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ItemTypeEnum ConvertMessageStringToEnum(string value)
        {
            foreach (ItemTypeEnum item in Enum.GetValues(typeof(ItemTypeEnum)))
            {
                if (item.ToMessage().Equals(value))
                {
                    return item;
                }
            }
            return ItemTypeEnum.Unknown;
        }

        /// <summary>
        /// Returns the ItemLocationEnum associated with the ItemType.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ItemLocationEnum GetLocationFromItemType(ItemTypeEnum itemType)
        {
            ItemLocationEnum itemLocation = ItemLocationEnum.Unknown;
            switch (itemType)
			{
                case ItemTypeEnum.Tuition:
                    itemLocation = ItemLocationEnum.PrimaryHand;
                    break;
                case ItemTypeEnum.Textbooks:
                    itemLocation = ItemLocationEnum.PrimaryHand;
                    break;
                case ItemTypeEnum.PrivateTutor:
                    itemLocation = ItemLocationEnum.Necklace;
                    break;
                case ItemTypeEnum.PencilEraser:
                    itemLocation = ItemLocationEnum.PrimaryHand;
                    break;
                case ItemTypeEnum.Notebook:
                    itemLocation = ItemLocationEnum.PrimaryHand;
                    break;
                case ItemTypeEnum.LibraryCard:
                    itemLocation = ItemLocationEnum.Necklace;
                    break;
                case ItemTypeEnum.Laptop:
                    itemLocation = ItemLocationEnum.PrimaryHand;
                    break;
                case ItemTypeEnum.IndexCards:
                    itemLocation = ItemLocationEnum.RightFinger;
                    break;
                case ItemTypeEnum.GraduationCapAndRobe:
                    itemLocation = ItemLocationEnum.Head;
                    break;
                case ItemTypeEnum.FoodCourtCard:
                    itemLocation = ItemLocationEnum.Necklace;
                    break;
                case ItemTypeEnum.FinancialAid:
                    itemLocation = ItemLocationEnum.OffHand;
                    break;
                case ItemTypeEnum.Diploma:
                    itemLocation = ItemLocationEnum.OffHand;
                    break;
                case ItemTypeEnum.Calculator:
                    itemLocation = ItemLocationEnum.LeftFinger;
                    break;
			}

            return itemLocation;
        }

        /// <summary>
        /// generate random name based on item type
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public static String getRandomeNameBasedOnType(ItemTypeEnum itemType)
        {
            // Fun item names
            List<string> possibleNames = new List<string>();
            switch (itemType)
            
            {
                case ItemTypeEnum.Tuition:
                    possibleNames.Add("Masters ");
                    possibleNames.Add("Undergraduate");
                    possibleNames.Add("Certificate");
                    break;
                case ItemTypeEnum.Textbooks:
                    possibleNames.Add("Math");
                    possibleNames.Add("English");
                    possibleNames.Add("Science");
                    possibleNames.Add("Chemistry");
                    possibleNames.Add("Art");
                    possibleNames.Add("Gym");
                    break;
                case ItemTypeEnum.PrivateTutor:
                    possibleNames.Add("Math");
                    possibleNames.Add("English");
                    possibleNames.Add("Science");
                    possibleNames.Add("Chemistry");
                    possibleNames.Add("Art");
                    possibleNames.Add("Gym");
                    break;
                case ItemTypeEnum.PencilEraser:
                    possibleNames.Add("Math");
                    possibleNames.Add("English");
                    possibleNames.Add("Science");
                    possibleNames.Add("Chemistry");
                    possibleNames.Add("Art");
                    possibleNames.Add("Gym");
                    break;
                case ItemTypeEnum.Notebook:
                    possibleNames.Add("Math");
                    possibleNames.Add("English");
                    possibleNames.Add("Science");
                    possibleNames.Add("Chemistry");
                    possibleNames.Add("Art");
                    possibleNames.Add("Gym");
                    break;
                case ItemTypeEnum.LibraryCard:
                    possibleNames.Add("Red");
                    possibleNames.Add("White");
                    possibleNames.Add("Blue");
                    possibleNames.Add("Yellow");
                    possibleNames.Add("Pink");
                    possibleNames.Add("Green");
                    break;
                case ItemTypeEnum.Laptop:
                    possibleNames.Add("Mac");
                    possibleNames.Add("Windows");
                    possibleNames.Add("Chrome");
                    possibleNames.Add("Asus");
                    possibleNames.Add("Acer");
                    break;
                case ItemTypeEnum.IndexCards:
                    possibleNames.Add("Math");
                    possibleNames.Add("English");
                    possibleNames.Add("Science");
                    possibleNames.Add("Chemistry");
                    possibleNames.Add("Art");
                    possibleNames.Add("Gym");
                    break;
                case ItemTypeEnum.GraduationCapAndRobe:
                    possibleNames.Add("Masters");
                    possibleNames.Add("Undergraduate");
                    possibleNames.Add("Certificate");
                    break;
                case ItemTypeEnum.FoodCourtCard:
                    possibleNames.Add("Red");
                    possibleNames.Add("White");
                    possibleNames.Add("Blue");
                    possibleNames.Add("Yellow");
                    possibleNames.Add("Pink");
                    possibleNames.Add("Green");
                    break;
                case ItemTypeEnum.FinancialAid:
                    possibleNames.Add("Masters");
                    possibleNames.Add("Undergraduate");
                    possibleNames.Add("Certificate");
                    break;
                case ItemTypeEnum.Diploma:
                    possibleNames.Add("Masters");
                    possibleNames.Add("Undergraduate");
                    possibleNames.Add("Certificate");
                    break;
                case ItemTypeEnum.Calculator:
                    possibleNames.Add("Red");
                    possibleNames.Add("White");
                    possibleNames.Add("Blue");
                    possibleNames.Add("Yellow");
                    possibleNames.Add("Pink");
                    possibleNames.Add("Green");
                    break;
            }

            // get length of list
            var listLength = possibleNames.Count();

            // get random number between 0 to listLength (not including listLength)
            Random r = new Random();
            int rInt = r.Next(0, listLength);

            // return the name at index rInt of the names
            return possibleNames.ElementAt(rInt) + " " + itemType.ToMessage();
        }

        /// <summary>
        /// generate random description based on item type
        /// </summary>
        /// <param name="itemType"></param>
        /// <returns></returns>
        public static string getDescriptionBasedOnType(ItemTypeEnum itemType)
        {
            string descriptions = null;
            
            switch (itemType)
            {
                case ItemTypeEnum.Tuition:
                    descriptions = "Pay your way through college.";
                    break;
                case ItemTypeEnum.Textbooks:
                    descriptions = "Reference course literature effectively.";
                    break;
                case ItemTypeEnum.PrivateTutor:
                    descriptions = "Get expert homework help.";
                    break;
                case ItemTypeEnum.PencilEraser:
                    descriptions = "Forget about your mistakes.";
                    break;
                case ItemTypeEnum.Notebook:
                    descriptions = "Keep track of the most crucial things to know.";
                    break;
                case ItemTypeEnum.LibraryCard:
                    descriptions = "Get your textbooks for free.";
                    break;
                case ItemTypeEnum.Laptop:
                    descriptions = "Complete your assignments faster with a laptop.";
                    break;
                case ItemTypeEnum.IndexCards:
                    descriptions = "Memorize your homework.";
                    break;
                case ItemTypeEnum.GraduationCapAndRobe:
                    descriptions = "The cap will help you feel closer to graduation.";
                    break;
                case ItemTypeEnum.FoodCourtCard:
                    descriptions = "Don’t run out of fuel.";
                    break;
                case ItemTypeEnum.FinancialAid:
                    descriptions = "Get some financial help.";
                    break;
                case ItemTypeEnum.Diploma:
                    descriptions = "A diploma is the (almost) final step before graduation.";
                    break;
                case ItemTypeEnum.Calculator:
                    descriptions = "Avoid doing math in your head.";
                    break;
            }

            return descriptions;
        }

        /// <summary>
        /// Given the itemType, return the image URI. 
        /// </summary>
        /// <param name="newData">Character to update</param>
        public static string GetImageURIFromItemType(ItemTypeEnum itemType)
        {
            string ImageURI = null;
            switch (itemType)
            {
                case ItemTypeEnum.IndexCards:
                    ImageURI = Constants.ItemTypeIndexCardsImageURI;
                    break;

                case ItemTypeEnum.PencilEraser:
                    ImageURI = Constants.ItemTypePencilEraserImageURI;
                    break;

                case ItemTypeEnum.Textbooks:
                    ImageURI = Constants.ItemTypeTextbooksImageURI;
                    break;

                case ItemTypeEnum.Notebook:
                    ImageURI = Constants.ItemTypeNotebookImageURI;
                    break;

                case ItemTypeEnum.Calculator:
                    ImageURI = Constants.ItemTypeCalculatorImageURI;
                    break;

                case ItemTypeEnum.LibraryCard:
                    ImageURI = Constants.ItemTypeLibraryCardImageURI;
                    break;

                case ItemTypeEnum.FoodCourtCard:
                    ImageURI = Constants.ItemTypeFoodCourtCardImageURI;
                    break;

                case ItemTypeEnum.Laptop:
                    ImageURI = Constants.ItemTypeLaptopImageURI;
                    break;

                case ItemTypeEnum.PrivateTutor:
                    ImageURI = Constants.ItemTypePrivateTutorImageURI;
                    break;

                case ItemTypeEnum.FinancialAid:
                    ImageURI = Constants.ItemTypeFinancialAidImageURI;
                    break;

                case ItemTypeEnum.Tuition:
                    ImageURI = Constants.ItemTypeTuitionImageURI;
                    break;

                case ItemTypeEnum.GraduationCapAndRobe:
                    ImageURI = Constants.ItemTypeGraduationCapAndRobeImageURI;
                    break;

                case ItemTypeEnum.Diploma:
                    ImageURI = Constants.ItemTypeDiplomaImageURI;
                    break;

                case ItemTypeEnum.Unknown:
                default:
                    ImageURI = Constants.ItemTypeDefaultImageURI;
                    break;
            }

            return ImageURI;
        }

        /// <summary>
        /// Given the itemType, return the damage. 
        /// </summary>
        /// <param name="newData">Character to update</param>
        public static int GetDamageFromItemType(ItemTypeEnum itemType)
        {
            int Damage = 0;
            switch (itemType)
            {
                case ItemTypeEnum.IndexCards:
                    Damage = 2;
                    break;

                case ItemTypeEnum.PencilEraser:
                    Damage = 1;
                    break;

                case ItemTypeEnum.Textbooks:
                    Damage = 10;
                    break;

                case ItemTypeEnum.Notebook:
                    Damage = 2;
                    break;

                case ItemTypeEnum.Calculator:
                    Damage = 5;
                    break;

                case ItemTypeEnum.LibraryCard:
                    Damage = 3;
                    break;

                case ItemTypeEnum.FoodCourtCard:
                    Damage = 5;
                    break;

                case ItemTypeEnum.Laptop:
                    Damage = 20;
                    break;

                case ItemTypeEnum.PrivateTutor:
                    Damage = 10;
                    break;

                case ItemTypeEnum.FinancialAid:
                    Damage = 40;
                    break;

                case ItemTypeEnum.Tuition:
                    Damage = 50;
                    break;

                case ItemTypeEnum.GraduationCapAndRobe:
                    Damage = 200;
                    break;

                case ItemTypeEnum.Diploma:
                    Damage = 1000;
                    break;

                case ItemTypeEnum.Unknown:
                default:
                    Damage = 0;
                    break;
            }

            return Damage;
        }
    }
}