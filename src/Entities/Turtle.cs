namespace turtle_mine.Entities
{
    public struct Turtle
    {
        public Point currentPoint;
        private Direction currentDirection;

        public Turtle(Point point, Direction direction)
        {
            this.currentPoint = point;
            this.currentDirection = direction;
        }

        public Turtle Move(Movement movement)
        {
            if (movement == Movement.Move)
                return new Turtle(currentPoint.Move(currentDirection), currentDirection);

            return new Turtle(currentPoint, currentDirection.Move(movement));
        }
    }
}