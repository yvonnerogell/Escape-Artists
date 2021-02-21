using NUnit.Framework;
using System.Linq;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterReadPageTests : CharacterReadPage
    {
        App app;
        CharacterReadPage page;

        public CharacterReadPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterReadPage(new GenericViewModel<CharacterModel>(new CharacterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterReadPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterReadPage_Update_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_Delete_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Delete_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_GetItemToDisplay_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.GetItemToDisplay(ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /*
        [Test]
        public void CharacterReadPage_ShowPopup_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterReadPage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */

        [Test]
        public async Task CharacterReadPage_AddItemsToDisplay_With_Data_PrimaryHand_Should_Remove_And_Pass()
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
        public async Task CharacterReadPage_AddItemsToDisplay_With_Data_Feet_Should_Remove_And_Pass()
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
        public async Task CharacterReadPage_AddItemsToDisplay_With_Data_Head_Should_Remove_And_Pass()
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
        public async Task CharacterReadPage_AddItemsToDisplay_With_Data_LeftFinger_Should_Remove_And_Pass()
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
        public async Task CharacterReadPage_AddItemsToDisplay_With_Data_Necklace_Should_Remove_And_Pass()
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
        public async Task CharacterReadPage_AddItemsToDisplay_With_Data_OffHand_Should_Remove_And_Pass()
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
        public async Task CharacterReadPage_AddItemsToDisplay_With_Data_RightFinger_Should_Remove_And_Pass()
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
        public async Task CharacterReadPage_GetItemToDisplay_With_Item_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.PrimaryHand });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.PrimaryHand).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(2, result.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public async Task CharacterReadPage_GetItemToDisplay_With_NoItem_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            var item = new ItemModel { Location = ItemLocationEnum.PrimaryHand };
            await ItemIndexViewModel.Instance.CreateAsync(item);

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.PrimaryHand).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(2, result.Children.Count());
        }

        [Test]
        public async Task CharacterReadPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            page.ViewModel.Data.PrimaryHand = item.Id;
            var StackItem = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public async Task CharacterReadPage_GetTotalDamageForCharacter_With_Data_Feet_Should_Return_10_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Feet, Damage = 10 });

            var character = new CharacterModel();
            character.Feet = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Feet).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetTotalDamageForCharacter();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public async Task CharacterReadPage_GetTotalDamageForCharacter_With_Data_Head_Should_Return_15_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head, Damage = 15 });

            var character = new CharacterModel();
            character.Head = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Head).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetTotalDamageForCharacter();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public async Task CharacterReadPage_GetTotalDamageForCharacter_With_Data_LeftFinger_Should_Return_20_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Finger, Damage = 20 });

            var character = new CharacterModel();
            character.LeftFinger = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.LeftFinger).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetTotalDamageForCharacter();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(20, result);
        }

        [Test]
        public async Task CharacterReadPage_GetTotalDamageForCharacter_With_Data_RightFinger_Should_Return_10_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Finger, Damage = 10 });

            var character = new CharacterModel();
            character.RightFinger = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.RightFinger).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetTotalDamageForCharacter();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public async Task CharacterReadPage_GetTotalDamageForCharacter_With_Data_Necklace_Should_Return_10_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Necklace, Damage = 10 });

            var character = new CharacterModel();
            character.Necklace = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Necklace).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetTotalDamageForCharacter();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public async Task CharacterReadPage_GetTotalDamageForCharacter_With_Data_OffHand_Should_Return_10_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.OffHand, Damage = 10 });

            var character = new CharacterModel();
            character.OffHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.OffHand).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetTotalDamageForCharacter();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public async Task CharacterReadPage_GetTotalDamageForCharacter_With_Data_PrimaryHand_Should_Return_10_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.PrimaryHand, Damage = 10 });

            var character = new CharacterModel();
            character.PrimaryHand = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.PrimaryHand).First().Id;
            page.ViewModel.Data = character;

            // Act
            var result = page.GetTotalDamageForCharacter();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void CharacterReadPage_GetDamageFromStringId_With_Null_Data_Should_Return_0_And_Pass()
        {
            // Arrange
            ItemIndexViewModel.Instance.Dataset.Clear();

            // Act
            var result = page.GetDamageFromStringId("Some string id that doesn't exist");

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}