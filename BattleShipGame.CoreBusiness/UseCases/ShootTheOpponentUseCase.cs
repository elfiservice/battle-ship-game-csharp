using BattleShipGame.CoreBusiness.Core.Models;
using BattleShipGame.CoreBusiness.Core.ValuesObjects;
using BattleShipGame.CoreBusiness.UseCases.Interfaces;

namespace BattleShipGame.CoreBusiness.UseCases;

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