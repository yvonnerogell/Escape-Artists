using System.Collections.Generic;
using System;
using System.Linq;

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
        /// Returns list of all administrators
        /// </summary>
        /// <returns></returns>
        public List<string> AdministratorList()
        {
            var adminList = new List<string>()
                {
                "HR Administrator",
                "Registration Administrator",
                "Graduation Office Administrator"
                };
            return adminList;
        }

        /// <summary>
        /// returns individual monster type
        /// </summary>
        public static SpecificMonsterTypeEnum TeachingAssistant { get { return new SpecificMonsterTypeEnum("Teaching Assistant"); } }
        public static SpecificMonsterTypeEnum AdjunctFaculty { get { return new SpecificMonsterTypeEnum("Adjunct Faculty"); } }
        public static SpecificMonsterTypeEnum AssistantProfessor { get { return new SpecificMonsterTypeEnum("Assistant Professor"); } }
        public static SpecificMonsterTypeEnum AssociateProfessor { get { return new SpecificMonsterTypeEnum("Associate Professor"); } }
        public static SpecificMonsterTypeEnum Professor { get { return new SpecificMonsterTypeEnum("Professor"); } }
        public static SpecificMonsterTypeEnum HRAdministrator { get { return new SpecificMonsterTypeEnum("HR Administrator"); } }
        public static SpecificMonsterTypeEnum RegistrationAdministrator { get { return new SpecificMonsterTypeEnum("Registration Administrator"); } }
        public staticSpecificMonsterTypeEnum GraduationOfficeAdministrator { get { return new SpecificMonsterTypeEnum("Graduation Office Administrator"); } }

    }

    /// <summary>
    /// Helper for the Specific Monster Type Enum Class
    /// </summary>
    public static class SpecificMonsterTypeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for SpecificMonsterTypeEnum
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecificMonsterTypeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for SpecificCharacterTypeEnum
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListMonster
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecificMonsterTypeEnum)).ToList().Where(m => m.ToString().Equals("Unknown") == false).ToList();
                return myList;
            }
        }


    }
}