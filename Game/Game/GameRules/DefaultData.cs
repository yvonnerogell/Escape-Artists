using System.Collections.Generic;

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
        public static List<BodyPartModel> LoadData(BodyPartModel temp)
        {
            var datalist = new List<BodyPartModel>()
            {
                new BodyPartModel {
                    Name = "I1",
                    Description = "I1",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = BodyPartEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new BodyPartModel {
                    Name = "I2",
                    Description = "I2",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = BodyPartEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new BodyPartModel {
                    Name = "I3",
                    Description = "I3",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = BodyPartEnum.Necklace,
                    Attribute = AttributeEnum.Attack
                },
                new BodyPartModel {
                    Name = "I4",
                    Description = "I4",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = BodyPartEnum.OffHand,
                    Attribute = AttributeEnum.Attack
                },
                new BodyPartModel {
                    Name = "I5",
                    Description = "I5",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = BodyPartEnum.Finger,
                    Attribute = AttributeEnum.Attack
                },
                new BodyPartModel {
                    Name = "I6",
                    Description = "I6",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 9,
                    Location = BodyPartEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
            };

            for (int i = 0; i < 20; i++)
            {
                var item = new BodyPartModel
                {
                    ImageURI = "item.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = BodyPartEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                };
                item.Name = "I" + (datalist.Count+1).ToString();
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
        var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(BodyPartEnum.Head);
        var NecklassString = ItemIndexViewModel.Instance.GetDefaultItemId(BodyPartEnum.Necklace);
        var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(BodyPartEnum.PrimaryHand);
        var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(BodyPartEnum.OffHand);
        var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(BodyPartEnum.Feet);
        var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(BodyPartEnum.Finger);
        var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(BodyPartEnum.Finger);

        var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "C1",
                    Description = "C1",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklace = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "C2",
                    Description = "C2",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklace = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "C3",
                    Description = "C3",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklace = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "C4",
                    Description = "C4",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklace = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "C5",
                    Description = "C5",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklace = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "C6",
                    Description = "C6",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklace = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "C7",
                    Description = "C6",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklace = NecklassString,
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
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<MonsterModel> LoadData(MonsterModel temp)
    {
        var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "M1",
                    Description = "M1",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M2",
                    Description = "M2",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M3",
                    Description = "M3",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M4",
                    Description = "M4",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M5",
                    Description = "M5",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M6",
                    Description = "M6",
                    ImageURI = "item.png",
                },

                new MonsterModel {
                    Name = "M7",
                    Description = "M7",
                    ImageURI = "item.png",
                },
            };

        return datalist;
    }
}
}