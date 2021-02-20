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

        #region LegacyEnumValues
        /*
            Leave legacy enums in for now.
         */

        // General Abilities 10 Range
        // Heal Self
        Bandage = 10,

        // Fighter Abilities > 20 Range
        // Buff Speed
        Nimble = 21,

        // Buff Defense
        Toughness = 22,

        // Buff Attack
        Focus = 23,

        // Cleric Abilities > 50 Range
        // Buff Speed
        Quick = 51,

        // Buff Defense
        Barrier = 52,

        // Buff Attack
        Curse = 53,

        // Heal Self
        Heal = 54,
        #endregion LegacyEnumValues

        /*
            Add your enums here starting at 100 
        */

        // Student can get extra credit
        ExtraCredit = 110,

        // Student can get an extension
        Extension = 121,

        //Student can get a flash of genius
        FlashGenius = 122,

        // Parent can give bribes
        Bribes = 123,

        // Parent can pay tuition
        PayTuition = 151,
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
            var Message = "Unknown";

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
                    Message = "None";
                    break;

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
        /// Returns a list of strings of the enum of not Cleric or Fighter
        /// </summary>
        public static List<string> GetListOthers
        {
            get
            {

                List<string> AbilityList = new List<string>{
                AbilityEnum.Bandage.ToString(),
                };

                return AbilityList;
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


        /// <summary>
        /// Given the Full String for an enum, return its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AbilityEnum ConvertMessageStringToEnum(string value)
        {
            foreach (AbilityEnum item in Enum.GetValues(typeof(AbilityEnum)))
            {
                if (item.ToMessage().Equals(value))
                {
                    return item;
                }
            }
            return AbilityEnum.Unknown;
        }
    }
}