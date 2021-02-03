namespace Game.Models
{
    /// <summary>
    /// The player in the round for Monster
    /// </summary>
    public class SpecificMonsterTypeEnum
    {
        private SpecificMonsterTypeEnum(string value) { Value = value; }

        public string Value { get; set; }

        // <summary>
        /// Returns list of all monsters
        /// </summary>
        /// <returns></returns>
        public List<string> MonsterList()
        {
            var monsterList = new List<string>()
                {
                "Teaching Assistant",
                "Adjunct Faculty",
                "Assistant Professor",
                "Associate Professor",
                "Professor",
                "HR Administrator",
                "Registration Administrator",
                "Graduation Office Administrator"
                };
            return monsterList;
        }

        /// <summary>
        /// Returns list of all faculty
        /// </summary>
        /// <returns></returns>
        public List<string> FacultyList()
        {
            var facultyList = new List<string>()
                {
                 "Teaching Assistant",
                "Adjunct Faculty",
                "Assistant Professor",
                "Associate Professor",
                "Professor"
                };
            return facultyList;
        }

        /// <summary>
        /// Returns list of all parents
        /// </summary>
        /// <returns></returns>
        public List<string> ParentList()
        {
            var characterList = new List<string>()
                {
                "Helicopter Parent",
                "Cool Parent"
                };
            return characterList;
        }

        /// <summary>
        /// returns individual character type
        /// </summary>
        public static SpecificCharacterTypeEnum SmartyPants { get { return new SpecificCharacterTypeEnum("Smarty Pants"); } }
        public static SpecificCharacterTypeEnum Overachiever { get { return new SpecificCharacterTypeEnum("Overachiever"); } }
        public static SpecificCharacterTypeEnum InternationalStudent { get { return new SpecificCharacterTypeEnum("International Student"); } }
        public static SpecificCharacterTypeEnum Prodigy { get { return new SpecificCharacterTypeEnum("Prodigy"); } }
        public static SpecificCharacterTypeEnum SecondCareer { get { return new SpecificCharacterTypeEnum("Second Career"); } }
        public static SpecificCharacterTypeEnum Slacker { get { return new SpecificCharacterTypeEnum("Slacker"); } }
        public static SpecificCharacterTypeEnum Procrastinator { get { return new SpecificCharacterTypeEnum("Procrastinator"); } }
        public static SpecificCharacterTypeEnum HelicopterParent { get { return new SpecificCharacterTypeEnum("Helicopter Parent"); } }
        public static SpecificCharacterTypeEnum CoolParent { get { return new SpecificCharacterTypeEnum("Cool Parent"); } }

    }

    /// <summary>
    /// Helper for the Specific Character Type Enum Class
    /// </summary>
    public static class SpecificCharacterTypeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for SpecificCharacterTypeEnum
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecificCharacterTypeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for SpecificCharacterTypeEnum
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListCharacter
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecificCharacterTypeEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }


    }
}