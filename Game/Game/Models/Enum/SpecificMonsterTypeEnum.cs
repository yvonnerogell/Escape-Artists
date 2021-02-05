using System.Collections.Generic;
using System;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The specific Monster Enums
    /// </summary>
    public enum SpecificMonsterTypeEnum
    {
        // not specified
        Unknown = 0,

        // Teaching assistant drops Index cards
        TeachingAssistant = 10,

        // Adjunct faculty has no unique drop item
        AdjunctFaculty = 20,

        // Assistant professor drops a laptop after a good fight
        AssistantProfessor = 30,

        // Associate professor is surprisingly not that rich, and drops textbooks
        AssociateProfessor = 40,

        // Professor lives and dies without dropping any item
        Professor = 50,

        // HR Administrator drops... financial aid!
        HRAdministrator = 60, 

        // Registration administrator is not one for dropping anything
        RegistrationAdministrator = 70,

        // Graduation office administrator drops cap and robe
        GraduationOfficeAdministrator = 80
    }

    public static class SpecificMonsterTypeEnumExtensions
    {
        /// <summary>
        /// Presents Monster Enums in string format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this SpecificMonsterTypeEnum value)
        {
            // Default String
            var Message = "PlayerType";

            switch (value)
            {

                case SpecificMonsterTypeEnum.TeachingAssistant:
                    Message = "Teaching Assistant";
                    break;

                case SpecificMonsterTypeEnum.AdjunctFaculty:
                    Message = "Adjunct Faculty";
                    break;

                case SpecificMonsterTypeEnum.AssistantProfessor:
                    Message = "Assistant Professor";
                    break;

                case SpecificMonsterTypeEnum.AssociateProfessor:
                    Message = "Associate Professor";
                    break;

                case SpecificMonsterTypeEnum.Professor:
                    Message = "Professor";
                    break;

                case SpecificMonsterTypeEnum.HRAdministrator:
                    Message = "HR Administrator";
                    break;

                case SpecificMonsterTypeEnum.RegistrationAdministrator:
                    Message = "Registration Administrator";
                    break;

                case SpecificMonsterTypeEnum.GraduationOfficeAdministrator:
                    Message = "Graduation Office Administrator";
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Monster Enum Class
    /// </summary>
    public static class SpecificMonsterTypeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for SpecificMonsterType
        /// </summary>
        public static List<string> GetListAll
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecificMonsterTypeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of all the strings of the SpecificMonsterTypeEnum
        /// </summary>
        public static List<string> GetListMessageAll
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(SpecificMonsterTypeEnum)))
                {
                    list.Add(((SpecificMonsterTypeEnum)item).ToMessage());
                }
                return list;
            }
        }

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
        public static SpecificMonsterTypeEnum GraduationOfficeAdministrator { get { return new SpecificMonsterTypeEnum("Graduation Office Administrator"); } }

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
        /// Returns a list of strings of the enum for SpecificMonsterTypeEnum
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