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
            ItemList.Add(new ItemModel { Id = null, Name = "None" });

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
        /// Create Random Character for the battle
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
    }
}