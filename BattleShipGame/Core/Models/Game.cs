using BattleShipGame.Core.Models.Ships;

namespace BattleShipGame.Core.Models;

public class Game
{
    Player Player1 { get; set; }
    Player Player2 { get; set; }

    private Ship[] RequiredShips = new Ship[]
    {
        new Carrier(),
        new Battleship(),
        new PatrolBoat(),
        new Submarine(),
        new Destroyer()
    };
}