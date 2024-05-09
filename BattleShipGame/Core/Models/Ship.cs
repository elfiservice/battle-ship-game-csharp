namespace BattleShipGame.Core.Models;

public class Ship(Cell[] cell)
{
    public Cell[] Cell { get; set; } = cell;
    
    public void FillCell(Cell cell)
    {
        Cell = Cell.Concat(new Cell[] { cell }).ToArray();
    }
    
    public void RemoveCell(Cell cell)
    {
        Cell = Cell.Where(c => c != cell).ToArray();
    }
    
    public Cell[] GetCells()
    {
        return Cell;
    }
    
}