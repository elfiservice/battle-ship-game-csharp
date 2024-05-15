namespace BattleShipGame.Core.Models;

public class Player
{
    string Username { get; set; }
    Ship[] Ships { get; set; }

    private BattleField BattleField { get; set; }

    public Player(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username is required.");
        }
        Username = username;
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
}