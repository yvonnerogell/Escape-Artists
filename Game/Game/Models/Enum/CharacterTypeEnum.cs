namespace Game.Models
{
    /// <summary>
    /// The player in the round, Monster or Character
    /// </summary>
    public enum CharacterTypeEnum
    {
        // Not Known
        Unknown = 0,

        // Character is of student type
        Student = 10,

        // Character is of parent type
        Parent = 11,
    }

    /// <summary>
    /// Helper for the Monster or Character
    /// </summary>
    public static class CharacterTypeEnumHelper
    {
        /// <summary>
        /// Helper used get msg
        /// </summary>
        public static string getAttackMessage(CharacterTypeEnum attacker, MonsterTypeEnum target)
        {
            string msg = "";
            switch (attacker)
            {
                case CharacterTypeEnum.Student:
                    switch (target)
                    {
                        case MonsterTypeEnum.Faculty:
                            msg = " pass an exam from ";
                            break;

                        case MonsterTypeEnum.Administrator:
                            msg = " finished the paper work from ";
                            break;
                    }
                    break;

                case CharacterTypeEnum.Parent:
                    switch (target)
                    {
                        case MonsterTypeEnum.Faculty:
                            msg = " puts pressure to make exam easier on ";
                            break;

                        case MonsterTypeEnum.Administrator:
                            msg = " complain about time needed to process paperwork from ";
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