using System.Threading.Tasks;
using System.Collections.Generic;

using NUnit.Framework;

using Xamarin.Forms.Mocks;
using Xamarin.Forms;

using Game;
using Game.Views;
using Game.Models;
using Game.ViewModels;
using Game.GameRules;

namespace UnitTests.Views
{
    [TestFixture]
    public class BattlePageTwoTests : BattlePageTwo
    {
        App app;
        BattlePageTwo page;

        public BattlePageTwoTests() : base(true) { }

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

            var characters = DefaultData.LoadData(new CharacterModel());
            characters.Add(new CharacterModel());

            // add characters to the Engine
            foreach (var character in characters)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(character));
            }

            // create a list of monsters
            var monsters = DefaultData.LoadData(new MonsterModel());
            monsters.Add(new MonsterModel());

            // add monsters to the Engine
            foreach (var monster in monsters)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(monster));
            }

            // create a list of Items
            var items = DefaultData.LoadData(new ItemModel());
            items.Add(new ItemModel());

            // add monsters to the Engine
            foreach (var item in items)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.ItemModelDropList.Add(new ItemModel(item));
            }
           
            page = new BattlePageTwo();

            // Put seed data into the system for all tests
            //BattleEngineViewModel.Instance.Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            //BattleEngineViewModel.Instance.Engine.StartBattle(false);

        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void BattlePageTwo_OnAppearing_Should_Pass()
        {
            // Get the current valute

            // Act
            OnAppearing();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]

        public void CreatePlayerDisplayBox_Null_Should_Pass()
        {
            // Get the current value
           
            // Act
            page.CreatePlayerDisplayBox(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GetCharacterToDisplay_Clicked_Default_Should_Pass()
        {
            // Act
            page.GetCharacterToDisplay(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GetCharacterToDisplay_Clicked_Null_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel(new CharacterModel());
            var button = page.Content.FindByName("CharacterButton");

            // Act
            page.GetCharacterToDisplay(player);

            // Reset

            // Assert
            Assert.IsNull(button); // Got to here, so it happened...
        }

        [Test]
        public void ShowPopupCharacter_Clicked_Default_Should_Pass()
        {
            // Arrange
            var character = new CharacterModel();
            // Act
            page.ShowPopupCharacter(character);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PopupSaveButtonCharacter_Clicked_Default_Should_Pass()
        {
            // Arrange
            Button s = new Button();
            // should be an existing name
            s.CommandParameter = "Nancy";
            System.EventArgs e = new System.EventArgs();
            // Act
            page.PopupSaveButtonCharacter_Clicked(s, e);

            //Reset
           // BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
           // selectedCharacters.Clear();

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PopupSaveButtonItem_Clicked_Default_Should_Pass()
        {
            // Arrange
            Button s = new Button();
            page.selectedCharacters.Add(new PlayerInfoModel(new CharacterModel
            {
                Name = "Nancy",
                    Description = "I would have been a professor by now if it weren't for the stress of I-94 renewal",
                    CharacterTypeEnum = CharacterTypeEnum.Student,
                    SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.InternationalStudent,
                    Range = 2,
                    Level = 1,
                    GPA = 80,
                    MaxHealth = 100,
                    ImageURI = Constants.SpecificCharacterTypeInternationalStudentImageURI,
                    Head = "None",
                    Necklace = "None",
                    PrimaryHand = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.Notebook),
            OffHand = "None",
                    Feet = "None",
                    RightFinger = "None",
                    LeftFinger = "None",
                    SpecialAbility = AbilityEnum.FlashGenius
                }));
            // should be an existing name
            s.CommandParameter = "Notebooks1";
            System.EventArgs e = new System.EventArgs();

            // Act
            page.PopupSaveButtonItem_Clicked(s, e);

            // Reset
            //selectedMonsters.Clear();
            //  BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            //  mainMonsters.Clear();
            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PopupSaveButtonMonster_Clicked_Default_Should_Pass()
        {
            // Arrange
            Button s = new Button();
            // should be an existing name
            s.CommandParameter = "Karen";
            System.EventArgs e = new System.EventArgs();
            
            // Act
            page.PopupSaveButtonMonster_Clicked(s,e);

            // Reset
            selectedMonsters.Clear();
          //  BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
          //  mainMonsters.Clear();
            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }



        [Test]
        public void ShowPopupMonster_Clicked_Default_Should_Pass()
        {
            // Arrange
            var monster = new MonsterModel();
            // Act
            page.ShowPopupMonster(monster);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ShowPopupItem_Clicked_Default_Should_Pass()
        {
            // Arrange
            var item = new ItemModel();
            // Act
            page.ShowPopupItem(item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Default_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var item = new ItemModel();
            // Act
            page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Asser
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Head_IndexCard_Should_Fail()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel { Head = null });
            characters.Add(newCharacter);
            var item = new ItemModel { ItemType = ItemTypeEnum.IndexCards };
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsFalse(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Head_HeadItem_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                Head = "None",
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Student
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.Head;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsTrue(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Parent_HeadItem_Should_Fail()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {           
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Parent
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.Head;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsFalse(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Parent_HeadItem_Should_Fail2()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Parent
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsFalse(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Graduated_HeadItem_Should_Fail()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                Name = "something",
                Level = 20
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.Head;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsFalse(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Necklace_NeckLaceItem_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                Necklace = "None",
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Student
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.Necklace;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsTrue(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }



        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_RightFinger_RightFingerItem_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                RightFinger = "None",
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Student
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.RightFinger;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsTrue(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }


        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_PrimaryHand_PrimaryHandItem_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                PrimaryHand = "None",
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Student
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.PrimaryHand;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsTrue(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }


        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_OffHand_OffHandItem_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                OffHand = "None",
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Student
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.OffHand;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsTrue(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }


        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_LeftFinger_LeftFingerItem_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                LeftFinger = "None",
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Student
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.LeftFinger;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsTrue(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Feet_FeetItem_Should_Pass()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                Feet = "None",
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Student
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.Feet;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsTrue(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }

        [Test]
        public void CharacterWhoCanAcceptItem_Clicked_Parent_FeetItem_Should_Fail()
        {
            // Arrange
            var characters = new List<PlayerInfoModel>();
            var newCharacter = new PlayerInfoModel(new CharacterModel
            {
                Name = "something",
                CharacterTypeEnum = CharacterTypeEnum.Parent
            });
            characters.Add(newCharacter);
            var item = new ItemModel();
            item.Location = ItemLocationEnum.Feet;
            // Act
            var list_of_characters = page.GetCharacterWhoCanAcceptItem(characters, item);

            // Reset

            // Assert
            Assert.IsFalse(list_of_characters.Contains(newCharacter.Name)); // Got to here, so it happened...
        }


        [Test]
        public void AddItemToCharacter_Clicked_Feet_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel();
            var item = new ItemModel();
            // Act
            page.AddItemToCharacter(player, ItemLocationEnum.Feet, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void AddItemToCharacter_Clicked_Head_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel();
            var item = new ItemModel();
            // Act
            page.AddItemToCharacter(player, ItemLocationEnum.Head, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void AddItemToCharacter_Clicked_OffHand_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel();
            var item = new ItemModel();
            // Act
            page.AddItemToCharacter(player, ItemLocationEnum.OffHand, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void AddItemToCharacter_Clicked_Necklace_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel();
            var item = new ItemModel();
            // Act
            page.AddItemToCharacter(player, ItemLocationEnum.Necklace, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void AddItemToCharacter_Clicked_PrimaryHand_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel();
            var item = new ItemModel();
            // Act
            page.AddItemToCharacter(player, ItemLocationEnum.PrimaryHand, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void AddItemToCharacter_Clicked_RightFinger_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel();
            var item = new ItemModel();
            // Act
            page.AddItemToCharacter(player, ItemLocationEnum.RightFinger, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void AddItemToCharacter_Clicked_LeftFinger_Should_Pass()
        {
            // Arrange
            var player = new PlayerInfoModel();
            var item = new ItemModel();
            // Act
            page.AddItemToCharacter(player, ItemLocationEnum.LeftFinger, item);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }





        [Test]
        public void PopupCloseButtonItem_Clicked_Default_Should_Pass()
        {
            // Arrange


            // Act
            page.ClosePopupItem_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GetMonsterToDisplay_Clicked_Default_Should_Pass()
        {
            // Act
            page.GetMonsterToDisplay(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GetMonsterToDisplay_Clicked_Null_Should_Pass()
        {
            // Act
            var monster = new PlayerInfoModel(new MonsterModel { Id = null });
            var result = page.GetMonsterToDisplay(monster);

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }

        [Test]
        public void GetItemToDisplay_Clicked_Default_Should_Pass()
        {
            // Act
            page.GetItemToDisplay(null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void GetItemToDisplay_Clicked_NotNull_Should_Pass()
        {
            // Act
            var result = page.GetItemToDisplay(new ItemModel { ItemType=ItemTypeEnum.Skateboard});

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }

        [Test]
        public void GetItemToDisplay_Clicked_Null_Should_Pass()
        {
            // Act
            var item = new ItemModel{ Id = null };
            var result = page.GetItemToDisplay(item);

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }

        [Test]
        public void PopupCloseButtonCharacter_Clicked_Default_Should_Pass()
        {
            // Act
            page.ClosePopupCharacter_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PopupCloseButtonMonster_Clicked_Default_Should_Pass()
        {
            // Arrange
         

            // Act
            page.ClosePopupMonster_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void DrawCharacterList_Default_Should_Pass()
        {
            // Act
            page.DrawCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void DrawSelectedCharacters_Default_Should_Pass()
        {
            // Act
            page.DrawSelectedCharacters();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void DrawCharacterList_AddRemove_Should_Pass()
        {
            // Arrange
            var FlexList = new List<FlexLayout>();
            var data = new FlexLayout();
            FlexList.Add(data);
            FlexList.Remove(data);
            // Act
            page.DrawCharacterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void DrawSelectedCharacters_AddRemove_Should_Pass()
        {
            // Arrange
            FlexLayout characterlistselectedframe = (FlexLayout)page.Content.FindByName("CharacterListSelectedFrame");
            // add two elements to the list because when will be removed
            characterlistselectedframe.Children.Add(new FlexLayout());
            characterlistselectedframe.Children.Add(new FlexLayout());

            // Act
            page.DrawSelectedCharacters();

            // Reset

            // Assert
            Assert.AreEqual(0, characterlistselectedframe.Children.Count);
        }

        [Test]
        public void DrawItems_Default_Should_Pass()
        {
            // Act
            page.DrawItems();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void DrawItems_Remove_Should_Pass()
        {
            // Arrange
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");
            // add two elements to the list because when will be removed
            itemlistfoundframe.Children.Add(new FlexLayout());
            itemlistfoundframe.Children.Add(new FlexLayout());

            // Act
            page.DrawItems();

            // Reset

            // Assert
            Assert.AreEqual(0, itemlistfoundframe.Children.Count);
        }

        [Test]
        public void DrawMonsterList_Default_Should_Pass()
        {
            // Act
            page.DrawMonsterList();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void DrawSelectedMonsters_Default_Should_Pass()
        {
            // Act
            page.DrawSelectedMonsters();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void DrawSelectedMonsters_AddRemove_Should_Pass()
        {
            // Arrange
            FlexLayout monsterlistselectedframe = (FlexLayout)page.Content.FindByName("MonsterListSelectedFrame");
            // add two elements to the list because when will be removed
            monsterlistselectedframe.Children.Add(new FlexLayout());
            monsterlistselectedframe.Children.Add(new FlexLayout());

            // Act
            page.DrawSelectedMonsters();

            // Reset

            // Assert
            Assert.AreEqual(0, monsterlistselectedframe.Children.Count);
        }

        [Test]
        public void DrawItemList_Default_Should_Pass()
        {
            // Act
            page.DrawItemLists();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void DrawSelectedItems_Default_Should_Pass()
        {
            // Act
            page.DrawSelectedItem();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void DrawSelectedItems_Remove_Should_Pass()
        {
            // Arrange
            FlexLayout itemlistselectedframe = (FlexLayout)page.Content.FindByName("ItemListSelectedFrame");
            // add two elements to the list because when will be removed
            itemlistselectedframe.Children.Add(new FlexLayout());
            itemlistselectedframe.Children.Add(new FlexLayout());

            // Act
            page.DrawSelectedItem();

            // Reset

            // Assert
            Assert.AreEqual(0, itemlistselectedframe.Children.Count);
        }

        [Test]
        public void BattlePageTwo_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattlePageTwo_ConstructorFlexLayout_Default_Should_Pass()
        {
            // Arrange
            var flexlayout = new FlexLayout();

            // Act
            var result = new BattlePageTwo(flexlayout);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }



        [Test]
        public void BattlePageTwo_AttackButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.AttackButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        /*
        [Test]
        public void BattlePage_ShowScoreButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowScoreButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_ExitButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ExitButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        

        [Test]
        public void BattlePage_StartButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.StartButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_NextRoundButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.NextRoundButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_ShowModalRoundOverPage_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowModalRoundOverPage();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */


        // [Test]
        //public void BattlePage_ClearMessages_Default_Should_Pass()
        //{
        // Arrange

        // Act
        //  page.ClearMessages();

        // Reset

        // Assert
        //Assert.IsTrue(true); // Got to here, so it happened...
        //}

        /*
        [Test]
        public void BattlePage_GameMessage_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.GameMessage();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_GameMessage_LevelUp_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.LevelUpMessage = "me";

            // Act
            page.GameMessage();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        */

        // [Test]
        // public void BattlePage_DrawGameBoardAttackerDefender_CurrentAttacker_Null_CurrentDefender_Null_Should_Pass()
        //{
        // Arrange
        //  BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
        //BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);

        // Act
        //page.DrawGameAttackerDefenderBoard();

        // Reset

        // Assert
        //Assert.IsTrue(true); // Got to here, so it happened...
        // }

        //  [Test]
        // public void BattlePage_DrawGameBoardAttackerDefender_CurrentAttacker_InValid_Null_Should_Pass()
        // {
        // Arrange

        //   var PlayerInfo = new PlayerInfoModel(new CharacterModel());

        // BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(PlayerInfo);
        //    BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(null);

        // Act
        //      page.DrawGameAttackerDefenderBoard();

        // Reset

        // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //  [Test]
        // public void BattlePage_DrawGameBoardAttackerDefender_CurrentDefender_InValid_Null_Should_Pass()
        //{
        // Arrange

        //  var PlayerInfo = new PlayerInfoModel(new CharacterModel());

        //BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
        //BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(PlayerInfo);

        // Act
        //page.DrawGameAttackerDefenderBoard();

        // Reset

        // Assert
        //Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //  [Test]
        //   public void BattlePage_DrawGameBoardAttackerDefender_CurrentDefender_Valid_Should_Pass()
        // {
        // Arrange

        //   BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(new PlayerInfoModel(new CharacterModel()));
        // BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(new PlayerInfoModel(new CharacterModel { Alive = false }));

        // Act
        //    page.DrawGameAttackerDefenderBoard();

        // Reset

        // Assert
        //   Assert.IsTrue(true); // Got to here, so it happened...
        // }

        /*
        [Test]
        public void BattlePage_DrawGameBoardAttackerDefender_Invalid_AttackerSource_Null_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(new PlayerInfoModel(new CharacterModel()));
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(new PlayerInfoModel(new CharacterModel { Alive = false }));

            var oldItem = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PrimaryHand;

            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PrimaryHand = item.Id;

            // Act
            page.DrawGameAttackerDefenderBoard();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PrimaryHand = oldItem;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_NextAttackExample_NextRound_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(new CharacterModel()));

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();

            BattleEngineViewModel.Instance.Engine.Round.MakePlayerList();

            // Has no monster, so should show next round.

            // Act
            page.NextAttackExample();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_NextAttackExample_GameOver_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            BattleEngineViewModel.Instance.Engine.Round.MakePlayerList();

            // Has no Character, so should show end game

            // Act
            page.NextAttackExample();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetAttackerAndDefender_Character_vs_Monster_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Make Character
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make Monster

            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);

            // Act
            page.SetAttackerAndDefender();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetAttackerAndDefender_Monster_vs_Character_Should_Pass()
        {
            // Arrange

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Make Character
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make Monster

            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(CharacterPlayer);

            // Act
            page.SetAttackerAndDefender();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetAttackerAndDefender_Character_vs_Unknown_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Make Character
            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make Monster

            BattleEngineViewModel.Instance.Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                            new MonsterModel
                            {
                                Speed = 100,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                                PlayerType = PlayerTypeEnum.Unknown
                            });

            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(CharacterPlayer);

            // Act
            page.SetAttackerAndDefender();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_GameOver_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.GameOver();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetSelectedCharacter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.SetSelectedCharacter(new MapModelLocation());

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetSelectedMonster_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.SetSelectedMonster(new MapModelLocation());

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_SetSelectedEmpty_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.SetSelectedEmpty(new MapModelLocation());

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_UpdateMapGrid_InValid_Bogus_Image_Should_Fail()
        {
            // Make the Row Bogus
            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation[0, 0].Row = -1;

            // Act
            var result = page.UpdateMapGrid();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation[0, 0].Row = 0;

            // Assert
            Assert.AreEqual(false, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_UpdateMapGrid_InValid_Bogus_ImageButton_Should_Fail()
        {
            // Get the current valute
            var name = "MapR0C0ImageButton";
            page.MapLocationObject.TryGetValue(name, out object data);
            page.MapLocationObject.Remove(name);

            // Act
            var result = page.UpdateMapGrid();

            // Reset
            page.MapLocationObject.Add(name, data);

            // Assert
            Assert.AreEqual(false, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_UpdateMapGrid_InValid_Bogus_Stack_Should_Fail()
        {
            // Get the current valute
            var nameStack = "MapR0C0Stack";
            page.MapLocationObject.TryGetValue(nameStack, out object dataStack);
            page.MapLocationObject.Remove(nameStack);

            var nameImage = "MapR0C0ImageButton";
            page.MapLocationObject.TryGetValue(nameImage, out object dataImage);

            page.MapLocationObject.Remove(nameImage);

            var dataImageBogus = new ImageButton { AutomationId = "bogus" };
            page.MapLocationObject.Add(nameImage, dataImageBogus);

            // Act
            var result = page.UpdateMapGrid();

            // Reset
            page.MapLocationObject.Remove(nameImage);
            page.MapLocationObject.Add(nameImage, dataImage);
            page.MapLocationObject.Add(nameStack, dataStack);

            // Assert
            Assert.AreEqual(false, result); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_UpdateMapGrid_Valid_Stack_Should_Pass()
        {
            // Need to build out a valid MapGrid with Engine MapGridLocation

            // Make Map in Engine

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.PopulateMapModel(BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList);

            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Unknown;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Make UI Map
            page.CreateMapGridObjects();
            page.UpdateMapGrid();

            // Move Character in Engine
            var result = BattleEngineViewModel.Instance.Engine.Round.Turn.MoveAsTurn(MonsterPlayer);

            // Act

            // Call for UpateMap
            page.UpdateMapGrid();

            // Reset

            // Assert
            Assert.AreEqual(true, result); // Got to here, so it happened...
        }

        [Test]
        public async Task BattlePage_ShowBattleSettingsPage_Default_Should_Pass()
        {
            // Get the current valute

            // Act
            await page.ShowBattleSettingsPage();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePage_Settings_Clicked_Default_Should_Pass()
        {
            // Get the current valute

            // Act
            page.Setttings_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattleSettingsPage_MakeMapGridBox_InValid_Should_Fail()
        {
            // Arrange
            var data = new MapModelLocation { Player = null, Column = 0, Row = 0 };

            // Act
            var result = page.MakeMapGridBox(data);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Default, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum);
        }

        [Test]
        public void BattleSettingsPage_ShowBattleMode_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowBattleMode();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeUIElements_Starting_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Starting;

            // Act
            page.ShowBattleModeUIElements();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeUIElements_NewRound_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.NewRound;

            // Act
            page.ShowBattleModeUIElements();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeUIElements_GameOver_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;

            // Act
            page.ShowBattleModeUIElements();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeUIElements_RoundOver_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.RoundOver;

            // Act
            page.ShowBattleModeUIElements();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeUIElements_Battling_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            // Act
            page.ShowBattleModeUIElements();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeUIElements_Unknown_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Unknown;

            // Act
            page.ShowBattleModeUIElements();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeDisplay_MapAbility_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.MapAbility;

            // Act
            page.ShowBattleModeDisplay();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeDisplay_MapFull_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.MapFull;

            // Act
            page.ShowBattleModeDisplay();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeDisplay_MapNext_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.MapNext;

            // Act
            page.ShowBattleModeDisplay();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeDisplay_SimpleAbility_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.SimpleAbility;

            // Act
            page.ShowBattleModeDisplay();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeDisplay_SimpleUnknown_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.Unknown;

            // Act
            page.ShowBattleModeDisplay();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_ShowBattleModeDisplay_SimpleNext_Should_Pass()
        {
            // Arrange
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnum.SimpleNext;

            // Act
            page.ShowBattleModeDisplay();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = save;

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_MapIcon_Clicked_Character_Should_Pass()
        {
            // Arrange
            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.PopulateMapModel(BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList);

            // Make UI Map
            page.CreateMapGridObjects();

            var nameImage = "MapR0C0ImageButton";
            page.MapLocationObject.TryGetValue(nameImage, out object dataImage);

            // Act

            // Force the click event to fire
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_MapIcon_Clicked_Monster_Should_Pass()
        {
            // Arrange
            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.PopulateMapModel(BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList);

            // Make UI Map
            page.CreateMapGridObjects();

            var nameImage = "MapR5C0ImageButton";
            page.MapLocationObject.TryGetValue(nameImage, out object dataImage);

            // Act

            // Force the click event to fire
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got Here
        }

        [Test]
        public void BattleSettingsPage_MapIcon_Clicked_Empty_Should_Pass()
        {
            // Arrange
            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Add(MonsterPlayer);

            BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.PopulateMapModel(BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList);

            // Make UI Map
            page.DrawMapGridInitialState();

            var nameImage = "MapR3C3ImageButton";
            page.MapLocationObject.TryGetValue(nameImage, out object dataImage);

            // Act

            // Force the click event to fire
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got Here
        }
        */
    }
}