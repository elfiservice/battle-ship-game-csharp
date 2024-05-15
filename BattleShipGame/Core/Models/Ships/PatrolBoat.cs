namespace BattleShipGame.Core.Models.Ships;

public class PatrolBoat() : Ship(length: 2)
{
    public override string ToString()
    {
        return $"{nameof(PatrolBoat)}, Length: {base.GetShipLength()}";
    }
}