using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using _07.Hack;

namespace UnitTests
{
    public class HackTests
    {
        [Test]
        public void MathAbsReturnsNegativeNumbersCorrectly()
        {
            Mock<IAbs> mockInt = new Mock<IAbs>();
            int negativeInt = -99;
            mockInt.Setup(m => m.ReturnAbsoluteValue(negativeInt)).Returns(Math.Abs(negativeInt));
            int expectedResult = 99;

            Assert.That(mockInt.Object.ReturnAbsoluteValue(negativeInt), Is.EqualTo(expectedResult));
        }

        [Test]
        public void MathFloorReturnsTheCorrectValue()
        {
            Mock<IFloor> doubleMock = new Mock<IFloor>();
            double doubleValue = 10.5;
            doubleMock.Setup(d => d.FloorNumber(doubleValue)).Returns(Math.Floor(doubleValue));
            double expectedResult = 10;

            Assert.That(doubleMock.Object.FloorNumber(doubleValue), Is.EqualTo(expectedResult));
        }
    }
}
