using System;
using NUnit.Framework;
using turtle_mine;
using turtle_mine.Entities;

namespace Tests
{
    public class DirectionHelperTests
    {
        [Test]
        public void ToDirection_North_ReturnsNorth()
        {
            Assert.AreEqual(Direction.North, "N".ToDirection());
        }

        [Test]
        public void ToDirection_South_ReturnsSouth()
        {
            Assert.AreEqual(Direction.South, "S".ToDirection());
        }

        [Test]
        public void ToDirection_East_ReturnsEast()
        {
            Assert.AreEqual(Direction.East, "E".ToDirection());
        }

        [Test]
        public void ToDirection_West_ReturnsWest()
        {
            Assert.AreEqual(Direction.West, "W".ToDirection());
        }

        [Test]
        public void ToDirection_WrongAbbreviation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "1".ToDirection());
        }

        [Test]
        public void ToDirection_NullAbbreviation_ThrowsException()
        {
            string nullString = null;
            Assert.Throws<ArgumentNullException>(() => nullString.ToDirection());
        }

        [Test]
        public void Move_NorthToRight_ReturnsEast()
        {
            Assert.AreEqual(Direction.East, Direction.North.Move(Movement.Right));
        }

        [Test]
        public void Move_SouthToLeft_ReturnsEast()
        {
            Assert.AreEqual(Direction.East, Direction.South.Move(Movement.Left));
        }

        [Test]
        public void Move_NorthToLeft_ReturnsWest()
        {
            Assert.AreEqual(Direction.West, Direction.North.Move(Movement.Left));
        }

        [Test]
        public void Move_SouthToRight_ReturnsWest()
        {
            Assert.AreEqual(Direction.West, Direction.South.Move(Movement.Right));
        }

        [Test]
        public void Move_EastToRight_ReturnsSouth()
        {
            Assert.AreEqual(Direction.South, Direction.East.Move(Movement.Right));
        }

        [Test]
        public void Move_WestToLeft_ReturnsSouth()
        {
            Assert.AreEqual(Direction.South, Direction.West.Move(Movement.Left));
        }

        [Test]
        public void Move_EastToLeft_ReturnsNorth()
        {
            Assert.AreEqual(Direction.North, Direction.East.Move(Movement.Left));
        }

        [Test]
        public void Move_WestToRight_ReturnsNorth()
        {
            Assert.AreEqual(Direction.North, Direction.West.Move(Movement.Right));
        }
    }
}