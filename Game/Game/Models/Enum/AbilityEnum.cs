using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of an Ability a character can have
    /// Used in Ability Crudi, and in Battles.
    /// </summary>
    public enum AbilityEnum
    {
        // Not specified
        Unknown = 0,

        // Not specified
        None = 1,
     
        // Student can get extra credit
        ExtraCredit = 10,

        // Student can get an extension
        Extension = 21,

        //Student can get a flash of genius
        FlashGenius = 22,

        // Parent can give bribes
        Bribes = 23,

        // Parent can pay tuition
        PayTuition = 51,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class AbilityEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this AbilityEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case AbilityEnum.ExtraCredit:
                    Message = "Extra credit";
                    break;

                case AbilityEnum.Extension:
                    Message = "Extension";
                    break;

                case AbilityEnum.FlashGenius:
                    Message = "Flash of genius";
                    break;

                case AbilityEnum.Bribes:
                    Message = "Bribes";
                    break;

                case AbilityEnum.PayTuition:
                    Message = "Pay tuition";
                    break;

                case AbilityEnum.None:
                case AbilityEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Ability Enum Class
    /// </summary>
    public static class AbilityEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Ability
        /// Removes the Abilitys that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetFullAbilityEnumList
        {
            get
            {
                var myList = Enum.GetNames(typeof(AbilityEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Full strings of the enum for AbilityEnum
        /// </summary>
        public static List<string> GetListMessageAll
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(AbilityEnum)))
                {
                    list.Add(((AbilityEnum)item).ToMessage());
                }
                return list;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AbilityEnum ConvertStringToEnum(string value)
        {
            return (AbilityEnum)Enum.Parse(typeof(AbilityEnum), value);
        }
    }
}