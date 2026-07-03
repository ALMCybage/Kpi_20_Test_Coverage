using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApplication1.Models;

namespace WebApplication1.Tests.Models
{
    /// <summary>
    /// Partial test suite for <see cref="Calculator"/>.
    /// Intentionally covers only the basic operations (~40% of the class) so the
    /// coverage-delta KPI has a meaningful, non-100% baseline to measure against.
    /// Untested on purpose: Modulo, Absolute, Negate, Percentage, Average, Max,
    /// memory operations, history and Clear.
    /// </summary>
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_ReturnsSum()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double result = calculator.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
            Assert.AreEqual(5, calculator.Result);
        }

        [TestMethod]
        public void Subtract_ReturnsDifference()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double result = calculator.Subtract(10, 4);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Multiply_ReturnsProduct()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double result = calculator.Multiply(6, 7);

            // Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Divide_ReturnsQuotient()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double result = calculator.Divide(20, 5);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_Throws()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            calculator.Divide(1, 0);

            // Assert handled by ExpectedException
        }

        [TestMethod]
        public void Power_ReturnsRaisedValue()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double result = calculator.Power(2, 10);

            // Assert
            Assert.AreEqual(1024, result);
        }

        [TestMethod]
        public void SquareRoot_ReturnsRoot()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double result = calculator.SquareRoot(81);

            // Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareRoot_Negative_Throws()
        {
            Calculator calculator = new Calculator();
            calculator.SquareRoot(-1);
        }

        [TestMethod]
        public void Modulo_ReturnsRemainder()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(1, calculator.Modulo(10, 3));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Modulo_ByZero_Throws()
        {
            Calculator calculator = new Calculator();
            calculator.Modulo(5, 0);
        }

        [TestMethod]
        public void Absolute_ReturnsPositive()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(7, calculator.Absolute(-7));
        }

        [TestMethod]
        public void Negate_FlipsSign()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(-4, calculator.Negate(4));
        }

        [TestMethod]
        public void Percentage_DividesBy100()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(0.25, calculator.Percentage(25));
        }

        [TestMethod]
        public void Average_ReturnsMean()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(20, calculator.Average(10, 20, 30));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Average_NoValues_Throws()
        {
            Calculator calculator = new Calculator();
            calculator.Average();
        }

        [TestMethod]
        public void Max_ReturnsLargest()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(30, calculator.Max(10, 30, 20));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Max_NoValues_Throws()
        {
            Calculator calculator = new Calculator();
            calculator.Max();
        }

        [TestMethod]
        public void Memory_StoreRecallClear_Works()
        {
            Calculator calculator = new Calculator();
            calculator.Add(5, 5);
            calculator.MemoryStore();
            Assert.AreEqual(10, calculator.MemoryRecall());

            calculator.MemoryClear();
            Assert.AreEqual(0, calculator.MemoryRecall());
        }

        [TestMethod]
        public void GetHistory_RecordsOperations()
        {
            Calculator calculator = new Calculator();
            calculator.Add(1, 2);
            calculator.Subtract(5, 1);
            Assert.AreEqual(2, calculator.GetHistory().Count);
        }

        [TestMethod]
        public void Clear_ResetsResultAndHistory()
        {
            Calculator calculator = new Calculator();
            calculator.Add(1, 2);
            calculator.Clear();

            Assert.AreEqual(0, calculator.Result);
            Assert.AreEqual(0, calculator.GetHistory().Count);
        }
    }
}
