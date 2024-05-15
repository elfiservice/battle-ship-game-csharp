namespace BattleShipGame.Core.Models.Ships;

public class Destroyer() : Ship(length: 3)
{
    public override string ToString()
    {
        return $"{nameof(Destroyer)}, Length: {base.GetShipLength()}";
    }
}