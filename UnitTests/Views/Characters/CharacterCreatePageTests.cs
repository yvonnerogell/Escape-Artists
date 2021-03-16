using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Game.Views.Characters;

namespace UnitTests.Views
{
    
    [TestFixture]
    public class CharacterCreatePageTests : CharacterCreatePage
    {
        App app;
        CharacterCreatePage page;

        public CharacterCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            //page = new CharacterCreatePage(new GenericViewModel<CharacterModel>(new CharacterModel()));
            page = new CharacterCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        
        [Test]
        public async Task CharacterCreatePage_AddItemsToDisplay_With_Data_PrimaryHand_Should_Remove_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.PrimaryHand });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.PrimaryHand).First().Id;
            page.ViewModel.Data = character;

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());
        }

        [Test]
        public async Task CharacterCreatePage_AddItemsToDisplay_With_Data_Feet_Should_Remove_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Feet });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Feet).First().Id;
            page.ViewModel.Data = character;

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());
        }

        [Test]
        public async Task CharacterCreatePage_AddItemsToDisplay_With_Data_Head_Should_Remove_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Head).First().Id;
            page.ViewModel.Data = character;

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());
        }

        [Test]
        public async Task CharacterCreatePage_AddItemsToDisplay_With_Data_LeftFinger_Should_Remove_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.LeftFinger });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.LeftFinger).First().Id;
            page.ViewModel.Data = character;

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());
        }

        [Test]
        public async Task CharacterCreatePage_AddItemsToDisplay_With_Data_Necklace_Should_Remove_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Necklace });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Necklace).First().Id;
            page.ViewModel.Data = character;

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());
        }

        [Test]
        public async Task CharacterCreatePage_AddItemsToDisplay_With_Data_OffHand_Should_Remove_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.OffHand });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.OffHand).First().Id;
            page.ViewModel.Data = character;

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());
        }

        [Test]
        public async Task CharacterCreatePage_AddItemsToDisplay_With_Data_RightFinger_Should_Remove_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.RightFinger });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.RightFinger).First().Id;
            page.ViewModel.Data = character;

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddItemsToDisplay();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());
        }


        [Test]
        public void CharacterCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_null_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Null_Description_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Description = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Null_Name_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Null_Name_Description_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.Description = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = "Bobbet";
            page.ViewModel.Data.Description = "testing";
            page.ViewModel.Data.PlayerType = PlayerTypeEnum.Character;
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            characterType.SelectedItem = SpecificCharacterTypeEnum.SmartyPants.ToMessage();

            // Act
            page.Save_Clicked(characterType, null);

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            ItemModel item = new ItemModel(ItemTypeEnum.Textbooks);
            var StackItem = page.LoadItem(item.Location);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        
        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_Slacker_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.Slacker.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_Prodigy_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.Prodigy.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_Procrastinator_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.Procrastinator.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_SecondCareer_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.SecondCareer.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_Overachiever_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.Overachiever.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_HelicopterParent_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.HelicopterParent.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_InternationalStudent_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.InternationalStudent.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_CoolParent_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.CoolParent.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPickerSelectedIndexChanged_Unknown_Should_Pass()
        {
            // Arrange
            Picker characterType = (Picker)page.FindByName("CharacterTypePicker");
            var original = characterType.SelectedItem;
            characterType.SelectedItem = SpecificCharacterTypeEnum.Unknown.ToMessage();

            // Act
            page.OnPickerSelectedIndexChanged(characterType, null);

            // Reset
            characterType.SelectedItem = original;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemsToDisplay_Head_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.PrimaryHand = null;
            page.ViewModel.Data.RightFinger = null;
            ItemModel head = new ItemModel(ItemTypeEnum.GraduationCapAndRobe);
            page.ViewModel.Data.Head = head.Id;
            page.newItems = new List<ItemModel> { head };
            // Act
            page.AddItemsToDisplay();

            // Reset
            page.ViewModel.Data = new CharacterModel();

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_AddItemsToDisplay_OffHand_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.PrimaryHand = null;
            page.ViewModel.Data.RightFinger = null;
            ItemModel Offhand = new ItemModel(ItemTypeEnum.Diploma);
            page.ViewModel.Data.OffHand = Offhand.Id;
            page.newItems = new List<ItemModel> { Offhand };
            // Act
            page.AddItemsToDisplay();

            // Reset
            page.ViewModel.Data = new CharacterModel();

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnSliderChanged_Valid_Should_Pass()
        {
            // Arrange
            var sender = new object();
            var e = new ValueChangedEventArgs(0, 1);
            OnSliderChanged(sender, e);

            // Act


            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnSliderChanged_Level_Should_Pass()
        {
            // Arrange
            page = new CharacterCreatePage();
            int oldLevel = 0;
            int newLevel = 15;

            Slider LevelSlider = (Slider)page.FindByName("LevelSlider");
            var args1 = new ValueChangedEventArgs(oldLevel, newLevel);

            // Act
            page.OnSliderChanged(LevelSlider, args1);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnSliderChanged_Attack_Should_Pass()
        {
            // Arrange
            int oldAttack = 0;
            int newAttack = 5;

            Slider AttackSlider = (Slider)page.FindByName("AttackSlider");
            var args2 = new ValueChangedEventArgs(oldAttack, newAttack);

            // Act
            page.OnSliderChanged(AttackSlider, args2);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnSliderChanged_Defense_Should_Pass()
        {
            // Arrange
            int oldDefense = 0;
            int newDefense = 5;

            Slider DefenseSlider = (Slider)page.FindByName("DefenseSlider");
            var args3 = new ValueChangedEventArgs(oldDefense, newDefense);

            // Act
            page.OnSliderChanged(DefenseSlider, args3);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnSliderChanged_Speed_Should_Pass()
        {
            // Arrange
            int oldSpeed = 0;
            int newSpeed = 5;

            Slider SpeedSlider = (Slider)page.FindByName("SpeedSlider");
            var args4 = new ValueChangedEventArgs(oldSpeed, newSpeed);

            // Act
            page.OnSliderChanged(SpeedSlider, args4);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnSliderChanged_GPA_Should_Pass()
        {
            // Arrange
            int oldGPA = 0;
            int newGPA = 4; // important to make this non-divisible by 5 

            Slider GPASlider = (Slider)page.FindByName("GPASlider");
            var args5 = new ValueChangedEventArgs(oldGPA, newGPA);

            // Act
            page.OnSliderChanged(GPASlider, args5);

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnSliderChanged_GPA_1_Should_Pass()
        {
            // Arrange
            int oldGPA_1 = 0;
            int newGPA_1 = 5; // important to make this divisible by 5 

            Slider GPASlider_1 = (Slider)page.FindByName("GPASlider");
            var args6 = new ValueChangedEventArgs(oldGPA_1, newGPA_1);

            // Act
            page.OnSliderChanged(GPASlider_1, args6);


            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //[Test]
        //public void CharacterCreatePage_ClosePopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_ClosePopup_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange
        //    page.ViewModel.Data = new CharacterModel();

        //    // Act
        //    page.ShowPopup(ItemLocationEnum.PrimaryHand);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    var data = new ItemModel();

        //    var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(data, 0);

        //    // Act
        //    page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
        //{
        //    // Arrange

        //    var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

        //    // Act
        //    page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCreatePage_Item_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    var item = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

        //    // Act
        //    var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterCratePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        //{
        //    // Arrange
        //    var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
        //    page.ViewModel.Data.Head = item.Id;
        //    var StackItem = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);
        //    var dataImage = StackItem.Children[0];

        //    // Act
        //    ((ImageButton)dataImage).PropagateUpClicked();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        /*
        [Test]
        public void CharacterCreatePage_RandomButton_Clicked_Vaid_Should_Pass()
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