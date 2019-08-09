using System;
using NUnit.Framework;
using turtle_mine;
using turtle_mine.Entities;

namespace Tests
{
    public class MovementHelperTests
    {
        [Test]
        public void ToMovement_Right_ReturnsRight()
        {
            Assert.AreEqual(Movement.Right, "R".ToMovement());
        }

        [Test]
        public void ToMovement_Left_ReturnsLeft()
        {
            Assert.AreEqual(Movement.Left, "L".ToMovement());
        }

        [Test]
        public void ToMovement_Move_ReturnsMove()
        {
            Assert.AreEqual(Movement.Move, "M".ToMovement());
        }

        [Test]
        public void ToMovement_WrongAbbreviation_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "1".ToMovement());
        }

        [Test]
        public void ToMovement_NullAbbreviation_ThrowsException()
        {
            string nullString = null;
            Assert.Throws<ArgumentNullException>(() => nullString.ToMovement());
        }
    }
}