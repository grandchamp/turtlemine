using System;
using NUnit.Framework;
using turtle_mine;
using turtle_mine.Entities;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void Run_ReachExit_ReturnsSuccess()
        {
            var board = new Board(3, 3, new Point(1, 1), new Point[] { new Point(2, 2) });
            var turtle = new Turtle(new Point(0, 0), Direction.East);
            var movements = new Movement[]
            {
                Movement.Move, Movement.Right, Movement.Move
            };

            Assert.AreEqual(Result.Success, new Game(board, turtle, movements).Run());
        }

        [Test]
        public void Run_ReachMine_ReturnsMineHit()
        {
            var board = new Board(3, 3, new Point(1, 1), new Point[] { new Point(1, 0) });
            var turtle = new Turtle(new Point(0, 0), Direction.East);
            var movements = new Movement[]
            {
                Movement.Move
            };

            Assert.AreEqual(Result.MineHit, new Game(board, turtle, movements).Run());
        }

        [Test]
        public void Run_HitNothing_ReturnsStillInDanger()
        {
            var board = new Board(3, 3, new Point(1, 1), new Point[] { new Point(1, 0) });
            var turtle = new Turtle(new Point(0, 0), Direction.East);
            var movements = new Movement[]
            {
                Movement.Right
            };

            Assert.AreEqual(Result.StillInDanger, new Game(board, turtle, movements).Run());
        }
    }
}