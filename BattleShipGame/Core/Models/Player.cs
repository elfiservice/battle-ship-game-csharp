namespace BattleShipGame.Core.Models;

public class Player
{
    string Username { get; set; }
    
    // maybe not be needed
    Ship[] Ships { get; set; }

    private BattleField BattleField { get; set; }

    public Player(string username, BattleField battleField)
    {
        if (string.IsNullOrEmpty(username) || battleField is null)
        {
            throw new ArgumentException("Username and Battlefield are required.");
        }
        Username = username;
        BattleField = battleField;
        Ships = new Ship[] { };
    }
    
    public void AddShip(Ship ship)
    {
        Ships = Ships.Concat(new Ship[] { ship }).ToArray();
    }
    
    public void RemoveShip(Ship ship)
    {
        Ships = Ships.Where(s => s != ship).ToArray();
    }
    
    public Ship[] GetShips()
    {
        return Ships;
    }
    
    public string GetUsername()
    {
        return Username;
    }
    
    public bool HasShips()
    {
        return Ships.Length > 0;
    }

    public void SetBattleField(BattleField field)
    {
        BattleField = field;
    }
    
    public BattleField GetBattleField()
    {
        return BattleField;
    }
}