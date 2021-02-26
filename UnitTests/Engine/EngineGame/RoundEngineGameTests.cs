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
            
            var ContainHighLevelCharacter = (Engine.EngineSettings.CharacterList.Find(m => (m.Level > 17)) != null);
            if (!ContainHighLevelCharacter)
            {
                Engine.EngineSettings.CharacterList.FirstOrDefault().Level = 18;
            }
            
            // Act
            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            data = new CharacterModel { Level = 18, MaxHealth = 10 };
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            Engine.Round.AddMonstersToRound();

            var result = Engine.EngineSettings.MonsterList.Find(m => m.SpecificMonsterTypeEnum == SpecificMonsterTypeEnum.GraduationOfficeAdministrator);

            // Reset
            MonsterIndexViewModel.Instance.ForceDataRefresh();
            CharacterIndexViewModel.Instance.ForceDataRefresh();
            //Engine.EngineSettings.MonsterList = null;

            // Assert
            Assert.IsNotNull(result);
        }
        
        
        #endregion AddMonstersToRound

    }
}