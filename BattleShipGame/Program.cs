// See https://aka.ms/new-console-template for more information

using BattleShipGame.Core.Models;
using BattleShipGame.Core.ValuesObjects;



var player1Name = "";

do
{
    Console.WriteLine("Player 1 name :");
    player1Name = Console.ReadLine();
} while (player1Name is "" or null);

var game = new Game();
game.Player1 = new Player(player1Name, new BattleField());
ProvideShipsTo(game.Player1);


void ProvideShipsTo(Player player)
{
    var battleField = player.GetBattleField();
    var numberOfShipsToProvide = battleField.RequiredShips.Length;

    for (int i = 0; i < numberOfShipsToProvide; i++)
    {
        var ship = battleField.RequiredShips[i];
        var shipLength = ship.GetShipLength();

        do
        {
            try
            {
                Console.WriteLine($"Player {player.GetUsername()}, Ship{i + 1} {ship.ToString()}, Cell {shipLength} : ");
        
                Console.WriteLine("Enter Column: ");
                var columnValue = Console.ReadLine();
                var column = new Column(columnValue);
        
            
                Console.WriteLine("Enter Row: ");
                var rowValue = Console.ReadLine();
                var row = new Row(Convert.ToInt32(rowValue));

                var cell = new Cell(column, row);
        
                ship.FillCell(cell);
        
                --shipLength;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ops! {e.Message}, try again.");
            }

        } while (shipLength > 0);
    
        Console.WriteLine($"LOG: {ship.ShowShipToString()}");
    }
}

Console.WriteLine("##### END #####");