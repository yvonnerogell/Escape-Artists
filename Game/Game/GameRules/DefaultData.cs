﻿using System.Collections.Generic;

using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Id = "Skateboard",
                    Name = "Blue " + ItemTypeEnum.Skateboard.ToMessage(),
                    Description = "Helps you get to class faster!",
                    ItemType = ItemTypeEnum.Skateboard,
                    ImageURI = Constants.ItemTypeSkateboardImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 10,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "IndexCards1",
                    Name = "Exam " + ItemTypeEnum.IndexCards.ToMessage(),
                    Description = "Memorize your homework.",
                    ItemType = ItemTypeEnum.IndexCards,
                    ImageURI = Constants.ItemTypeIndexCardsImageURI,
                    Range = 10,
                    Damage = 2,
                    Value = 2,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "IndexCards2",
                    Name = "Midterm " + ItemTypeEnum.IndexCards.ToMessage(),
                    Description = "Memorize your homework.",
                    ItemType = ItemTypeEnum.IndexCards,
                    ImageURI = Constants.ItemTypeIndexCardsImageURI,
                    Range = 10,
                    Damage = 2,
                    Value = 2,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "PencilEraser1",
                    Name = "Blue " + ItemTypeEnum.PencilEraser.ToMessage(),
                    Description = "Forget about your mistakes.",
                    ItemType = ItemTypeEnum.PencilEraser,
                    ImageURI = Constants.ItemTypePencilEraserImageURI,
                    Range = 10,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Textbooks1",
                    Name = "Math " + ItemTypeEnum.Textbooks.ToMessage(),
                    Description = "Reference course literature effectively.",
                    ItemType = ItemTypeEnum.Textbooks,
                    ImageURI = Constants.ItemTypeTextbooksImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 10,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Textbooks2",
                    Name = "English " + ItemTypeEnum.Textbooks.ToMessage(),
                    Description = "Reference course literature effectively.",
                    ItemType = ItemTypeEnum.Textbooks,
                    ImageURI = Constants.ItemTypeTextbooksImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 10,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Notebooks1",
                    Name = "Pink " + ItemTypeEnum.Notebook.ToMessage(),
                    Description = "Keep track of the most crucial things to know.",
                    ItemType = ItemTypeEnum.Notebook,
                    ImageURI = Constants.ItemTypeNotebookImageURI,
                    Range = 10,
                    Damage = 2,
                    Value = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Calculator1",
                    Name = "Graphing " + ItemTypeEnum.Calculator.ToMessage(),
                    Description = "Avoid doing math in your head.",
                    ItemType = ItemTypeEnum.Calculator,
                    ImageURI = Constants.ItemTypeCalculatorImageURI,
                    Range = 10,
                    Damage = 5,
                    Value = 5,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Librarycard1",
                    Name = "Student " + ItemTypeEnum.LibraryCard.ToMessage(),
                    Description = "Get your textbooks for free.",
                    ItemType = ItemTypeEnum.LibraryCard,
                    ImageURI = Constants.ItemTypeLibraryCardImageURI,
                    Range = 10,
                    Damage = 3,
                    Value = 3,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Foodcourtcard1",
                    Name = "Student " + ItemTypeEnum.FoodCourtCard.ToMessage(),
                    Description = "Don’t run out of fuel.",
                    ItemType = ItemTypeEnum.FoodCourtCard,
                    ImageURI = Constants.ItemTypeFoodCourtCardImageURI,
                    Range = 10,
                    Damage = 5,
                    Value = 5,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Laptop1",
                    Name = "Mac " + ItemTypeEnum.Laptop.ToMessage(),
                    Description = "Complete your assignments faster with a laptop.",
                    ItemType = ItemTypeEnum.Laptop,
                    ImageURI = Constants.ItemTypeLaptopImageURI,
                    Range = 10,
                    Damage = 20,
                    Value = 20,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Laptop2",
                    Name = "PC " + ItemTypeEnum.Laptop.ToMessage(),
                    Description = "Complete your assignments faster with a laptop.",
                    ItemType = ItemTypeEnum.Laptop,
                    ImageURI = Constants.ItemTypeLaptopImageURI,
                    Range = 10,
                    Damage = 20,
                    Value = 20,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "privatetutor1",
                    Name = "Math " + ItemTypeEnum.PrivateTutor.ToMessage(),
                    Description = "Get expert homework help.",
                    ItemType = ItemTypeEnum.PrivateTutor,
                    ImageURI = Constants.ItemTypePrivateTutorImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 10,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "FinancialAid1",
                    Name = "Undergraduate " + ItemTypeEnum.FinancialAid.ToMessage(),
                    Description = "Get some financial help.",
                    ItemType = ItemTypeEnum.FinancialAid,
                    ImageURI = Constants.ItemTypeFinancialAidImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 40,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Tuition1",
                    Name = "Sprint quarter " + ItemTypeEnum.Tuition.ToMessage(),
                    Description = "Pay your way through college.",
                    ItemType = ItemTypeEnum.Tuition,
                    ImageURI = Constants.ItemTypeTuitionImageURI,
                    Range = 10,
                    Damage = 50,
                    Value = 50,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Graduationcapandrobe1",
                    Name = "Master's " + ItemTypeEnum.GraduationCapAndRobe.ToMessage(),
                    Description = "The cap will help you feel closer to graduation.",
                    ItemType = ItemTypeEnum.GraduationCapAndRobe,
                    ImageURI = Constants.ItemTypeGraduationCapAndRobeImageURI,
                    Range = 10,
                    Damage = 200,
                    Value = 200,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Id = "Mastersdiploma1",
                    Name = "Master's " + ItemTypeEnum.Diploma.ToMessage(),
                    Description = "A diploma is the (almost) final step before graduation.",
                    ItemType = ItemTypeEnum.Diploma,
                    ImageURI = Constants.ItemTypeDiplomaImageURI,
                    Range = 10,
                    Damage = 1000,
                    Value = 1000,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
            };

            return datalist;
        }

        /// <summary>
        /// Load Example Scores
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load Characters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);
            var NecklaceString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Necklace);
            var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);
            var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.OffHand);
            var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Feet);
            var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
            var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
            
            var DefaultIndexCards = (string)null;
            var item = ItemIndexViewModel.Instance.GetItem("IndexCards1");
            if (item != null)
            {
                DefaultIndexCards = item.Id;
            }

            var DefaultTextbooks = (string)null;
            item = ItemIndexViewModel.Instance.GetItem("Textbooks1");
            if (item != null)
            {
                DefaultIndexCards = item.Id;
            }

            var DefaultLaptop = (string)null;
            item = ItemIndexViewModel.Instance.GetItem("Laptop1");
            if (item != null)
            {
                DefaultIndexCards = item.Id;
            }

            var DefaultPencilEraser = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.PencilEraser);

            var DefaultNotebook = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.Notebook);
            var DefaultCalculator = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.Calculator);
            var DefaultLibraryCard = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.LibraryCard);
            var DefaultFoodCourtCard = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.FoodCourtCard);
            var DefaultPrivateTutor = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.PrivateTutor);
            var DefaultTuition = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.Tuition);


            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Bobbet",
                    Description = "My IQ is bigger than your height in centimeters!",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants,
                    Range = 3,
                    Level = 1,
                    GPA = 80,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeSmartyPantsImageURI,
                    Head = null,
                    Necklace = null,
                    PrimaryHand = DefaultPencilEraser,
                    OffHand = null,
                    Feet = null,
                    RightFinger = DefaultIndexCards,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.ExtraCredit,
                    TileImageURI = Constants.SpecificCharacterTypeSmartyPantsTileImageURI,
                },

                new CharacterModel {
                    Name = "Lucy",
                    Description = "Where can I find extra reading on this material?",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever,
                    Range = 3,
                    Level = 1,
                    GPA = 80,
                    MaxHealth = 10,
                    ImageURI = Constants.SpecificCharacterTypeOverachieverImageURI,
                    Head = null,
                    Necklace = null,
                    PrimaryHand = DefaultTextbooks,
                    OffHand = null,
                    Feet = null,
                    RightFinger = null,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.FlashGenius,
                    TileImageURI = Constants.SpecificCharacterTypeOverachieverTileImageURI,
        },

                new CharacterModel {
                    Name = "Nancy",
                    Description = "I would have been a professor by now if it weren't for the stress of I-94 renewal",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.InternationalStudent,
                    Range = 2,
                    Level = 1,
                    GPA = 80,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeInternationalStudentImageURI,
                    Head = null,
                    Necklace = null,
                    PrimaryHand = DefaultNotebook,
                    OffHand = null,
                    Feet = null,
                    RightFinger = null,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.FlashGenius,
                    TileImageURI = Constants.SpecificCharacterTypeInternationalStudentTileImageURI,
                },

                new CharacterModel {
                    Name = "Petter",
                    Description = "I'm a big Proust fan ... since the age of 4",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Prodigy,
                    Range = 2,
                    Level = 1,
                    GPA = 70,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeProdigyImageURI,
                    Head = null,
                    Necklace = DefaultLibraryCard,
                    PrimaryHand = null,
                    OffHand = null,
                    Feet = null,
                    RightFinger = null,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.ExtraCredit,
                    TileImageURI = Constants.SpecificCharacterTypeProdigyTileImageURI,
                },

                new CharacterModel {
                    Name = "Micheal",
                    Description = "So no one told you life was gonna be this way",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SecondCareer,
                    Range = 2,
                    Level = 1,
                    GPA = 80,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeSecondCareerImageURI,
                    Head = null,
                    Necklace = null,
                    PrimaryHand = DefaultLaptop,
                    OffHand = null,
                    Feet = null,
                    RightFinger = null,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.Extension,
                    TileImageURI = Constants.SpecificCharacterTypeSecondCareerTileImageURI,
                },

                new CharacterModel {
                    Name = "Brian",
                    Description = "So the midterm is sometime this month, right?",
                    Level = 1,
                    GPA = 50,
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Slacker,
                    Range = 2,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeSlackerImageURI,
                    Head = null,
                    Necklace = null,
                    PrimaryHand = null,
                    OffHand = null,
                    Feet = "Skateboard",
                    RightFinger = null,
                    LeftFinger = DefaultCalculator,
                    SpecialAbility = AbilityEnum.Extension,
                    TileImageURI = Constants.SpecificCharacterTypeSlackerTileImageURI,
                },

                new CharacterModel {
                    Name = "Emily",
                    Description = "Only if they hadn't released the new GoT season...",
                    Level = 1,
                    GPA = 60,
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Procrastinator,
                    Range = 2,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeProcrastinatorImageURI,
                    Head = null,
                    Necklace = DefaultFoodCourtCard,
                    PrimaryHand = null,
                    OffHand = null,
                    Feet = null,
                    RightFinger = null,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.Extension,
                    TileImageURI = Constants.SpecificCharacterTypeProcrastinatorTileImageURI,
                },

                 new CharacterModel {
                    Name = "Ms. Wang",
                    Description = "My baby needs me!",
                    Level = 1,
                    GPA = 50,
                    CharacterTypeEnum = CharacterTypeEnum.Parent,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.HelicopterParent,
                    Range = 2,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeHelicopterParentImageURI,
                    Head = null,
                    Necklace = null,
                    PrimaryHand = DefaultTuition,
                    OffHand = null,
                    Feet = null,
                    RightFinger = null,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.Bribes,
                    TileImageURI = Constants.SpecificCharacterTypeHelicopterParentTileImageURI,
                },

                  new CharacterModel {
                    Name = "Mr. Robert",
                    Description = "I'm cool, can't help it",
                    Level = 1,
                    GPA = 30,
                    CharacterTypeEnum = CharacterTypeEnum.Parent,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.CoolParent,
                    Range = 1,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeCoolParentImageURI,
                    Head = null,
                    Necklace = DefaultPrivateTutor,
                    PrimaryHand = null,
                    OffHand = null,
                    Feet = null,
                    RightFinger = null,
                    LeftFinger = null,
                    SpecialAbility = AbilityEnum.PayTuition,
                    TileImageURI = Constants.SpecificCharacterTypeCoolParentTileImageURI,
                },
            };

            return datalist;
        }

        /// <summary>
        /// Load Monsters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<MonsterModel> LoadData(MonsterModel temp)
        {
            var DefaultIndexCards = (string)null;
            var item = ItemIndexViewModel.Instance.GetItem("IndexCards2");
            if (item != null)
            {
                DefaultIndexCards = item.Id;
            }

            var DefaultLaptop = (string)null;
            item = ItemIndexViewModel.Instance.GetItem("Laptop2");
            if (item != null)
            {
                DefaultLaptop = item.Id;
            }

            var DefaultTextbooks = (string)null;
            item = ItemIndexViewModel.Instance.GetItem("Textbooks2");
            if (item != null)
            {
                DefaultIndexCards = item.Id;
            }

            var DefaultFinancialAid = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.FinancialAid);
            var DefaultGraduationCapAndRobe = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.GraduationCapAndRobe);
            //var DefaultDiploma = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.Diploma);
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Sam",
                    Description = "I do all the work everyone else gets credit for!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.TeachingAssistant,
                    Range = 2,
                    Difficulty = DifficultyEnum.Easy,
                    UniqueDropItem = DefaultIndexCards,
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeTeachingAssistantImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeTeachingAssistantTileImageURI
                },

                new MonsterModel {
                    Name = "Mr. Smith",
                    Description = "No one can fire me.",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AdjunctFaculty,
                    Range = 2,
                    Difficulty = DifficultyEnum.Average,
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeAdjunctFacultyImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeAdjunctFacultyTileImageURI
                },

                new MonsterModel {
                    Name = "Mr. Frank",
                    Description = "I have to grade everything!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AssistantProfessor,
                    Range = 2,
                    Difficulty = DifficultyEnum.Average,
                    UniqueDropItem = DefaultLaptop,
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeAssistantProfessorImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeAssistantProfessorTileImageURI
                },

                new MonsterModel {
                    Name = "Ms. Randy",
                    Description = "I love teaching!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AssociateProfessor,
                    Range = 3,
                    Difficulty = DifficultyEnum.Difficult,
                    UniqueDropItem = DefaultTextbooks,
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeAssociateProfessorImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeAssociateProfessorTileImageURI
                },

                new MonsterModel {
                    Name = "Professor Michaela",
                    Description = "So many research projects!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Professor,
                    Range = 3,
                    Difficulty = DifficultyEnum.Difficult,
                    Attack = 5,
                    ImageURI = Constants.SpecificMonsterTypeProfessorImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeProfessorTileImageURI
                },

                new MonsterModel {
                    Name = "Karen",
                    Description = "Do you want to get paid?",
                    MonsterTypeEnum = MonsterTypeEnum.Administrator,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator,
                    Range = 1,
                    Difficulty = DifficultyEnum.Easy,
                    UniqueDropItem = DefaultFinancialAid,
                    Attack = 3,
                    ImageURI = Constants.SpecificMonsterTypeHRAdministratorImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeHRAdministratorTileImageURI
                },

                new MonsterModel {
                    Name = "Sandra",
                    Description = "Class is full, take it next quarter.",
                    MonsterTypeEnum = MonsterTypeEnum.Administrator,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.RegistrationAdministrator,
                    Range = 1,
                    Difficulty = DifficultyEnum.Average,
                    Attack = 2,
                    ImageURI = Constants.SpecificMonsterTypeRegistrationAdministratorImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeRegistrationAdministratorTileImageURI
                },

                 new MonsterModel {
                    Name = "Mandy",
                    Description = "You have graduated!!!",
                    MonsterTypeEnum = MonsterTypeEnum.Administrator,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.GraduationOfficeAdministrator,
                    Range = 2,
                    Difficulty = DifficultyEnum.Difficult,
                    UniqueDropItem = DefaultGraduationCapAndRobe,
                    Attack = 8,
                    ImageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI,
                    TileImageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorTileImageURI
                },
            };

            return datalist;
        }
    }
}