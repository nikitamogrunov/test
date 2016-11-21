using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class ExpOperator : Operator
    {
        public ExpOperator() : base("@", 1, OperatorType.UnaryOperator)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            return (decimal)Math.Exp((double)param.Pop());
        }
    }
}
