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

            // Reset monster list because closebutton calls new round, which adds monsters. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();

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

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Graduate_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 20 }) };
            var item = new ItemModel { Location = ItemLocationEnum.Necklace };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }


        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Feet_Null_Parent_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Feet = null, CharacterTypeEnum = CharacterTypeEnum.Parent }) };
            var item = new ItemModel { Location = ItemLocationEnum.Feet };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Feet_None_Student_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Feet = "None", CharacterTypeEnum = CharacterTypeEnum.Student }) };
            var item = new ItemModel { Location = ItemLocationEnum.Feet };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Feet_Null_Student_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Feet = null, CharacterTypeEnum = CharacterTypeEnum.Student }) };
            var item = new ItemModel { Location = ItemLocationEnum.Feet };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Feet_None_Parent_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Feet = "None", CharacterTypeEnum = CharacterTypeEnum.Parent }) };
            var item = new ItemModel { Location = ItemLocationEnum.Feet };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Feet_None_No_Item_Match_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Feet = "None", CharacterTypeEnum = CharacterTypeEnum.Parent }) };
            var item = new ItemModel { Location = ItemLocationEnum.Head };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Head_Null_Parent_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Head = null, CharacterTypeEnum = CharacterTypeEnum.Parent, Feet = "feet" }) };
            var item = new ItemModel { Location = ItemLocationEnum.Head };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Head_None_Student_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Head = "None", CharacterTypeEnum = CharacterTypeEnum.Student, Feet = "feet" }) };
            var item = new ItemModel { Location = ItemLocationEnum.Head };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Head_Null_Student_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Head = null, CharacterTypeEnum = CharacterTypeEnum.Student }) };
            var item = new ItemModel { Location = ItemLocationEnum.Head };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Head_None_Parent_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Head = "None", CharacterTypeEnum = CharacterTypeEnum.Parent }) };
            var item = new ItemModel { Location = ItemLocationEnum.Head };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Head_None_Item_No_Match_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel { Level = 1, Head = "None", CharacterTypeEnum = CharacterTypeEnum.Parent }) };
            var item = new ItemModel { Location = ItemLocationEnum.Feet };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_LeftFinger_Null_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1,
                LeftFinger = null,
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                OffHand = "offhand",
                Necklace = "necklace",
                RightFinger = "rigth finger",
                PrimaryHand = "primary hand",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.LeftFinger };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_LeftFinger_None_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1,
                LeftFinger = "None",
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = "feet",
                OffHand = "offhand",
                Necklace = "necklace",
                RightFinger = "rigth finger",
                PrimaryHand = "primary hand",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.LeftFinger };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_LeftFinger_None_Item_No_Match_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1,
                LeftFinger = "None",
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = "feet",
                OffHand = "offhand",
                Necklace = "necklace",
                RightFinger = "rigth finger",
                PrimaryHand = "primary hand",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.PrimaryHand };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Necklace_Null_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, Necklace = null,
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = "feet",
                OffHand = "offhand",
                PrimaryHand = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.Necklace };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Necklace_None_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, Necklace = "None",
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                OffHand = "offhand",
                PrimaryHand = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.Necklace };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Necklace_None_Item_No_Match_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, Necklace = "None",
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                OffHand = "offhand",
                PrimaryHand = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.PrimaryHand };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Offhand_Null_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, OffHand = null,
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                Necklace = "necklace",
                PrimaryHand = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.OffHand };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Offhand_None_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, OffHand = "None",
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = "feet",
                Necklace = "necklace",
                PrimaryHand = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.OffHand };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_Offhand_None_Item_No_Match_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, OffHand = "None",
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = "feet",
                Necklace = "necklace",
                PrimaryHand = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.Head };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_PrimaryHand_Null_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, PrimaryHand = null,
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = "feet",
                OffHand = "offhand",
                Necklace = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.PrimaryHand };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_PrimaryHand_None_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, PrimaryHand = "None",
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                OffHand = "offhand",
                Necklace = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.PrimaryHand };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_PrimaryHand_None_Item_No_MatchShould_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, PrimaryHand = "None",
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                OffHand = "offhand",
                Necklace = "primary hand",
                RightFinger = "rigth finger",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.OffHand };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_RightFinger_Null_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, RightFinger = null,
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = "feet",
                OffHand = "offhand",
                PrimaryHand = "primary hand",
                Necklace = "necklace",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.RightFinger };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_RightFinger_None_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, RightFinger = "None",
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                OffHand = "offhand",
                PrimaryHand = "primary hand",
                Necklace = "necklace",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.RightFinger };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(1, result.Count); // Got to here, so it happened...
        }


        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_RightFinger_None_Item_No_Match_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, RightFinger = "None",
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = "feet",
                OffHand = "offhand",
                PrimaryHand = "primary hand",
                Necklace = "necklace",
                LeftFinger = "left finger",
                Head = "head"}) };
            var item = new ItemModel { Location = ItemLocationEnum.LeftFinger };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }

        [Test]
        public void RoundOverPage_GetCharacterWhoCanAcceptItem_None_Available_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel> { new PlayerInfoModel(new CharacterModel {
                Level = 1, Feet = "None",
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Head = "head", PrimaryHand = "primary hand", OffHand = "off hand", Necklace = "necklace",
                RightFinger = "right finger", LeftFinger = "left finger"
            }) };
            var item = new ItemModel { Location = ItemLocationEnum.RightFinger };

            // Act
            var result = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Count); // Got to here, so it happened...
        }



        /*
        [Test]
        public void RoundOverPage_DrawCharacterList_Valid_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = null;
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList = new List<PlayerInfoModel>();
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel { Level = 1, Name = "Name", ImageURI="squid.jpg"}));
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