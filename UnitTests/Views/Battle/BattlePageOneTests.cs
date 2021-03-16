using System.Threading.Tasks;
using System.Collections.Generic;

using NUnit.Framework;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game;
using Game.Views;
using Game.Models;
using Game.ViewModels;
using Game.GameRules;

namespace UnitTests.Views
{
    [TestFixture]
    public class BattlePageOneTests : BattlePageOne
    {
        App app;
        BattlePageOne page;

        public BattlePageOneTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            BattleEngineViewModel.Instance.SetBattleEngineToGame();

            var characters = DefaultData.LoadData(new CharacterModel());

            foreach (var character in characters)
			{
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }

            var monsters = DefaultData.LoadData(new MonsterModel());

            foreach (var monster in monsters)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(monster));
            }

            page = new BattlePageOne();

            // Put seed data into the system for all tests
            BattleEngineViewModel.Instance.Engine.Round.ClearLists();
        }

        
        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }


        [Test]
        public void BattlePage_OnAppearing_Should_Pass()
        {
            // Get the current valute

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattlePage_Constructor_Default_CurrentAttacker_Null_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattlePageOne();

            // Reset

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(null, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);
        }

        [Test]
        public void BattlePage_Constructor_Default_CurrentAttacker_Student_Should_Pass()
        {
            // Arrange
            var attacker = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CharacterTypeEnum = CharacterTypeEnum.Student });
            var defender = new PlayerInfoModel(new MonsterModel { Name = "Goofey", MonsterTypeEnum = MonsterTypeEnum.Faculty });

            // Need to set both of these so that current defender and attacker are both populated
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = attacker;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = defender;

            // Act
            var result = new BattlePageOne();

            // Reset

            // Assert
            Assert.AreEqual(attacker, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

            // Reset - have to reset here because needed to assert current attacker
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
        }

        [Test]
        public void BattlePage_Constructor_Default_CurrentAttacker_Parent_Should_Pass()
        {
            // Arrange
            var attacker = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CharacterTypeEnum = CharacterTypeEnum.Parent });
            var defender = new PlayerInfoModel(new MonsterModel { Name = "Goofey", MonsterTypeEnum = MonsterTypeEnum.Faculty });

            // Need to set both of these so that current defender and attacker are both populated
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = attacker;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = defender;

            // Act
            var result = new BattlePageOne();

            // Reset

            // Assert
            Assert.AreEqual(attacker, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

            // Reset - have to reset here because needed to assert current attacker
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
        }

        [Test]
        public void BattlePage_Constructor_Default_CurrentAttacker_Unknown_Should_Pass()
        {
            // Arrange
            var attacker = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CharacterTypeEnum = CharacterTypeEnum.Unknown });
            var defender = new PlayerInfoModel(new MonsterModel { Name = "Goofey", MonsterTypeEnum = MonsterTypeEnum.Faculty });

            // Need to set both of these so that current defender and attacker are both populated
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = attacker;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = defender;

            // Act
            var result = new BattlePageOne();

            // Reset

            // Assert
            Assert.AreEqual(attacker, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

            // Reset - have to reset here because needed to assert current attacker
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
        }

        [Test]
        public void BattlePage_Constructor_Default_CurrentAttacker_Monster_Unknown_Should_Pass()
        {
            // Arrange
            var attacker = new PlayerInfoModel(new MonsterModel { Name = "Minnie", MonsterTypeEnum = MonsterTypeEnum.Unknown });
            var defender = new PlayerInfoModel(new CharacterModel { Name = "Goofey", CharacterTypeEnum = CharacterTypeEnum.Student });

            // Need to set both of these so that current defender and attacker are both populated
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = attacker;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = defender;

            // Act
            var result = new BattlePageOne();

            // Reset

            // Assert
            Assert.AreEqual(attacker, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

            // Reset - have to reset here because needed to assert current attacker
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
        }

        [Test]
        public void BattlePage_Constructor_Default_CurrentAttacker_Monster_Faculty_Should_Pass()
        {
            // Arrange
            var attacker = new PlayerInfoModel(new MonsterModel { Name = "Minnie", MonsterTypeEnum = MonsterTypeEnum.Faculty });
            var defender = new PlayerInfoModel(new CharacterModel { Name = "Goofey", CharacterTypeEnum = CharacterTypeEnum.Student });

            // Need to set both of these so that current defender and attacker are both populated
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = attacker;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = defender;

            // Act
            var result = new BattlePageOne();

            // Reset

            // Assert
            Assert.AreEqual(attacker, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

            // Reset - have to reset here because needed to assert current attacker
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
        }

        [Test]
        public void BattlePage_Constructor_Default_CurrentAttacker_Monster_Administrator_Should_Pass()
        {
            // Arrange
            var attacker = new PlayerInfoModel(new MonsterModel { Name = "Minnie", MonsterTypeEnum = MonsterTypeEnum.Administrator });
            var defender = new PlayerInfoModel(new CharacterModel { Name = "Goofey", CharacterTypeEnum = CharacterTypeEnum.Student });
           
            // Need to set both of these so that current defender and attacker are both populated
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = attacker;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = defender;

            // Act
            var result = new BattlePageOne();

            // Reset

            // Assert
            Assert.AreEqual(attacker, BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

            // Reset - have to reset here because needed to assert current attacker
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
        }

        [Test]
        public void BattlePage_NextAttackButton_Clicked_NavigationStack_Should_Pass()
        {
            // Arrange
            BattlePageOne page1 = new BattlePageOne();

            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new PickCharactersPage());
            page1.Navigation.PushAsync(new NewRoundPage());

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;

            // Act
            page1.NextAttackButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePage_NextAttackButton_Clicked_RoundOver_Should_Pass()
        {
            // Arrange
            page.nextPlayer = new PlayerInfoModel(new MonsterModel { PlayerType = PlayerTypeEnum.Monster, MonsterTypeEnum = MonsterTypeEnum.Administrator, Name = "monster", ImageURI = "uri", SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator });
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = page.nextPlayer;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = new PlayerInfoModel(new CharacterModel { Name = "character", PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever, CharacterTypeEnum = CharacterTypeEnum.Student, ImageURI = "uri", GPA = 13 });

            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.RoundOver;

            // Act
            page.NextAttackButton_Clicked(null, null);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
            page.nextPlayer = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        
        [Test]
        public void BattlePage_NextAttackButton_Clicked_Unknown_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;
            page.nextPlayer = new PlayerInfoModel(new MonsterModel { PlayerType = PlayerTypeEnum.Monster, MonsterTypeEnum = MonsterTypeEnum.Administrator, Name = "monster", ImageURI = "uri", SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator });


            // Act
            page.NextAttackButton_Clicked(null, null);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
            page.nextPlayer = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;


            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        
        [Test]
        public void BattlePage_NextAttackButton_Clicked_GameOver_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;
            page.nextPlayer = new PlayerInfoModel(new MonsterModel { PlayerType = PlayerTypeEnum.Monster, MonsterTypeEnum = MonsterTypeEnum.Administrator, Name = "monster", ImageURI = "uri", SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator });


            // Act
            page.NextAttackButton_Clicked(null, null);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
            page.nextPlayer = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        
        [Test]
        public void BattlePage_NextAttackButton_Clicked_Battling_Character_NextPlayer_Should_Pass()
        {
            // Arrange
            page.nextPlayer = new PlayerInfoModel(new CharacterModel { PlayerType = PlayerTypeEnum.Character, CharacterTypeEnum = CharacterTypeEnum.Student, Name = "monster", ImageURI = "uri", SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Slacker });
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = page.nextPlayer;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = new PlayerInfoModel(new CharacterModel { Name = "character", PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever, CharacterTypeEnum = CharacterTypeEnum.Student, ImageURI = "uri", GPA = 13 });

            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            // Act
            page.NextAttackButton_Clicked(null, null);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
            page.nextPlayer = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_NextAttackButton_Clicked_Battling_Monster_NextPlayer_Should_Pass_()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();
            var nextPlayer = new PlayerInfoModel(new MonsterModel { PlayerType = PlayerTypeEnum.Monster, MonsterTypeEnum = MonsterTypeEnum.Administrator, Name = "monster", ImageURI = "uri", SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator });
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(nextPlayer);

            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = new PlayerInfoModel(new CharacterModel { Name = "character", PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever, CharacterTypeEnum = CharacterTypeEnum.Student, ImageURI = "uri", GPA = 13 });

            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            // Act
            page.NextAttackButton_Clicked(null, null);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
            page.nextPlayer = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePage_RoundOverButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.RoundOverButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_RoundOverButton_Clicked_NavigationStack_Should_Pass()
        {
            // Arrange
            BattlePageOne page1 = new BattlePageOne();

            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new PickCharactersPage());
            page1.Navigation.PushAsync(new NewRoundPage());

            // Act
            page1.RoundOverButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePage_ExitButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ExitButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        

        [Test]
        public void BattlePage_SetAttackerDefenderImages_Character_Monster_Should_Return_True()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Make Character
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                                ImageURI = "characterURI"
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make Monster

            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                                ImageURI = "monsterURI"
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            // Act
            var result = page.SetAttackerDefenderImages(CharacterPlayer, MonsterPlayer);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void BattlePage_SetAttackerDefenderImages_Character_Monster_Null_Should_Return_False()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Make Character
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                                ImageURI = "characterURI"
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make Monster

            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            // Act
            var result = page.SetAttackerDefenderImages(CharacterPlayer, null);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;

            // Assert
            Assert.IsFalse(result);
        }
        [Test]
        public void BattlePage_SetAttackerDefenderImages_Character_Null_Monster_Should_Return_False()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Make Monster
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                                ImageURI = "monsterURI"
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            // Act
            var result = page.SetAttackerDefenderImages(null, MonsterPlayer);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void BattlePage_SetAttackerDefenderImages_Character_Null_Monster_Nll_Should_Return_False()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Act
            var result = page.SetAttackerDefenderImages(null, null);

            // Reset

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void BattlePage_GetAttackerText_Monster_Faculty_Character_Student_Should_Pass()
        {
            // Arrange
            var currentAttacker = new PlayerInfoModel(new MonsterModel { Name = "Honkey", MonsterTypeEnum = MonsterTypeEnum.Faculty, SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.Professor, PlayerType = PlayerTypeEnum.Monster });
            var currentDefender = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever });

            // Act
            var result = page.GetAttackText(currentAttacker, currentDefender);

            // Reset

            // Assert
            Assert.AreEqual("Professor Honkey\n vs \nOverachiever Minnie", result); 
        }



        [Test]
        public void BattlePage_GetAttackerText_Monster_Administrator_Character_Student_Should_Pass()
        {
            // Arrange
            var currentAttacker = new PlayerInfoModel(new MonsterModel { Name = "Honkey", MonsterTypeEnum = MonsterTypeEnum.Administrator, SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.RegistrationAdministrator, PlayerType = PlayerTypeEnum.Monster });
            var currentDefender = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SecondCareer });

            // Act
            var result = page.GetAttackText(currentAttacker, currentDefender);

            // Reset

            // Assert
            Assert.AreEqual("Registration Administrator Honkey\n vs \nSecond Career Minnie", result);
        }

        [Test]
        public void BattlePage_GetAttackerText_Attacker_Student_Monster_Defender_Faculty_Should_Pass()
        {
            // Arrange
            var currentAttacker = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Slacker });
            var currentDefender = new PlayerInfoModel(new MonsterModel { Name = "Honkey", MonsterTypeEnum = MonsterTypeEnum.Faculty, SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AdjunctFaculty, PlayerType = PlayerTypeEnum.Monster });

            // Act
            var result = page.GetAttackText(currentAttacker, currentDefender);

            // Reset

            // Assert
            Assert.AreEqual("Slacker Minnie\n vs \nAdjunct Faculty Honkey", result);
        }

        [Test]
        public void BattlePage_GetAttackerText_Attacker_Student_Defender_Null_Should_Pass()
        {
            // Arrange
            var currentAttacker = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Slacker });

            // Act
            var result = page.GetAttackText(currentAttacker, null);

            // Reset

            // Assert
            Assert.AreEqual("Slacker Minnie", result);
        }

        [Test]
        public void BattlePage_GetAttackerText_Attacker_Student_Monster_Defender_Administrator_Should_Pass()
        {
            // Arrange
            var currentAttacker = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character });
            var currentDefender = new PlayerInfoModel(new MonsterModel { Name = "Honkey", MonsterTypeEnum = MonsterTypeEnum.Administrator, SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.GraduationOfficeAdministrator, PlayerType = PlayerTypeEnum.Monster });

            // Act
            var result = page.GetAttackText(currentAttacker, currentDefender);

            // Reset

            // Assert
            Assert.AreEqual("Smarty Pants Minnie\n vs \nGraduation Office Administrator Honkey", result);
        }

        [Test]
        public void BattlePage_GetCharacterGPA_67_Should_Pass()
        {
            // Arrange
            var currentCharacter = new PlayerInfoModel (new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character });

            // Act
            var result = page.GetCharacterGPA(currentCharacter);

            // Reset

            // Assert
            Assert.AreEqual("67", result);
        }

        [Test]
        public void BattlePage_GetCharacterHealth_15_Should_Pass()
        {
            // Arrange
            var currentCharacter = new PlayerInfoModel( new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character });

            // Act
            var result = page.GetCharacterHealth(currentCharacter);

            // Reset

            // Assert
            Assert.AreEqual("15", result);
        }

        [Test]
        public void BattlePage_GetCharacterName_Should_Pass()
        {
            // Arrange
            var currentCharacter = new PlayerInfoModel(new CharacterModel { Name = "Minnie", CurrentHealth = 15, GPA = 67, CharacterTypeEnum = CharacterTypeEnum.Student, PlayerType = PlayerTypeEnum.Character });

            // Act
            var result = page.GetCharacterName(currentCharacter);

            // Reset

            // Assert
            Assert.AreEqual("Minnie", result);
        }

        [Test]
        public void BattlePage_SetBattleMessage_Should_Pass()
        {
            // Arrange
            var message = "Faculty Honkey gives Minnie an exam.";

            // Act
            page.SetBattleMessage(message);

            var m1 = ((Label)page.FindByName("BattleMessageLabel")).Text;

            // Reset


            // Assert
            Assert.AreEqual("Faculty Honkey gives Minnie an exam.", m1);
        }

        [Test]
        public void BattlePage_ShowBattleMode_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowBattleMode();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_ShowBattleMode_Testing_Default_Should_Pass()
        {
            // Arrange
            bool save = page.UnitTestSetting;
            page.UnitTestSetting = true;

            // Act
            page.ShowBattleMode();

            // Reset
            page.UnitTestSetting = save;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePage_Settings_Clicked_Default_Should_Pass()
        {
            //Arrange
            //Act
            page.Settings_Clicked(null, null);
            //Reset
            //Assert
            Assert.IsTrue(true); //Got to her, so it happened...
        }

        [Test]
        public async Task BattlePage_ShowBattleSettingsPage_Default_Should_Pass()
        {
            //Arrange
            //Act
            await page.ShowBattleSettingsPage();
            //Reset
            //Assert
            Assert.IsTrue(true);
        }

    }
}