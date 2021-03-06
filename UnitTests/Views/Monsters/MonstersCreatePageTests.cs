﻿using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Linq;
using Game.Views.Monsters;

namespace UnitTests.Views
{
    [TestFixture]
    public class MonsterCreatePageTests : MonsterCreatePage
    {
        App app;
        MonsterCreatePage page;

        public MonsterCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            //page = new MonsterCreatePage(new GenericViewModel<MonsterModel>(new MonsterModel()));
            page = new MonsterCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Save_Clicked_Null_Image_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_ShowItem_Valid_Should_Pass()
        {
            // Arrange
            ItemModel item = new ItemModel();
            
            // Act
            page.ShowItem(null, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Save_Clicked_Should_Pass()
        {
            // Arrange
            //ViewModel.Data = new MonsterModel();
            page.ViewModel.Data.Name = "Professor Mike";
            page.ViewModel.Data.Description = "loves working on projects";
            page.ViewModel.Data.PlayerType = PlayerTypeEnum.Monster;

            Picker monsterType = (Picker) page.FindByName("MonsterTypePicker");
            monsterType.SelectedItem = SpecificMonsterTypeEnum.Professor.ToMessage();
            
            // Act
            page.Save_Clicked(monsterType, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            ItemModel item = new ItemModel();
            var StackItem = page.LoadItem(item);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_AttackSlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider ValueSlider = (Slider)page.FindByName("AttackSlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(ValueSlider, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_DefenseSlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider ValueSlider = (Slider)page.FindByName("DefenseSlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(ValueSlider, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_SpeedSlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider ValueSlider = (Slider)page.FindByName("SpeedSlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(ValueSlider, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        //[Test]
        //public void MonsterCreatePage_RollDice_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.RollDice_Clicked(null,null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterCreatePage_ClosePopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterCreatePage_ClosePopup_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterCreatePage_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ShowPopup(new ItemModel());

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterCreatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    var data = new ItemModel();

        //    var selectedMonsterChangedEventArgs = new SelectedItemChangedEventArgs(data, 0);

        //    // Act
        //    page.OnPopupItemSelected(null, selectedMonsterChangedEventArgs);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        ////}

        //[Test]
        //public void MonsterCreatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
        //{
        //    // Arrange

        //    var selectedMonsterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

        //    // Act
        //    page.OnPopupItemSelected(null, selectedMonsterChangedEventArgs);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterCreatePage_Item_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    var item = page.GetItemToDisplay();

        //    // Act
        //    var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void MonsterCreatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        //{
        //    // Arrange
        //    var StackItem = page.GetItemToDisplay();
        //    var dataImage = StackItem.Children[0];

        //    // Act
        //    ((ImageButton)dataImage).PropagateUpClicked();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        /*
        [Test]
        public void MonsterCreatePage_RandomButton_Clicked_Vaid_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */
    }
}