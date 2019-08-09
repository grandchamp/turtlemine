using System;
using turtle_mine.Entities;

namespace turtle_mine
{
    public static class DirectionHelpers
    {
        public static Direction ToDirection(this string abbreviation)
        {
            if (abbreviation == null)
                throw new ArgumentNullException(nameof(abbreviation));

            if (abbreviation.Equals("N"))
                return Direction.North;
            else if (abbreviation.Equals("S"))
                return Direction.South;
            else if (abbreviation.Equals("E"))
                return Direction.East;
            else if (abbreviation.Equals("W"))
                return Direction.West;
            else
                throw new ArgumentOutOfRangeException(nameof(abbreviation), "The provided input is not a valid direction.");
        }

        public static Direction Move(this Direction direction, Movement move)
        {
            switch (direction)
            {
                case Direction.North when move == Movement.Right:
                case Direction.South when move == Movement.Left:
                    return Direction.East;
                case Direction.North when move == Movement.Left:
                case Direction.South when move == Movement.Right:
                    return Direction.West;
                case Direction.East when move == Movement.Right:
                case Direction.West when move == Movement.Left:
                    return Direction.South;
                case Direction.East when move == Movement.Left:
                case Direction.West when move == Movement.Right:
                    return Direction.North;
                default:
                    return direction;
            }
        }
    }
}