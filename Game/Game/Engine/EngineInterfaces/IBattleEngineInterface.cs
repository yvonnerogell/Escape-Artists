using Game.Engine.EngineModels;
using Game.Models;

namespace Game.Engine.EngineInterfaces
{
   public interface IBattleEngineInterface
    {
        // The Round Variable
        IRoundEngineInterface Round { get; set; }

        // Engine Settings for this round
        EngineSettingsModel EngineSettings { get;}

        /// <summary>
        /// Add the charcter to the character list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool PopulateCharacterList(CharacterModel data);

        /// <summary>
        /// Start the Battle
        /// </summary>
        /// <param name="isAutoBattle"></param>
        /// <returns></returns>
        bool StartBattle(bool isAutoBattle);

        /// <summary>
        /// End the Battle
        /// </summary>
        /// <returns></returns>
        bool EndBattle();
    }
}
