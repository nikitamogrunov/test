using Calculator.RPNCalculator;
using Calculator.RPNCalculator.Addititional;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Calculator.Test
{
    public class CalculatorTest
    {

        private readonly ICalculator calc;
        public CalculatorTest()
        {
            OperatorList opList = new OperatorList();
            opList.Add(new Operator("+", 2, OperatorType.Operator, 2, (param) => { return param.Pop() + param.Pop(); }));
            opList.Add(new Operator("-", 2, OperatorType.Operator, 2, (param) => { return param.Pop() - param.Pop(); }));
            opList.Add(new Operator("*", 3, OperatorType.Operator, 2, (param) => { return param.Pop() * param.Pop(); }));
            opList.Add(new Operator("/", 3, OperatorType.Operator, 2, (param) => { return param.Pop() / param.Pop(); }));
            opList.Add(new Operator("sqrt", 1, OperatorType.Operator, 1, 
                (param) => { return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(param.Pop()))); }));
            opList.Add(new Operator("(", 0, OperatorType.InBracket));
            opList.Add(new Operator(")", 0, OperatorType.OutBracket));

            calc = new RPNCalculator.Calculator(opList, new StringSeparator(),
                new PostfixNotationParser(), new PostfixNotationExecuter());
        }
        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("(1+1)*2", 4)]
        [InlineData("1+1*2", 3)]
        [InlineData("0.5*4", 2)]
        [InlineData("()", 0)]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        //[InlineData("-1", -1)]
        //[InlineData("-1*4", -4)]
        //[InlineData("(-1)", -1)]
        //[InlineData("(-1)+2", 1)]
        [InlineData("sqrt(4)", 2)]
        [InlineData("sqrt(8+8)", 4)]
        public void CalculatorExecTest(string expression, decimal result)
        {
            Assert.Equal(result, calc.Execute(expression));
        }

        [Fact]
        public void NotImplemetOperatorFailTest()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => calc.Execute("1&1"));
            Assert.Equal("Оператор \"&\" не поддерживается!", ex.Message);
        }

        [Theory]
        [InlineData("(1+1")]
        [InlineData("1+1)")]
        [InlineData("(")]
        [InlineData(")")]
        public void MismatchedBracesFailTest(string expression)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => calc.Execute(expression));
            Assert.Equal("Несогласованные скобки в выражении!", ex.Message);
        }

        [Theory]
        [InlineData("1+")]
        [InlineData("+1")]
        [InlineData("+")]
        public void NotEnoughOperandsFailTest(string expression)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => calc.Execute(expression));
            Assert.Equal("В выражении не хватает операндов!", ex.Message);
        }
    }
}
