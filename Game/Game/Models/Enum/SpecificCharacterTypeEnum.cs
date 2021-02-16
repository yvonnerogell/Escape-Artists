﻿using System.Collections.Generic;
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

        //The following are Student type 
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

        //The following are Parent type 

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
            var Message = "Unknown";

            switch (value)
            {

                case SpecificCharacterTypeEnum.SmartyPants:
                    Message = "Smarty Pants";
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
        /// Returns a list of all the friendly strings of the SpecificCharacterTypeEnum, except the Unknown enum.
        /// </summary>
        public static List<string> GetListMessageAllNoUnknown
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(SpecificCharacterTypeEnum)))
                {
                    list.Add(((SpecificCharacterTypeEnum)item).ToMessage());
                }
                list.Remove(SpecificCharacterTypeEnum.Unknown.ToString());
                return list;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Student SpecificCharacterType
        /// </summary>
        public static List<string> GetStudentList
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecificCharacterTypeEnum)).ToList();
                myList.Remove("CoolParent");
                myList.Remove("HelicopterParent");
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Full strings of the enum for SpecificCharacterType
        /// </summary>
        public static List<string> GetStudentListMessage
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(SpecificCharacterTypeEnum)))
                {
                    list.Add(((SpecificCharacterTypeEnum)item).ToMessage());
                }
                list.Remove("Cool Parent");
                list.Remove("Helicopter Parent");
                return list;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Parent SpecificCharacterType
        /// </summary>
        public static List<string> GetParentList
        {
            get
            {
                var myList = new List<string>();
                myList.Add("CoolParent");
                myList.Add("HelicopterParent");
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Full strings of the enum for Parent SpecificCharacterType
        /// </summary>
        public static List<string> GetParentListMessage
        {
            get
            {
                var list = new List<string>();
                list.Add("Cool Parent");
                list.Add("Helicopter Parent");
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

        /// <summary>
        /// Given a SpecificCharacterTypeEnum, returns the corresponding CharacterTypeEnum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CharacterTypeEnum GetCharacterTypeEnumFromSpecificCharacterTypeEnum(SpecificCharacterTypeEnum specificCharacterType)
        {
            var result = CharacterTypeEnum.Unknown;
            switch (specificCharacterType)
            {
                case SpecificCharacterTypeEnum.CoolParent:
                case SpecificCharacterTypeEnum.HelicopterParent:
                    result = CharacterTypeEnum.Parent;
                    break;
                case SpecificCharacterTypeEnum.InternationalStudent:
                case SpecificCharacterTypeEnum.Overachiever:
                case SpecificCharacterTypeEnum.Procrastinator:
                case SpecificCharacterTypeEnum.Prodigy:
                case SpecificCharacterTypeEnum.SecondCareer:
                case SpecificCharacterTypeEnum.Slacker:
                case SpecificCharacterTypeEnum.SmartyPants:
                    result = CharacterTypeEnum.Student;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Returns the ability enum associated with the indicated SpecificCharacterType.
        /// </summary>
        /// <param name="specificCharacterType">SpecificCharacterType used to extract ability enum</param>
        /// <returns>Ability Enum associated with specified SpecificCharacterType</returns>
        public static AbilityEnum ToAbility(SpecificCharacterTypeEnum specificCharacterType)
        {
            var abilityEnum = AbilityEnum.Unknown;
            switch (specificCharacterType)
            {
                case SpecificCharacterTypeEnum.SmartyPants:
                    abilityEnum = AbilityEnum.ExtraCredit;
                    break;
                case SpecificCharacterTypeEnum.Slacker:
                    abilityEnum = AbilityEnum.Extension;
                    break;
                case SpecificCharacterTypeEnum.SecondCareer:
                    abilityEnum = AbilityEnum.Extension;
                    break;
                case SpecificCharacterTypeEnum.Prodigy:
                    abilityEnum = AbilityEnum.ExtraCredit;
                    break;
                case SpecificCharacterTypeEnum.Procrastinator:
                    abilityEnum = AbilityEnum.Extension;
                    break;
                case SpecificCharacterTypeEnum.Overachiever:
                    abilityEnum = AbilityEnum.FlashGenius;
                    break;
                case SpecificCharacterTypeEnum.InternationalStudent:
                    abilityEnum = AbilityEnum.FlashGenius;
                    break;
                case SpecificCharacterTypeEnum.HelicopterParent:
                    abilityEnum = AbilityEnum.Bribes;
                    break;
                case SpecificCharacterTypeEnum.CoolParent:
                    abilityEnum = AbilityEnum.PayTuition;
                    break;
                default:
                    abilityEnum = AbilityEnum.Unknown;
                    break;
            }
            return abilityEnum;
        }
    }
}