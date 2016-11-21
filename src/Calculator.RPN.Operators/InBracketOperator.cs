using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class InBracketOperator : Operator
    {
        public InBracketOperator() : base("(", 0, OperatorType.InBracket)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            throw new NotImplementedException();
        }
    }
}
