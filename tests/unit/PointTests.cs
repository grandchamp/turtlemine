using System;
using NUnit.Framework;
using turtle_mine.Entities;

namespace Tests
{
    public class PointTests
    {
        private Point _point = new Point(1, 1);

        [Test]
        public void MoveNorth()
        {
            var expected = new Point(1, 0);

            Assert.AreEqual(expected, _point.Move(Direction.North));
        }

        [Test]
        public void MoveSouth()
        {
            var expected = new Point(1, 2);

            Assert.AreEqual(expected, _point.Move(Direction.South));
        }

        [Test]
        public void MoveEast()
        {
            var expected = new Point(2, 1);

            Assert.AreEqual(expected, _point.Move(Direction.East));
        }

        [Test]
        public void MoveWest()
        {
            var expected = new Point(0, 1);

            Assert.AreEqual(expected, _point.Move(Direction.West));
        }
    }
}