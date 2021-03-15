using System.Collections.Generic;

using Game.Models;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;
using System.Linq;
using Game.Helpers;
using Game.ViewModels;
using System.Diagnostics;
using Game.GameRules;
using System;

namespace Game.Engine.EngineGame
{
    /* 
     * Need to decide who takes the next turn
     * Target to Attack
     * Should Move, or Stay put (can hit with weapon range?)
     * Death
     * Manage Round...
     * 
     */

    /// <summary>
    /// Engine controls the turns
    /// 
    /// A turn is when a Character takes an action or a Monster takes an action
    /// 
    /// </summary>
    public class TurnEngine : TurnEngineBase, ITurnEngineInterface
    {
        #region Algrorithm
        // Attack or Move
        // Roll To Hit
        // Decide Hit or Miss
        // Decide Damage
        // Death
        // Drop Items
        // Turn Over
        #endregion Algrorithm

        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        /// <summary>
        /// CharacterModel Attacks...
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override bool TakeTurn(PlayerInfoModel Attacker)
        {
            // Choose Action.  Such as Move, Attack etc.

            // INFO: Teams, if you have other actions they would go here.

            // If the action is not set, then try to set it or use Attact

            // Based on the current action...

            // Increment Turn Count so you know what turn number

            // Save the Previous Action off

            // Reset the Action to unknown for next time

            //throw new System.NotImplementedException();

            return base.TakeTurn(Attacker);
        }

        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            // If it is the characters turn, and NOT auto battle, use what was sent into the engine

            /*
             * The following is Used for Monsters, and Auto Battle Characters
             * 
             * Order of Priority
             * If can attack Then Attack
             * Next use Ability or Move
             */

            // Assume Move if nothing else happens

            // Check to see if ability is avaiable

            // See if Desired Target is within Range, and if so attack away

            //throw new System.NotImplementedException();
            return base.DetermineActionChoice(Attacker);
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        public override bool MoveAsTurn(PlayerInfoModel Attacker)
        {

            /*
             * TEAMS Work out your own move logic if you are implementing move
             * 
             * Mike's Logic
             * The monster or charcter will move to a different square if one is open
             * Find the Desired Target
             * Jump to the closest space near the target that is open
             * 
             * If no open spaces, return false
             * 
             */

            /*
            Auto and Manual are differently implmented.
            Auto Battle
                * Attacker range is determined by: 
                    1. monster move based on monster type. 
                        * professors can move faster (2-3 blocks)
                        * admin can only move (1-2 blocks)
                    2. character move based on character type.
                        * students can move faster (2-3 blocks)
                        * parents can only move (1-2 blocks)
                * move closest to defender by only within the range of the attacker.

            Manual Battle
                1. character selects move as action for specific player 
                2. the blocks they can move will be highlighted in color.
                3. player clicks on the highlighted color moves the character to that block
                              
             */

            // If the Monster the calculate the options
            if (Attacker.PlayerType == PlayerTypeEnum.Monster)
            {
                // For Attack, Choose Who
                EngineSettings.CurrentDefender = AttackChoice(Attacker);

                if (EngineSettings.CurrentDefender == null)
                {
                    return false;
                }

                // Get X, Y for Defender
                var locationDefender = EngineSettings.MapModel.GetLocationForPlayer(EngineSettings.CurrentDefender);
                if (locationDefender == null)
                {
                    return false;
                }

                var locationAttacker = EngineSettings.MapModel.GetLocationForPlayer(Attacker);
                if (locationAttacker == null)
                {
                    return false;
                }

                // Find Location Nearest to Defender that is Open.

                // Get the Open Locations based on range of attacker
                var openSquare = EngineSettings.MapModel.ReturnClosestEmptyLocationBasedOnRange(locationAttacker, locationDefender);

                if (EngineSettings.HackathonDebug == true)
                {
                   openSquare = EngineSettings.MapModel.ReturnClosestEmptyLocationBasedOnSpeed(locationAttacker, locationDefender);
                }

                Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", locationAttacker.Player.Name, locationAttacker.Column, locationAttacker.Row, openSquare.Column, openSquare.Row));

                EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " moves closer to " + EngineSettings.CurrentDefender.Name;

                return EngineSettings.MapModel.MovePlayerOnMap(locationAttacker, openSquare);
            }

            return true;
        }

        /// <summary>
        /// Decide to use an Ability or not
        /// 
        /// Set the Ability
        /// </summary>
        public override bool ChooseToUseAbility(PlayerInfoModel Attacker)
        {
            // See if healing is needed.

            // If not needed, then role dice to see if other ability should be used
            // Choose the % chance
            // Select the ability

            // Don't try

            //throw new System.NotImplementedException();
            return base.ChooseToUseAbility(Attacker);
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        public override bool UseAbility(PlayerInfoModel Attacker)
        {
            return base.UseAbility(Attacker);
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Use the special ability.
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns>true if ability is used, false otherwise</returns>
        public override bool UseSpecialAbility(PlayerInfoModel Attacker)
        {
            return base.UseSpecialAbility(Attacker);
        }

        /// <summary>
        /// Attack as a Turn
        /// 
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// 
        /// </summary>
        public override bool Attack(PlayerInfoModel Attacker)
        {
            // INFO: Teams, AttackChoice will auto pick the target, good for auto battle

            // Manage autobattle

            // Do Attack

            //throw new System.NotImplementedException();
            return base.Attack(Attacker);
        }

        /// <summary>
        /// Decide which to attack
        /// </summary>
        public override PlayerInfoModel AttackChoice(PlayerInfoModel data)
        {
            //throw new System.NotImplementedException();

            switch (data.PlayerType)
            {
                case PlayerTypeEnum.Monster:
                    return SelectCharacterToAttack();

                case PlayerTypeEnum.Character:
                default:
                    return SelectMonsterToAttack();
            }
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        public override PlayerInfoModel SelectCharacterToAttack()
        {
            // Select first in the list

            // Teams, You need to implement your own Logic can not use mine.
            //return base.SelectCharacterToAttack();

            //throw new System.NotImplementedException();

            /*
            Instead of taking the first available character, we chose the weakest or strongest.
            1. roll dice between 1 or 2. 
            2. if 1 we attack the weakest character
            3. if 2 we attack the strongest character
            */

            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            // roll dice
            var d2 = DiceHelper.RollDice(1, 2);
            PlayerInfoModel Defender = null;

            if (d2 == 1)
            {
                Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Character)
                .OrderBy(m => m.Level).FirstOrDefault();
                return Defender;
            }

            Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Character)
                .OrderBy(m => m.Level).LastOrDefault();

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        public override PlayerInfoModel SelectMonsterToAttack()
        {
            // Select first one to hit in the list for now...
            // Attack the Weakness (lowest HP) MonsterModel first 

            // Teams, You need to implement your own Logic can not use mine.
            //return base.SelectMonsterToAttack();
            //throw new System.NotImplementedException();

            /*
            Instead of taking the first available monster, we chose the weakest or strongest.
            1. roll dice between 1 or 2. 
            2. if 1 we attack the weakest monster
            3. if 2 we attack the strongest monster
            */

            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            // roll dice
            var d2 = DiceHelper.RollDice(1, 2);
            PlayerInfoModel Defender = null;

            if (d2 == 1)
            {
                Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                .OrderBy(m => m.Level).FirstOrDefault();
                return Defender;
            }

            Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                .OrderBy(m => m.Level).LastOrDefault();

            return Defender;
        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        public override bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            // Set Messages to empty

            // Do the Attack

            // Hackathon
            // ?? Hackathon Scenario ?? 

            // See if the Battle Settings Overrides the Roll

            // Based on the Hit Status, what to do...
            // It's a Miss

            // It's a Hit

            //Calculate Damage

            // Apply the Damage

            // Check if Dead and Remove

            // If it is a character apply the experience earned

            // Battle Message 

            //throw new System.NotImplementedException();

            //return base.TurnAsAttack(Attacker, Target);

            if (Attacker == null)
            {
                return false;
            }

            if (Target == null)
            {
                return false;
            }

            // Set Messages to empty
            EngineSettings.BattleMessagesModel.ClearMessages();

            // Do the Attack
            CalculateAttackStatus(Attacker, Target);

            // See if the Battle Settings Overrides the Roll
            EngineSettings.BattleMessagesModel.HitStatus = BattleSettingsOverride(Attacker);

            switch (EngineSettings.BattleMessagesModel.HitStatus)
            {
                case HitStatusEnum.Miss:
                    // It's a Miss

                    break;

                case HitStatusEnum.CriticalMiss:
                    // It's a Critical Miss, so Bad things may happen
                    DetermineCriticalMissProblem(Attacker);

                    break;

                case HitStatusEnum.CriticalHit:
                case HitStatusEnum.Hit:
                    // It's a Hit

                    //Calculate Damage
                    EngineSettings.BattleMessagesModel.DamageAmount = Attacker.GetDamageRollValue();

                    // If critical Hit, double the damage
                    if (EngineSettings.BattleMessagesModel.HitStatus == HitStatusEnum.CriticalHit)
                    {
                        EngineSettings.BattleMessagesModel.DamageAmount *= 2;
                    }

                    // Apply the Damage
                    ApplyDamage(Target);

                    EngineSettings.BattleMessagesModel.TurnMessageSpecial = EngineSettings.BattleMessagesModel.GetCurrentHealthMessage();

                    // Check if Dead and Remove
                    RemoveIfDead(Target);

                    // If it is a character apply the experience earned
                    CalculateExperience(Attacker, Target);

                    // check if attacker/character is graduated and remove if that's the case
                    if (Attacker.PlayerType == PlayerTypeEnum.Character)
                    {
                        RemoveIfGraduated(Attacker);
                    }

                    break;
            }
            TurnMessageResultForAttack(Attacker, Target);

            EngineSettings.BattleMessagesModel.TurnMessage =
                EngineSettings.BattleMessagesModel.TurnMessageResult + 
                Attacker.Name + EngineSettings.BattleMessagesModel.AttackStatus + Target.Name + 
                EngineSettings.BattleMessagesModel.TurnMessageSpecial + 
                EngineSettings.BattleMessagesModel.ExperienceEarned;

            Debug.WriteLine(EngineSettings.BattleMessagesModel.TurnMessage);

            return true;
        }


        /// <summary>
        /// Helper method to get the attack message 
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool TurnMessageResultForAttack(PlayerInfoModel attacker, PlayerInfoModel target)
        {
           
            if (attacker.PlayerType == PlayerTypeEnum.Character)
            {
                EngineSettings.BattleMessagesModel.TurnMessageResult = TurnMessageResultForAttackCharacter(attacker.CharacterTypeEnum, target.MonsterTypeEnum);
                return true;
            }

            if (attacker.PlayerType == PlayerTypeEnum.Monster)
            {
                EngineSettings.BattleMessagesModel.TurnMessageResult = TurnMessageResultForAttackMonster(attacker.MonsterTypeEnum, target.CharacterTypeEnum);
                return true;
            }

                return false;
        }

        /// <summary>
        /// helper method to get the attack message for Character to Monster
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string TurnMessageResultForAttackCharacter(CharacterTypeEnum attacker, MonsterTypeEnum target)
        {
            string msg = "";
            switch (EngineSettings.BattleMessagesModel.HitStatus)
            {
                case HitStatusEnum.CriticalHit:
                    msg = attacker.ToString() + CharacterTypeEnumHelper.getAttackMessage(attacker, target) + target.ToString() + ". ";
                    break;
                case HitStatusEnum.Hit:
                    msg = attacker.ToString() + CharacterTypeEnumHelper.getAttackMessage(attacker, target) + target.ToString() + ". ";
                    break;

                default:
                    break;
            }

            return msg;
        }

        /// <summary>
        /// helper method to get the attack message for Monster to Character
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string TurnMessageResultForAttackMonster(MonsterTypeEnum attacker, CharacterTypeEnum target)
        {
            string msg = "";
            switch (EngineSettings.BattleMessagesModel.HitStatus)
            {
                case HitStatusEnum.CriticalHit:
                    msg = attacker.ToString() + MonsterTypeEnumHelper.GetAttackMessage(attacker, target) + target.ToString() + ". ";
                    break;
                case HitStatusEnum.Hit:
                    msg = attacker.ToString() + MonsterTypeEnumHelper.GetAttackMessage(attacker, target) + target.ToString() + ". ";
                    break;

                default:
                    break;
            }

            return msg;
        }


        /// <summary>
        /// See if the Battle Settings will Override the Hit
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker)
        {
            //throw new System.NotImplementedException();
            return base.BattleSettingsOverride(Attacker);
        }

        /// <summary>
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum)
        {
            // Based on the Hit Status, establish a message

            //throw new System.NotImplementedException();
            return base.BattleSettingsOverrideHitStatusEnum(myEnum);
        }

        /// <summary>
        /// Apply the Damage to the Target
        /// Also target is dead if health <= 0
        /// </summary>
        public override int ApplyDamage(PlayerInfoModel Target)
        {
            //apply the damage to target, if target is less than 0, cause death
            //throw new System.NotImplementedException();
            return base.ApplyDamage(Target);
        }

        /// <summary>
        /// Calculate the Attack, return if it hit or missed.
        /// </summary>
        public override HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            //throw new System.NotImplementedException();
            // Remember Current Player
            EngineSettings.BattleMessagesModel.PlayerType = PlayerTypeEnum.Monster;

            // Choose who to attack
            EngineSettings.BattleMessagesModel.TargetName = Target.Name;
            EngineSettings.BattleMessagesModel.AttackerName = Attacker.Name;

            // Set Attack and Defense
            var AttackScore = Attacker.Level + Attacker.GetAttack();
            var DefenseScore = Target.GetDefense() + Target.Level;

            //For hackathon, making character Bob always miss... poor bob
            if (Attacker.Name == "Bob" || Attacker.Name == "bob")
            {
                return HitStatusEnum.Miss;
            }

            // Modifying for 
            if (Attacker.PlayerType == PlayerTypeEnum.Character && Attacker.CharacterTypeEnum == CharacterTypeEnum.Student)
            {
                AttackScore = Convert.ToInt32(Math.Ceiling(Attacker.Level * (0.5 + Attacker.GPA/100) + Attacker.GetAttack()));
            }

            EngineSettings.BattleMessagesModel.HitStatus = RollToHitTarget(AttackScore, DefenseScore);

            return EngineSettings.BattleMessagesModel.HitStatus;
        }

        /// <summary>
        /// Calculate Experience
        /// Level up if needed
        /// </summary>
        public override bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            //throw new System.NotImplementedException();
            //return base.CalculateExperience(Attacker, Target);
            if (Attacker.PlayerType == PlayerTypeEnum.Character)
            {
                var points = " points";

                var experienceEarned = Target.CalculateExperienceEarned(EngineSettings.BattleMessagesModel.DamageAmount);

                if (experienceEarned == 1)
                {
                    points = " point";
                }

                EngineSettings.BattleMessagesModel.ExperienceEarned = " Earned " + experienceEarned + points;

                var LevelUp = Attacker.AddExperience(experienceEarned);
                if (LevelUp)
                {
                    EngineSettings.BattleMessagesModel.LevelUpMessage = Attacker.Name + " is now Level " + Attacker.Level + " With Health Max of " + Attacker.GetMaxHealthTotal;
                    Debug.WriteLine(EngineSettings.BattleMessagesModel.LevelUpMessage);
                }

                // check if level is above 20 and holds graduation item 
                Attacker.GraduateIfLevelAboveMaxLevel();

                // Add Experinece to the Score
                EngineSettings.BattleScore.ExperienceGainedTotal += experienceEarned;
            }

            return true;
        }

        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        public override bool RemoveIfDead(PlayerInfoModel Target)
        {
            //throw new System.NotImplementedException();
            return base.RemoveIfDead(Target);
        }

        /// <summary>
        /// If Graduated process Target Graduated
        /// </summary>
        /// <param name="Target"></param>
        public bool RemoveIfGraduated(PlayerInfoModel Target)
        {
            // Check for alive
            if (Target.Graduated == true && Target.PlayerType == PlayerTypeEnum.Character)
            {
                TargetGraduated(Target);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Target Graduated
        /// 
        /// Process for graduation...
        /// </summary>
        /// <param name="Target"></param>
        public virtual bool TargetGraduated(PlayerInfoModel Character)
        {
            bool found;

            // Mark Status in output
            EngineSettings.BattleMessagesModel.TurnMessageSpecial = " and causes graduation! ";

            // Removing the 
            EngineSettings.MapModel.RemovePlayerFromMap(Character);

            // Add the Character to the killed list
            EngineSettings.BattleScore.GraduateList += Character.FormatOutput() + "\n";

            EngineSettings.BattleScore.GraduateModelList.Add(Character);

            //DropItems(Target);

            found = EngineSettings.CharacterList.Remove(EngineSettings.CharacterList.Find(m => m.Guid.Equals(Character.Guid)));
            found = EngineSettings.PlayerList.Remove(EngineSettings.PlayerList.Find(m => m.Guid.Equals(Character.Guid)));

            return true;
        }

        /// <summary>
        /// Target Died
        /// 
        /// Process for death...
        /// 
        /// Returns the count of items dropped at death
        /// </summary>
        public override bool TargetDied(PlayerInfoModel Target)
        {
            // Mark Status in output

            // Removing the 

            // INFO: Teams, Hookup your Boss if you have one...

            // Using a switch so in the future additional PlayerTypes can be added (Boss...)
            // Add the Character to the killed list

            // Add one to the monsters killed count...

            // Add the MonsterModel to the killed list

            //throw new System.NotImplementedException();
            return base.TargetDied(Target);
        }

        /// <summary>
        /// Drop Items
        /// </summary>
        public override int DropItems(PlayerInfoModel Target)
        {
            // Drop Items to ItemModel Pool

            // I feel generous, even when characters die, random drops happen :-)
            // If Random drops are enabled, then add some....

            // Add to ScoreModel

            //throw new System.NotImplementedException();
            //return base.DropItems(Target);
            
            var DroppedMessage = "\nItems Dropped : \n";

            // Drop Items to ItemModel Pool
            var myItemList = Target.DropAllItems();

            // Get the monster's unique drop item.
            if (Target.PlayerType == PlayerTypeEnum.Monster)
            {
                var myItem = ItemIndexViewModel.Instance.GetItem(Target.UniqueDropItem);
                if (myItem != null)
                {
                    myItemList.Add(myItem);
                }
            }

            // I feel generous, even when characters die, random drops happen :-)
            // If Random drops are enabled, then add some....

            // add item only if is not null
            foreach (ItemModel item in GetRandomMonsterItemDrops(EngineSettings.BattleScore.RoundCount))
            {
                if (item != null)
                {
                    myItemList.Add(item);
                }
            }

            //myItemList.AddRange(GetRandomMonsterItemDrops(EngineSettings.BattleScore.RoundCount));

            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                EngineSettings.BattleScore.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                DroppedMessage += ItemModel.Name + "\n";
            }

            EngineSettings.ItemPool.AddRange(myItemList);

            if (myItemList.Count == 0)
            {
                DroppedMessage = " Nothing dropped. ";
            }

            EngineSettings.BattleMessagesModel.DroppedMessage = DroppedMessage;

            EngineSettings.BattleScore.ItemModelDropList.AddRange(myItemList);

            return myItemList.Count();

        }

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        public override HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            //throw new System.NotImplementedException();
            return base.RollToHitTarget(AttackScore, DefenseScore);
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        public override List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // Teams, You need to implement your own modification to the Logic cannot use mine as is.

            // You decide how to drop monster items, level, etc.

            // The Number drop can be Up to the Round Count, but may be less.  
            // Negative results in nothing dropped

            //return base.GetRandomMonsterItemDrops(round);
            //throw new System.NotImplementedException();

            /*
            Once monster is killed for the round, they will drop their item. 
                1. find which monsters were killed
                2. see if they have drop item
                3. move that item to the list. make a copy of it. 
            
            List<PlayerInfoModel> DeadMonster = EngineSettings.BattleScore.MonsterModelDeathList;
            var result = new List<ItemModel>();

            foreach (PlayerInfoModel monster in DeadMonster)
            {
                var data = ItemIndexViewModel.Instance.GetItem(monster.UniqueDropItem);
                result.Add(data);
            }

            return result;
            */


            /*
            TODO: call get monsterUniqueItem with our game flavor random items
            
            We added in another method for helper. 

            */
            var NumberToDrop = (DiceHelper.RollDice(1, round + 1) - 1);

            var result = new List<ItemModel>();

            for (var i = 0; i < NumberToDrop; i++)
            {
                // Get a random Unique Item
                var data = ItemIndexViewModel.Instance.GetItem(RandomPlayerHelper.GetMonsterUniqueItem());
                result.Add(data);
            }

            return result;
        }

        /// <summary>
        /// Critical Miss Problem
        /// </summary>
        public override bool DetermineCriticalMissProblem(PlayerInfoModel attacker)
        {
            //throw new System.NotImplementedException();
            return base.DetermineCriticalMissProblem(attacker);
        }
    }
}