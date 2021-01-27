using System.Collections.Generic;

using Game.Models;

namespace Game.Engine.EngineInterfaces
{
    public interface IRoundEngineInterface
    {
        ITurnEngineInterface Turn { get; set; }

        bool ClearLists();
        bool NewRound();
        int AddMonstersToRound();
        bool EndRound();
        void PickupItemsForAllCharacters();

        bool SetCurrentAttacker(PlayerInfoModel player);
        bool SetCurrentDefender(PlayerInfoModel player);

        RoundEnum RoundNextTurn();
        PlayerInfoModel GetNextPlayerTurn();
        List<PlayerInfoModel> RemoveDeadPlayersFromList();
        List<PlayerInfoModel> OrderPlayerListByTurnOrder();
        List<PlayerInfoModel> MakePlayerList();
        PlayerInfoModel GetNextPlayerInList();
        bool PickupItemsFromPool(PlayerInfoModel character);
        bool GetItemFromPoolIfBetter(PlayerInfoModel character, BodyPartEnum setLocation);
        BodyPartModel SwapCharacterItem(PlayerInfoModel character, BodyPartEnum setLocation, BodyPartModel PoolItem);
        //bool RemoveCharacterBuffs();
        List<PlayerInfoModel> PlayerList();
    }
}
