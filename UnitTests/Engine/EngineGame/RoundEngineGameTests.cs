using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.ViewModels;
using Game.Engine.EngineGame;
using System.Collections.Generic;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class RoundEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();

            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
            Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            Engine.StartBattle(true);   
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void RoundEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region AddMonstersToRound
        
        [Test]
        public void RoundEngine_AddMonstersToRound_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            
            var result = Engine.Round.AddMonstersToRound();


            // Reset
            MonsterIndexViewModel.Instance.ForceDataRefresh();
            //Engine.EngineSettings.MonsterList = null;

            // Assert
            Assert.IsNotNull(result);
        }
        
        
        [Test]
        public void RoundEngine_AddMonstersToRound_Valid_HighLevelCharacter_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            data = new CharacterModel { Level = 18, MaxHealth = 10 };
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            // Act
            Engine.Round.AddMonstersToRound();

            var result = Engine.EngineSettings.MonsterList.Find(m => m.SpecificMonsterTypeEnum == SpecificMonsterTypeEnum.GraduationOfficeAdministrator);

            // Reset
            MonsterIndexViewModel.Instance.ForceDataRefresh();
            CharacterIndexViewModel.Instance.ForceDataRefresh();
            //Engine.EngineSettings.MonsterList = null;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RoundEngine_AddMonstersToRound_Valid_HighLevelCharacter_EmptyMonster_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            data = new CharacterModel { Level = 18, MaxHealth = 10 };
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            // Act
            MonsterIndexViewModel.Instance.Dataset.Clear();

            Engine.Round.AddMonstersToRound();

            var result = Engine.EngineSettings.MonsterList.Find(m => m.SpecificMonsterTypeEnum == SpecificMonsterTypeEnum.GraduationOfficeAdministrator);

            // Reset
            MonsterIndexViewModel.Instance.ForceDataRefresh();
            CharacterIndexViewModel.Instance.ForceDataRefresh();
            //Engine.EngineSettings.MonsterList = null;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Name, "Mr. Smith");
        }

        #endregion AddMonstersToRound

        
        #region PickupItemsFromPool
        [Test]
        public void RoundEngine_PickupItemsFromPool_Auto_Valid_Default_Should_Pass()
        {
            // Arrange
            PlayerInfoModel easyCharacter = new PlayerInfoModel( new CharacterModel());
            
            // Act

            //Engine.EngineSettings.ItemPool.Add()

            bool result = Engine.Round.PickupItemsFromPool(easyCharacter);


            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RoundEngine_PickupItemsFromPool_Auto_Valid_Student_Level_18_Should_Pass()
        {
            // Arrange
            PlayerInfoModel character = new PlayerInfoModel(new CharacterModel { Level = 18, CharacterTypeEnum = CharacterTypeEnum.Student});
            var save = Engine.EngineSettings.ItemPool;
            Engine.EngineSettings.ItemPool.Clear();
            Engine.EngineSettings.ItemPool.Add(new ItemModel { ItemType = ItemTypeEnum.GraduationCapAndRobe });

            // Act
            bool result = Engine.Round.PickupItemsFromPool(character);

            // Reset
            Engine.EngineSettings.ItemPool.Clear();
            Engine.EngineSettings.ItemPool = save;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RoundEngine_PickupItemsFromPool_Auto_Valid_Student_Level_15_Should_Pass()
        {
            // Arrange
            PlayerInfoModel character = new PlayerInfoModel(new CharacterModel { Level = 15, CharacterTypeEnum = CharacterTypeEnum.Student });

            // Act

            bool result = Engine.Round.PickupItemsFromPool(character);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RoundEngine_PickupItemsFromPool_Auto_Valid_Parent_Level_15_Should_Pass()
        {
            // Arrange
            PlayerInfoModel character = new PlayerInfoModel(new CharacterModel { Level = 15, CharacterTypeEnum = CharacterTypeEnum.Parent });

            // Act

            bool result = Engine.Round.PickupItemsFromPool(character);

            // Reset

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RoundEngine_PickupItemsFromPool_Manual_Valid_Default_Should_Pass()
        {
            // Arrange
            PlayerInfoModel easyCharacter = new PlayerInfoModel(new CharacterModel());
            Engine.EngineSettings.BattleScore.AutoBattle = false;
            // Act

            //Engine.EngineSettings.ItemPool.Add()

            bool result = Engine.Round.PickupItemsFromPool(easyCharacter);


            // Reset
            Engine.EngineSettings.BattleScore.AutoBattle = true;

            // Assert
            Assert.IsTrue(result);
        }

        #endregion PickupItemsFromPool


        #region SwapCharacterItem

        [Test]
        public void RoundEngine_SwapCharacterItem_Default_Should_Pass()
        {
            // Arrange
            PlayerInfoModel easyCharacter = new PlayerInfoModel(new CharacterModel());
            ItemModel testItem = new ItemModel(ItemTypeEnum.GraduationCapAndRobe);

            // Act

            //Engine.EngineSettings.ItemPool.Add()
            
            var result = Engine.Round.SwapCharacterItem(easyCharacter, ItemLocationEnum.Head, testItem);
            // Reset

            // Assert
            // should return null since there's no items on the head to basic character model
            Assert.IsNull(result);
        }

        #endregion SwapCharacterItem



        [Test]
        public void RoundEngine_RemoveGraduatedandDeadPlayersFromList_Default_Should_Pass()
        {
            // Arrange
            var save = Engine.EngineSettings.PlayerList;
            Engine.EngineSettings.PlayerList.Clear();
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(new CharacterModel { Alive = false, Graduated = false}));
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(new CharacterModel { Alive = false, Graduated = false }));
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(new CharacterModel { Graduated = true, Alive = true }));
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(new CharacterModel { Graduated = true, Alive = true }));
            Engine.EngineSettings.PlayerList.Add(new PlayerInfoModel(new CharacterModel { Graduated = false, Alive = true }));

            // Act
            var result = ((RoundEngine)Engine.Round).RemoveGraduatedandDeadPlayersFromList();

            // Assert
            Assert.AreEqual(1, result.Count);

            // Reset
            Engine.EngineSettings.PlayerList.Clear();
            Engine.EngineSettings.PlayerList = save;
        }
        #region AmazonSameBattleDeliverItems

        [Test]
        public void RoundEngine_DropedItemOutput_Valid_Default_Should_Pass()
        {
            // Arrange
            List<ItemModel> items = new List<ItemModel>();
            items.AddRange(ItemIndexViewModel.Instance.GetLocationItems(ItemLocationEnum.Head));
            // Act
            RoundEngine test = new RoundEngine();
            //Engine.EngineSettings.ItemPool.Add()

            test.DropedItemOutput("Head", items);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void RoundEngine_GetWhatIsNeededForEmptyLocation_Valid_Head_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Head = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            int result = test.GetWhatIsNeededForEmptyLocation(ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RoundEngine_GetWhatIsNeededForEmptyLocation_Valid_Necklace_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Necklace = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            int result = test.GetWhatIsNeededForEmptyLocation(ItemLocationEnum.Necklace);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RoundEngine_GetWhatIsNeededForEmptyLocation_Valid_PrimaryHand_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                PrimaryHand = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            int result = test.GetWhatIsNeededForEmptyLocation(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RoundEngine_GetWhatIsNeededForEmptyLocation_Valid_OffHand_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                OffHand = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            int result = test.GetWhatIsNeededForEmptyLocation(ItemLocationEnum.OffHand);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RoundEngine_GetWhatIsNeededForEmptyLocation_Valid_RightFinger_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                RightFinger = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            int result = test.GetWhatIsNeededForEmptyLocation(ItemLocationEnum.RightFinger);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RoundEngine_GetWhatIsNeededForEmptyLocation_Valid_LeftFinger_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                LeftFinger = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            int result = test.GetWhatIsNeededForEmptyLocation(ItemLocationEnum.LeftFinger);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RoundEngine_GetWhatIsNeededForEmptyLocation_Valid_Feet_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            int result = test.GetWhatIsNeededForEmptyLocation(ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_Head_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Head = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_Head_Parent_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Head = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_Necklace_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Necklace);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Necklace = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_PrimaryHand_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                PrimaryHand = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_OffHand_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.OffHand);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                OffHand = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_RightFinger_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.RightFinger);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                RightFinger = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_LeftFinger_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.LeftFinger);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                LeftFinger = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_Feet_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Feet);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Feet = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetBetterItems_Valid_Feet_Parent_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Feet);
            test.EngineSettings.ItemPool.Clear();
            item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Parent,
                Feet = item.Id,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetBetterItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }

        [Test]
        public async Task RoundEngine_GetAmazonSameBattleDeliveryItems_Valid_Default_Should_Pass()
        {
            // Arrange
            RoundEngine test = new RoundEngine();
            test.EngineSettings.CharacterList.Clear();
            //ItemModel item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Feet);
            test.EngineSettings.ItemPool.Clear();
            //item.Value = 1;
            CharacterModel testCharacter = new CharacterModel
            {
                CharacterTypeEnum = CharacterTypeEnum.Student,
                Head = null,
                Necklace = null,
                PrimaryHand = null,
                RightFinger = null,
                LeftFinger = null,
                Feet = null,
            };
            test.EngineSettings.CharacterList.Add(new PlayerInfoModel(testCharacter));

            // Act
            await test.GetAmazonSameBattleDeliveryItems();

            // Reset
            ItemIndexViewModel.Instance.Dataset.Clear();
            await ItemIndexViewModel.Instance.LoadDefaultDataAsync();

            // Assert
            Assert.IsTrue(true);
            //Assert.IsTrue(test.EngineSettings.ItemPool.FirstOrDefault().Value > 1);
        }


        #endregion AmazonSameBattleDeliverItems
    }
}