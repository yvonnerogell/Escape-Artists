using System.Collections.Generic;

using Game.GameRules;

namespace Game.Models
{
    /// <summary>
    /// Player for the game.
    /// 
    /// Either Monster or Character
    /// 
    /// Constructor Player to Player used a T in Round
    /// </summary>
    public class PlayerInfoModel : BasePlayerModel<PlayerInfoModel>
    {
        // Track the Abilities in the Battle
        // The AbilityTracker holds the character's ability and the number of times it can be used per round (default is 1)
        // Only characters have abilities.
        public Dictionary<AbilityEnum, int> AbilityTracker = new Dictionary<AbilityEnum, int>();

        // Only monsters can have UniqueDropItems
        public string UniqueDropItem { get; set; }

        // Only Characters can have GPA
        public int GPA { get; set; }

        // Only characters have abilities, so only characters will have this variable
        // Indicates whether ability has been used in current round
        public bool AbilityUsedInCurrentRound { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PlayerInfoModel() { }

        /// <summary>
        /// Copy from one PlayerInfoModel into Another
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(PlayerInfoModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperienceTotal = data.ExperienceTotal;
            ExperienceRemaining = data.ExperienceRemaining;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;

            // Set the Base Attributes
            Speed = data.Speed;
            Range = data.Range;
            Defense = data.Defense;
            Attack = data.Attack;
            MaxHealth = data.MaxHealth;
            CurrentHealth = data.CurrentHealth;

            ImageURI = data.ImageURI;

            // Set the strings for the items
            Head = data.Head;
            Necklace = data.Necklace;
            PrimaryHand = data.PrimaryHand;
            OffHand = data.OffHand;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;

            UniqueDropItem = data.UniqueDropItem;

            Difficulty = data.Difficulty;

            AbilityTracker = data.AbilityTracker;

            GPA = data.GPA;
        }

        /// <summary>
        /// Create PlayerInfoModel from character
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(CharacterModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperienceTotal = data.ExperienceTotal;
            ExperienceRemaining = data.ExperienceRemaining;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;

            // Set the Base Attributes
            Speed = data.Speed;
            Range = data.Range;
            Defense = data.Defense;
            Attack = data.Attack;
            MaxHealth = data.MaxHealth;
            CurrentHealth = data.CurrentHealth;

            ImageURI = data.ImageURI;

            // Set the strings for the items
            Head = data.Head;
            Necklace = data.Necklace;
            PrimaryHand = data.PrimaryHand;
            OffHand = data.OffHand;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;

            Difficulty = data.Difficulty;

            // Give the copy a differet quid, so it can be used in the battles as a copy
            Guid = System.Guid.NewGuid().ToString();

            // Set current experience to be 1 above minimum.
            ExperienceTotal = LevelTableHelper.LevelDetailsList[Level - 1].Experience + 1;

            AbilityTracker.Add(data.SpecialAbility, Constants.SpecialAbilityUsePerRound);

            GPA = data.GPA;

            AbilityUsedInCurrentRound = data.AbilityUsedInCurrentRound;

        }

        /// <summary>
        /// Crate PlayerInfoModel from Monster
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(MonsterModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperienceTotal = data.ExperienceTotal;
            ExperienceRemaining = data.ExperienceRemaining;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.GetSpeed();
            ImageURI = data.ImageURI;
            MaxHealth = data.GetMaxHealthTotal;
            CurrentHealth = data.GetCurrentHealthTotal;

            // Set the Base Attributes
            Speed = data.Speed;
            Range = data.Range;
            Defense = data.Defense;
            Attack = data.Attack;
            MaxHealth = data.MaxHealth;
            CurrentHealth = data.CurrentHealth;

            // Set the strings for the items
            Head = data.Head;
            Necklace = data.Necklace;
            PrimaryHand = data.PrimaryHand;
            OffHand = data.OffHand;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;
            
            UniqueDropItem = data.UniqueDropItem;

            Difficulty = data.Difficulty;

            // Give the copy a differet quid, so it can be used in the battles as a copy
            Guid = System.Guid.NewGuid().ToString();

            // Set amount to give to be 1 below max for that level.
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;

        }

        /// <summary>
        /// Formats the output of this player.
        /// </summary>
        /// <returns></returns>
        public override string FormatOutput()
        {
            var myReturn = string.Empty;
            myReturn += Name;
            myReturn += " , " + Description;
            myReturn += " , Level : " + Level.ToString();

            if (PlayerType == PlayerTypeEnum.Character)
            {
                myReturn += " , Total Experience : " + ExperienceTotal;
                myReturn += " , Damage : " + GetDamageTotalString;
                myReturn += " , Attack :" + GetAttackTotal;
                myReturn += " , Defense :" + GetDefenseTotal;
                myReturn += " , Speed :" + GetSpeedTotal;
            }

            myReturn += " , Items : " + ItemSlotsFormatOutput();

            return myReturn;
        }

        #region Abilities


        /// <summary>
        /// Returns the special ability to be used. If none is available (e.g. for Monsters, since they don't have special abilities
        /// or if a character has already used their special ability in a round), then the method return AbilityEnum.None
        /// </summary>
        /// <returns>The ability enum that can be used.</returns>
        public AbilityEnum SelectSpecialAbilityToUse()
		{

            var abilityEnum = AbilityEnum.None;

            // Monsters will not have any abilities in the AbilityTracker, and will therefore return AbilityEnum.None
            if (AbilityTracker.Count == 0)
			{
                return abilityEnum;
            }
            
            // Characters will only have 1 ability in their trackers. However, foreach loop was easiest way to
            // not have to switch on SpecificCharacterType. 
            foreach (var item in AbilityTracker)
			{
                abilityEnum = item.Key;

                var result = AbilityTracker.TryGetValue(abilityEnum, out int remaining);
                
                // If the special ability count is 0, return None since there is no more to use this round
                if (remaining <= 0)
				{
                    abilityEnum = AbilityEnum.None;
				}
            }
            return abilityEnum;
		}

        /// <summary>
        /// Returns true if the specified ability is available for use, false if not. 
        /// </summary>
        /// <param name="ability"></param>
        /// <returns></returns>
        public bool IsAbilityAvailable(AbilityEnum ability)
        {
            var available = AbilityTracker.TryGetValue(ability, out int remaining);
            if (available == false)
            {
                // does not exist
                return false;
            }

            if (remaining < 1)
            {
                // out of tries
                return false;
            }

            return true;
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns>Returns true if ability was successfully used, false if not</returns>
        public bool UseAbility(AbilityEnum ability)
        {
            var available = AbilityTracker.TryGetValue(ability, out int remaining);
            if (available == false)
            {
                // does not exist
                return false;
            }

            if (remaining < 1)
            {
                // out of tries
                return false;
            }

            switch (ability)
			{
                case AbilityEnum.ExtraCredit:
                    GPA = (int)(GPA * Constants.SpecialAbilityGPABoostExtension);
                    break;
                case AbilityEnum.Bribes:
                    GPA = (int)(GPA * Constants.SpecialAbilityGPABoostBribes);
                    break;
                case AbilityEnum.Extension:
                    GPA = (int)(GPA * Constants.SpecialAbilityGPABoostExtension);
                    break;
                case AbilityEnum.FlashGenius:
                    GPA = (int)(GPA * Constants.SpecialAbilityGPABoostFlashGenius);
                    break;
                case AbilityEnum.PayTuition:
                    GPA = (int)(GPA * Constants.SpecialAbilityGPABoostPayTuition);
                    break;
                default:
                    break;
			}

            // Reduce the count
            AbilityTracker[ability] = remaining - 1;
            AbilityUsedInCurrentRound = true;

            return true;
        }
        #endregion Abilities

    }
}