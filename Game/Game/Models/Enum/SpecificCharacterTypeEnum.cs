using System.Collections.Generic;
using System;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The specific Character enum type.  
    /// </summary>
    public enum SpecificCharacterTypeEnum
    {
        // Not specified
        Unknown = 0,

        // Smarty pants is smart, has special ability and extra Head item location
        SmartyPants = 10,

        // Overacheiver works hard and extra Head and Necklace item location
        Overachiever = 15,

        // International Student is multi-cultured, has special ability and extra Head item location
        InternationalStudent = 20,

        // Prodigy Student is smart, has special ability and extra Head item location
        Prodigy = 25,

        // Second Career has real life experience, has special ability and Head and Necklace item location.
        SecondCareer = 30,

        // Slacker likes to chill and has extra Head and Necklace item location
        Slacker = 35,

        // Procrastinator likes to wait, has special ability and extra Head item location
        Procrastinator = 40,

        // Helicopter Parent likes to control and has special ability
        HelicopterParent = 45,

        // Cool Parent likes to relax and has special ability
        CoolParent = 50
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class SpecificCharacterTypeEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this SpecificCharacterTypeEnum value)
        {
            // Default String
            var Message = "PlayerType";

            switch (value)
            {

                case SpecificCharacterTypeEnum.SmartyPants:
                    Message = "SmartyPants";
                    break;

                case SpecificCharacterTypeEnum.Overachiever:
                    Message = "Overachiever";
                    break;

                case SpecificCharacterTypeEnum.InternationalStudent:
                    Message = "International Student";
                    break;

                case SpecificCharacterTypeEnum.Prodigy:
                    Message = "Prodigy";
                    break;

                case SpecificCharacterTypeEnum.SecondCareer:
                    Message = "Second Career";
                    break;

                case SpecificCharacterTypeEnum.Slacker:
                    Message = "Slacker";
                    break;

                case SpecificCharacterTypeEnum.Procrastinator:
                    Message = "Procrastinator";
                    break;

                case SpecificCharacterTypeEnum.HelicopterParent:
                    Message = "Helicopter Parent";
                    break;

                case SpecificCharacterTypeEnum.CoolParent:
                    Message = "Cool Parent";
                    break;

                case SpecificCharacterTypeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Enum Class
    /// </summary>
    public static class SpecificCharacterTypeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for SpecificCharacterType
        /// </summary>
        public static List<string> GetListAll
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecificCharacterTypeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Full strings of the enum for SpecificCharacterType
        /// </summary>
        public static List<string> GetListMessageAll
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(SpecificCharacterTypeEnum)))
                {
                    list.Add(((SpecificCharacterTypeEnum)item).ToMessage());
                }
                return list;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SpecificCharacterTypeEnum ConvertStringToEnum(string value)
        {
            return (SpecificCharacterTypeEnum)Enum.Parse(typeof(SpecificCharacterTypeEnum), value);
        }

        /// <summary>
        /// Given the Full String for an enum, return its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SpecificCharacterTypeEnum ConvertMessageStringToEnum(string value)
        {
            foreach (SpecificCharacterTypeEnum item in Enum.GetValues(typeof(SpecificCharacterTypeEnum)))
            {
                if (item.ToMessage().Equals(value))
                {
                    return item;
                }
            }
            return SpecificCharacterTypeEnum.Unknown;
        }
    }

}