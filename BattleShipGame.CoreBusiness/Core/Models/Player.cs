namespace BattleShipGame.CoreBusiness.Core.Models;

public class Player
{
    string Username { get; set; }
    
    private BattleField BattleField { get; set; }

    private List<Cell> OwnGuesses { get; set; } = [];

    private List<Cell> OpponentGuesses { get; set; } = [];

    public Player(string username, BattleField battleField)
    {
        if (string.IsNullOrEmpty(username) || battleField is null)
        {
            throw new ArgumentException("Username and Battlefield are required.");
        }
        Username = username;
        BattleField = battleField;
    }
    
    
    public string GetUsername()
    {
        return Username;
    }
    
    public bool HasShips()
    {
        return !BattleField.AllShipsDestroyed();
    }

    public void SetBattleField(BattleField field)
    {
        BattleField = field;
    }
    
    public BattleField GetBattleField()
    {
        return BattleField;
    }
    
    public void ShotToOpponent(Player opponent, Cell myShotCell)
    {
        if (MyShotExistInMyOwnGuesses(myShotCell))
        {
            throw new Exception("You already tried this coordinate.");
        }
        else
        {
            OwnGuesses.Add(myShotCell);
            opponent.OpponentGuesses.Add(myShotCell);
        }
    }
    
    private bool MyShotExistInMyOwnGuesses(Cell cell)
    {
        return OwnGuesses.Any(c => c.GetCordinates() == cell.GetCordinates());
    }
}