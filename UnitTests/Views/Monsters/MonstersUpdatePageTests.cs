using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Linq;

namespace UnitTests.Views
{
    [TestFixture]
    public class MonsterUpdatePageTests : MonsterUpdatePage
    {
        App app;
        MonsterUpdatePage page;

        public MonsterUpdatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterUpdatePage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Name = "Mike";
            page.ViewModel.Data.Description = "Too many projects!";

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void MonsterUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_AttackSlider_OnSliderValueChanged_Default_Should_Pass()
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
        public void MonsterUpdatePage_DefenseSlider_OnSliderValueChanged_Default_Should_Pass()
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
        public void MonsterUpdatePage_SpeedSlider_OnSliderValueChanged_Default_Should_Pass()
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


        [Test]
        public void MonsterUpdatePage_UpdateNewItem_Clicked_Default_Should_Pass()
        {
            // Arrange
            ItemModel item = new ItemModel();
            // Act
            page.UpdateNewItem(null, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        

        [Test]
        public void MonsterUpdatePage_LoadItem_Default_Should_Pass()
        {
            // Arrange

            var data = new ItemModel();

            // Act
            page.LoadItem(data);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_AddUniqueDropItemToDisplay_Default_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.UniqueDropItem = "Skateboard";
            page.AddUniqueDropItemToDisplay();

            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            // Act

            // Reset
            page.ViewModel.Data.UniqueDropItem = null;

            // Assert
            Assert.AreEqual(1, itemBox.Children.Count());  // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_AddUniqueDropItemToDisplay_Reload_Should_Pass()
        {
            // Arrange
            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            itemBox.Children.Add(new Label());
            itemBox.Children.Add(new Label());

            // Act
            page.AddUniqueDropItemToDisplay();

            // Reset

            // Assert
            Assert.AreEqual(0, itemBox.Children.Count());  // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_AddUniqueDropItemToDisplay_Empty_Should_Pass()
        {
            // Arrange
            page.AddUniqueDropItemToDisplay();

            FlexLayout itemBox = (FlexLayout)page.Content.FindByName("ItemBox");

            // Act

            // Reset

            // Assert
            Assert.AreEqual(0, itemBox.Children.Count());  // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
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

    }
}