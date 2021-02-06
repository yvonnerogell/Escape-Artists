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
            var Message = "Unknown";

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

        /// <summary>
        /// Returns a list of all the strings of the SpecificMonsterTypeEnum
        /// </summary>
        public static List<string> GetListMessageAllNoUnknown
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(SpecificMonsterTypeEnum)))
                {
                    list.Add(((SpecificMonsterTypeEnum)item).ToMessage());
                }
                list.Remove(SpecificMonsterTypeEnum.Unknown.ToString());
                return list;
            }
        }

        /// <summary>
        /// Returns a list of Faculty types as SpecificMonsterTypeEnums
        /// </summary>
        public static List<string> GetFacultyList
        {
            get
            {
                var myList = new List<string>();
                myList.Add("Teaching Assistant");
                myList.Add("Adjunct Faculty");
                myList.Add("Assistant Professor");
                myList.Add("Associate Professor");
                myList.Add("Professor");
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Faculty types as String
        /// </summary>
        public static List<string> GetFacultyListMessage
        {
            get
            {
                var myList = new List<string>();
                myList.Add("Teaching Assistant");
                myList.Add("Adjunct Faculty");
                myList.Add("Assistant Professor");
                myList.Add("Associate Professor");
                myList.Add("Professor");
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Administrator types as SpecificMonsterTypeEnums
        /// </summary>
        public static List<string> GetAdministratorList
        {
            get
            {
                var myList = new List<string>();
                myList.Add("HR Administrator");
                myList.Add("Registration Administrator");
                myList.Add("Graduation Office Administrator");
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Administrator types as String
        /// </summary>
        public static List<string> GetAdministratorListMessage
        {
            get
            {
                var myList = new List<string>();
                myList.Add("HR Administrator");
                myList.Add("Registration Administrator");
                myList.Add("Graduation Office Administrator");
                return myList;
            }
        }

        /// <summary>
        /// Returns Enum values for a string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SpecificMonsterTypeEnum ConvertStringToEnum(string value)
        {
            return (SpecificMonsterTypeEnum)Enum.Parse(typeof(SpecificMonsterTypeEnum), value);
        }

        /// <summary>
        /// Given the Full String for an enum, return its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SpecificMonsterTypeEnum ConvertMessageStringToEnum(string value)
        {
            foreach (SpecificMonsterTypeEnum item in Enum.GetValues(typeof(SpecificMonsterTypeEnum)))
            {
                if (item.ToMessage().Equals(value))
                {
                    return item;
                }
            }
            return SpecificMonsterTypeEnum.Unknown;
        }

        /// <summary>
        /// Given the Full String for an enum, return its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MonsterTypeEnum GetMonsterTypeEnumFromSpecificMonsterTypeEnum(SpecificMonsterTypeEnum specificMonsterType)
        {
            var result = MonsterTypeEnum.Unknown;
            switch (specificMonsterType)
			{
                case SpecificMonsterTypeEnum.AdjunctFaculty:
                case SpecificMonsterTypeEnum.AssistantProfessor:
                case SpecificMonsterTypeEnum.AssociateProfessor:
                case SpecificMonsterTypeEnum.Professor:
                case SpecificMonsterTypeEnum.TeachingAssistant:
                    result = MonsterTypeEnum.Faculty;
                    break;
                case SpecificMonsterTypeEnum.GraduationOfficeAdministrator:
                case SpecificMonsterTypeEnum.HRAdministrator:
                case SpecificMonsterTypeEnum.RegistrationAdministrator:
                    result = MonsterTypeEnum.Administrator;
                    break;
			}
            return result;
        }
    }

}
