namespace turtle_mine.Entities
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new Point(x, y - 1);
                case Direction.South:
                    return new Point(x, y + 1);
                case Direction.East:
                    return new Point(x + 1, y);
                case Direction.West:
                    return new Point(x - 1, y);
                default:
                    return this;
            }
        }
    }
}