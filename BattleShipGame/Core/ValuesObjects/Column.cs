namespace BattleShipGame.Core.ValuesObjects;

public class Column
{
    private string Value { get; set; }
    private string[] _validValues = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
    
    public Column(string value)
    {
        if (!_validValues.Contains(value))
        {
            throw new ArgumentException("Invalid column value, must be between A and J.");
        }
        Value = value;
    }
    
    public string GetValue()
    {
        return Value;
    }
}
