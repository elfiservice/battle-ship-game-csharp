using BattleShipGame.CoreBusiness.Core.Models;

namespace BattleShipGame.CoreBusiness.UseCases.Interfaces;

public interface IShootTheOpponentUseCase
{
    bool Execute(Player currentPlayer, Player opponentPlayer, string cellCoordinates);
}