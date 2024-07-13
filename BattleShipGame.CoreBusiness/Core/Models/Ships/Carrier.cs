namespace BattleShipGame.CoreBusiness.Core.Models.Ships;

public class Carrier() : Ship(length: 5)
{
    public override string ToString()
    {
        return $"{nameof(Carrier)}, Length: {base.GetShipLength()}";
    }
}