using System;
using NUnit.Framework;
using turtle_mine;
using turtle_mine.Entities;

namespace Tests
{
    public class ParsingHelperTests
    {
        public void ParseIntToTuple_Valid_ReturnsTuple()
        {
            Assert.AreEqual((1, 1), "1,1".ParseToIntTuple());
        }

        public void ParseIntToTuple_ValidWithSeparator_ReturnsTuple()
        {
            Assert.AreEqual((1, 1), "1 1".ParseToIntTuple(' '));
        }

        public void ParseIntToTuple_NullValue_ThrowsException()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => "".ParseToIntTuple());
            Assert.Throws<ArgumentNullException>(() => nullString.ParseToIntTuple());
        }

        public void ParseIntToTuple_NoSeparatorFound_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "1 1".ParseToIntTuple());
        }

        public void ParseMinePoints_Valid_ReturnMines()
        {
            var expected = new Point[]
            {
                new Point(1, 1),
                new Point(2, 2)
            };

            CollectionAssert.AreEqual(expected, "1,1 2,2".ParseMinePoints());
        }

        public void ParseMinePoints_NullValue_ThrowsException()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => "".ParseMinePoints());
            Assert.Throws<ArgumentNullException>(() => nullString.ParseMinePoints());
        }

        public void ParseMinePoints_NoSeparatorFound_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "1 1".ParseMinePoints());
        }

        public void ParseTurtle_Valid_ReturnTurtle()
        {
            var expected = new Turtle(new Point(1, 1), Direction.East);

            Assert.AreEqual(expected, "1 1 E".ParseTurtle());
        }

        public void ParseTurtle_NullValue_ThrowsException()
        {
            string nullString = null;

            Assert.Throws<ArgumentNullException>(() => "".ParseTurtle());
            Assert.Throws<ArgumentNullException>(() => nullString.ParseTurtle());
        }

        public void ParseTurtle_InvalidLength_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "1 1".ParseTurtle());
        }

        public void ParseMovements_Valid_ReturnMovements()
        {
            var expected = new Movement[]
            {
                Movement.Left,
                Movement.Right,
                Movement.Move
            };

            Assert.AreEqual(expected, new string[] { "", "", "", "", "L R", "M" }.ParseMovements());
        }
    }
}