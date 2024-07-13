namespace BattleShipGame.CoreBusiness.Core.ValuesObjects.Ships;

public class Carrier() : Ship(length: 5)
{
    public override string ToString()
    {
        return $"{nameof(Carrier)}, Length: {base.GetShipLength()}";
    }
}