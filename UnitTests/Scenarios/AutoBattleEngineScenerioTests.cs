using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.Helpers;
using Game.ViewModels;

namespace Scenario
{
    [TestFixture]
    public class AutoBattleEngineScenarioTests
    {
        AutoBattleEngine AutoBattle;

        [SetUp]
        public void Setup()
        {
            AutoBattle = new AutoBattleEngine();

            AutoBattle.Battle.EngineSettings.CharacterList.Clear();
            AutoBattle.Battle.EngineSettings.MonsterList.Clear();
            AutoBattle.Battle.EngineSettings.CurrentDefender = null;
            AutoBattle.Battle.EngineSettings.CurrentAttacker = null;

            AutoBattle.Battle.StartBattle(true);   // Clear the Engine
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void AutoBattleEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AutoBattle;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Monsters_1_Should_Pass()
        {
            //Arrange

            // Add Characters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMike);


            // Add Monsters

            // Need to set the Monster count to 1, so the battle goes to Next Round Faster
            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 1;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }

		[Test]
		public async Task AutoBattleEngine_RunAutoBattle_Character_Level_Up_Should_Pass()
		{

			/* 
             * Test to force leveling up of a character during the battle
             * 
             * 1 Character, Experience set at next level mark
             * 
             * 6 Monsters
             * 
             * Character Should Level UP 1 level
             * 
             */

			//Arrange

			// Add Characters

			AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

			CharacterIndexViewModel.Instance.Dataset.Clear();

			// To See Level UP happening, a character needs to be close to the next level
			var character = new PlayerInfoModel
			{
                ExperienceTotal = 300,
				Name = "Mike Level Example",
				Speed = 100,    // Go first
                PlayerType = PlayerTypeEnum.Character
			};

            var save = AutoBattle.Battle.EngineSettings.CharacterList;
            AutoBattle.Battle.EngineSettings.CharacterList.Clear();
            AutoBattle.Battle.EngineSettings.CharacterList.Add(character);


			// Add Monsters

			//Act
			var result = await AutoBattle.RunAutoBattle();

            //Reset
            AutoBattle.Battle.EngineSettings.CharacterList.Clear();
            AutoBattle.Battle.EngineSettings.CharacterList = save; 

            //Assert
            Assert.AreEqual(true, result);
			Assert.AreEqual(true, AutoBattle.Battle.EngineSettings.BattleScore.CharacterAtDeathList.Contains("Mike Level Example"));
			// Assert.AreEqual(StartLevel+1, Engine.EngineSettings.BattleScore.CharacterModelDeathList.Where(m=>m.Guid.Equals(Character.Guid)).First().Level);
		}

        // TODO: WORK IN PROGRESS: This test will not yet test the MoveAsTurn because the only ActionEnum available
        // for autobattle is Attack. 
        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Monster_MoveAsTurn_Should_Pass()
        {

            /* 
             * Test to force leveling up of a character during the battle
             * 
             * 1 Character, Experience set at next level mark
             * 
             * 6 Monsters
             * 
             * Character Should Level UP 1 level
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

            var save = AutoBattle.Battle.EngineSettings.CharacterList;

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;
            AutoBattle.Battle.EngineSettings.CharacterList.Clear();
            AutoBattle.Battle.EngineSettings.CharacterList.Add(character);

            // Set current action to Move
            AutoBattle.Battle.EngineSettings.CurrentAction = ActionEnum.Move;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset
            AutoBattle.Battle.EngineSettings.CharacterList = save;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(true, AutoBattle.Battle.EngineSettings.BattleScore.CharacterAtDeathList.Contains("Mike Level Example"));
            // Assert.AreEqual(StartLevel+1, Engine.EngineSettings.BattleScore.CharacterModelDeathList.Where(m=>m.Guid.Equals(Character.Guid)).First().Level);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_GameOver_Round_1_Should_Pass()
        {
            /* 
             * 
             * 1 Character, Speed slowest, only 1 HP
             * 
             * 6 Monsters
             * 
             * Should end in the first round
             * 
             */

            //Arrange

            // Add Characters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 10,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                ListOrder = 1,
                            });

            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);


            // Add Monsters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 6;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_InValid_Round_Loop_Should_Fail()
        {
            /* 
             * Test infinate rounds.  
             * 
             * Characters overpower monsters, game never ends
             * 
             * 6 Character
             *      Speed high
             *      Hit Hard
             *      High health
             * 
             * 1 Monsters
             *      Slow
             *      Weak Hit
             *      Weak health
             * 
             * Should never end
             * 
             * Inifinite Loop Check should stop the game
             * 
             */

            //Arrange

            // Add Characters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 5,
                                MaxHealth = 200,
                                CurrentHealth = 200,
                                ExperienceTotal = 1,
                            });

            var CharacterPlayerMin = new PlayerInfoModel(
                new CharacterModel
                {
                    Speed = 99,
                    Level = 1,
                    MaxHealth = 200,
                    CurrentHealth = 200,
                    ExperienceTotal = 1,
                });

            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);
            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);
            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);
            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);
            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);
            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMin);

            // Add Monsters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 1;

            // Controll Rolls,  Hit is always a 3
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(3);

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, AutoBattle.Battle.EngineSettings.BattleScore.RoundCount > AutoBattle.Battle.EngineSettings.MaxRoundCount);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_InValid_Trun_Loop_Should_Fail()
        {
            /* 
             * Test infinate turn.  
             * 
             * Monsters overpower Characters game never ends
             * 
             * 1 Character
             *      Speed low
             *      Hit weak
             *      Health low
             * 
             * 6 Monsters
             *      Speed High
             *      Hit strong
             *      Health High
             * 
             * Rolls for always Miss
             * 
             * Should never end
             * 
             * Inifinite Loop Check should stop the game
             * 
             */

            //Arrange

            // Add Characters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                MaxHealth = 1,
                                CurrentHealth = 1,
                            });

            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMike);


            // Add Monsters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 6;

            // Controll Rolls,  Always Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, AutoBattle.Battle.EngineSettings.BattleScore.TurnCount > AutoBattle.Battle.EngineSettings.MaxTurnCount);
            Assert.AreEqual(true, AutoBattle.Battle.EngineSettings.BattleScore.RoundCount < AutoBattle.Battle.EngineSettings.MaxRoundCount);
        }

        //[Test]
        //public async Task AutoBattleEngine_RunAutoBattle_GameOver_Round_2_Should_Pass()
        //{
        //    /* 
        //     * 
        //     * 2 Character, Speed slowest, only 1 HP each
        //     * 
        //     * 2 Monsters
        //     * 
        //     * Should end in the first round
        //     * 
        //     */

        //    //Arrange

        //    // Add Characters

        //    Engine.EngineSettings.MaxNumberPartyCharacters = 2;

        //    var CharacterPlayerMike = new PlayerInfoModel(
        //                    new CharacterModel
        //                    {
        //                        Speed = -1, // Will go last...
        //                        Level = 10,
        //                        CurrentHealth = 1,
        //                        ExperienceTotal = 1,
        //                        ExperienceRemaining = 1,
        //                        Name = "Mike",
        //                    });

        //    Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
        //    Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);


        //    // Add Monsters

        //    Engine.EngineSettings.MaxNumberPartyMonsters = 2;

        //    var MonsterPlayer = new PlayerInfoModel(
        //        new MonsterModel
        //        {
        //            Speed = 100, // Will go first...
        //            Level = 10,
        //            CurrentHealth = 1,
        //            ExperienceTotal = 1,
        //            ExperienceRemaining = 1,
        //        });

        //    Engine.EngineSettings.MonsterList.Add(MonsterPlayer);
        //    Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

        //    //Act
        //    var result = await Engine.RunAutoBattle();

        //    //Reset

        //    //Assert
        //    Assert.AreEqual(true, result);
        //}


        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_GraduationCeremony_Should_Pass()
        {
            /* 
             * Tests graduation ceremony
             * 
             * Characters will not die but will reach level 20, which means they will graduate and a ceremony will happen
             * 
             * 1 Character
             *      Speed high
             *      Level 20
             *      Health high
             * 
             * 1 Monsters
             *      Speed High
             *      Hit strong
             *      Health High
             * 
             * Always rolls hits
             * 
             * 
             */

            //Arrange

            // Add Characters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 10,
                                Level = 20,
                                MaxHealth = 100,
                                CurrentHealth = 100,
                                SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.InternationalStudent,
                                GPA = 100,
                                Graduated = true
                            });

            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Add Monsters
            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 1;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(0, AutoBattle.Battle.EngineSettings.BattleScore.CharacterModelDeathList.Count);
            Assert.AreEqual(1, AutoBattle.Battle.EngineSettings.BattleScore.GraduateModelList.Count);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Fight_BigBoss_Should_Pass()
        {
            /* 
             * Tests fighting big boss if character is  > 17 level 
             * 
             * created:
             * 1 Character
             *      Speed high
             *      Level 18
             *      Health high
             * 
             * created during game then killed:
             * 1 Monsters
             *      Graduation monster with graduation cap
             *      Speed High
             *      Hit strong
             *      Health High
             * 
             * Always rolls hits
             * 
             * 
             */

            //Arrange

            // Add Characters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 10,
                                Level = 18,
                                MaxHealth = 100,
                                CurrentHealth = 100,
                                SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.InternationalStudent,
                                CharacterTypeEnum = CharacterTypeEnum.Student,
                                GPA = 100,
                                Graduated = true
                            });

            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Add Monsters
            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 1;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, AutoBattle.Battle.EngineSettings.BattleScore.MonsterModelDeathList.Count);
            Assert.IsTrue(AutoBattle.Battle.EngineSettings.BattleScore.MonsterModelDeathList.Any(m => m.SpecificMonsterTypeEnum == SpecificMonsterTypeEnum.GraduationOfficeAdministrator));
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Fight_BigBoss_Pickup_Grad_cap_Should_Pass()
        {
            /* 
             * Tests fighting big boss if character is  > 17 level, then if beaten pick up graduation cap 
             * 
             * created:
             * 1 Character
             *      Speed high
             *      Level 20
             *      Health high
             * 
             * created during game then killed:
             * Monsters
             *      Graduation monster with graduation cap
             *      Speed High
             *      Hit strong
             *      Health High
             *      
             * Character then is holding the cap when they graduate
             * Always rolls hits
             * 
             * 
             */

            //Arrange

            // Add Characters

            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 10,
                                Level = 20,
                                MaxHealth = 100,
                                CurrentHealth = 100,
                                SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.InternationalStudent,
                                CharacterTypeEnum = CharacterTypeEnum.Student,
                                GPA = 100,
                            });

            AutoBattle.Battle.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Add Monsters
            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 1;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, AutoBattle.Battle.EngineSettings.BattleScore.GraduateModelList.Count);

            // check if the graduated student holds the graduation cap
            var character = AutoBattle.Battle.EngineSettings.BattleScore.GraduateModelList.FirstOrDefault();
            string headItem = character.Head;
            ItemModel item = ItemIndexViewModel.Instance.GetItem(headItem);
            Assert.IsTrue(item.ItemType == ItemTypeEnum.GraduationCapAndRobe);
        }

        [Test]
        public async Task AutoBattleEngine_RunBattle_OneParent_VS_Monsters_Should_Pass()
        {
            //Arrange

            //Setting up one character - PARENT
            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;
            var ParentCharacter = new PlayerInfoModel(
                           new CharacterModel
                           {
                               Name = "Cool Parent Test",
                               Speed = 10,
                               Level = 5,
                               MaxHealth = 100,
                               CurrentHealth = 100,
                               SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.CoolParent,
                               CharacterTypeEnum = CharacterTypeEnum.Parent
                           }) ;
            AutoBattle.Battle.EngineSettings.CharacterList.Add(ParentCharacter);

            //Setting up multiple monsters
            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 2;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset
            AutoBattle.Battle.EngineSettings.CharacterList.Clear();

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunBattle_OneStudent_VS_Monsters_Should_Pass()
        {
            //Arrange

            //Setting up one character - STUDENT
            AutoBattle.Battle.EngineSettings.MaxNumberPartyCharacters = 1;
            var StudentCharacter = new PlayerInfoModel(
                           new CharacterModel
                           {
                               CharacterTypeEnum = CharacterTypeEnum.Student
                           });
            AutoBattle.Battle.EngineSettings.CharacterList.Add(StudentCharacter);

            //Setting up multiple monsters
            AutoBattle.Battle.EngineSettings.MaxNumberPartyMonsters = 2;

            //Act
            var result = await AutoBattle.RunAutoBattle();

            //Reset
            AutoBattle.Battle.EngineSettings.CharacterList.Clear();

            //Assert
            Assert.AreEqual(true, result);

        }
    }

}







