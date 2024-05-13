namespace BattleShipGame.Core.Models.Ships;

public class Carrier(Cell[] cell) : Ship(cell)
{
    private const int Length = 5;
}