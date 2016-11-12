using Calculator.RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class OperandTest
    {
        [Fact]
        public void OperandExecuteTest()
        {

            Operand op = new Operand((in1, in2) => { return in1 + in2.Value; });
            Operand op2 = new Operand((in1, in2) => { return in1 - in2.Value; });
            Operand op3 = new Operand((in1, in2) => { return in1 * in2.Value; });
            Operand op4 = new Operand((in1, in2) => { return in1 / in2.Value; });
            Operand op5 = new Operand((in1, in2) => { return Convert.ToDecimal(Math.Sin(Convert.ToDouble(in1))); });

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
