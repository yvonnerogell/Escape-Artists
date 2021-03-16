using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;
using Game.GameRules;

namespace UnitTests.Views
{
    [TestFixture]
    public class PickCharactersPageTests : PickCharactersPage
    {
        App app;
        PickCharactersPage page;

        public PickCharactersPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            BattleEngineViewModel.Instance.SetBattleEngineToGame();

            page = new PickCharactersPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void PickCharactersPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PickCharactersPage_Constructor_UT_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PickCharactersPage(false);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PickCharactersPage_BattleButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.BattleButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_BattleButton_Clicked_Navigation_Should_Pass()
        {
            // Arrange
            PickCharactersPage page1 = new PickCharactersPage();
            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new GamePage());

            // Act
            page1.BattleButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_CreateEngineCharacterList_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            BattleEngineViewModel.Instance.PartyCharacterList = new ObservableCollection<CharacterModel>();
            BattleEngineViewModel.Instance.PartyCharacterList.Add(new CharacterModel());

            // Act
            page.CreateEngineCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_OnApperaing_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            BattleEngineViewModel.Instance.PartyCharacterList = new ObservableCollection<CharacterModel>();
            BattleEngineViewModel.Instance.PartyCharacterList.Add(new CharacterModel());

            var temp = page.EngineViewModel.Engine;

            page.UpdateNextButtonState();

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_UpdateButtonState_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.UpdateNextButtonState();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_OnDatabaseCharacterItemSelected_Default_Should_Pass()
        {
            // Arrange
            var selectedCharacter = new CharacterModel();
            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(selectedCharacter, 0);

            // Act
            page.OnDatabaseCharacterItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickCharactersPage_OnDatabaseCharacterItemSelected_InValid_Should_Pass()
        {
            // Arrange
            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnDatabaseCharacterItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        
        [Test]
        public void PickCharacterPage_OnCharacter_Clicked_Does_Not_Exist_()
        {
            // Arrange
            var characters = DefaultData.LoadData(new CharacterModel());

            // Add characters to the Engine
            foreach (var character in characters)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }

            ImageButton s = new ImageButton();
            // Test does not exist
            s.CommandParameter = "Test";
            System.EventArgs e = new System.EventArgs();

            // Act
            page.OnCharacter_Clicked(s, e);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...

            //Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
        }

        [Test]
        public async Task PickCharacterPage_OnCharacter_Clicked_Name_Exists_Should_Pass()
        {
            // Arrange
            var characters = DefaultData.LoadData(new CharacterModel());

            //add characters to the Engine
            foreach (var character in characters)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }

            var player = new CharacterModel { Name = "Test", Id = "id" };

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(player));
            page.selectedCharacters.Clear();
            page.selectedCharacters.Add(player);
            await page.ViewModel.CreateAsync(player);

            ImageButton s = new ImageButton();
            // This id does now exist
            s.CommandParameter = "id";
            System.EventArgs e = new System.EventArgs();

            // Act
            page.OnCharacter_Clicked(s, e);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...

            //Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            page.selectedCharacters.Clear();
            await page.ViewModel.DeleteAsync(player);
        }

        [Test]
        public async Task PickCharacterPage_OnCharacter_Clicked_Name_Exists_Not_Selected_Should_Pass()
        {
            // Arrange
            var characters = DefaultData.LoadData(new CharacterModel());

            //add characters to the Engine
            foreach (var character in characters)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }

            var player = new CharacterModel { Name = "Test", Id = "id" };

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(player));
            page.selectedCharacters.Clear();
            await page.ViewModel.CreateAsync(player);

            ImageButton s = new ImageButton();
            // This id does now exist
            s.CommandParameter = "id";
            System.EventArgs e = new System.EventArgs();

            // Act
            page.OnCharacter_Clicked(s, e);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...

            //Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            page.selectedCharacters.Clear();
            await page.ViewModel.DeleteAsync(player);
        }
    }
}