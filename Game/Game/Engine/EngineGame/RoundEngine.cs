using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.GameRules;
using Game.Helpers;
using Game.Models;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// Manages the Rounds
    /// </summary>
    public class RoundEngine : RoundEngineBase, IRoundEngineInterface
    {
        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        //// The Turn Engine
        //public new ITurnEngineInterface Turn
        //{
        //    get
        //    {
        //        if (base.Turn == null)
        //        {
        //            base.Turn = new TurnEngine();
        //        }
        //        return base.Turn;
        //    }
        //    set { base.Turn = Turn; }
        //}

        public RoundEngine()
        {
            Turn = new TurnEngine();
        }

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        public override bool ClearLists()
        {
            EngineSettings.ItemPool.Clear();
            EngineSettings.MonsterList.Clear();
            return true;
        }

        /// <summary>
        /// Call to make a new set of monsters..
        /// </summary>
        public override bool NewRound()
        {
            // End the existing round
            EndRound();

            // Remove Character Buffs
            RemoveCharacterBuffs();

            // Populate New Monsters..
            AddMonstersToRound();

            // Make the BaseEngine.PlayerList
            MakePlayerList();

            // Set Order for the Round
            OrderPlayerListByTurnOrder();

            // Populate BaseEngine.MapModel with Characters and Monsters
            EngineSettings.MapModel.PopulateMapModel(EngineSettings.PlayerList);

            // Update Score for the RoundCount
            EngineSettings.BattleScore.RoundCount++;

            return true;
        }

        /// <summary>
        /// Add Monsters to the Round
        /// 
        /// Because Monsters can be duplicated, will add 1, 2, 3 to their name
        ///   
        /*
            * Hint: 
            * I don't have crudi monsters yet so will add 6 new ones..
            * If you have crudi monsters, then pick from the list

            * Consdier how you will scale the monsters up to be appropriate for the characters to fight
            * 
            */
        /// </summary>
        /// <returns></returns>
        public override int AddMonstersToRound()
        {
            // Teams, You need to implement your own Logic can not use mine.
            
            //return base.AddMonstersToRound();
            
            //throw new System.NotImplementedException();

            /*
            Ideas for adding monsters to round:
            1. check what levels are in character list, maybe take it as an average of the levels. 
            2. add in the monsters similar to base by adding in random monster, except we 
               add them based on specific monster type. then adjust the values based on average level of monster.
            3. if any character is on level 18+, they will need to fight the Graduation Office Administrator
               which will hold Graduation cap and robe. 
            */

            int TargetLevel = 1;
            bool ContainHighLevelCharacter = false;
            int MaxParty = EngineSettings.MaxNumberPartyMonsters;

            // get the average level of characters
            if (EngineSettings.CharacterList.Count() > 0)
            {
                // Get the average
                TargetLevel = Convert.ToInt32(EngineSettings.CharacterList.Average(m => m.Level));

                // if character list contains level higher than 17
                if (EngineSettings.CharacterList.Find(m => (m.Level > 17)) != null)
                {
                    ContainHighLevelCharacter = true;
                    // Add graduate monster
                    MaxParty--;
                }
                
            }

            // load the monsters list
            for (var i = 0; i < MaxParty; i++)
            {
                var data = RandomPlayerHelper.GetRandomMonsterEscapingSchool(TargetLevel);

                // Help identify which Monster it is
                data.Name += " " + EngineSettings.MonsterList.Count() + 1;

                EngineSettings.MonsterList.Add(new PlayerInfoModel(data));
            }

            // if the character contains level higher than 17+ then we add a big boss monster
            // if player beats this monster the student will graduate! 
            if (ContainHighLevelCharacter)
            {
                MonsterModel BigBoss = ViewModels.MonsterIndexViewModel.Instance.GetDefaultMonster(SpecificMonsterTypeEnum.GraduationOfficeAdministrator);
                if (BigBoss == null)
                {
                    var Item = ViewModels.ItemIndexViewModel.Instance.GetDefaultItemTypeItem(ItemTypeEnum.GraduationCapAndRobe);
                    BigBoss = new MonsterModel{ 
                        PlayerType = PlayerTypeEnum.Monster,
                        MonsterTypeEnum = MonsterTypeEnum.Administrator,
                        SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.GraduationOfficeAdministrator,
                        Name = "Mr. Smith",
                        Description = "You have graduated!!!",
                        Attack = 8,
                        Difficulty = DifficultyEnum.Difficult,
                        UniqueDropItem = Item.Id,
                        ImageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI};
                }

                EngineSettings.MonsterList.Add(new PlayerInfoModel(BigBoss));
                // Add MaxNumberPartyMonster back.
                MaxParty++;
            }


            if (EngineSettingsModel.Instance.HackathonDebug == true)
            {
                var d2 = DiceHelper.RollDice(1, 10);
                // 50/50 chance of it occuring with boss battle
                if (d2 % 2 == 0)
                {
                    // clear the monster list
                    EngineSettings.MonsterList.Clear();

                    // add in the new badass monster
                    MonsterModel BigBoss = new MonsterModel
                    {
                        PlayerType = PlayerTypeEnum.Monster,
                        MonsterTypeEnum = MonsterTypeEnum.Faculty,
                        SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Professor,
                        Name = "Mike Koenig",
                        Description = "You will never graduate!!!",
                        Attack = 10,
                        Range = 5,
                        Level = 20,
                        Difficulty = DifficultyEnum.Difficult,
                        ImageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI
                    };

                    EngineSettings.MonsterList.Add(new PlayerInfoModel(BigBoss));
                }
            }

            return EngineSettings.MonsterList.Count();
            
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List
        /// Clear the MonsterModel List
        /// </summary>
        public override bool EndRound()
        {
            // In Auto Battle this happens and the characters get their items, In manual mode need to do it manualy
            if (EngineSettings.BattleScore.AutoBattle)
            {
                PickupItemsForAllCharacters();
            }

            // Reset Monster and Item Lists
            ClearLists();

            return true;
        }

        /// <summary>
        /// For each character pickup the items
        /// </summary>
        public override bool PickupItemsForAllCharacters()
        {
            // In Auto Battle this happens and the characters get their items
            // When called manualy, make sure to do the character pickup before calling EndRound

            //throw new System.NotImplementedException();
            return base.PickupItemsForAllCharacters();
        }

        /// <summary>
        /// Manage Next Turn
        /// 
        /// Decides Who's Turn
        /// Remembers Current Player
        /// 
        /// Starts the Turn
        /// 
        /// </summary>
        public override RoundEnum RoundNextTurn()
        {
            // No characters, game is over..

            // Check if round is over

            // If in Auto Battle pick the next attacker

            // Do the turn..

            //throw new System.NotImplementedException();

            // No characters, game is over...

            if (CheckGraduationCeremony())
            {
                EngineSettings.RoundStateEnum = RoundEnum.GraduationCeremony;
                return EngineSettings.RoundStateEnum;
            }

            if (EngineSettings.CharacterList.Count < 1)
            {
                // Game Over
                EngineSettings.RoundStateEnum = RoundEnum.GameOver;
                return EngineSettings.RoundStateEnum;
            }

            // Check if round is over
            if (EngineSettings.MonsterList.Count < 1)
            {
                // If over, New Round
                EngineSettings.RoundStateEnum = RoundEnum.NewRound;
                return RoundEnum.NewRound;
            }

            if (EngineSettings.BattleScore.AutoBattle)
            {
                // Decide Who gets next turn
                // Remember who just went...
                EngineSettings.CurrentAttacker = GetNextPlayerTurn();

                // Only Attack for now if CurrentAction is set to Unknown, else do the action
                if (EngineSettings.CurrentAction == ActionEnum.Unknown)
                {
                    EngineSettings.CurrentAction = ActionEnum.Attack;
                }
            }

            // Do the turn....
            Turn.TakeTurn(EngineSettings.CurrentAttacker);

            EngineSettings.RoundStateEnum = RoundEnum.NextTurn;

            return EngineSettings.RoundStateEnum;
        }

        /// <summary>
        /// Helper to check if it meets the graduation ceremony conditions
        /// </summary>
        /// <returns></returns>
        public bool CheckGraduationCeremony()
        {
            // students still in school
            if (EngineSettings.CharacterList.Any(m => m.CharacterTypeEnum == CharacterTypeEnum.Student))
            {
                return false;
            }

            // no one gradated
            if (EngineSettings.BattleScore.GraduateModelList.Count() == 0)
            {
                return false;
            }

            // no students left, and some people graduated!
            return true;
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        public override PlayerInfoModel GetNextPlayerTurn()
        {
            // Remove the Dead

            // Get Next Player

            //throw new System.NotImplementedException();

            return base.GetNextPlayerTurn();
        }

        /// <summary>
        /// Remove Dead Players from the List
        /// </summary>
        public override List<PlayerInfoModel> RemoveDeadPlayersFromList()
        {
            //throw new System.NotImplementedException();
            return base.RemoveDeadPlayersFromList();
        }

        /// <summary>
        /// Remove Graduated and Dead Players from the List
        /// </summary>
        public List<PlayerInfoModel> RemoveGraduatedandDeadPlayersFromList()
        {
            // if player has graduated, then we can remove them
            // all players have Graduated as false to default
            EngineSettings.PlayerList = EngineSettings.PlayerList.Where(m => (m.Alive == true && m.Graduated == false)).ToList();
            return EngineSettings.PlayerList;
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public override List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            // TODO Teams: Implement the order

            //throw new System.NotImplementedException();

            // TODO: remove use of base!!
            return base.OrderPlayerListByTurnOrder();
        }

        /// <summary>
        /// Who is Playing this round?
        /// </summary>
        public override List<PlayerInfoModel> MakePlayerList()
        {
            // Start from a clean list of players

            // Remember the Insert order, used for Sorting

            // Add the Characters

            // Add the Monsters

            //throw new System.NotImplementedException();
            return base.MakePlayerList();
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        public override PlayerInfoModel GetNextPlayerInList()
        {
            // Walk the list from top to bottom
            // If Player is found, then see if next player exist, if so return that.
            // If not, return first player (looped)

            // If List is empty, return null

            // No current player, so set the first one

            // Find current player in the list

            // If at the end of the list, return the first element

            // Return the next element

            //throw new System.NotImplementedException();
            
            return base.GetNextPlayerInList();
        }

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        public override bool PickupItemsFromPool(PlayerInfoModel character)
        {

            // TODO: Teams, You need to implement your own Logic if not using auto apply

            // I use the same logic for Auto Battle as I do for Manual Battle

            //throw new System.NotImplementedException();

            // TODO: remove use of base!! 
            /*
            We will be implementing different logic depending on Auto Battle and Manual Battle. 
            Auto Battle:
                1. same idea as current auto battle, except parents cannot pickup item for head and feet
                2. if graduation cap exist, place it with high level character

            Manual Battle:
                1. only load the items for character if they can hold it. Parents cannot load head or feet
                2. then player picks it up. 
                3. create a method to load the drop down list. 

            We will have a button for auto assign based on auto battle on manual battle. 
            */
            
            if (EngineSettings.BattleScore.AutoBattle)
            {
                if (character.CharacterTypeEnum == CharacterTypeEnum.Student && character.Level > 17)
                {
                    if (EngineSettings.ItemPool.Any(m => m.ItemType == ItemTypeEnum.GraduationCapAndRobe))
                    {
                        ItemModel GradItem = EngineSettings.ItemPool.Find(m => m.ItemType == ItemTypeEnum.GraduationCapAndRobe);
                        character.Head = GradItem.Id;
                        EngineSettings.ItemPool.Remove(GradItem);
                    }
                }
                
                GetItemFromPoolIfBetter(character, ItemLocationEnum.Necklace);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.PrimaryHand);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.OffHand);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.RightFinger);
                GetItemFromPoolIfBetter(character, ItemLocationEnum.LeftFinger);



                // Have the character, walk the items in the pool, and decide if any are better than current one.
                if (character.CharacterTypeEnum == CharacterTypeEnum.Student)
                {
                    GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
                    GetItemFromPoolIfBetter(character, ItemLocationEnum.Feet);
                }

                return true;
            }

            // if manual play
            return base.PickupItemsFromPool(character);
        }

        /// <summary>
        /// Swap out the item if it is better
        /// 
        /// Uses Value to determine
        /// </summary>
        public override bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            //throw new System.NotImplementedException();
            return base.GetItemFromPoolIfBetter(character, setLocation);
        }

        /// <summary>
        /// Swap the Item the character has for one from the pool
        /// 
        /// Drop the current item back into the Pool
        /// </summary>
        public override ItemModel SwapCharacterItem(PlayerInfoModel character, ItemLocationEnum setLocation, ItemModel PoolItem)
        {
            //throw new System.NotImplementedException();
            return base.SwapCharacterItem(character, setLocation, PoolItem);
        }

        /// <summary>
        /// For all characters in player list, remove their buffs
        /// </summary>
        public override bool RemoveCharacterBuffs()
        {
            //throw new System.NotImplementedException();
            return base.RemoveCharacterBuffs();
        }
    }
}