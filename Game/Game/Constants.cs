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
        public static string SpecificMonsterTypeAssociateProfessorImageURI = "squid.jpg";
        public static string SpecificMonsterTypeProfessorImageURI = "squid.jpg";

        // Administrator Monster types Image URIs
        public static string SpecificMonsterTypeHRAdministratorImageURI = "squid.jpg";
        public static string SpecificMonsterTypeRegistrationAdministratorImageURI = "squid.jpg";
        public static string SpecificMonsterTypeGraduationOfficeAdministratorImageURI = "squid.jpg";

        // Student Character Types Image URIs
        public static string SpecificCharacterTypeDefaultImageURI = "smarty_pants_character.png";
        public static string SpecificCharacterTypeSmartyPantsImageURI = "smarty_pants_character.png";
        public static string SpecificCharacterTypeOverachieverImageURI = "overachiever_student.png";
        public static string SpecificCharacterTypeInternationalStudentImageURI = "international_student.png";
        public static string SpecificCharacterTypeProdigyImageURI = "prodigy_student.png";
        public static string SpecificCharacterTypeSecondCareerImageURI = "second_career_student.png";
        public static string SpecificCharacterTypeSlackerImageURI = "slacker_student.png";
        public static string SpecificCharacterTypeProcrastinatorImageURI = "procrastinator_student.png";

        // Item Types Image URIs
        public static string ItemTypeIndexCardsImageURI = "item.png";
        public static string ItemTypePencilEraserImageURI = "item.png";
        public static string ItemTypeTextbooksImageURI = "item.png";
        public static string ItemTypeNotebookImageURI = "item.png";
        public static string ItemTypeCalculatorImageURI = "item.png";
        public static string ItemTypeLibraryCardImageURI = "item.png";
        public static string ItemTypeFoodCourtCardImageURI = "item.png";
        public static string ItemTypeLaptopImageURI = "item.png";
        public static string ItemTypePrivateTutorImageURI = "item.png";
        public static string ItemTypeFinancialAidImageURI = "item.png";
        public static string ItemTypeTuitionImageURI = "item.png";
        public static string ItemTypeGraduationCapAndRobeImageURI = "item.png";
        public static string ItemTypeDiplomaImageURI = "item.png";

        // Parent Character Types Image URIs
        public static string SpecificCharacterTypeHelicopterParentImageURI = "helicopter_parent.png";
        public static string SpecificCharacterTypeCoolParentImageURI = "coolparent.png";

        // Default Character name
        public static string CharacterNameDefault = "New Character Name";
        public static string CharacterDescriptionDefault = "New Character Description";

        // Default Monster name
        public static string MonsterNameDefault = "New Monster Name";
        public static string MonsterDescriptionDefault = "New Monster Description";
    }
}