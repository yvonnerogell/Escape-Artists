﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game;
using Game.Views;
using Game.Models;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class NewRoundPageTests
    {
        App app;
        NewRoundPage page;
        NewRoundPage UTPage;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            //BattleEngineViewModel.Instance.SetBattleEngineToKoenig();
            BattleEngineViewModel.Instance.SetBattleEngineToGame();

            page = new NewRoundPage();
            UTPage = new NewRoundPage(true);
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void NewRoundPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void NewRoundPage_Constructor_RoundCount_Greater_Than_1_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount = 2;

            // Act
            var result = new NewRoundPage();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount = save;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void NewRoundPage_BeginGridButton_Clicked_Navigation_Should_Pass()
        {
            // Arrange
            NewRoundPage page1 = new NewRoundPage();

            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new PickCharactersPage());
            page1.UnitTestSetting = true;

            // Act
            page1.BeginGridButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        
        [Test]
        public void NewRoundPage_BeginSimpleButton_Clicked_NextPlayer_Character_Should_Pass()
        {
            // Arrange
            page.nextPlayer = new PlayerInfoModel { PlayerType = PlayerTypeEnum.Character };

            // Act
            page.BeginSimpleButton_Clicked(null, null);

            // Reset
            page.nextPlayer = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void NewRoundPage_BeginSimpleButton_Clicked_Navigation_Should_Pass()
        {
            // Arrange
            NewRoundPage page1 = new NewRoundPage();

            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new PickCharactersPage());
            page1.nextPlayer = new PlayerInfoModel { PlayerType = PlayerTypeEnum.Character };

            // Act
            page1.BeginSimpleButton_Clicked(null, null);

            // Reset
            page.nextPlayer = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void NewRoundPage_BeginSimpleButton_Clicked_NextPlayer_Monster_Should_Pass()
        {
            // Arrange
            page.nextPlayer = new PlayerInfoModel(new MonsterModel { PlayerType = PlayerTypeEnum.Monster, MonsterTypeEnum = MonsterTypeEnum.Administrator, Name="monster", ImageURI = "uri" , SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.HRAdministrator}) ;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = page.nextPlayer;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = new PlayerInfoModel(new CharacterModel { Name = "character", PlayerType = PlayerTypeEnum.Character, SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.Overachiever, CharacterTypeEnum = CharacterTypeEnum.Student, ImageURI = "uri", GPA = 13 });

            // Act
            page.BeginSimpleButton_Clicked(null, null);

            // Reset
            page.nextPlayer = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void NewRoundPage_CreatePlayerDisplayBox_Valid_Should_Pass()
        {
            // Arrange
            // Act
            var result = page.CreatePlayerDisplayBox(new PlayerInfoModel(new CharacterModel { Name = "test" }));

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }

        [Test]
        public void NewRoundPage_CreatePlayerDisplayBox_Null_Should_Pass()
        {
            // Arrange
            // Act
            var result = page.CreatePlayerDisplayBox(null);

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }

        [Test]
        public void NewRoundPage_NewRoundPage_CharacterList_MonsterList_Should_Pass()
        {
            // Arrange
            // Act

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            var result = new NewRoundPage();

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }

        [Test]
        public void ExitButton_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ExitButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void NewRoundPage_SetBattleStateEnum_RoundEnum_GameOver_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.GameOver;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.GameOver, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

        }

        [Test]
        public void NewRoundPage_SetBattleStateEnum_RoundEnum_GraduationCeremony_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.GraduationCeremony;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.GameOver, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

        }

        [Test]
        public void NewRoundPage_SetBattleStateEnum_RoundEnum_NextTurn_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.NextTurn;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.Battling, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

        }

        [Test]
        public void NewRoundPage_SetBattleStateEnum_RoundEnum_NewRound_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.NewRound;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.NewRound, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

        }

        [Test]
        public void NewRoundPage_SetBattleStateEnum_RoundEnum_Unknown_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.Unknown;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.Unknown, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

        }
    }
}