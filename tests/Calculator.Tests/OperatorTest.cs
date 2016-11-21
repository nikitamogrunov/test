using Calculator.RPN;
using Calculator.RPN.Operators;
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
        public void AddOperatorExecuteTest()
        {
            Operator op = new AddOperator();
            var result = op.Execute(SetStack());
            Assert.Equal(7, result);
        }
    }
}
