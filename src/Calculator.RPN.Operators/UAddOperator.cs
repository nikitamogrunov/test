using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class UAddOperator : Operator
    {
        public UAddOperator() : base("+", 10, OperatorType.UnaryOperator)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            return param.Pop();
        }
    }
}
