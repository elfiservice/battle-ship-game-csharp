// See https://aka.ms/new-console-template for more information

using BattleShipGame.CoreBusiness.Core.Models;
using BattleShipGame.CoreBusiness.Core.ValuesObjects;
using BattleShipGame.CoreBusiness.UseCases;


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

StartGame(game);


void ProvideShipsTo(Player player)
{
    var battleField = player.GetBattleField();
    var numberOfShipsToProvide = battleField.RequiredShips.Length;

    for (int i = 0; i < numberOfShipsToProvide; i++)
    {
        var ship = battleField.RequiredShips[i];

        do
        {
            try
            {
                Console.WriteLine($"Player {player.GetUsername()}, Ship{i + 1} {ship.ToString()}, Cell {ship.GetCells().Length + 1} : ");
        
                Console.WriteLine("Enter Column e Row, ex: A12: ");
                var cellCoordinates = Console.ReadLine();
                
                ship = new SetChipCellUseCase().Execute(ship, cellCoordinates, battleField);
                
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ops! {e.Message}, try again.");
                Console.ResetColor();
            }

        } while (ship.HasCellToFill());
    
        Console.WriteLine($"LOG: {ship.ShowShipToString()}");
    }
}

void StartGame(Game gameToStart)
{
    var currentPlayer = gameToStart.Player1;
    var opponentPlayer = gameToStart.Player2;

    do
    {
        Console.WriteLine($"Player {currentPlayer.GetUsername()}, your turn.");
        Console.WriteLine("Enter with your guess, Column e Row, ex: A12: ");
        var cellCoordinates = Console.ReadLine();
        
        try
        {
            bool hit = new ShootTheOpponentUseCase().Execute(currentPlayer, opponentPlayer, cellCoordinates ?? "");
            
            if (hit)
            {
                ShowMessageToUser(MessageLevel.Success, "HIT!");
            }
            else
            {
                ShowMessageToUser(MessageLevel.Info, "MISS!");
            }
            
            var hasShips = opponentPlayer.HasShips();
            if (!hasShips)
            {
                gameToStart.SetWinner(currentPlayer);
                
                ShowMessageToUser(
                    MessageLevel.Success, $"Player {currentPlayer.GetUsername()} wins!");
                Console.ResetColor();
                break;
            }
            
            (currentPlayer, opponentPlayer) = (opponentPlayer, currentPlayer);
        }
        catch (Exception e)
        {
            ShowMessageToUser(
                MessageLevel.Error, $"Ops! {e.Message}, try again.");
        }
        
    } while (gameToStart.HasNotWinner());
}

Console.WriteLine("##### END #####");


void ShowMessageToUser(MessageLevel type, string message)
{
    Console.BackgroundColor = GetColorByMessageLevel(type);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(message);
    Console.ResetColor();
}

ConsoleColor GetColorByMessageLevel(MessageLevel type)
{
    return type switch
    {
        MessageLevel.Error => ConsoleColor.Red,
        MessageLevel.Warning => ConsoleColor.Yellow,
        MessageLevel.Info => ConsoleColor.Blue,
        MessageLevel.Success => ConsoleColor.Green,
        _ => ConsoleColor.White
    };
}

enum MessageLevel
{
    Error,
    Warning,
    Info,
    Success
}

