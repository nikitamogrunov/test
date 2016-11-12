using Calculator.RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class OperatorTest
    {
        [Fact]
        public void OperandExecuteTest()
        {

            Operator op = new Operator("+", 1, OperatorType.Operator, (in1, in2) => { return in1 + in2.Value; });
            Operator op2 = new Operator("-", 1, OperatorType.Operator, (in1, in2) => { return in1 - in2.Value; });
            Operator op3 = new Operator("*", 2, OperatorType.Operator, (in1, in2) => { return in1 * in2.Value; });
            Operator op4 = new Operator("/", 2, OperatorType.Operator, (in1, in2) => { return in1 / in2.Value; });
            Operator op5 = new Operator("sin", 2, OperatorType.Operator, (in1, in2) => { return Convert.ToDecimal(Math.Sin(Convert.ToDouble(in1))); });

            var result = op.Execute(4, 1);
            var result2 = op2.Execute(4, 1);
            var result3 = op3.Execute(4, 1);
            var result4 = op4.Execute(5, 2);

            Assert.Equal(5, result);
            Assert.Equal(3, result2);
            Assert.Equal(4, result3);
            Assert.Equal(2.5m, result4);
            Assert.Equal(0.5m, op5.Execute(30 * (decimal)Math.PI / 180));


        }
    }
}
