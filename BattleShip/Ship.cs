using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        public List<(int x, int y)> OccupiedCells { get; }
        private HashSet<(int x, int y)> _hits;

        public Ship(int x, int y, int length, bool isVertical)
        {
            OccupiedCells = new List<(int, int)>();
            _hits = new HashSet<(int, int)>();

            for (int i = 0; i < length; i++)
            {
                int newX = isVertical ? x + i : x;
                int newY = isVertical ? y : y + i;
                OccupiedCells.Add((newX, newY));
            }
        }

        public bool Hit(int x, int y)
        {
            if (OccupiedCells.Contains((x, y)))
            {
                _hits.Add((x, y));
                return true;
            }
            return false;
        }

        public bool IsSunk()
        {
            return _hits.Count == OccupiedCells.Count;
        }
    }
}
