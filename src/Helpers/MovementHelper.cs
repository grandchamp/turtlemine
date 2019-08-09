using System;
using turtle_mine.Entities;

namespace turtle_mine
{
    public static class MovementHelper
    {
        public static Movement ToMovement(this string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value.Equals("R"))
                return Movement.Right;
            if (value.Equals("L"))
                return Movement.Left;
            if (value.Equals("M"))
                return Movement.Move;
            else
                throw new ArgumentOutOfRangeException(nameof(value), "The provided value is not a valid movement.");
        }
    }
}