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
            //BattleEngineViewModel.Instance.SetBattleEngineToKoenig();
            BattleEngineViewModel.Instance.SetBattleEngineToGame();

            // Put seed data into the system for all tests
            BattleEngineViewModel.Instance.Engine.Round.ClearLists();
            CharacterModel TestCharacter = new CharacterModel
            {
                Name = "TestCharacterName",
                TileImageURI = Constants.SpecificCharacterTypeDefaultTileImageURI,
                SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants,
                PrimaryHand = ItemIndexViewModel.Instance.GetDefaultItemTypeItemId(ItemTypeEnum.Notebook),
            };

            MonsterModel TestMonster = new MonsterModel
            {
                Id = "TestMonsterId",
                Name = "TestMonsterName",
                TileImageURI = Constants.SpecificMonsterTypeAssistantProfessorTileImageURI,
                SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AssistantProfessor,
            };

            PlayerInfoModel TestPlayerMonster = new PlayerInfoModel(TestMonster);
            TestPlayerMonster.Id = "TestMonsterPlayerId";
            
            BattleEngineViewModel.Instance.Engine.EngineSettings.MonsterList.Add(TestPlayerMonster);

            BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(new PlayerInfoModel(TestCharacter));
            BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(TestPlayerMonster);
            //Start the Engine in AutoBattle Mode
            //BattleEngineViewModel.Instance.Engine.StartBattle(false);

            page = new BattlePageTwo();
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
        public void PopupSaveButtonItem_Clicked_Default_Should_Pass()
        {

            // Arrange
            Button s = new Button();

            // should be an existing name
            s.CommandParameter = "Notebooks1";
            System.EventArgs e = new System.EventArgs();

            // Act
            page.PopupSaveButtonItem_Clicked(s, e); 

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...

        }

        [Test]
        public void PopupSaveButtonMonster_Clicked_Default_Should_Pass()
        {
            // Arrange
            Button s = new Button();
            // should be an existing name
            s.CommandParameter = "TestMonsterPlayerId";
            System.EventArgs e = new System.EventArgs();
            
            // Act
            page.PopupSaveButtonMonster_Clicked(s,e);

            // Reset
            
            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
            Assert.AreEqual("TestMonsterPlayerId", BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Id);
        }

        [Test]
        public void ShowPopupMonster_Clicked_Default_Should_Pass()
        {
            // Arrange
            var monster = new PlayerInfoModel();
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
            
            // Arrange
            var player = new PlayerInfoModel(new MonsterModel());
            var button = page.Content.FindByName("MonsterButton");

            // Act
            page.GetMonsterToDisplay(player);

            // Reset

            // Assert
            Assert.IsNull(button); // Got to here, so it happened...
        }

        [Test]
        public void BattlePageTwo_GetMonsterToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var monster = new PlayerInfoModel(new MonsterModel { SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.AdjunctFaculty });
            var StackItem = page.GetMonsterToDisplay(monster);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
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
        public void BattlePageTwo_GetItemToDisplay_Click_Button_Valid_Should_Pass()
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

        [Test]
        public void GetItemToDisplay_Clicked_NotNull_Should_Pass()
        {
            // Arrange

            // Act
            var result = page.GetItemToDisplay(new ItemModel { ItemType=ItemTypeEnum.Skateboard});

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
        }

        [Test]
        public void GetItemToDisplay_Clicked_Null_Should_Pass()
        {
            // Arrange

            // Act
            var item = new ItemModel{ Id = null };
            var result = page.GetItemToDisplay(item);

            // Reset

            // Assert
            Assert.IsNotNull(result); // Got to here, so it happened...
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
            // Arrange

            // Act
            page.DrawCharacterList();

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

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...

            // Reset
        }

        [Test]
        public void DrawItems_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;

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
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;

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
        public void DrawItems_Add_Head_Should_Pass()
        {
            // Arrange
            
            // Items are added to this FlexLayout
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");
            
            // Populate ItemList and CharacterList
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(new CharacterModel
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
                Head = "Skateboard",
                SpecialAbility = AbilityEnum.FlashGenius
            });

            // Act
            page.DrawItems();

            // Assert
            Assert.AreEqual(1, itemlistfoundframe.Children.Count);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
        }

        [Test]
        public void DrawItems_Add_Necklace_Should_Pass()
        {
            // Arrange

            // Items are added to this FlexLayout
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");

            // Populate ItemList and CharacterList
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(new CharacterModel
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
                Necklace = "Skateboard",
                SpecialAbility = AbilityEnum.FlashGenius
            });

            // Act
            page.DrawItems();

            // Assert
            Assert.AreEqual(1, itemlistfoundframe.Children.Count);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
        }

        [Test]
        public void DrawItems_Add_OffHand_Should_Pass()
        {
            // Arrange

            // Items are added to this FlexLayout
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");

            // Populate ItemList and CharacterList
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(new CharacterModel
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
                OffHand = "Skateboard",
                SpecialAbility = AbilityEnum.FlashGenius
            });

            // Act
            page.DrawItems();

            // Assert
            Assert.AreEqual(1, itemlistfoundframe.Children.Count);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
        }

        [Test]
        public void DrawItems_Add_PrimaryHand_Should_Pass()
        {
            // Arrange

            // Items are added to this FlexLayout
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");

            // Populate ItemList and CharacterList
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(new CharacterModel
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
                PrimaryHand = "Skateboard",
                SpecialAbility = AbilityEnum.FlashGenius
            });

            // Act
            page.DrawItems();

            // Assert
            Assert.AreEqual(1, itemlistfoundframe.Children.Count);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
        }

        [Test]
        public void DrawItems_Add_RightFinger_Should_Pass()
        {
            // Arrange

            // Items are added to this FlexLayout
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");

            // Populate ItemList and CharacterList
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(new CharacterModel
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
                RightFinger = "Skateboard",
                SpecialAbility = AbilityEnum.FlashGenius
            });

            // Act
            page.DrawItems();

            // Assert
            Assert.AreEqual(1, itemlistfoundframe.Children.Count);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
        }

        [Test]
        public void DrawItems_Add_LeftFinger_Should_Pass()
        {
            // Arrange

            // Items are added to this FlexLayout
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");

            // Populate ItemList and CharacterList
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(new CharacterModel
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
                LeftFinger = "Skateboard",
                SpecialAbility = AbilityEnum.FlashGenius
            });

            // Act
            page.DrawItems();

            // Assert
            Assert.AreEqual(1, itemlistfoundframe.Children.Count);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
        }

        [Test]
        public void DrawItems_Add_Feet_Should_Pass()
        {
            // Arrange

            // Items are added to this FlexLayout
            FlexLayout itemlistfoundframe = (FlexLayout)page.Content.FindByName("ItemListFoundFrame");

            // Populate ItemList and CharacterList
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = new PlayerInfoModel(new CharacterModel
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
                Feet = "Skateboard",
                SpecialAbility = AbilityEnum.FlashGenius
            });

            // Act
            page.DrawItems();

            // Assert
            Assert.AreEqual(1, itemlistfoundframe.Children.Count);

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = null;
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
        public void DrawMonsterList_Remove_Should_Pass()
        {
            // Arrange
            FlexLayout monsterlistframe = (FlexLayout)page.Content.FindByName("MonsterListFrame");
            // add two elements to the list because when will be removed
            monsterlistframe.Children.Add(new FlexLayout());

            // Act
            page.DrawMonsterList();
            
            // Reset
            
            // Assert
            Assert.AreEqual(1, monsterlistframe.Children.Count);
        }

        [Test]
        public void DrawSelectedMonsters_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.DrawSelectedMonsters();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...

        }

        [Test]
        public void DrawSelectedItems_Default_Should_Pass()
        {
            //Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);

            // Act
            page.DrawSelectedItem();

            // Reset
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.AttackItem = null;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePageTwo_OnPickerSelectedActionChanged_Default_Should_Pass()
        {
            // Arrange
            var picker = (Picker)page.FindByName("ActionSelectedPicker");
            System.EventArgs e = new System.EventArgs();

            // Act
            page.OnPickerSelectedActionChanged(picker, e);

            // Reset

            // Assert
            // -1 is the default
            Assert.IsTrue(true);
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
        public void BattlePageTwo_ExitButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ExitButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePage_ShowBattleMode_Testing_Default_Should_Pass()
        {
            // Arrange
            bool save = page.UnitTestSetting;
            page.UnitTestSetting = true;

            // Act
            page.ShowBattleMode();

            // Reset
            page.UnitTestSetting = save;

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePage_Settings_Clicked_Default_Should_Pass()
        {
            //Arrange

            //Act
            page.Settings_Clicked(null, null);

            //Reset

            //Assert
            Assert.IsTrue(true); //Got to her, so it happened...
        }

        [Test]
        public async Task BattlePage_ShowBattleSettingsPage_Default_Should_Pass()
        {
            //Arrange

            //Act
            await page.ShowBattleSettingsPage();

            //Reset

            //Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void BattlePageTwo_Apply_Attack_Clicked_Clicked_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Attack;

            // Act
            page.Apply_Attack_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePageTwo_Apply_Attack_Clicked_Navigation_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Attack;
            BattlePageTwo page1 = new BattlePageTwo();

            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new PickCharactersPage());

            // Act
            page1.Apply_Attack_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        [Test]
        public void BattlePageTwo_Apply_Ability_Clicked_Clicked_Default_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.EngineGameSpecialAbility = AbilityEnum.Bribes;

            // Act
            page.Apply_Ability_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePageTwo_Apply_Ability_Clicked_Navigation_Should_Pass()
        {
            // Arrange
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.EngineGameSpecialAbility = AbilityEnum.Bribes;
            BattlePageTwo page1 = new BattlePageTwo();

            page1.Navigation.PushAsync(new HomePage());
            page1.Navigation.PushAsync(new GamePage());
            page1.Navigation.PushAsync(new PickCharactersPage());

            // Act
            page1.Apply_Ability_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void BattlePageTwo_SetBattleStateEnum_RoundEnum_GameOver_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.GameOver;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.GameOver, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;

        }

        [Test]
        public void BattlePageTwo_SetBattleStateEnum_RoundEnum_GraduationCeremony_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.GraduationCeremony;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.GameOver, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
        }

        [Test]
        public void BattlePageTwo_SetBattleStateEnum_RoundEnum_NextTurn_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.NextTurn;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.Battling, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
        }

        [Test]
        public void BattlePageTwo_SetBattleStateEnum_RoundEnum_NewRound_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.NewRound;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.NewRound, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
        }

        [Test]
        public void BattlePageTwo_SetBattleStateEnum_RoundEnum_Unknown_Should_Pass()
        {
            // Arrange
            RoundEnum roundCondition = RoundEnum.Unknown;
            var save = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum;

            //Act
            page.SetBattleStateEnum(roundCondition);

            //Assert
            Assert.AreEqual(BattleStateEnum.Unknown, BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum);

            //Reset - need to reset here to test the battlestateenum in engine view model. 
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = save;
        }
    }
}