namespace BattleShipGame.Core.Models;

public abstract class Ship(int length)
{
    private int _length = length;
    private Cell[] Cells { get; set; } = Array.Empty<Cell>();
    
    private int Direction { get; set; } = 0;
    
    const int Horizontal = 1;
    const int Vertical = 2;
    
    public void FillCell(Cell cell)
    {
        SetDirection(cell);
        CheckPreviousCell(cell);
        CheckPreviousRow(cell);
        CheckPreviousColumn(cell);
        CheckSequentialCells(cell);
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
    
    private void CheckPreviousCell(Cell cell)
    {
        if (Cells.Length == 0)
        {
            return;
        }
        
        var lastCell = Cells.Last();
        if (lastCell.Column.GetValue() == cell.Column.GetValue() && lastCell.Row.GetValue() == cell.Row.GetValue())
        {
            ThrowErrorMessageToUser("The cell is already in the ship.");
        }
    }
    
    private void CheckPreviousRow(Cell cell)
    {
        if (Cells.Length == 0)
        {
            return;
        }
        
        var lastCell = Cells.Last();
        if (lastCell.Column.GetValue() == cell.Column.GetValue() && lastCell.Row.GetIndex() != cell.Row.GetIndex() - 1)
        {
            ThrowErrorMessageToUser("The Ship is not in the same row.");
        }
    }
    
    private void CheckPreviousColumn(Cell cell)
    {
        if (Cells.Length == 0)
        {
            return;
        }
        
        var lastCell = Cells.Last();
        if (lastCell.Row.GetValue() == cell.Row.GetValue() && lastCell.Column.GetIndex() != cell.Column.GetIndex() - 1)
        {
            ThrowErrorMessageToUser("The Ship is not in the same column.");
        }
    }
    
    private void CheckSequentialCells(Cell cell)
    {
        if (Cells.Length == 0)
        {
            return;
        }
        
        var lastCell = Cells.Last();
        
        if (Direction == Horizontal  && (lastCell.Row.GetValue() != cell.Row.GetValue() ||
                                         lastCell.Column.GetIndex() != cell.Column.GetIndex() - 1))
        {
            ThrowErrorMessageToUser("The Ship is not follow the correct Horizontal sequence.");
        }
        
        if (Direction == Vertical && (lastCell.Column.GetValue() != cell.Column.GetValue() ||
                                      lastCell.Row.GetIndex() != cell.Row.GetIndex() - 1))
        {
            ThrowErrorMessageToUser("The Ship is not follow the correct Vertical sequence.");
        }

    }

    private void ThrowErrorMessageToUser(string message)
    {
        CheckToResetDirection();
        throw new ArgumentException(message);
    }

    private void SetDirection(Cell cell)
    {
        var shouldNotSetDirection = Direction != 0;
        
        if (Cells.Length == 0 || shouldNotSetDirection)
        {
            return;
        }
        
        var lastCell = Cells.Last();

        if (lastCell.Column.GetIndex() == cell.Column.GetIndex())
        {
            Direction = Vertical;
        }
        else
        {
            Direction = Horizontal;
        }
    }
    
    private void CheckToResetDirection()
    {
        if (Cells.Length == 1)
        {
            Direction = 0;
        }
    }
}