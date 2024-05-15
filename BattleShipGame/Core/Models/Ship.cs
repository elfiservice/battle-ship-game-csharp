namespace BattleShipGame.Core.Models;

public abstract class Ship(int length)
{
    private int _length = length;
    private Cell[] Cells { get; set; } = Array.Empty<Cell>();
    
    public void FillCell(Cell cell)
    {
        Cells = Cells.Concat(new Cell[] { cell }).ToArray();
    }
    
    public void RemoveCell(Cell cell)
    {
        Cells = Cells.Where(c => c != cell).ToArray();
    }
    
    public Cell[] GetCells()
    {
        return Cells;
    }

    public int GetShipLength()
    {
        return _length;
    }

    public string ShowShipToString()
    {
        // loop over the cells and return the string representation of the ship
        return string.Join(", ", Cells.Select(cell => $"({cell.Column.GetValue()},{cell.Row.GetValue()})"));
    }
}