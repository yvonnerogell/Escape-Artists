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
    public class MonsterReadPageTests : MonsterReadPage
    {
        App app;
        MonsterReadPage page;

        public MonsterReadPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterReadPage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterReadPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterReadPage_Update_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Update_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_Delete_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Delete_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_GetDamageFromUniqueDropItem_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.GetDamageFromUniqueDropItem("Skateboard");

            // Reset

            // Assert
            Assert.IsTrue(true);

        }

        [Test]
        public void MonsterReadPage_ShowItem_Valid_Should_Pass()
        {
            // Arrange
            ItemModel item = new ItemModel(ItemTypeEnum.PencilEraser);

            // Act
            page.ShowItem(null, item);

            // Reset

            // Assert
            Assert.IsTrue(true);

        }

        
        [Test]
        public void MonsterReadPage_LoadItem_Valid_Should_Pass()
        {
            // Arrange
            ItemModel item = new ItemModel(ItemTypeEnum.PencilEraser);

            // Act
            page.LoadItem(item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_LoadItem_Valid_Click_Button_Should_Open_Popup()
        {
            // Arrange
            ItemModel item = new ItemModel(ItemTypeEnum.PencilEraser);

            var stackView = page.LoadItem(item);

            ImageButton imageButtonView = new ImageButton();

            foreach (View i in ((StackLayout)stackView).Children.Where(x => x.GetType() == typeof(ImageButton)))
            {
                imageButtonView = (ImageButton)i;
            }

            // Act
            imageButtonView.PerformClick();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void MonsterReadPage_AddItemsToDisplay_With_Data_Should_Remove_And_Pass()
        {
            // Arrange

            // Put some data into the box so it can be removed
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            // remove and load based on unique item, since this model doesn't have any should load nothing
            page.AddUniqueDropItemToDisplay();

            // Reset

            // Assert
            Assert.AreEqual(0, itemBox.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public async Task MonsterReadPage_GetItemToDisplay_With_Item_Should_Pass()
        {
            // Arrange
            //ItemIndexViewModel.Instance.Dataset.Clear();

            //await ItemIndexViewModel.Instance.CreateAsync(new ItemModel { Location = ItemLocationEnum.Head });

            var Monster = new MonsterModel();
            ItemModel item = ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Head).First();
            Monster.UniqueDropItem = item.Id;
            page.ViewModel.Data = Monster;

            // Act
            page.AddUniqueDropItemToDisplay();
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            // Reset

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count()); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var StackItem = page.LoadItem(new ItemModel());
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_CheckUniqueDrop_Valid_Should_Pass()
        {
            // Arrange
            var original = page.ViewModel.Data.UniqueDropItem;
            page.ViewModel.Data.UniqueDropItem = "FakeId";

            // Act
            page.CheckUniqueDrop();

            // Reset
            page.ViewModel.Data.UniqueDropItem = original;
            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterReadPage_LoadItem_Null_Should_Pass()
        {
            // Arrange
            var original = page.ViewModel.Data.UniqueDropItem;
            page.ViewModel.Data.UniqueDropItem = "FakeId";

            // Act
            var result = page.LoadItem(null);

            // Reset
            page.ViewModel.Data.UniqueDropItem = original;
            // Assert
            Assert.AreEqual(result, null); // Got to here, so it happened...
        }
    }
}