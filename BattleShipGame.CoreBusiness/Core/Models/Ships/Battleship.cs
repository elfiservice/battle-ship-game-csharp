namespace BattleShipGame.CoreBusiness.Core.Models.Ships;

public class Battleship() : Ship(length: 4)
{
    public override string ToString()
    {
        return $"{nameof(Battleship)}, Length: {base.GetShipLength()}";
    }
}