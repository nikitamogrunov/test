using Calculator.RPNCalculator;
using Calculator.RPNCalculator.Addititional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Test
{
    public class StringParserTest
    {
        [Fact]
        public void ParsingTest()
        {
            string exp = "-1 + 28*Exp(1314)/2&5";
            IStringSeparator separator = new StringSeparator();
            Assert.Equal("-1;+;28;*;Exp;(;1314;);/;2;&;5", String.Join(";", separator.Separate(exp).ToArray()));
        }
    }
}
