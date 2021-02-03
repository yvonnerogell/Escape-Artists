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
                    Name = "I1",
                    Description = "I1",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I2",
                    Description = "I2",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I3",
                    Description = "I3",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I4",
                    Description = "I4",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I5",
                    Description = "I5",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I6",
                    Description = "I6",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
            };

            for (int i = 0; i < 20; i++)
            {
                var item = new ItemModel
                {
                    ImageURI = "item.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                };
                item.Name = "I" + (datalist.Count + 1).ToString();
                item.Description = item.Name;

                datalist.Add(item);
            }

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
                    ImageURI = "student.png",
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
                    ImageURI = "student.png",
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
                    ImageURI = "student.png",
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
                    ImageURI = "student.png",
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
                    ImageURI = "student.png",
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
                    ImageURI = "student.png",
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
                    ImageURI = "student.png",
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
                    ImageURI = "parent.png",
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
                    ImageURI = "parent.png",
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
                    UniqueDropItem = ItemLocationEnum.Head,
                    Items = null,
                    Attack = 1,
                    ImageURI = "squid.jpg"
                }
            };

            return datalist;
        }
    }
}