using NUnit.Framework;

using Game.Models;
using System.Threading.Tasks;
using Game.ViewModels;
using Game.Helpers;
using System.Linq;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        #region TestSetup
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        [SetUp]
        public void Setup()
        {
            // Choose which engine to run
            //EngineViewModel.SetBattleEngineToKoenig();
            EngineViewModel.SetBattleEngineToGame();

            // Put seed data into the system for all tests
            EngineViewModel.EngineGame.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            EngineViewModel.EngineGame.StartBattle(false);

            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Scenario0
        [Test]
        public void HakathonScenario_Scenario_0_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert


            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Scenario0

        #region Scenario1
        [Test]
        public async Task HackathonScenario_Scenario_1_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, EngineViewModel.Engine.EngineSettings.BattleScore.RoundCount);
        }

        #endregion Scenario1

        #region Scenario14
        [Test]
        public async Task HackathonScenario_Scenario_14_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      14
            *      
            * Description: 
            *      Start a Boss Battle, which replaces 6 monsters with 1 boss based on roll chances 
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Changed AddMonstersToRound:
            *           * make sure EngineSettingsModel.Instance.HackathonDebug == true
            *           * if dice roll is higher than likelihood % then clear monster list and add 1 big boss:
            *           MonsterModel BigBoss = new MonsterModel
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
                            ImageURI = Constants.SpecificMonsterTypeProfessorImageURI,
                        };
            * 
            * Test Algrorithm:
            *      turn EngineSettingsModel.Instance.HackathonDebug to be true
            *      force dice roll to be higher than likelihood (in our case keep likelihood 0)
            *      force the game to only have 1 round and 1 turn so we can see what is added in the monster list
            *  
            *      Startup Battle
            *      Start auto battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify there is only one monster
            *      Verify the monster list monster includes big boss
            *  
            */

            //Arrange

            // Set Character Conditions

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = true;
            EngineViewModel.EngineGame.EngineSettings.MaxRoundCount = 1;
            EngineViewModel.EngineGame.EngineSettings.MaxTurnCount = 1;

            //Act
            var result = await EngineViewModel.AutoBattleEngineGame.RunAutoBattle();

            //Reset
            DiceHelper.DisableForcedRolls();
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;
            EngineViewModel.EngineGame.EngineSettings.MaxRoundCount = 100;
            EngineViewModel.EngineGame.EngineSettings.MaxTurnCount = 1000;

            //Assert
            // validate monster is big boss
            //Assert.IsFalse(result);
            Assert.AreEqual(1, EngineViewModel.EngineGame.EngineSettings.MonsterList.Count());
            Assert.AreEqual("Mike Koenig", EngineViewModel.EngineGame.EngineSettings.MonsterList.FirstOrDefault().Name);
        }

        #endregion Scenario14


        #region Scenario25
        [Test]
        public async Task HackathonScenario_Scenario_25_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      25
            *      
            * Description: 
            * Drop an Item if the Target took a hit (probabilistic)
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      TurnEngineBase.cs – Added LoseDamagedItem() method into AddDamage() in TurnBaseEngine.cs 
            *      TurnEngineBase.cs – Added LoseDamagedItem_Probability as a hardcoded public int
            *      PlayerInfoModel.cs - Added a LoseDamagedItem switch
            *      
            * Test Algorithm:
            *      Create Character with a droppable item in RightFinger
            *      Create a Monster Hit
            *      Set CurrentAction to ActionEnum.Attack
            *      Set hackathon debug to true
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify that DroppedItemList has a new addition
            *  
            */

            //Arrange

            // This works in Attack mode
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = true;
            EngineViewModel.EngineGame.EngineSettings.CurrentAction = ActionEnum.Attack;

            // Set Character Conditions
            EngineViewModel.EngineGame.EngineSettings.MaxNumberPartyCharacters = 1;
            var character = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 0,
                                Level = 1,
                                RightFinger = "IndexCards1",
                                CurrentHealth = 2,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "WeakDefender"
                            });
            character.LoseDamagedItem = true;

            EngineViewModel.EngineGame.EngineSettings.CharacterList.Clear();
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Add(character);
            // Setting a monster as attacker, and our character as defender
            EngineViewModel.EngineGame.EngineSettings.CurrentAttacker = EngineViewModel.EngineGame.EngineSettings.MonsterList[0];
            EngineViewModel.EngineGame.EngineSettings.CurrentDefender = character;


            // Monster hits, and to make things simpler, the character misses
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;
            //EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;
            EngineViewModel.EngineGame.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Hit;

            // Start with empty Dropped Item List
            //EngineViewModel.EngineGame.EngineSettings.BattleScore.ItemModelDropList.Clear();

            //Act
            var result = await EngineViewModel.AutoBattleEngineGame.RunAutoBattle();

            //Assert
            Assert.IsTrue(result);
            // Dropped Item List adds the item
            Assert.IsNull(EngineViewModel.EngineGame.EngineSettings.CurrentDefender.RightFinger);
            //Assert.IsTrue(EngineViewModel.EngineGame.EngineSettings.BattleScore.ItemModelDropList.Count > 0);

            // Reset
            EngineViewModel.EngineGame.EngineSettings.CurrentAttacker = null;
            EngineViewModel.EngineGame.EngineSettings.CurrentDefender = null;
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Clear();
            //EngineViewModel.EngineGame.EngineSettings.BattleScore.ItemModelDropList.Clear();
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;
            EngineViewModel.EngineGame.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Unknown;

        }
        #endregion Scenario25

        #region Scenario34
        [Test]
        public async Task HackathonScenario_Scenario_34_Valid_WantsToRest_True_Should_Pass()
        {

            /*
             * Test 1/2.
             * 
            * Scenario Number:  
            *      34
            *      
            * Description: 
            *      Take 5... 
            *      Why is it that a character must take an action?  
            *      Can’t a hard-working character just sit back and take a break? 
            *      Allow characters to choose to do nothing for their turn, they just sit back and take in 
            *      all that is happening around them. Resting restores 2 health per rest.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      PlayerInfoModel - Add variable to track number of FiveMinuteBreaks character has taken. Also add variable that indicates if player wants to rest. 
            *      ActionEnum.cs - Added ActionEnum.Rest
            *      TurnEngineBase.cs - Added case for ActionEnum.Rest which calls RestAsTurn(Attacker)
            * 
            * Test Algorithm:
            *      Create Character named Minnie
            *      Set speed to 100 so she goes first
            *      Set Current Health to 100 to ensure she survives long enough to take a couple of turns
            *      Set character.WantsToRest to true
            *      Set hackathon debug to true
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Requires two tests: one where WantsToRest is set to true and one where it's set to false. 
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify dead character Minnie's FiveMinuteBreaks is greater than 0
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.EngineGame.EngineSettings.MaxNumberPartyCharacters = 1;

            var character = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Minnie",
                            });
            character.WantsToRest = true;

            EngineViewModel.EngineGame.EngineSettings.CharacterList.Clear();
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Add(character);

            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = true;

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            // Minnie always misses when she attacks
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;

            //Act
            var result = await EngineViewModel.AutoBattleEngineGame.RunAutoBattle();

            //Reset
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(EngineViewModel.EngineGame.EngineSettings.BattleScore.CharacterModelDeathList[0].FiveMinuteBreaks > 0);

        }

        [Test]
        public async Task HackathonScenario_Scenario_34_Valid_WantsToRest_False_Should_Pass()
        {

            /*
             * Test 2/2.
             * 
            * Scenario Number:  
            *      34
            *      
            * Description: 
            *      Take 5... 
            *      Why is it that a character must take an action?  
            *      Can’t a hard-working character just sit back and take a break? 
            *      Allow characters to choose to do nothing for their turn, they just sit back and take in 
            *      all that is happening around them. Resting restores 2 health per rest.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      PlayerInfoModel - Add variable to track number of FiveMinuteBreaks character has taken. Also add variable that indicates if player wants to rest. 
            *      ActionEnum.cs - Added ActionEnum.Rest
            *      TurnEngineBase.cs - Added case for ActionEnum.Rest which calls RestAsTurn(Attacker)
            * 
            * Test Algorithm:
            *      Create Character named Minnie
            *      Set speed to 100 so she goes first
            *      Set Current Health to 100 to ensure she survives long enough to take a couple of turns
            *      Set character.WantsToRest to false
            *      Set hackathon debug to true
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Requires two tests: one where WantsToRest is set to true and one where it's set to false. 
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify dead character Minnie's FiveMinuteBreaks is == 0
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.EngineGame.EngineSettings.MaxNumberPartyCharacters = 1;

            var character = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Minnie",
                            });
            character.WantsToRest = false;

            EngineViewModel.EngineGame.EngineSettings.CharacterList.Clear();
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Add(character);

            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = true;

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            // Minnie always misses when she attacks
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;

            //Act
            var result = await EngineViewModel.AutoBattleEngineGame.RunAutoBattle();

            //Reset
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(EngineViewModel.EngineGame.EngineSettings.BattleScore.CharacterModelDeathList[0].FiveMinuteBreaks == 0);

        }
        #endregion Scenario34

        #region Scenario35
        [Test]
        public async Task HackathonScenario_Scenario_35_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      35
            *      
            * Description: 
            *      Move based on speed
            *      Limit the distance a player can move to their speed attribute. 
            *      If a player has speed of 3, then they can move 3 squares, a speed of 6 can move 6 etc.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      MapModel - created a new method to move based on speed limit of the playerInfoModel. 
            *      TurnEngine - if debug is turned on use speed variable to figure out distance moved. 
            * 
            * Test Algorithm:
            *      Create Character named SlowPoke
            *      Set speed to 1
            *      Set current action to Move
            *      Set hackathon debug to true
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Test that current 
            * 
            * Validation:
            *      Verify Battle Returned True
            *  
            */

            //Arrange

            // Add Characters

            // To See Level UP happening, a character needs to be close to the next level
            var character = new PlayerInfoModel
            {
                ExperienceTotal = 300,
                Name = "Mike Level Example",
                Level = 19,
                Speed = -1,    // Go last
                PlayerType = PlayerTypeEnum.Character
            };

            var save = EngineViewModel.EngineGame.EngineSettings.CharacterList;

            EngineViewModel.EngineGame.EngineSettings.MaxNumberPartyCharacters = 1;
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Clear();
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Add(character);
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = true;

            // Set current action to Move
            EngineViewModel.EngineGame.EngineSettings.CurrentAction = ActionEnum.Move;

            //Act
            var result = await EngineViewModel.AutoBattleEngineGame.RunAutoBattle();

            //Reset
            EngineViewModel.EngineGame.EngineSettings.CharacterList = save;
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(true, EngineViewModel.EngineGame.EngineSettings.BattleScore.CharacterAtDeathList.Contains("Mike Level Example"));
        }
        #endregion Scenario35

        #region Scenario38
        [Test]
        public async Task HackathonScenario_Scenario_38_Valid_Slip_100_Likelihood_Should_Pass()
        {

            /* 
             * Test 1/2.
             * 
            * Scenario Number:  
            *     38
            *      
            * Description: 
            *     Black Ice in Seattle 
            *     Just like a cold January, black ice forms on the map and everyone takes a chance of 
            *     slipping and falling instead of carrying out their action.  Use the settings to enable 
            *     Seattle Winter, and set the percentage change of slipping while going out to get a latte.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Create Seattle Winter setting in EngineSettingsModel
            *      Create SeattleWinterLikelihood variable in EngineSettingsModel - this will be a floating number between 0 and 1. 
            *      Add SlippedNumTimes variable to PlayerInfoModel so we can track how many times a character slipped 
            *      Create new action enum in ActionEnum - ActionEnum.Slip
            *      Add case for ActionEnum.Slip to TurnEngineBase.cs + method for SlipAsTurn that will cause some damage (because it hurts to slip and fall)
            *      
            * 
            * Test Algorithm:
            *      Create Character named Minnie
            *      Set Seattle Winter setting to true
            *      Set Seattle WinterLikelihood to 100 so it's 100% sure we will slip and fall
            *      Set speed to 100 so we go first. 
            *      Set health to 100 so we can ensure to stay alive for a little while
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Requires 2 tests: One where likelihood is 100% and slip always happens, and one where likelihood is 0 and slip never happens
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify dead character Minnie's SlippedNumTimes is greater than 0
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = true;

            EngineViewModel.EngineGame.EngineSettings.MaxNumberPartyCharacters = 1;

            var character = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Minnie",
                            });

            EngineViewModel.EngineGame.EngineSettings.CharacterList.Clear();
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Add(character);

            EngineViewModel.EngineGame.EngineSettings.SeattleWinter = true;
            EngineViewModel.EngineGame.EngineSettings.SeattleWinterLikelihood = 100;

            // Set Monster Conditions

            // Monsters always hit
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            // Minnie always misses when she attacks
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;


            //Act
            var result = await EngineViewModel.AutoBattleEngineGame.RunAutoBattle();

            //Reset
            EngineViewModel.EngineGame.EngineSettings.SeattleWinter = false;
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(EngineViewModel.EngineGame.EngineSettings.BattleScore.CharacterModelDeathList[0].SlippedNumTimes > 0);
        }

        [Test]
        public async Task HackathonScenario_Scenario_38_Valid_Slip_0_Likelihood_Should_Pass()
        {

            /* 
             * Test 2/2. 
             * 
            * Scenario Number:  
            *     38
            *      
            * Description: 
            *     Black Ice in Seattle 
            *     Just like a cold January, black ice forms on the map and everyone takes a chance of 
            *     slipping and falling instead of carrying out their action.  Use the settings to enable 
            *     Seattle Winter, and set the percentage change of slipping while going out to get a latte.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Create Seattle Winter setting in EngineSettingsModel
            *      Create SeattleWinterLikelihood variable in EngineSettingsModel - this will be a floating number between 0 and 1. 
            *      Add SlippedNumTimes variable to PlayerInfoModel so we can track how many times a character slipped 
            *      Create new action enum in ActionEnum - ActionEnum.Slip
            *      Add case for ActionEnum.Slip to TurnEngineBase.cs + method for SlipAsTurn that will cause some damage (because it hurts to slip and fall)
            *      
            * 
            * Test Algorithm:
            *      Create Character named Minnie
            *      Set Seattle Winter setting to true
            *      Set Seattle WinterLikelihood to 0 so it never slips.
            *      Set speed to 100 so we go first. 
            *      Set health to 100 so we can ensure to stay alive for a little while
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Requires 2 tests: One where likelihood is 100% and slip always happens, and one where likelihood is 0 and slip never happens
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify dead character Minnie's SlippedNumTimes is greater than 0
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = true;

            EngineViewModel.EngineGame.EngineSettings.MaxNumberPartyCharacters = 1;

            var character = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 1,
                                CurrentHealth = 100,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Minnie",
                            });

            EngineViewModel.EngineGame.EngineSettings.CharacterList.Clear();
            EngineViewModel.EngineGame.EngineSettings.CharacterList.Add(character);

            EngineViewModel.EngineGame.EngineSettings.SeattleWinter = true;
            EngineViewModel.EngineGame.EngineSettings.SeattleWinterLikelihood = 0;

            // Set Monster Conditions

            // Monsters always hit
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            // Minnie always misses when she attacks
            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;


            //Act
            var result = await EngineViewModel.AutoBattleEngineGame.RunAutoBattle();

            //Reset
            EngineViewModel.EngineGame.EngineSettings.SeattleWinter = false;
            EngineViewModel.EngineGame.EngineSettings.HackathonDebug = false;

            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(EngineViewModel.EngineGame.EngineSettings.BattleScore.CharacterModelDeathList[0].SlippedNumTimes == 0);
        }
        #endregion Scenario38
    }
}