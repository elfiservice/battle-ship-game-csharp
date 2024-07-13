
namespace BattleShipGame.CoreBusiness.Core.ValuesObjects;

public class Cell(Column column, Row row)
{
    public Row Row { get; private set; } = row;
    public Column Column { get; private set; } = column;
    
    public string GetCordinates()
    {
        return $"{Column.GetValue()}{Row.GetValue()}";
    }
}