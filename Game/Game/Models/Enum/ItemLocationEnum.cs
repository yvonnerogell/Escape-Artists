﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// Valid Locations to put things
    /// 
    /// Notice how Finger has Right and Left
    /// </summary>
    public enum ItemLocationEnum
    {
        // Not specified
        Unknown = 0,

        // The head includes, Hats, Helms, Caps, Crowns, Hair Ribbons, Bunny Ears, and anything else that sits on the head
        Head = 10,

        // Things to put around the neck, such as Necklace, broaches, scarfs, neck ribbons.  Can have at the same time with Head items ex. Ribbon for Hair, and Ribbon for Neck is OK to have
        Necklace = 12,

        // The primary hand used for fighting with a sword or a staff.  
        PrimaryHand = 20,

        // The second hand used for holding a shield or dagger, or wand.  OK to have both primary and offhand loaded at the same time
        OffHand = 22,

        // Any finger, used for rings, because they can go on any finger.
        Finger = 30,

        // A finger on the Right hand for rings.  Can only have one right on the right hand
        RightFinger = 31,

        // A finger on the left hand for rings.  Can only have one ring on the left hand.  Can have ring on left and right at the same time
        LeftFinger = 32,

        // Boots, shoes, socks or anything else on the feet
        Feet = 40,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class ItemLocationEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this ItemLocationEnum value)
        {
            // Default String
            var Message = "Unknown";

            switch (value)
            {
                case ItemLocationEnum.Head:
                    Message = "Head";
                    break;

                case ItemLocationEnum.Necklace:
                    Message = "Necklace";
                    break;

                case ItemLocationEnum.PrimaryHand:
                    Message = "Primary Hand";
                    break;

                case ItemLocationEnum.OffHand:
                    Message = "Off Hand";
                    break;

                case ItemLocationEnum.RightFinger:
                    Message = "Right Finger";
                    break;

                case ItemLocationEnum.LeftFinger:
                    Message = "Left Finger";
                    break;

                case ItemLocationEnum.Finger:
                    Message = "Any Finger";
                    break;

                case ItemLocationEnum.Feet:
                    Message = "Feet";
                    break;

                case ItemLocationEnum.Unknown:
                default:
                    break;
            }
            return Message;
        }
    }

    /// <summary>
    /// Helper for Item Locations
    /// </summary>
    public static class ItemLocationEnumHelper
    {
        /// <summary>
        /// Gets the list of locations that an Item can have.
        /// Does not include the Left and Right Finger 
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();
                var myReturn = myList.Where(a =>
                                            a.ToString() != ItemLocationEnum.Unknown.ToString() &&
                                            a.ToString() != ItemLocationEnum.LeftFinger.ToString() &&
                                            a.ToString() != ItemLocationEnum.RightFinger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();
                return myReturn;
            }
        }

        /// <summary>
        ///  Gets the list of locations a character can use
        ///  Removes Finger for example, and allows for left and right finger
        /// </summary>
        public static List<string> GetListCharacter
        {
            get
            {
                var myList = Enum.GetNames(typeof(ItemLocationEnum)).ToList();
                var myReturn = myList.Where(a =>
                                           a.ToString() != ItemLocationEnum.Unknown.ToString() &&
                                            a.ToString() != ItemLocationEnum.Finger.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();

                return myReturn;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ItemLocationEnum ConvertStringToEnum(string value)
        {
            return (ItemLocationEnum)Enum.Parse(typeof(ItemLocationEnum), value);
        }

        /// <summary>
        /// If asked for a position number, return a location.  Head as 1 etc. 
        /// This compsenstates for the enum #s not being sequential, but allows for calls to the postion for random allocation etc (roll 1-7 dice and pick a item to equipt), etc... 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static ItemLocationEnum GetLocationByPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return ItemLocationEnum.Head;

                case 2:
                    return ItemLocationEnum.Necklace;

                case 3:
                    return ItemLocationEnum.PrimaryHand;

                case 4:
                    return ItemLocationEnum.OffHand;

                case 5:
                    return ItemLocationEnum.RightFinger;

                case 6:
                    return ItemLocationEnum.LeftFinger;

                case 7:
                default:
                    return ItemLocationEnum.Feet;
            }
        }

        /// <summary>
        /// Returns the ItemLocationEnum associated with the ItemType.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<ItemTypeEnum> GetItemFromLocationType(ItemLocationEnum location)
        {
            List<ItemTypeEnum> items = new List<ItemTypeEnum>();
            switch (location)
            {
                case ItemLocationEnum.Head:
                    items.Add(ItemTypeEnum.GraduationCapAndRobe);
                    break;
                case ItemLocationEnum.Necklace:
                    items.Add(ItemTypeEnum.LibraryCard);
                    items.Add(ItemTypeEnum.FoodCourtCard);
                    items.Add(ItemTypeEnum.PrivateTutor);
                    break;
                case ItemLocationEnum.PrimaryHand:
                    items.Add(ItemTypeEnum.PencilEraser);
                    items.Add(ItemTypeEnum.Textbooks);
                    items.Add(ItemTypeEnum.Notebook);
                    items.Add(ItemTypeEnum.Laptop);
                    items.Add(ItemTypeEnum.Tuition);
                    break;
                case ItemLocationEnum.OffHand:
                    items.Add(ItemTypeEnum.FinancialAid);
                    break;
                case ItemLocationEnum.RightFinger:
                    items.Add(ItemTypeEnum.IndexCards);
                    break;
                case ItemLocationEnum.LeftFinger:
                    items.Add(ItemTypeEnum.Calculator);
                    break;
                case ItemLocationEnum.Feet:
                    items.Add(ItemTypeEnum.Skateboard);
                    break;
            }

            return items;
        }
    }
}