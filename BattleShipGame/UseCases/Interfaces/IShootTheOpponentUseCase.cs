using BattleShipGame.Core.Models;

namespace BattleShipGame.UseCases.Interfaces;

public interface IShootTheOpponentUseCase
{
    bool Execute(Player currentPlayer, Player opponentPlayer, string cellCoordinates);
}