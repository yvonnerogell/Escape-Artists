using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Models;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// AutoBattle Engine
    /// 
    /// Runs the engine simulation with no user interaction
    /// 
    /// </summary>
    public class AutoBattleEngine : AutoBattleEngineBase, IAutoBattleInterface
    {
        #region Algrorithm
        // Prepare for Battle
        // Pick 6 Characters
        // Initialize the Battle
        // Start a Round

        // Fight Loop
        // Loop in the round each turn
        // If Round is over, Start New Round
        // Check end state of round/game

        // Wrap up
        // Get Score
        // Save Score
        // Output Score
        #endregion Algrorithm

        public AutoBattleEngine()
        {
            Battle = new BattleEngine();
        }


        /// <summary>
        /// Run Auto Battle
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<bool> RunAutoBattle()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            RoundEnum RoundCondition;

            Debug.WriteLine("Auto Battle Starting");

            // Auto Battle, does all the steps that a human would do.

            // Prepare for Battle

            CreateCharacterParty();

            // Start Battle in AutoBattle mode
            Battle.StartBattle(true);

            // Fight Loop. Continue until Game is Over...
            do
            {
                // Check for excessive duration.
                if (DetectInfinateLoop())
                {
                    Debug.WriteLine("Aborting, More than Max Rounds");
                    Battle.EndBattle();
                    return false;
                }

                Debug.WriteLine("Next Turn " + Battle.EngineSettings.BattleScore.TurnCount);
                Debug.WriteLine("Characsts left: " + Battle.EngineSettings.CharacterList.Count());

                // Do the turn...
                // If the round is over start a new one...
                RoundCondition = Battle.Round.RoundNextTurn();

                if (RoundCondition == RoundEnum.NewRound)
                {
                    Battle.Round.NewRound();
                    Debug.WriteLine("New Round: " + Battle.EngineSettings.BattleScore.RoundCount);
                }

            } while ((RoundCondition == RoundEnum.NewRound) || (RoundCondition == RoundEnum.NextTurn));

            if (RoundCondition == RoundEnum.GameOver)
            {
                Debug.WriteLine("Game Over");
            }

            if (RoundCondition == RoundEnum.GraduationCeremony)
            {
                Debug.WriteLine("Graduation Ceremony!!!");
            }

            // Wrap up
            Battle.EndBattle();

            return true;
        }

        /// <summary>
        /// Create character list and monster list
        /// </summary>
        /// <returns></returns>
        public override bool CreateCharacterParty()
        {
            return base.CreateCharacterParty();
        }

        /// <summary>
        /// detect if there's infinite rounds (no game end)
        /// </summary>
        /// <returns></returns>
        public override bool DetectInfinateLoop()
        {
            return base.DetectInfinateLoop();
        }
    }
}