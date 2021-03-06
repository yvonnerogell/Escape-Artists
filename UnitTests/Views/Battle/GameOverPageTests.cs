﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Models;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class GameOverPageTests
    {
        App app;
        GameOverPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            BattleEngineViewModel.Instance.SetBattleEngineToGame();

            page = new GameOverPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void GameOverPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GameOverPage_CloseButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_CloseButton_Clicked_Default_Navigation_Should_Pass()
        {
            // Arrange
            // Arrange
            GameOverPage page1 = new GameOverPage();

            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new PickCharactersPage());

            // Act
            page1.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage_YourScoreButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.YourScoreButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GameOverPage__Default_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.CharacterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Draw the Monsters
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.MonsterModelDeathList.Add(new PlayerInfoModel(new CharacterModel()));

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());

            // Act
            page.DrawOutput();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}