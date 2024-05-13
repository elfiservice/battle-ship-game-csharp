namespace BattleShipGame.Core.Models;

public class Player
{
    string Username { get; set; }
    Ship[] Ships { get; set; }

    public Player(string username, Ship[] ships)
    {
        Ships = ships;
        
        if (string.IsNullOrEmpty(Username))
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
}