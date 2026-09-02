using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    /// <summary>
    /// A simple arithmetic calculator that supports the four basic operations,
    /// a handful of common math helpers, and a running memory/history.
    /// Kept dependency-free so it is easy to unit test for coverage.
    /// </summary>
    public class Calculator
    {
        private readonly List<string> _history = new List<string>();

        /// <summary>
        /// The last computed result. Starts at zero.
        /// </summary>
        public double Result { get; private set; }

        /// <summary>
        /// A value stored in memory via <see cref="MemoryStore"/>.
        /// </summary>
        public double Memory { get; private set; }

        /// <summary>
        /// Adds two numbers and stores the outcome as the current result.
        /// </summary>
        public double Add(double a, double b)
        {
            Result = a + b;
            Record("{0} + {1} = {2}", a, b, Result);
            return Result;
        }

                public double Add(double a, double b,double c)
        {
            Result = a + b;
            Record("{0} + {1} = {2}", a, b, Result);
            return Result;
        }
                public double Add(double a, double b,double c,double d)
        {
            Result = a + b;
            Record("{0} + {1} = {2}", a, b, Result);
            return Result;
        }
                public double Add(double a, double b,double c,double d,double e)
        {
            Result = a + b;
            Record("{0} + {1} = {2}", a, b, Result);
            return Result;
        }
                public double Add(double a, double b,double c,double d,double e,double f)
        {
            Result = a + b;
            Record("{0} + {1} = {2}", a, b, Result);
            return Result;
        }

        /// <summary>
        /// Subtracts <paramref name="b"/> from <paramref name="a"/>.
        /// </summary>
        public double Subtract(double a, double b)
        {
            Result = a - b;
            Record("{0} - {1} = {2}", a, b, Result);
            return Result;
        }

        /// <summary>
        /// Multiplies two numbers together.
        /// </summary>
        public double Multiply(double a, double b)
        {
            Result = a * b;
            Record("{0} * {1} = {2}", a, b, Result);
            return Result;
        }

        /// <summary>
        /// Divides <paramref name="a"/> by <paramref name="b"/>.
        /// Throws <see cref="DivideByZeroException"/> when the divisor is zero.
        /// </summary>
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            Result = a / b;
            Record("{0} / {1} = {2}", a, b, Result);
            return Result;
        }

        /// <summary>
        /// Returns the remainder of the integer-style division a mod b.
        /// </summary>
        public double Modulo(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot take modulo by zero.");
            }

            Result = a % b;
            Record("{0} % {1} = {2}", a, b, Result);
            return Result;
        }

        /// <summary>
        /// Raises <paramref name="baseValue"/> to the given exponent.
        /// </summary>
        public double Power(double baseValue, double exponent)
        {
            Result = Math.Pow(baseValue, exponent);
            Record("{0} ^ {1} = {2}", baseValue, exponent, Result);
            return Result;
        }

        /// <summary>
        /// Returns the square root of <paramref name="value"/>.
        /// Throws <see cref="ArgumentException"/> for negative input.
        /// </summary>
        public double SquareRoot(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Cannot take the square root of a negative number.", nameof(value));
            }

            Result = Math.Sqrt(value);
            Record("sqrt({0}) = {1}", value, Result);
            return Result;
        }

        /// <summary>
        /// Returns the absolute value of <paramref name="value"/>.
        /// </summary>
        public double Absolute(double value)
        {
            Result = Math.Abs(value);
            Record("abs({0}) = {1}", value, Result);
            return Result;
        }

        /// <summary>
        /// Negates the sign of <paramref name="value"/>.
        /// </summary>
        public double Negate(double value)
        {
            Result = -value;
            Record("negate({0}) = {1}", value, Result);
            return Result;
        }

        /// <summary>
        /// Converts a value to a percentage (value / 100).
        /// </summary>
        public double Percentage(double value)
        {
            Result = value / 100.0;
            Record("{0}% = {1}", value, Result);
            return Result;
        }

        /// <summary>
        /// Returns the arithmetic mean of the supplied values.
        /// </summary>
        public double Average(params double[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentException("At least one value is required.", nameof(values));
            }

            double sum = 0;
            foreach (double value in values)
            {
                sum += value;
            }

            Result = sum / values.Length;
            Record("avg of {0} values = {1}", values.Length, Result);
            return Result;
        }

        /// <summary>
        /// Returns the largest of the supplied values.
        /// </summary>
        public double Max(params double[] values)
        {
            if (values == null || values.Length == 0)
            {
                throw new ArgumentException("At least one value is required.", nameof(values));
            }

            double max = values[0];
            foreach (double value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }

            Result = max;
            Record("max = {0}", Result);
            return Result;
        }

        /// <summary>
        /// Stores the current result into memory.
        /// </summary>
        public void MemoryStore()
        {
            Memory = Result;
            Record("memory stored: {0}", Memory);
        }

        /// <summary>
        /// Recalls and returns the value currently held in memory.
        /// </summary>
        public double MemoryRecall()
        {
            Record("memory recalled: {0}", Memory);
            return Memory;
        }

        /// <summary>
        /// Clears the stored memory value back to zero.
        /// </summary>
        public void MemoryClear()
        {
            Memory = 0;
            Record("memory cleared");
        }

        /// <summary>
        /// Returns a read-only snapshot of every operation performed so far.
        /// </summary>
        public IReadOnlyList<string> GetHistory()
        {
            return _history.AsReadOnly();
        }

        /// <summary>
        /// Resets the current result and clears the operation history.
        /// </summary>
        public void Clear()
        {
            Result = 0;
            _history.Clear();
        }

        private void Record(string format, params object[] args)
        {
            _history.Add(string.Format(format, args));
        }
    }
}
