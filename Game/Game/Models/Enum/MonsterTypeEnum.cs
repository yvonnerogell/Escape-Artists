namespace Game.Models
{
    /// <summary>
    /// The player in the round for Monster
    /// </summary>
    public enum MonsterTypeEnum
    {
        // Not Known
        Unknown = 0,

        // Monster is of Faculty type
        Faculty = 20,

        // Monster is of administrator type
        Administrator = 21,
    }

    /// <summary>
    /// Enum helper for the Monster
    /// </summary>
    public static class MonsterTypeEnumHelper
    {
        /// <summary>
        /// Helper used get attack message
        /// </summary>
        public static string GetAttackMessage(MonsterTypeEnum attacker, CharacterTypeEnum target)
        {
            string msg = "";
            switch (attacker)
            {
                case  MonsterTypeEnum.Faculty:
                    switch (target)
                    {
                        case CharacterTypeEnum.Student:
                            msg = " gives an exam to ";
                            break;

                        case CharacterTypeEnum.Parent:
                            msg = " calls for parent-teacher conference with ";
                            break;
                    }
                    break;

                case MonsterTypeEnum.Administrator:
                    switch (target)
                    {
                        case CharacterTypeEnum.Student:
                            msg = " gives forms to fill out to ";
                            break;

                        case CharacterTypeEnum.Parent:
                            msg = " requests payment from ";
                            break;
                    }
                    break;

                default:
                    break;
            }
            return msg;
        }
    }
}