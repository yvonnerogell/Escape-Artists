using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.ViewModels;
using Game.Engine.EngineGame;

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
    }
}