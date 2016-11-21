using Calculator.RPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators
{
    public class OutBracketOperator : Operator
    {
        public OutBracketOperator() : base(")", 0, OperatorType.OutBracket)
        {
        }

        public override decimal Execute(Stack<decimal> param)
        {
            throw new NotImplementedException();
        }
    }
}
