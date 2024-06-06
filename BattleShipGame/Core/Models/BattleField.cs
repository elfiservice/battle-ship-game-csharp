using BattleShipGame.Core.Models.Ships;

namespace BattleShipGame.Core.Models;

public class BattleField
{
    private string[] _validDimension = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
    public Ship[] RequiredShips = new Ship[]
    {
        new Carrier(),
        new Battleship(),
        new PatrolBoat(),
        new Submarine(),
        new Destroyer()
    };
    
    public int GetDimension()
    {
        return _validDimension.Length;
    }
    
    public bool CellHitOtherShip(string cellCordinates, Ship ship)
    {
        return RequiredShips.Any(requiredShip =>
                    requiredShip != ship &&
                    requiredShip.GetCells().Any(cell =>
                        cell.GetCordinates() == cellCordinates));
    }
}