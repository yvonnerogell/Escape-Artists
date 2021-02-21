using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterUpdatePageTests : CharacterUpdatePage
    {
        App app;
        CharacterUpdatePage page;

        public CharacterUpdatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterUpdatePage(new GenericViewModel<CharacterModel>(new CharacterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Empty_Name_Description_Should_Pass()
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
        public void CharacterUpdatePage_Save_Clicked_Empty_Name_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Description = "Some description";

            // Act
            page.Save_Clicked(null, null);

            // Reset
            page.ViewModel.Data.Description = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Empty_Description_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = "Some name";

            // Act
            page.Save_Clicked(null, null);

            // Reset
            page.ViewModel.Data.Name = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void CharacterUpdatePage_Save_Clicked_Filled_Name_Description_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = "Some name";
            page.ViewModel.Data.Description = "Some description";

            // Act
            page.Save_Clicked(null, null);

            // Reset
            page.ViewModel.Data.Name = null;
            page.ViewModel.Data.Description = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void CharacterUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public async Task CharacterUpdatePage_AddItemsToDisplay_With_Data_PrimaryHand_Should_Pass()
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
        public async Task CharacterUpdatePage_AddItemsToDisplay_With_Data_Feet_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Feet });

            var character = new CharacterModel();
            character.Feet = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Feet).First().Id;
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
        public async Task CharacterUpdatePage_AddItemsToDisplay_With_Data_LeftFinger_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Finger });

            var character = new CharacterModel();
            character.LeftFinger = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.LeftFinger).First().Id;
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
        public async Task CharacterUpdatePage_AddItemsToDisplay_With_Data_RightFinger_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Finger });

            var character = new CharacterModel();
            character.RightFinger = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.RightFinger).First().Id;
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
        public async Task CharacterUpdatePage_AddItemsToDisplay_With_Data_Head_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head });

            var character = new CharacterModel();
            character.Head = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Head).First().Id;
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
        public async Task CharacterUpdatePage_AddItemsToDisplay_With_Data_Necklace_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Necklace });

            var character = new CharacterModel();
            character.Necklace = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Necklace).First().Id;
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
        public async Task CharacterUpdatePage_AddItemsToDisplay_With_Data_OffHand_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.OffHand });

            var character = new CharacterModel();
            character.OffHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.OffHand).First().Id;
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
        public void CharacterUpdatePage_LevelSlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider LevelSlider = (Slider)page.FindByName("LevelSlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(LevelSlider, args);

            // Reset

            // Assert
            Assert.AreEqual(newValue, LevelSlider.Value);
        }

        [Test]
        public void CharacterUpdatePage_AttackSlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider AttackSlider = (Slider)page.FindByName("AttackSlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(AttackSlider, args);

            // Reset

            // Assert
            Assert.AreEqual(newValue, AttackSlider.Value);
        }

        [Test]
        public void CharacterUpdatePage_DefenseSlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider DefenseSlider = (Slider)page.FindByName("DefenseSlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(DefenseSlider, args);

            // Reset

            // Assert
            Assert.AreEqual(newValue, DefenseSlider.Value);
        }

        [Test]
        public void CharacterUpdatePage_SpeedSlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider SpeedSlider = (Slider)page.FindByName("SpeedSlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(SpeedSlider, args);

            // Reset

            // Assert
            Assert.AreEqual(newValue, SpeedSlider.Value);
        }

        /*
        [Test]
        public void CharacterUpdatePage_GPASlider_OnSliderValueChanged_Default_Should_Pass()
        {
            // Arrange
            double oldValue = 0.0;
            double newValue = 5.0;

            Slider GPASlider = (Slider)page.FindByName("GPASlider");

            var args = new ValueChangedEventArgs(oldValue, newValue);

            // Act
            page.OnSliderChanged(GPASlider, args);

            // Reset

            // Assert
            Assert.AreEqual(newValue, GPASlider.Value);
        }
        */

        //[Test]
        //public void CharacterUpdatePage_Attack_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel();
        //    var ViewModel = new GenericViewModel<CharacterModel>(data);

        //    page = new CharacterUpdatePage(ViewModel);
        //    double oldValue = 0.0;
        //    double newValue = 1.0;

        //    var args = new ValueChangedEventArgs(oldValue, newValue);

        //    // Act
        //    page.Attack_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_Defense_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel();
        //    var ViewModel = new GenericViewModel<CharacterModel>(data);

        //    page = new CharacterUpdatePage(ViewModel);
        //    double oldRange = 0.0;
        //    double newRange = 1.0;

        //    var args = new ValueChangedEventArgs(oldRange, newRange);

        //    // Act
        //    page.Defense_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_Speed_OnStepperDamageChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel();
        //    var ViewModel = new GenericViewModel<CharacterModel>(data);

        //    page = new CharacterUpdatePage(ViewModel);
        //    double oldDamage = 0.0;
        //    double newDamage = 1.0;

        //    var args = new ValueChangedEventArgs(oldDamage, newDamage);

        //    // Act
        //    page.Speed_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_Level_Changed_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel();
        //    var ViewModel = new GenericViewModel<CharacterModel>(data);

        //    page = new CharacterUpdatePage(ViewModel);
        //    double oldDamage = 0.0;
        //    double newDamage = 1.0;

        //    var args = new ValueChangedEventArgs(oldDamage, newDamage);

        //    // Act
        //    page.Level_Changed(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_RollDice_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.RollDice_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_ClosePopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_ClosePopup_Clicked_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    page.ClosePopup_Clicked(null, null);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
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
        //public void CharacterUpdatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
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
        //public void CharacterUpdatePage_Item_ShowPopup_Default_Should_Pass()
        //{
        //    // Arrange

        //    var item = page.GetItemToDisplay(ItemLocationEnum.Head);

        //    // Act
        //    var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

        //    page.ShowPopup(ItemLocationEnum.Head);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void CharacterUpdatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        //{
        //    // Arrange
        //    var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
        //    page.ViewModel.Data.Head = item.Id;
        //    var StackItem = page.GetItemToDisplay(ItemLocationEnum.Head);
        //    var dataImage = StackItem.Children[0];

        //    // Act
        //    ((ImageButton)dataImage).PropagateUpClicked();

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        /*
        #region ButtonUpDown
        [Test]
        public void CharacterUpdatePage_AttackDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Attack = 1;

            // Act
            page.AttackDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AttackUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Attack = 1;

            // Act
            page.AttackUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        

        [Test]
        public void CharacterUpdatePage_DefenseDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Defense = 1;

            // Act
            page.DefenseDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_DefenseUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Defense = 1;

            // Act
            page.DefenseUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Speed = 1;

            // Act
            page.SpeedDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Speed = 1;

            // Act
            page.SpeedUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AttackDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Attack = 0;

            // Act
            page.AttackDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AttackUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Attack = 10;

            // Act
            page.AttackUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_DefenseDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Defense = 0;

            // Act
            page.DefenseDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_DefenseUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Defense = 10;

            // Act
            page.DefenseUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Speed = 0;

            // Act
            page.SpeedDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Speed = 10;

            // Act
            page.SpeedUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        #endregion ButtonUpDown

        #region UpdateHealth
        [Test]
        public void CharacterUpdatePage_UpdateHealthValue_Valid_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.UpdateHealthValue();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        #endregion UpdateHealth

        #region RandomButton_Clicked
        [Test]
        public void CharacterUpdatePage_RandomButton_Clicked_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        #endregion RandomButton_Clicked

        #region LevelPicker_Changed
        [Test]
        public void CharacterUpdatePage_LevelPicker_SelectedIndex_Neg1_Should_Return_Level()
        {
            // Arrange

            // Make a new Character to use for the Picker Tests
            page.ViewModel.Data = new CharacterModel()
            {
                Id = "test",
                Level = 10
            };

            var control = (Picker)page.FindByName("LevelPicker");
            control.SelectedIndex = -1;

            // Act
            page.LevelPicker_Changed(null, null);
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(10, result + 1);
        }

        [Test]
        public void CharacterUpdatePage_LevelPicker_SelectedIndex_No_Change_Should_Skip()
        {
            // Arrange

            // Make a new Character to use for the Picker Tests
            page.ViewModel.Data = new CharacterModel()
            {
                Id = "test",
                Level = 10
            };

            var control = (Picker)page.FindByName("LevelPicker");
            control.SelectedIndex = 10 - 1;

            // Act
            page.LevelPicker_Changed(null, null);
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(10, result + 1);
        }


        [Test]
        public void CharacterUpdatePage_LevelPicker_SelectedIndex_Change_Should_Update_Picker_To_Level()
        {
            // Arrange

            // Make a new Character to use for the Picker Tests
            page.ViewModel.Data = new CharacterModel()
            {
                Id = "test",
                Level = 1
            };

            var control = (Picker)page.FindByName("LevelPicker");
            control.SelectedIndex = 15;

            // Act
            page.LevelPicker_Changed(null, null);
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(16, result + 1);
        }
        #endregion LevelPicker_Changed
        */
    }
}