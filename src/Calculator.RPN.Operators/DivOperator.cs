using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class DivOperator : Operator
    {
        public DivOperator() : base("/", 2, OperatorType.BinaryOperator)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            return param.Pop() / param.Pop();
        }
    }
}
