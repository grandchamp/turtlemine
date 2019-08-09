using System;
using NUnit.Framework;
using turtle_mine;
using turtle_mine.Entities;

namespace Tests
{
    public class PointHelperTests
    {
        [Test]
        public void ToPoint_ReturnsPoint()
        {
            Assert.AreEqual(new Point(1, 1), (1, 1).ToPoint());
        }
    }
}