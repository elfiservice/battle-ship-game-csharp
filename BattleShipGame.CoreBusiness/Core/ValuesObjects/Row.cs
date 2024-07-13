namespace BattleShipGame.CoreBusiness.Core.ValuesObjects;

public class Row
{
    private int Value { get; set; }
    private int[] _validValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
    public Row(int value)
    {
        if (!_validValues.Contains(value))
        {
            throw new ArgumentException("Invalid row value, must be between 1 and 10.");
        }
        Value = value;
    }
    
    public int GetValue()
    {
        return Value;
    }
    
    public int GetIndex()
    {
        return Array.IndexOf(_validValues, Value);
    }
}