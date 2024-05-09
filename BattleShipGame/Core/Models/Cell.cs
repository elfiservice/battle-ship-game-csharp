using BattleShipGame.Core.ValuesObjects;

namespace BattleShipGame.Core.Models;

public class Cell(Row row, Column column)
{
    public Row Row { get; private set; } = row;
    public Column Column { get; private set; } = column;
}