using Calculator.RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void ParsingTest()
        {
            string exp = "-1 + 28*Exp(1314)/2&5";
            Assert.Equal("-;1;+;28;*;Exp;(;1314;);/;2;&;5", String.Join(";", StringParser.Parse(exp).ToArray()));


        }

    }
}
