
using BattleShipGame.CoreBusiness.Core.ValuesObjects;
using BattleShipGame.CoreBusiness.UseCases.Interfaces;

namespace BattleShipGame.CoreBusiness.UseCases;

public class SetChipCellUseCase : ISetChipCellUseCase
{
    public Ship Execute(Ship ship, string? cellCoordinates, BattleField battleField)
    {
        try
        {
            ValidateCellCoordinates(ship, cellCoordinates, battleField);
            
            var columnValue = cellCoordinates![0];
            var rowValue = cellCoordinates.Substring(1);
            
            var column = new Column(columnValue.ToString());
            var row = new Row(Convert.ToInt32(rowValue));
            
            var cell = new Cell(column, row);
        
            ship.FillCell(cell);
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }

        return ship;
    }
    
    void ValidateCellCoordinates(Ship ship, string? cellCoordinates, BattleField battleField)
    {
        if (string.IsNullOrEmpty(cellCoordinates))
        {
            throw new ArgumentException("Cell coordinates are required.");
        }
                
        if (battleField.ShipOverlayBoundaries(ship))
        {
            ship.ClearCells();
            throw new ArgumentException("The ship is overlaying the boundaries of the battlefield.");
        }
                
        if (battleField.CellHitOtherShip(cellCoordinates, ship))
        {
            throw new ArgumentException("The cell is already in another ship.");
        }
    }
}