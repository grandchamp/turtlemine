using turtle_mine.Entities;

namespace turtle_mine
{
    public static class PointHelpers
    {
        public static Point ToPoint(this (int first, int second) value)
            => new Point(value.first, value.second);
    }
}