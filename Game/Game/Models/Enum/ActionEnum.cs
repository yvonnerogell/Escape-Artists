﻿namespace Game.Models
{
    /// <summary>
    /// The Types of s a Action can have
    /// Used in Action Crudi, and in Battles.
    /// </summary>
    public enum ActionEnum
    {
        // Not specified  - has to be -1 to make it compatible with pickers
        Unknown = -1,

        // Ability
        Ability = 1,

        // Attack
        Attack = 2,

        // Move
        Move = 3,

        // Rest
        Rest = 4,

        // Slip
        Slip = 5,

        // Special ability
        SpecialAbility = 10,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class ActionEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this ActionEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case ActionEnum.Attack:
                    Message = " Attacks ";
                    break;

                case ActionEnum.Move:
                    Message = " Moves ";
                    break;

                case ActionEnum.Ability:
                    Message = " Uses Ability ";
                    break;

                case ActionEnum.Rest:
                    Message = " Rests ";
                    break;

                case ActionEnum.Slip:
                    Message = " Slips ";
                    break;

                case ActionEnum.SpecialAbility:
                    Message = " Special Ability ";
                    break;

                case ActionEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToImageURI(this ActionEnum value)
        {
            // Default String
            var Message = "item.png";

            switch (value)
            {
                case ActionEnum.Attack:
                    Message = "item.png";
                    break;

                case ActionEnum.Move:
                    Message = "item.png";
                    break;

                case ActionEnum.Ability:
                    Message = "item.png";
                    break;

                case ActionEnum.Rest:
                    Message = "item.png";
                    break;

                case ActionEnum.Slip:
                    Message = "item.png";
                    break;

                case ActionEnum.SpecialAbility:
                    Message = "item.png";
                    break;

                case ActionEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}