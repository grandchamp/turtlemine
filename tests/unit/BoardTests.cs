using System;
using NUnit.Framework;
using turtle_mine.Entities;

namespace Tests
{
    public class BoardTests
    {
        private Point MINE_POINT = new Point(2, 2);
        private Point EXIT_POINT = new Point(3, 3);
        private Point NORMAL_POINT = new Point(1, 1);
        private Point OUT_OF_BOUNDS = new Point(-1, 0);

        private Board _board;
        [SetUp]
        public void Setup()
        {
            _board = new Board(5, 4, EXIT_POINT,
                               new Point[]
                               {
                                   MINE_POINT
                               });
        }

        [Test]
        public void PointHasMineOn_ReturnsTrue()
        {
            Assert.True(_board.HasMineOn(MINE_POINT));
        }

        [Test]
        public void PointHasNotMineOn_ReturnsTrue()
        {
            Assert.False(_board.HasMineOn(NORMAL_POINT));
        }

        [Test]
        public void PointHasExitOn_ReturnsTrue()
        {
            Assert.True(_board.HasExitOn(EXIT_POINT));
        }

        [Test]
        public void PointHasNotExitOn_ReturnsFalse()
        {
            Assert.False(_board.HasExitOn(NORMAL_POINT));
        }

        [Test]
        public void PointIsOutOfBounds_ReturnsTrue()
        {
            Assert.True(_board.IsOutOfBounds(OUT_OF_BOUNDS));
        }

        [Test]
        public void PointIsNotOutOfBounds_ReturnFalse()
        {
            Assert.False(_board.IsOutOfBounds(NORMAL_POINT));
        }

        [Test]
        public void InvalidBoardWidth_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Board(-1, 1, EXIT_POINT, null));
        }

        [Test]
        public void InvalidBoardHeight_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Board(1, 0, EXIT_POINT, null));
        }

        [Test]
        public void OutOfBoundsExitPoint_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Board(1, 1, OUT_OF_BOUNDS, null));
        }

        [Test]
        public void NullMines_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new Board(4, 4, EXIT_POINT, null));
        }
    }
}