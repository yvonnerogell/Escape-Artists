using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineGame;
using Game.Engine.EngineModels;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class TurnEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
            //Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void TurnEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor


        [Test]
        public void TurnEngine_ChooseToUseAbility_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).ChooseToUseAbility(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).UseAbility(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).DetermineActionChoice(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TurnEngine_DetermineCriticalMissProblem_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).DetermineCriticalMissProblem(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        
        [Test]
        public void TurnEngine_CalculateAttackStatus_Valid_Character_Student_Should_Pass()
        {
            // Arrange
            CharacterModel attacker = new CharacterModel {
                PlayerType = PlayerTypeEnum.Character,
                CharacterTypeEnum = CharacterTypeEnum.Student,
                
            };
            MonsterModel defender = new MonsterModel ();

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).CalculateAttackStatus(new PlayerInfoModel(attacker), new PlayerInfoModel(defender));

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TurnEngine_CalculateAttackStatus_Valid_Monster_Should_Pass()
        {
            // Arrange
            CharacterModel defender = new CharacterModel
            {
                PlayerType = PlayerTypeEnum.Character,
                CharacterTypeEnum = CharacterTypeEnum.Student,
            };
            MonsterModel attacker = new MonsterModel();

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).CalculateAttackStatus(new PlayerInfoModel(attacker), new PlayerInfoModel(defender));

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TurnEngine_TurnMessageResultForAttackMonster_CriticalHit_Valid_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty };
            var targetStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Student };
            var saveStatus = Engine.EngineSettings.BattleMessagesModel.HitStatus;
            Engine.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.CriticalHit;

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).TurnMessageResultForAttackMonster(attackerFaculty.MonsterTypeEnum, targetStudent.CharacterTypeEnum);

            // Reset
            Engine.EngineSettings.BattleMessagesModel.HitStatus = saveStatus;

            // Assert
            Assert.AreEqual("Faculty gives an exam to Student. ", result);
        }


        [Test]
        public void TurnEngine_TurnMessageResultForAttackMonster_Hit_Valid_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty };
            var targetStudent = new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Parent };
            var saveStatus = Engine.EngineSettings.BattleMessagesModel.HitStatus;
            Engine.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Hit;

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).TurnMessageResultForAttackMonster(attackerFaculty.MonsterTypeEnum, targetStudent.CharacterTypeEnum);

            // Reset
            Engine.EngineSettings.BattleMessagesModel.HitStatus = saveStatus;

            // Assert
            Assert.AreEqual("Faculty calls for parent-teacher conference with Parent. ", result);
        }


        [Test]
        public void TurnEngine_TurnMessageResultForAttack_Monster_Attacker_Valid_Should_Pass()
        {
            // Arrange
            var attackerFaculty = new PlayerInfoModel (new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty });
            var targetStudent = new PlayerInfoModel (new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Student });
            var saveStatus = Engine.EngineSettings.BattleMessagesModel.HitStatus;
            Engine.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.CriticalHit;

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).TurnMessageResultForAttack(attackerFaculty, targetStudent);

            // Reset
            Engine.EngineSettings.BattleMessagesModel.HitStatus = saveStatus;

            // Assert
            Assert.AreEqual(true, result);
        }


        [Test]
        public void TurnEngine_TurnMessageResultForAttack_CharacterAttacker_Valid_Should_Pass()
        {
            // Arrange
            var targetFaculty = new PlayerInfoModel(new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Faculty });
            var attackerStudent = new PlayerInfoModel(new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Student });
            var saveStatus = Engine.EngineSettings.BattleMessagesModel.HitStatus;
            Engine.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.CriticalHit;

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).TurnMessageResultForAttack(attackerStudent, targetFaculty);

            // Reset
            Engine.EngineSettings.BattleMessagesModel.HitStatus = saveStatus;

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnMessageResultForAttack_Unknown_Valid_Should_Pass()
        {
            // Arrange
            var targetFaculty = new PlayerInfoModel(new MonsterModel { MonsterTypeEnum = MonsterTypeEnum.Unknown });
            var attackerStudent = new PlayerInfoModel(new CharacterModel { CharacterTypeEnum = CharacterTypeEnum.Unknown });
            targetFaculty.PlayerType = PlayerTypeEnum.Unknown;
            attackerStudent.PlayerType = PlayerTypeEnum.Unknown;
            var saveStatus = Engine.EngineSettings.BattleMessagesModel.HitStatus;
            Engine.EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.CriticalHit;

            // Act
            var result = ((TurnEngine)Engine.Round.Turn).TurnMessageResultForAttack(attackerStudent, targetFaculty);

            // Reset
            Engine.EngineSettings.BattleMessagesModel.HitStatus = saveStatus;

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_PlayerList_Null_Should_Return_Null()
        {
            // Arrange
            var save = Engine.EngineSettings.PlayerList;
            Engine.EngineSettings.PlayerList = null;

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset
            Engine.EngineSettings.PlayerList = save;

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_PlayerList_Empty_Should_Return_Null()
        {
            // Arrange
            var save = Engine.EngineSettings.PlayerList;
            Engine.EngineSettings.PlayerList.Clear();

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset
            Engine.EngineSettings.PlayerList = save;

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}