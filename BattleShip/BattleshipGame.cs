using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class BattleshipGame
    {
        private const int BoardSize = 10;
        private readonly char[,] _board;
        private readonly List<Ship> _ships;

        public BattleshipGame()
        {
            _board = new char[BoardSize, BoardSize];
            _ships = new List<Ship>();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int hor = 0; hor < BoardSize; hor++)
            {
                for (int ver = 0; ver < BoardSize; ver++)
                {
                    _board[hor, ver] = '~'; // Water
                }
            }
        }

        public bool PlaceShip(int x, int y, int length, bool isVertical)
        {
            if (!CanPlaceShip(x, y, length, isVertical)) return false;

            var ship = new Ship(x, y, length, isVertical);
            _ships.Add(ship);

            foreach (var (shipX, shipY) in ship.OccupiedCells)
                _board[shipX, shipY] = 'S'; // ship positions

            return true;
        }

        private bool CanPlaceShip(int x, int y, int length, bool isVertical)
        {
            if (isVertical && (x + length > BoardSize))
                return false;

            if (!isVertical && (y + length > BoardSize))
                return false;

            for (int i = 0; i < length; i++)
            {
                int checkX = isVertical ? x + i : x;
                int checkY = isVertical ? y : y + i;

                if (_board[checkX, checkY] == 'S') return false; // ship 
            }


            return true;
        }

        public string Attack(int x, int y)
        {
            foreach (var ship in _ships)
            {
                if (ship.Hit(x, y))
                {
                    _board[x, y] = 'X'; // Hit
                    return ship.IsSunk() ? "Hit and sunk" : "Hit";
                }
            }
            _board[x, y] = 'O'; // Miss
            return "Missed";
        }

        public bool IsGameOver()
        {
            return _ships.All(ship => ship.IsSunk());
        }

        public void DisplayBoard()
        {
            Console.WriteLine(" 0 1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < BoardSize; i++)
            {
                Console.Write(i );
                for (int j = 0; j < BoardSize; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();


            }
            Console.WriteLine();
        }
    }
}
