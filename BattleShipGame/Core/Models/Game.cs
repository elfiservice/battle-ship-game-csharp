using BattleShipGame.Core.Models.Ships;

namespace BattleShipGame.Core.Models;

public class Game
{
    public Player Player1 { get; set; }
    Player Player2 { get; set; }

    public Ship[] RequiredShips = new Ship[]
    {
        new Carrier(),
        new Battleship(),
        new PatrolBoat(),
        new Submarine(),
        new Destroyer()
    };
}