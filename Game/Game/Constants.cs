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
        public static string SpecificMonsterTypeTeachingAssistantImageURI = "teaching_assistant_monster.jpg";
        public static string SpecificMonsterTypeAdjunctFacultyImageURI = "adjunct_faculty_monster.jpg";
        public static string SpecificMonsterTypeAssistantProfessorImageURI = "assistant_professor_monster.jpg";
        public static string SpecificMonsterTypeAssociateProfessorImageURI = "associate_professor_monster.jpg";
        public static string SpecificMonsterTypeProfessorImageURI = "professor_monster.jpg";

        // Administrator Monster types Image URIs
        public static string SpecificMonsterTypeHRAdministratorImageURI = "human_resources_monster.jpg";
        public static string SpecificMonsterTypeRegistrationAdministratorImageURI = "registration_monster.jpg";
        public static string SpecificMonsterTypeGraduationOfficeAdministratorImageURI = "grad_office_monster.jpg";

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
        public static string ItemTypeDefaultImageURI = "item.png";
        public static string ItemTypeIndexCardsImageURI = "item_indexcards.png";
        public static string ItemTypePencilEraserImageURI = "item_pencil.png";
        public static string ItemTypeTextbooksImageURI = "item_textbook.png";
        public static string ItemTypeNotebookImageURI = "item_notebook.png";
        public static string ItemTypeCalculatorImageURI = "item_calculator.png";
        public static string ItemTypeLibraryCardImageURI = "item_librarycard.png";
        public static string ItemTypeFoodCourtCardImageURI = "item_foodcard.png";
        public static string ItemTypeLaptopImageURI = "item_laptop.png";
        public static string ItemTypePrivateTutorImageURI = "item_privatetutor.png";
        public static string ItemTypeFinancialAidImageURI = "item_financialaid.png";
        public static string ItemTypeTuitionImageURI = "item_tuition.png";
        public static string ItemTypeGraduationCapAndRobeImageURI = "item_gradcap.png";
        public static string ItemTypeDiplomaImageURI = "item_diploma.png";

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