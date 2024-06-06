using BattleShipGame.Core.ValuesObjects;

namespace BattleShipGame.Core.Models;

public class Cell(Column column, Row row)
{
    public Row Row { get; private set; } = row;
    public Column Column { get; private set; } = column;
    
    public string GetCordinates()
    {
        return $"{Column.GetValue()}{Row.GetValue()}";
    }
}