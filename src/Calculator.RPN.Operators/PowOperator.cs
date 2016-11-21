using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class PowOperator : Operator
    {
        public PowOperator() : base("^", 3, OperatorType.BinaryOperator)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            return (decimal)Math.Pow((double)param.Pop(), (double)param.Pop());
        }
    }
}
