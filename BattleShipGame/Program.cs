// See https://aka.ms/new-console-template for more information

using BattleShipGame.Core.Models;
using BattleShipGame.Core.ValuesObjects;

var game = new Game();

var player1Name = "";

do
{
    Console.WriteLine("Player 1 name :");
    player1Name = Console.ReadLine();
} while (player1Name is "" or null);


game.Player1 = new Player(player1Name);

var numberOfShipsToProvide = game.RequiredShips.Length;

for (int i = 0; i < numberOfShipsToProvide; i++)
{
    var ship = game.RequiredShips[i];
    var shipLength = ship.GetShipLength();

    do
    {
        Console.WriteLine($"Player 1, Ship: {i + 1}");
        
        Console.WriteLine("Enter Column: ");
        var columnValue = Console.ReadLine();
        var column = new Column(columnValue);
        
            
        Console.WriteLine("Enter Row: ");
        var rowValue = Console.ReadLine();
        var row = new Row(Convert.ToInt32(rowValue));

        var cell = new Cell(column, row);
        
        ship.FillCell(cell);
        
        --shipLength;
    } while (shipLength > 0);
    
    Console.WriteLine($"LOG: {ship.GetCells().ToString()}");
}



Console.WriteLine("##### END #####");