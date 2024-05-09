namespace BattleShipGame.Core.Models;

public class BattleField
{
    Player Player { get; set; }
    private string[] _validDimension = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

    public BattleField(Player player)
    {
        Player = player;
    }
    
    public int GetDimension()
    {
        return _validDimension.Length;
    }
    
    public Player GetPlayer()
    {
        return Player;
    }
}