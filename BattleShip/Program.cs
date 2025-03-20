
using Battleship;

class Program
{
    static void Main()
    {
        var game = new BattleshipGame();
        game.PlaceShip(2, 2, 3, true);
        game.PlaceShip(5, 5, 4, false);

        while (!game.IsGameOver())
        {
            game.DisplayBoard();
            Console.Write("Enter attack coordinates (x y): ");
            var input = Console.ReadLine().Split(' ');
            if (input.Length != 2 || !int.TryParse(input[0], out int x) || !int.TryParse(input[1], out int y))
            {
                Console.WriteLine("Invalid. Try again.");
                continue;
            }

            Console.WriteLine(game.Attack(x, y));
        }

        game.DisplayBoard();
        Console.WriteLine("Game Over, the ships are sunk");
    }
}
