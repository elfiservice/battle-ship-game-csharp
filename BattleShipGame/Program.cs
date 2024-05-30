// See https://aka.ms/new-console-template for more information

using BattleShipGame.Core.Models;
using BattleShipGame.Core.ValuesObjects;
using BattleShipGame.UseCases;


var player1Name = "";
var player2Name = "";

do
{
    Console.WriteLine("Player 1 name :");
    player1Name = Console.ReadLine();
} while (player1Name is "" or null);

do
{
    Console.WriteLine("Player 2 name :");
    player2Name = Console.ReadLine();
} while (player2Name is "" or null);

var game = new Game();
game.Player1 = new Player(player1Name, new BattleField());
ProvideShipsTo(game.Player1);

game.Player2 = new Player(player2Name, new BattleField());
ProvideShipsTo(game.Player2);


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
        
                Console.WriteLine("Enter Column e Row, ex: A12: ");
                var cellCordinates = Console.ReadLine();
                
                if (string.IsNullOrEmpty(cellCordinates))
                {
                    throw new ArgumentException("Cell cordinates are required.");
                }

                ship = new SetChipCellUseCase().Execute(ship, cellCordinates);
        
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