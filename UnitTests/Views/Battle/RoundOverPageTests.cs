using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.Models;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.ViewModels;

namespace UnitTests.Views
{
    [TestFixture]
    public class RoundOverPageTests : RoundOverPage
    { 
        App app;
        RoundOverPage page;

        public RoundOverPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            page = new RoundOverPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void RoundOverPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }


        [Test]
        public void RoundOverPage_CloseButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        
        [Test]
        public void RoundOverPage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_Feet_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.Feet;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual("item id", player.Feet);
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_Head_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.Head;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual("item id", player.Head);
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_Necklace_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.Necklace;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual("item id", player.Necklace);
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_LeftFinger_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.LeftFinger;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual("item id", player.LeftFinger);
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_Offhand_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.OffHand;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual("item id", player.OffHand);
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_PrimaryHand_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.PrimaryHand;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual("item id", player.PrimaryHand);
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_RightFinger_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.RightFinger;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual("item id", player.RightFinger);
        }

        [Test]
        public void RoundOverPage_AddItemToCharacter_Unknown_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel { Id = "item id" };
            var player = new PlayerInfoModel();
            var location = ItemLocationEnum.Unknown;

            // Act
            page.AddItemToCharacter(player, location, item);

            // Reset

            // Assert
            Assert.AreEqual(null, player.Feet);
            Assert.AreEqual(null, player.Head);
            Assert.AreEqual(null, player.LeftFinger);
            Assert.AreEqual(null, player.Necklace);
            Assert.AreEqual(null, player.OffHand);
            Assert.AreEqual(null, player.PrimaryHand);
            Assert.AreEqual(null, player.RightFinger);
        }

        [Test]
        public void RoundOverPage_GameOverButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.GameOverButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_CreatePlayerDisplayBox_Null_Should_Pass()
        {
            // Arrange
            // Act
            page.CreatePlayerDisplayBox(null);

            // Reset


            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_FindItemForLocation_Item_Location_Matches_Should_Pass()
        {
            // Arrange
            var location = ItemLocationEnum.Necklace;
            var item1 = new ItemModel { Location = ItemLocationEnum.Necklace };
            var item2 = new ItemModel { Location = ItemLocationEnum.Feet };
            var items = new List<ItemModel>
            {
                item1,
                item2
            };

            // Act
            var result = page.FindItemForLocation(location, items);

            // Reset


            // Assert
            Assert.AreEqual(item1, result); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_FindItemForLocation_Item_Location_No_Match_Should_Pass()
        {
            // Arrange
            var location = ItemLocationEnum.Head;
            var item1 = new ItemModel { Location = ItemLocationEnum.Necklace };
            var item2 = new ItemModel { Location = ItemLocationEnum.Feet };
            var items = new List<ItemModel>
            {
                item1,
                item2
            };

            // Act
            var result = page.FindItemForLocation(location, items);

            // Reset


            // Assert
            Assert.AreEqual(null, result); // Got to here, so it happened...
        }




        /*
        [Test]
        public void RoundOverPage_DrawCharacterList_Valid_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel { Level = 1}));
            ((FlexLayout)page.FindByName("CharacterListFrame")).Children.Add(new Label());
            ((FlexLayout)page.FindByName("CharacterListFrame")).Children.Add(new Label());
            ((FlexLayout)page.FindByName("CharacterListFrame")).Children.Add(new Label());

            // Act - draw it twice
            page.DrawCharacterList();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = null;
            var flexList = ((FlexLayout)page.FindByName("CharacterListFrame")).Children.ToList();
            foreach (var data in flexList)
			{
                ((FlexLayout)page.FindByName("CharacterListFrame")).Children.Remove(data);

            }

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */

        /*
        [Test]
        public void RoundOverPage_DrawGraduatesList_Valid_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            // Act
            page.DrawCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */

        /*
        [Test]
        public void RoundOverPage_DrawDroppedItems_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());

            // Draw two times
            page.DrawDroppedItems();

            // Act
            page.DrawDroppedItems();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        

        [Test]
        public void RoundOverPage_DrawItemLists_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(new ItemModel());

            // Draw two times
            page.DrawItemLists();

            // Act  BattleEngineViewModel.Instance.Engine.EngineSettings.
            page.DrawItemLists();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_DrawSelectedItems_Valid_Should_Pass()
        {
            // Arrange

            // Draw the Items
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelSelectList.Add(new ItemModel());

            // Draw two times
            page.DrawSelectedItems();

            // Act
            page.DrawSelectedItems();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */

        /*
        [Test]
        public void RoundOverPage_ShowPopup_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }



        [Test]
        public void RoundOverPage_GetItemToDisplay_Null_Should_Pass()
        {
            // Arrange
            // Act
            page.GetItemToDisplay(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetItemToDisplay_InValid_Id_Should_Pass()
        {
            // Arrange
            // Act
            page.GetItemToDisplay(new ItemModel { Id = "" });

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public async Task RoundOverPage_GetItemToDisplay_Valid_Should_Pass()
        {
            // Arrange
            var data = new ItemModel { Name = "Mike" };
            await ItemIndexViewModel.Instance.CreateAsync(data);

            // Act
            page.GetItemToDisplay(data);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }





        [Test]
        public void RoundOverPage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            var StackItem = page.GetItemToDisplay(item);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */
    }
}