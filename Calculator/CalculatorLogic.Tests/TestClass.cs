using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLogic.Tests
{
    [TestFixture]
    public class TestClass
    {
        [TestCase("6,4 + 7", ExpectedResult = 13.4)]
        [TestCase("7   +   11", ExpectedResult = 18)]
        [TestCase("4 + 002", ExpectedResult = 6)]
        [TestCase("0+0", ExpectedResult = 0)]
        [TestCase("7+00010", ExpectedResult = 17)]
        [TestCase("6,4 *10", ExpectedResult = 64)]
        [TestCase("0* 15", ExpectedResult = 0)]
        [TestCase("0*0", ExpectedResult = 0)]
        [TestCase("6,4 *2", ExpectedResult = 12.8)]
        [TestCase("6,4 /2", ExpectedResult = 3.2)]
        [TestCase("6,4 /1", ExpectedResult = 6.4)]
        [TestCase("0/15", ExpectedResult = 0)]
        [TestCase("15,3 / 3", ExpectedResult = 5.1)]
        [TestCase("2 /2", ExpectedResult = 1)]
        [TestCase("30,4 -20,4", ExpectedResult = 10)]
        [TestCase("0 -20,4", ExpectedResult = -20.4)]
        [TestCase("5 -5", ExpectedResult = 0)]
        [TestCase("20 - 10,0", ExpectedResult = 10)]
        [TestCase("4 -1", ExpectedResult = 3)]
        public double AdditionTwoNumbersTest(string exp)
        {
            return Calculator.Calculate(exp);
        }



        [TestCase("5+2- / *3")]
        [TestCase("4 + 1 -- 3")]
        [TestCase("54544515//51515")]
        public void CalcExceptionTests(string exp)
        {

            Assert.Throws<FormatException>(() => Calculator.Calculate(exp));
        }
    }
}
