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
            *           * if dice roll is even then clearn monster list and add 1 boss:
            *           MonsterModel BigBoss = new MonsterModel
                        {
                            PlayerType = PlayerTypeEnum.Monster,
                            MonsterTypeEnum = MonsterTypeEnum.Administrator,
                            SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.GraduationOfficeAdministrator,
                            Name = "Mike Koenig",
                            Description = "You will never graduate!!!",
                            Attack = 10,
                            Range = 5,
                            Level = 20,
                            Difficulty = DifficultyEnum.Difficult,
                            ImageURI = Constants.SpecificMonsterTypeGraduationOfficeAdministratorImageURI
                        };
            * 
            * Test Algrorithm:
            *      turn EngineSettingsModel.Instance.HackathonDebug to be true
            *      force dice roll to be even (in our case keep it 2)
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
            Assert.AreEqual(1, EngineViewModel.EngineGame.EngineSettings.MonsterList.Count());
            Assert.AreEqual("Mike Koenig", EngineViewModel.EngineGame.EngineSettings.MonsterList.FirstOrDefault().Name);
        }

        #endregion Scenario14

        #region Scenario34
        [Test]
        public async Task HackathonScenario_Scenario_34_Valid_Default_Should_Pass()
        {
        
            /* 
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
            *      PlayerInfoModel - Add variable to track number of FiveMinuteBreaks character has taken
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
            *      Test that current 
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
        #endregion Scenario34


    }
}