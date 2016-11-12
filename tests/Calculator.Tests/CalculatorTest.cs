using Calculator.RPNCalculator;
using Calculator.RPNCalculator.Addititional;
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



        //[Fact]
        //public void PostfixParserTest()
        //{
        //    List<string> expr = new List<string> { "3", "+", "4", "*", "2", "/","(","1" ,"-", "5",")","^", "2" };
        //    var opList = new OperatorList();
        //    opList.Add(new Operator("+", 1, OperatorType.Operator));
        //    opList.Add(new Operator("/", 2, OperatorType.Operator));
        //    opList.Add(new Operator("-", 1, OperatorType.Operator));
        //    opList.Add(new Operator("*", 2, OperatorType.Operator));
        //    opList.Add(new Operator("^", 3, OperatorType.Operator));
        //    opList.Add(new Operator("(", 0, OperatorType.InBracket));
        //    opList.Add(new Operator(")", 0, OperatorType.OutBracket));


        //   // 3 4 2 * 1 5 - 2 ^ / +
        //    Assert.Equal("3;4;2;*;1;5;-;2;^;/;+", String.Join(";", PostfixNotationParser.Parse(expr, opList).ToArray()));
        //}

        [Fact]
        public void PostfixParserTest()
        {
            List<string> expr = new List<string> { "3", "+", "4"};
            var opList = new OperatorList();
            opList.Add(new Operator("+", 1, OperatorType.Operator));

            var res = PostfixNotationParser.Parse(expr, opList);
            // 3 4 
            Assert.Equal(3m, res.Dequeue().Subject);
            Assert.Equal(4m, res.Dequeue().Subject);
            Assert.Equal("+", ((Operator)(res.Dequeue().Subject)).Symbol);
        }


    }
}
