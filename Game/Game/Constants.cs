using System;
using System.IO;

namespace Game
{
    public static class Constants
    {
        public const string DatabaseFilename = "game.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

        // Faculty Monster types Image URIs
        public static string SpecificMonsterTypeDefaultImageURI = "squid.jpg";
        public static string SpecificMonsterTypeTeachingAssistantImageURI = "squid.jpg";
        public static string SpecificMonsterTypeAdjunctFacultyImageURI = "squid.jpg";
        public static string SpecificMonsterTypeAssistantProfessorImageURI = "squid.jpg";
        public static string SpecificMonsterTypeProfessorImageURI = "squid.jpg";

        // Administrator Monster types Image URIs
        public static string SpecificMonsterTypeHRAdministratorImageURI = "squid.jpg";
        public static string SpecificMonsterTypeRegistrationAdministratorImageURI = "squid.jpg";
        public static string SpecificMonsterTypeGraduationOfficeAdministratorImageURI = "squid.jpg";
        public static string SpecificMonsterTypeAssociateProfessorImageURI = "squid.jpg";

        // Student Character Types Image URIs
        public static string SpecificCharacterTypeDefaultImageURI = "student.png";
        public static string SpecificCharacterTypeSmartyPantsImageURI = "student.png";
        public static string SpecificCharacterTypeOverachieverImageURI = "student.png";
        public static string SpecificCharacterTypeInternationalStudentImageURI = "student.png";
        public static string SpecificCharacterTypeProdigyImageURI = "student.png";
        public static string SpecificCharacterTypeSecondCareerImageURI = "student.png";
        public static string SpecificCharacterTypeSlackerImageURI = "student.png";
        public static string SpecificCharacterTypeProcrastinatorImageURI = "student.png";

        // Parent Character Types Image URIs
        public static string SpecificCharacterTypeHelicopterParentImageURI = "parent.png";
        public static string SpecificCharacterTypeCoolParentImageURI = "parent.png";

        // Default Character name
        public static string CharacterNameDefault = "New Character Name";
        public static string CharacterDescriptionDefault = "New Character Description";

        // Default Monster name
        public static string MonsterNameDefault = "New Monster Name";
        public static string MonsterDescriptionDefault = "New Monster Description";
    }
}