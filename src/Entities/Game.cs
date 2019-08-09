using System;
using System.Collections.Generic;
using System.Linq;
using turtle_mine.Exceptions;

namespace turtle_mine.Entities
{
    public class Game
    {
        private readonly Board _board;
        private readonly Turtle _turtle;
        private readonly IEnumerable<Movement> _movements;
        public Game(Board board, Turtle turtle, IEnumerable<Movement> movements)
        {
            _board = board;
            _turtle = turtle;
            _movements = movements;
        }

        public Result Run()
        {
            try
            {
                var lastTurtle = _movements.Aggregate(_turtle, (turtle, movement) =>
               {
                   Console.WriteLine($"Turtle position: ({turtle.currentPoint.x},{turtle.currentPoint.y})");

                   if (movement == Movement.Move)
                       CheckTurtlePosition(turtle);

                   return turtle.Move(movement);
               });

                CheckTurtlePosition(lastTurtle);
            }
            catch (TurtleHasReachedMineException)
            {
                return Result.MineHit;
            }
            catch (TurtleHasReachedExitException)
            {
                return Result.Success;
            }

            return Result.StillInDanger;
        }

        private void CheckTurtlePosition(Turtle turtle)
        {
            if (_board.HasMineOn(turtle.currentPoint))
                throw new TurtleHasReachedMineException();

            if (_board.HasExitOn(turtle.currentPoint))
                throw new TurtleHasReachedExitException();

            if (_board.IsOutOfBounds(turtle.currentPoint))
                throw new TurtleIsOutOfBoundsException();
        }
    }
}