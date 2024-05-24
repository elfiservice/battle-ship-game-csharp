using BattleShipGame.Core.Models.Ships;

namespace BattleShipGame.Core.Models;

public class Game
{
    public Player Player1 { get; set; }
    Player Player2 { get; set; }
    
    Player Winner { get; set; }
}