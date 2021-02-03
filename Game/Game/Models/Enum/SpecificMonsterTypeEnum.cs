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
        public static SpecificCharacterTypeEnum TeachingAssistant { get { return new SpecificCharacterTypeEnum("Teaching Assistant"); } }
        public static SpecificCharacterTypeEnum AdjunctFaculty { get { return new SpecificCharacterTypeEnum("Adjunct Faculty"); } }
        public static SpecificCharacterTypeEnum AssistantProfessor { get { return new SpecificCharacterTypeEnum("Assistant Professor"); } }
        public static SpecificCharacterTypeEnum AssociateProfessor { get { return new SpecificCharacterTypeEnum("Associate Professor"); } }
        public static SpecificCharacterTypeEnum Professor { get { return new SpecificCharacterTypeEnum("Professor"); } }
        public static SpecificCharacterTypeEnum HRAdministrator { get { return new SpecificCharacterTypeEnum("HR Administrator"); } }
        public static SpecificCharacterTypeEnum RegistrationAdministrator { get { return new SpecificCharacterTypeEnum("Registration Administrator"); } }
        public static SpecificCharacterTypeEnum GraduationOfficeAdministrator { get { return new SpecificCharacterTypeEnum("Graduation Office Administrator"); } }

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