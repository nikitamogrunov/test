using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class SqrtOperator : Operator
    {
        public SqrtOperator() : base("sqrt", 3, OperatorType.UnaryOperator)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            return (decimal)Math.Sqrt((double)param.Pop());
        }
    }
}
