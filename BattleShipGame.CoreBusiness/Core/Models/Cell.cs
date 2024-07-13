using BattleShipGame.CoreBusiness.Core.ValuesObjects;

namespace BattleShipGame.CoreBusiness.Core.Models;

public class Cell(Column column, Row row)
{
    public Row Row { get; private set; } = row;
    public Column Column { get; private set; } = column;
    
    public string GetCordinates()
    {
        return $"{Column.GetValue()}{Row.GetValue()}";
    }
}