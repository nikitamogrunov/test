using Calculator.RPNCalculator;
using System;
using System.Linq;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void ParsingTest()
        {
            //     Calculator.RPNCalculator.Calculator calc = new RPNCalculator.Calculator();
            //   var res = calc.Separate("abs(1) + 2");

            string exp = "-1 + 28*Exp(1314)/2&5";



            Assert.Equal("-;1;+;28;*;Exp;(;1314;);/;2;&;5", String.Join(";", StringParser.Parse(exp).ToArray()));
        }

    }
}
