using System;
using System.Collections.Generic;
using System.Linq;

using Game.Helpers;
using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    public static class RandomPlayerHelper
    {
        /// <summary>
        /// Get Health
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int GetHealth(int level)
        {
            // Roll the Dice and reset the Health
            return DiceHelper.RollDice(level, 10);
        }

        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterUniqueItem()
        {
            var itemIndex = DiceHelper.RollDice(1, ItemIndexViewModel.Instance.Dataset.Count()) - 1;

            // Check to see if there are enough items, if not, then just use the first one...
            var result = ItemIndexViewModel.Instance.Dataset.First().Id;

            if (itemIndex < ItemIndexViewModel.Instance.Dataset.Count)
            {
                result = ItemIndexViewModel.Instance.Dataset.ElementAt(itemIndex).Id;
            }
            return result;
        }

        /// <summary>
        /// Get a random item for monster
        /// </summary>
        /// <returns></returns>
        public static ItemModel GetMonsterItemEscapingSchool()
        {
            var itemIndex = DiceHelper.RollDice(1, ItemIndexViewModel.Instance.Dataset.Count()) - 1;

            // Check to see if there are enough items, if not, then just use the first one...
            var result = ItemIndexViewModel.Instance.Dataset.First();

            for (var i = itemIndex; i < ItemIndexViewModel.Instance.Dataset.Count; i++)
			{
                result = ItemIndexViewModel.Instance.Dataset.ElementAt(i);
                if (result.ItemType == ItemTypeEnum.GraduationCapAndRobe)
				{
                    result = null;
                    continue;
				}

			}
            
            return result;
        }

        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static DifficultyEnum GetMonsterDifficultyValue()
        {
            var DifficultyList = DifficultyEnumHelper.GetListMonster;

            var RandomDifficulty = DifficultyList.ElementAt(DiceHelper.RollDice(1, DifficultyList.Count()) - 1);

            var result = DifficultyEnumHelper.ConvertStringToEnum(RandomDifficulty);

            return result;
        }

        /// <summary>
        /// Get Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterImage()
        {

            List<String> StringList = new List<String> { "grad_office_monster.png", "human_resources_monster.png", "assistant_professor_monster.png", "associate_professor_monster.png", "registration_monster.png", "professor_monster.png" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterImage()
        {

            List<String> StringList = new List<String> { "helicopter_parent.png", "cool_parent.png", "overachiever_student.png", "prodigy_student.png", "slacker_student.png", "smarty_pants_character.png", "second_career_student.png" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterName()
        {

            List<String> StringList = new List<String> { "Franks", "Anderson", "Jefferson", "Cruise", "Smith", "Garcia", "Brown", "Davis", "Williams" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterDescription()
        {
            List<String> StringList = new List<String> { "eats Elf", "the Elf hater", "Elf destoryer", "Elf Hunter", "Elf Killer", "Can't we all get along?" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description for faculty monster
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterDescriptionFaculty()
        {
            List<String> StringList = new List<String> { "Gives hard exams.", "You will never pass this class.", "Think you can graduate? Good luck.", "You need extra homework, is what you need.", "You think this assignment was easy? Watch this next one.", "I'm smart, you're dumb. I'm big, you're little. I'm right, you're wrong." };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description for administrator monster
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterDescriptionAdministrator()
        {
            List<String> StringList = new List<String> { "Just one more form to fill out.", "Oh no, you're not done, here's another form.", "You think you have a lot of paperwork to do? You should see my office.", "Just three more forms for you.", "I'm sorry, I can't find the paperwork you said you submitted.", "Let's see. I have four more students ahead of you in line, but I should be able to get to your forms next week." };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterName()
        {

            List<String> StringList = new List<String> { "Sarah", "Mariah", "Sascha", "Mika", "Gaurav", "Arnold", "Liam", "Oliver", "William", "Noah", "Harper", "Ayushi", "Michaela", "Michel", "Carlos", "Fely", "Yukari", "Charlotte", "Elijah", "Mason" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterDescription()
        {
            List<String> StringList = new List<String> { "the terrible", "the awesome", "the lost", "the old", "the younger", "the quiet", "the loud", "the helpless", "the happy", "the sleepy", "the angry", "the clever" };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description for character parent.
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterDescriptionParent()
        {
            List<String> StringList = new List<String> { "I love my baby.", "My child is the best.", "My child is the smartest.", "My child is the brightest.", "My little baby will graduate soon!", "What can I say? School is expensive.", "I don't agree with the grade my child got." };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Description for character student.
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterDescriptionStudent()
        {
            List<String> StringList = new List<String> { "I really do like school. I think.", "I wish I could graduate.", "I hope I get a good grade.", "I hope I chose the right career.", "I like hanging out with friends.", "School is overrated.", "I'm glad my parents are paying for this." };

            var index = DiceHelper.RollDice(1, StringList.Count()) - 1;

            var result = StringList.First();

            if (index < StringList.Count)
            {
                result = StringList.ElementAt(index);
            }

            return result;
        }

        /// <summary>
        /// Get Random Ability Number
        /// </summary>
        /// <returns></returns>
        public static int GetAbilityValue()
        {
            // 0 to 9, not 1-10
            return DiceHelper.RollDice(1, 10) - 1;
        }

        /// <summary>
        /// Get a Random Level
        /// </summary>
        /// <returns></returns>
        public static int GetLevel()
        {
            // 1-20
            return DiceHelper.RollDice(1, 20);
        }

        /// <summary>
        /// Get a Random Item for the Location
        /// 
        /// Return the String for the ID
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static string GetItem(ItemLocationEnum location)
        {
            var ItemList = ItemIndexViewModel.Instance.GetLocationItems(location);
            if (ItemList.Count == 0)
            {
                return null;
            }

            // Add None to the list
            ItemList.Insert(0, new ItemModel { Id = null, Name = "None" });

            var result = ItemList.First().Id;

            var index = DiceHelper.RollDice(1, ItemList.Count()) - 1;
            if (index < ItemList.Count)
            {
                result = ItemList.ElementAt(index).Id;
            }

            return result;
        }


        /// <summary>
        /// Get a Random Item for the Location. This method it particular to the Escaping School game flavor.
        /// 
        /// Return the String for the ID
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static string GetItemEscapingSchool(ItemLocationEnum location)
        {

            var ItemList = new List<ItemModel>();

            // Add None to the list
            ItemList.Add(new ItemModel { Id = null, Name = "None" });

            var itemtypes = ItemLocationEnumHelper.GetItemFromLocationType(location);
            if (itemtypes.Count == 0)
            {
                return null;
            }

            foreach (var type in itemtypes)
			{
                ItemModel item = new ItemModel();
                item.Name = ItemTypeEnumHelper.getRandomeNameBasedOnType(type);
                item.Description = ItemTypeEnumHelper.getDescriptionBasedOnType(type);
                item.ItemType = type;
                item.Attribute = AttributeEnum.Attack;
                item.Location = location;
                item.ImageURI = ItemTypeEnumHelper.GetImageURIFromItemType(type);
                item.Damage = ItemTypeEnumHelper.GetDamageFromItemType(type);
                ItemList.Add(item);
			}

            var result = ItemList.First().Id;

            var index = DiceHelper.RollDice(1, ItemList.Count()) - 1;
            if (index < ItemList.Count)
            {
                result = ItemList.ElementAt(index).Id;
            }

            return result;
        }

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static CharacterModel GetRandomCharacter(int MaxLevel)
        {
            var result = new CharacterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetCharacterName(),
                Description = GetCharacterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                // Randomize an Item for Location
                Head = GetItem(ItemLocationEnum.Head),
                Necklace = GetItem(ItemLocationEnum.Necklace),
                PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand),
                OffHand = GetItem(ItemLocationEnum.OffHand),
                RightFinger = GetItem(ItemLocationEnum.Finger),
                LeftFinger = GetItem(ItemLocationEnum.Finger),
                Feet = GetItem(ItemLocationEnum.Feet),

                ImageURI = GetCharacterImage()
            };

            result.MaxHealth = DiceHelper.RollDice(MaxLevel, 10);

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            return result;
        }

        /// <summary>
        /// Create Random Character for Escaping School
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static CharacterModel GetRandomCharacterEscapingSchool(int MaxLevel)
        {
            var type = DiceHelper.RollDice(1, 2);

            if (type % 2 == 0)
			{
                return GetRandomCharacterParent(MaxLevel);
			}
            return GetRandomCharacterStudent(MaxLevel);
        }

        /// <summary>
        /// Create Random Character for the battle. This method is specific to our game flavor - Escaping School.Creates a parent.
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static CharacterModel GetRandomCharacterParent(int MaxLevel)
        {
            
            var result = new CharacterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetCharacterName(),
                Description = GetCharacterDescriptionParent(),
                CharacterTypeEnum = CharacterTypeEnum.Parent,

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                // Randomize an Item for Location. Parents don't have heads or feet.
                Necklace = GetItem(ItemLocationEnum.Necklace),
                PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand),
                OffHand = GetItem(ItemLocationEnum.OffHand),
                RightFinger = GetItem(ItemLocationEnum.Finger),
                LeftFinger = GetItem(ItemLocationEnum.Finger),
            };

            var specifictype = DiceHelper.RollDice(1, 2);

            if (specifictype % 2 == 0)
			{
                result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.CoolParent;
			}
            if (specifictype % 2 != 0)
            {
                result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.HelicopterParent;
            }

            result.ImageURI = SpecificCharacterTypeEnumHelper.ToImageURI(result.SpecificCharacterTypeEnum);

            result.MaxHealth = DiceHelper.RollDice(MaxLevel, 10);

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            return result;
        }

        /// <summary>
        /// Create Random Character for the battle. This method is specific to our game flavor - Escaping School.Creates a parent.
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static CharacterModel GetRandomCharacterStudent(int MaxLevel)
        {

            var result = new CharacterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetCharacterName(),
                Description = GetCharacterDescriptionParent(),
                CharacterTypeEnum = CharacterTypeEnum.Student,

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                // Randomize an Item for Location. Parents don't have heads or feet.
                Necklace = GetItem(ItemLocationEnum.Necklace),
                PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand),
                OffHand = GetItem(ItemLocationEnum.OffHand),
                RightFinger = GetItem(ItemLocationEnum.Finger),
                LeftFinger = GetItem(ItemLocationEnum.Finger),
            };

            var specifictype = DiceHelper.RollDice(1, 7);

            switch (specifictype)
			{
                case 1:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.InternationalStudent;
                    break;
                case 2:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever;
                    break;
                case 3:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Procrastinator;
                    break;
                case 4:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Prodigy;
                    break;
                case 5:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SecondCareer;
                    break;
                case 6:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Slacker;
                    break;
                case 7:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants;
                    break;
                default:
                    result.SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Unknown;
                    break;
			}

            result.ImageURI = SpecificCharacterTypeEnumHelper.ToImageURI(result.SpecificCharacterTypeEnum);

            result.MaxHealth = DiceHelper.RollDice(MaxLevel, 10);

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            return result;
        }

        /// <summary>
        /// Create Random monster for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetRandomMonster(int MaxLevel, bool Items = false)
        {
            var result = new MonsterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetMonsterName(),
                Description = GetMonsterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                ImageURI = GetMonsterImage(),

                Difficulty = GetMonsterDifficultyValue()
            };

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);
            result.Level = result.Difficulty.ToModifier(result.Level);

            // Get the new Max Health
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Set ExperienceRemaining so Monsters can both use this method
            var LevelData = LevelTableHelper.LevelDetailsList.ElementAtOrDefault(result.Level + 1) ?? LevelTableHelper.LevelDetailsList.Last();
            result.ExperienceRemaining = LevelData.Experience;

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            // Monsters can have weapons too....
            if (Items)
            {
                result.Head = GetItem(ItemLocationEnum.Head);
                result.Necklace = GetItem(ItemLocationEnum.Necklace);
                result.PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand);
                result.OffHand = GetItem(ItemLocationEnum.OffHand);
                result.RightFinger = GetItem(ItemLocationEnum.Finger);
                result.LeftFinger = GetItem(ItemLocationEnum.Finger);
                result.Feet = GetItem(ItemLocationEnum.Feet);
            }

            return result;
        }

        /// <summary>
        /// Create Random monster faculty for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetRandomMonsterFaculty(int MaxLevel)
        {

            var result = new MonsterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetMonsterName(),
                Description = GetMonsterDescriptionFaculty(),
                MonsterTypeEnum = MonsterTypeEnum.Faculty,

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                Difficulty = GetMonsterDifficultyValue()
            };

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);
            result.Level = result.Difficulty.ToModifier(result.Level);

            // Get the new Max Health
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            var specifictype = DiceHelper.RollDice(1, 5);

            result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Unknown;

            switch (specifictype)
            {
                case 1:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AdjunctFaculty;
                    break;
                case 2:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AssistantProfessor;
                    break;
                case 3:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AssociateProfessor;
                    break;
                case 4:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Professor;
                    break;
                default:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Unknown;
                    break;
            }

            result.ImageURI = SpecificMonsterTypeEnumHelper.ToImageURI(result.SpecificMonsterTypeEnum);

            // Set ExperienceRemaining so Monsters can both use this method
            var LevelData = LevelTableHelper.LevelDetailsList.ElementAtOrDefault(result.Level + 1) ?? LevelTableHelper.LevelDetailsList.Last();
            result.ExperienceRemaining = LevelData.Experience;

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            var uniqueDrop = result.DropItemBasedOnCharacterType(result.SpecificMonsterTypeEnum);

            if (uniqueDrop != null)
			{
                result.UniqueDropItem = uniqueDrop.Id;
			}

            return result;
        }

        /// <summary>
        /// Create Random monster faculty for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetRandomMonsterAdministrator(int MaxLevel)
        {

            var result = new MonsterModel()
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetMonsterName(),
                Description = GetMonsterDescriptionFaculty(),
                MonsterTypeEnum = MonsterTypeEnum.Faculty,

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                Difficulty = GetMonsterDifficultyValue()
            };

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);
            result.Level = result.Difficulty.ToModifier(result.Level);

            // Get the new Max Health
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            var specifictype = DiceHelper.RollDice(1, 2);

            result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Unknown;

            switch (specifictype)
            {
                case 1:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator;
                    break;
                case 2:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.RegistrationAdministrator;
                    break;
                default:
                    result.SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Unknown;
                    break;
            }

            result.ImageURI = SpecificMonsterTypeEnumHelper.ToImageURI(result.SpecificMonsterTypeEnum);

            // Set ExperienceRemaining so Monsters can both use this method
            var LevelData = LevelTableHelper.LevelDetailsList.ElementAtOrDefault(result.Level + 1) ?? LevelTableHelper.LevelDetailsList.Last();
            result.ExperienceRemaining = LevelData.Experience;

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            var uniqueDrop = result.DropItemBasedOnCharacterType(result.SpecificMonsterTypeEnum);

            if (uniqueDrop != null)
            {
                result.UniqueDropItem = uniqueDrop.Id;
            }

            return result;
        }
    }
}