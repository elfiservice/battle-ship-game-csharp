
using BattleShipGame.CoreBusiness.Core.ValuesObjects.Ships;

namespace BattleShipGame.CoreBusiness.Core.ValuesObjects;

public class BattleField
{
    private string[] _validDimension = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
    public Ship[] RequiredShips = new Ship[]
    {
        
        // new Carrier(),
        // new Battleship(),
        // new PatrolBoat(),
        // new Submarine(),
        new Destroyer()
    };
    
    public int GetDimension()
    {
        return _validDimension.Length;
    }
    
    public bool CellHitOtherShip(string? cellCordinates, Ship ship)
    {
        return RequiredShips.Any(requiredShip =>
                    requiredShip != ship &&
                    requiredShip.GetCells().Any(cell =>
                        cell.GetCordinates() == cellCordinates));
    }
    
    public bool ShipOverlayBoundaries(Ship ship)
    {
        var dimension = GetDimension();
        var shipLength = ship.GetShipLength();
        var shipDirection = ship.GetDirection();

        var minimumGap = dimension - shipLength;
        var firstCellOfShipExpected = minimumGap + 1;

        var shipCells = ship.GetCells();
        
        if (shipCells.Length == 0)
        {
            return false;
        }
        
        var firstCell = ship.GetCells().First();

        if (shipDirection == 1)
        {
            // Horizontal
            var firstColumn = firstCell.Column.GetValue();
            var actualFirstColumnPosition = Array.IndexOf(_validDimension, firstColumn) + 1;

            if (actualFirstColumnPosition > firstCellOfShipExpected)
            {
                return true;
            }
        }
        else
        {
            // Vertical
            var actualFirstRowPosition = firstCell.Row.GetValue();

            if (actualFirstRowPosition > firstCellOfShipExpected)
            {
                return true;
            }
        }

        return false;
    }
    
    private Ship GetShipByCell(string cellCordinates)
    {
        return RequiredShips.First(ship =>
            ship.GetCells().Any(cell =>
                cell.GetCordinates() == cellCordinates));
    }
    
    public bool AllShipsDestroyed()
    {
        return RequiredShips.All(ship => ship.GetCells().Length == 0);
    }
    
    public bool HitShip(Cell currentlyPlayerShot)
    {
        return RequiredShips.Any(ship =>
            ship.GetCells().Any(cell =>
                cell.GetCordinates() == currentlyPlayerShot.GetCordinates()));
    }
    
    public void RemoveCellFromShip(Cell currentlyPlayerShot)
    {
        var ship = GetShipByCell(currentlyPlayerShot.GetCordinates());
        var cell = ship.GetCells().First(cell => cell.GetCordinates() == currentlyPlayerShot.GetCordinates());
        
        ship.RemoveCell(cell);
    }
}