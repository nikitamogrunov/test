using Calculator.RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Test
{
    public class OperatorTest
    {
        Stack<decimal> SetStack()
        {
            Stack<decimal> paramStack = new Stack<decimal>();
            paramStack.Push(2);
            paramStack.Push(5);
            return paramStack;
        }

        [Fact]
        public void OperandExecuteTest()
        {

            Operator op = new Operator("+", 1, OperatorType.Operator, 2, (param) => { return param.Pop() + param.Pop(); });
            Operator op2 = new Operator("-", 1, OperatorType.Operator, 2, (param) => { return param.Pop() - param.Pop(); });
            Operator op3 = new Operator("*", 2, OperatorType.Operator, 2, (param) => { return param.Pop() * param.Pop(); });
            Operator op4 = new Operator("/", 2, OperatorType.Operator, 2, (param) => { return param.Pop() / param.Pop(); });
            Operator op5 = new Operator("sin", 2, OperatorType.Operator, 1, (param) => { return Convert.ToDecimal(Math.Sin(Convert.ToDouble(param.Pop()) * Math.PI / 180)); });
 
             var result = op.Execute(SetStack());
            var result2 = op2.Execute(SetStack());
            var result3 = op3.Execute(SetStack());
            var result4 = op4.Execute(SetStack());

            Assert.Equal(7, result);
            Assert.Equal(3, result2);
            Assert.Equal(10, result3);
            Assert.Equal(2.5m, result4);

            Stack<decimal> paramStack = new Stack<decimal>();
          
            paramStack.Push(30);

            Assert.Equal(0.5m, op5.Execute(paramStack));
        }
    }
}
