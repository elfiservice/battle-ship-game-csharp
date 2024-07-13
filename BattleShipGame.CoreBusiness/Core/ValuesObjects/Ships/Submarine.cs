namespace BattleShipGame.CoreBusiness.Core.ValuesObjects.Ships;

public class Submarine() : Ship(length: 3)
{
    public override string ToString()
    {
        return $"{nameof(Submarine)}, Length: {base.GetShipLength()}";
    }
}