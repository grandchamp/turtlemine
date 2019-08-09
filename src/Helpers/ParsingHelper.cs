using System;
using System.Collections.Generic;
using turtle_mine.Entities;

namespace turtle_mine
{
    public static class ParsingHelper
    {
        public static (int first, int second) ParseToIntTuple(this string value, char separator = ',')
        {
            CheckNullInput(value);

            if (!value.Contains(separator))
                throw new ArgumentOutOfRangeException(nameof(value), "The provided input doesn't contains the provided separator.");

            var split = value.Split(separator);

            return (int.Parse(split[0]), int.Parse(split[1]));
        }

        public static IEnumerable<Point> ParseMinePoints(this string value)
        {
            CheckNullInput(value);

            if (!value.Contains(','))
                throw new ArgumentOutOfRangeException(nameof(value), "The provided input is not a list of points.");

            var splitPoints = value.Split(' ');
            foreach (var point in splitPoints)
            {
                var splitPoint = point.ParseToIntTuple();

                yield return splitPoint.ToPoint();
            }
        }

        public static Turtle ParseTurtle(this string value)
        {
            CheckNullInput(value);

            var values = value.Split(' ');

            if (values.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(value), "The provided input is not a valid initial position for the turtle.");

            return new Turtle(new Point(int.Parse(values[0]), int.Parse(values[1])), values[2].ToDirection());
        }

        public static IEnumerable<Movement> ParseMovements(this string[] values)
        {
            for (int i = 4; i <= values.Length - 1; i++)
            {
                var movements = values[i].Split(' ');

                foreach (var movement in movements)
                    yield return movement.ToMovement();
            }
        }

        private static void CheckNullInput(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(value);
        }
    }
}