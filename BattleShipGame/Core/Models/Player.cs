namespace BattleShipGame.Core.Models;

public class Player
{
    string Username { get; set; }
    Ship[] Ship { get; set; }

    public Player(string username, Ship[] ship)
    {
        Ship = ship;
        
        if (string.IsNullOrEmpty(Username))
        {
            throw new ArgumentException("Username is required.");
        }
        Username = username;
    }
    
    public void AddShip(Ship ship)
    {
        Ship = Ship.Concat(new Ship[] { ship }).ToArray();
    }
    
    public void RemoveShip(Ship ship)
    {
        Ship = Ship.Where(s => s != ship).ToArray();
    }
    
    public Ship[] GetShips()
    {
        return Ship;
    }
    
    public string GetUsername()
    {
        return Username;
    }
    
    public bool HasShips()
    {
        return Ship.Length > 0;
    }
}