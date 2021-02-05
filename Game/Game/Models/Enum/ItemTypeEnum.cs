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
            var Message = "ItemType";

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

    }
}