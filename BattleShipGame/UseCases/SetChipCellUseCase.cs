using BattleShipGame.Core.Models;
using BattleShipGame.Core.ValuesObjects;
using BattleShipGame.UseCases.Interfaces;

namespace BattleShipGame.UseCases;

public class SetChipCellUseCase : ISetChipCellUseCase
{
    public Ship Execute(Ship ship, string cellCordinates)
    {
        var columnValue = cellCordinates[0];
        var rowValue = cellCordinates.Substring(1);

        try
        {
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
}