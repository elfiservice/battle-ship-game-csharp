namespace BattleShipGame.CoreBusiness.Core.Models;

public class Game
{
    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    
    public Player Playing { get; set; }

    private Player? Winner { get; set; } = null;

    public bool HasNotWinner()
    {
        return Winner is null;
    }
    
    public void SetWinner(Player player)
    {
        Winner = player;
    }
}