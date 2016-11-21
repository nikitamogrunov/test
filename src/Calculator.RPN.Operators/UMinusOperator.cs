using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class UMinusOperator : Operator
    {
        public UMinusOperator() : base("-", 10, OperatorType.UnaryOperator)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            return -param.Pop();
        }
    }
}
