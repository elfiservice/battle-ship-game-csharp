using BattleShipGame.Core.Models;
using BattleShipGame.Core.ValuesObjects;
using BattleShipGame.UseCases.Interfaces;

namespace BattleShipGame.UseCases;

public class ShootTheOpponentUseCase : IShootTheOpponentUseCase
{
    public bool Execute(Player currentPlayer, Player opponentPlayer, string cellCoordinates)
    {
        var currentlyPlayerShot = new Cell(new Column(cellCoordinates[0].ToString()), new Row(Convert.ToInt32(cellCoordinates.Substring(1))));
        currentPlayer.ShotToOpponent(opponentPlayer, currentlyPlayerShot);

        var opponentBattleField = opponentPlayer.GetBattleField();
        var isHitAShip = opponentBattleField.HitShip(currentlyPlayerShot);

        if (isHitAShip)
        {
            opponentBattleField.RemoveCellFromShip(currentlyPlayerShot);
        }

        return isHitAShip;
    }
}