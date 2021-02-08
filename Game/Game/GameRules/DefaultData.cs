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
                    Name = ItemTypeEnum.IndexCards.ToMessage(),
                    Description = "Memorize your homework.",
                    ImageURI = Constants.ItemTypeIndexCardsImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 2,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.PencilEraser.ToMessage(),
                    Description = "Forget about your mistakes.",
                    ImageURI = Constants.ItemTypePencilEraserImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.Textbooks.ToMessage(),
                    Description = "Reference course literature effectively.",
                    ImageURI = Constants.ItemTypeTextbooksImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 10,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.Notebook.ToMessage(),
                    Description = "Keep track of the most crucial things to know.",
                    ImageURI = Constants.ItemTypeNotebookImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.Calculator.ToMessage(),
                    Description = "Avoid doing math in your head.",
                    ImageURI = Constants.ItemTypeCalculatorImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 5,
                    Location = ItemLocationEnum.LeftFinger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.LibraryCard.ToMessage(),
                    Description = "Get your textbooks for free.",
                    ImageURI = Constants.ItemTypeLibraryCardImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 3,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.FoodCourtCard.ToMessage(),
                    Description = "Don’t run out of fuel.",
                    ImageURI = Constants.ItemTypeFoodCourtCardImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 5,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.Laptop.ToMessage(),
                    Description = "Complete your assignments faster with a laptop.",
                    ImageURI = Constants.ItemTypeLaptopImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 20,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.PrivateTutor.ToMessage(),
                    Description = "Get expert homework help.",
                    ImageURI = Constants.ItemTypePrivateTutorImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 10,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.FinancialAid.ToMessage(),
                    Description = "Get some financial help.",
                    ImageURI = Constants.ItemTypeFinancialAidImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 40,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.Tuition.ToMessage(),
                    Description = "Pay your way through college.",
                    ImageURI = Constants.ItemTypeTuitionImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 50,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.GraduationCapAndRobe.ToMessage(),
                    Description = "The cap will help you feel closer to graduation.",
                    ImageURI = Constants.ItemTypeGraduationCapAndRobeImageURI,
                    Range = 10,
                    Damage = 10,
                    Value = 200,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = ItemTypeEnum.Diploma.ToMessage(),
                    Description = "A diploma is the (almost) final step before graduation.",
                    ImageURI = Constants.ItemTypeDiplomaImageURI,
                    Range = 10,
                    Damage = 10,
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

            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Bobbet",
                    Description = "My IQ is bigger than your height in centimeters!",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants,
                    Level = 1,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeSmartyPantsImageURI,
                    Head = HeadString,
                    Necklace = "None",
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Lucy",
                    Description = "Where can I find extra reading on this material?",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever,
                    Level = 1,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeOverachieverImageURI,
                    Head = HeadString,
                    Necklace = NecklaceString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Nancy",
                    Description = "I would have been a professor by now if it weren't for the stress of I-94 renewal",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.InternationalStudent,
                    Level = 1,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeInternationalStudentImageURI,
                    Head = HeadString,
                    Necklace = "None",
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Petter",
                    Description = "I'm a big Proust fan ... since the age of 4",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Prodigy,
                    Level = 1,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeProdigyImageURI,
                    Head = HeadString,
                    Necklace = "None",
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Micheal",
                    Description = "So no one told you life was gonna be this way",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SecondCareer,
                    Level = 1,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeSecondCareerImageURI,
                    Head = HeadString,
                    Necklace = NecklaceString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Brian",
                    Description = "So the midterm is sometime this month, right?",
                    Level = 1,
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Slacker,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeSlackerImageURI,
                    Head = HeadString,
                    Necklace = NecklaceString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Emily",
                    Description = "Only if they hadn't released the new GoT season...",
                    Level = 1,
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Procrastinator,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeProcrastinatorImageURI,
                    Head = HeadString,
                    Necklace = "None",
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                 new CharacterModel {
                    Name = "Ms. Wang",
                    Description = "My baby needs me!",
                    Level = 1,
                    CharacterTypeEnum = CharacterTypeEnum.Parent,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.HelicopterParent,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeHelicopterParentImageURI,
                    Head = "None",
                    Necklace = "None",
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                  new CharacterModel {
                    Name = "Mr. Robert",
                    Description = "I'm cool, can't help it",
                    Level = 1,
                    CharacterTypeEnum = CharacterTypeEnum.Parent,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.CoolParent,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeCoolParentImageURI,
                    Head = "None",
                    Necklace = "None",
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
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
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Sam",
                    Description = "I do all the work everyone else gets credit for!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.TeachingAssistant,
                    Difficulty = DifficultyEnum.Easy,
                    UniqueDropItem = ItemTypeEnum.IndexCards.ToMessage(),
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeTeachingAssistantImageURI
                },

                new MonsterModel {
                    Name = "Mr. Smith",
                    Description = "No one can fire me.",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AdjunctFaculty,
                    Difficulty = DifficultyEnum.Average,
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeAdjunctFacultyImageURI
                },

                new MonsterModel {
                    Name = "Mr. Frank",
                    Description = "I have to grade everything!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AssistantProfessor,
                    Difficulty = DifficultyEnum.Average,
                    UniqueDropItem = ItemTypeEnum.Laptop.ToMessage(),
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeAssistantProfessorImageURI
                },

                new MonsterModel {
                    Name = "Ms. Randy",
                    Description = "I love teaching!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AssociateProfessor,
                    Difficulty = DifficultyEnum.Difficult,
                    UniqueDropItem = ItemTypeEnum.Textbooks.ToMessage(),
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 1,
                    ImageURI = Constants.SpecificMonsterTypeAssociateProfessorImageURI
                },

                new MonsterModel {
                    Name = "Professor Mike",
                    Description = "So many research projects!",
                    MonsterTypeEnum = MonsterTypeEnum.Faculty,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Professor,
                    Difficulty = DifficultyEnum.Difficult,
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 5,
                    ImageURI = Constants.SpecificMonsterTypeProfessorImageURI
                },

                new MonsterModel {
                    Name = "Karen",
                    Description = "Do you want to get paid?",
                    MonsterTypeEnum = MonsterTypeEnum.Administrator,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator,
                    Difficulty = DifficultyEnum.Easy,
                    UniqueDropItem = ItemTypeEnum.FinancialAid.ToMessage(),
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 3,
                    ImageURI = Constants.SpecificMonsterTypeHRAdministratorImageURI
                },

                new MonsterModel {
                    Name = "Sandra",
                    Description = "Class is full, take it next quarter.",
                    MonsterTypeEnum = MonsterTypeEnum.Administrator,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.RegistrationAdministrator,
                    Difficulty = DifficultyEnum.Average,
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 2,
                    ImageURI = Constants.SpecificMonsterTypeRegistrationAdministratorImageURI
                },

                 new MonsterModel {
                    Name = "Mandy",
                    Description = "You have graduated!!!",
                    MonsterTypeEnum = MonsterTypeEnum.Administrator,
                    SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.GraduationOfficeAdministrator,
                    Difficulty = DifficultyEnum.Difficult,
                    UniqueDropItem = ItemTypeEnum.GraduationCapAndRobe.ToMessage(),
                    Items = new List<ItemLocationEnum>()
                    {
                        ItemLocationEnum.Head,
                        ItemLocationEnum.Necklace
                    },
                    Attack = 8,
                    ImageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI
                },
            };

            return datalist;
        }
    }
}