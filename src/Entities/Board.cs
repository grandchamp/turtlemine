using System;
using System.Collections.Generic;
using System.Linq;

namespace turtle_mine.Entities
{
    public class Board
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Point Exit { get; private set; }
        public IEnumerable<Point> Mines { get; private set; }

        public Board(int xAxisSize, int yAxisSize, Point exitPoint, IEnumerable<Point> mines)
        {
            if (xAxisSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(xAxisSize), "X axis can't be <= 0");

            if (yAxisSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(yAxisSize), "Y axis can't be <= 0");

            Width = xAxisSize;
            Height = yAxisSize;

            if (IsOutOfBounds(exitPoint))
                throw new ArgumentOutOfRangeException(nameof(exitPoint), "The exit point is out of bounds.");

            Exit = exitPoint;

            if (mines == null)
                throw new ArgumentNullException(nameof(mines));

            Mines = mines;
        }

        public bool HasMineOn(Point point)
            => Mines.Any(mine => point.Equals(mine));

        public bool HasExitOn(Point point)
            => Exit.Equals(point);

        public bool IsOutOfBounds(Point point)
            => point.x < 0 || point.x > this.Width - 1 || point.y < 0 && point.y > this.Height - 1;
    }
}
