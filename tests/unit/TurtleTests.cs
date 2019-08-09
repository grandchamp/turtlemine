using System;
using NUnit.Framework;
using turtle_mine.Entities;

namespace Tests
{
    public class TurtleTests
    {
        private Turtle _turtle = new Turtle(new Point(1, 1), Direction.North);

        [Test]
        public void MoveRight()
        {
            var expected = new Turtle(new Point(1, 1), Direction.East);

            Assert.AreEqual(expected, _turtle.Move(Movement.Right));
        }

        [Test]
        public void MoveLeft()
        {
            var expected = new Turtle(new Point(1, 1), Direction.West);

            Assert.AreEqual(expected, _turtle.Move(Movement.Left));
        }

        [Test]
        public void Move()
        {
            var expected = new Turtle(new Point(1, 0), Direction.North);

            Assert.AreEqual(expected, _turtle.Move(Movement.Move));
        }
    }
}