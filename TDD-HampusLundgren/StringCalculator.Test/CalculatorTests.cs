using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator sut { get; set; }
        [SetUp]
        public void Setup()
        {
            sut = new Calculator();
        }

        [Test]
        public void AddEmptyStringReturnsZero()
        {
            // Arrange
            // Act
            var result = sut.Add("");
            // Assert
            Assert.AreEqual(0, result);
        }
        [Test]
        public void AddOneReturnOne()
        {
            // Arrange
            // Act
            var result = sut.Add("1");
            // Assert
            Assert.AreEqual(1, result);
        }
        [Test]
        public void AddTwoDifferentNumbersReturnSum()
        {
            // Arrange
            // Act
            var result = sut.Add("1,12");
            // Assert
            Assert.AreEqual(13, result);
        }
        [Test]
        public void SplittNumbersOnNewLine()
        {
            // Arrange
            // Act
            var result = sut.Add("1\n2,3");
            // Assert
            Assert.AreEqual(6, result);
        }
        [Test]
        public void AddNegativeNumbers_CastExeption()
        {
            Assert.Throws<NegatesForibbenExeption>(() =>
            {
                sut.Add("-1,-15\n-20,500");
            });
        }
        [Test]
        public void IgnoreNumbersBiggerThen1000()
        {
            // Arrange
            // Act
            var result = sut.Add("1\n20,3000");
            // Assert
            Assert.AreEqual(21, result);
        }
   
    }
}
