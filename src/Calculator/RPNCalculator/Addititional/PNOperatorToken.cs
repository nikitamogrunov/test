using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Addititional
{
    public class PNOperatorToken: PNToken
    {
        public PNOperatorToken(Operator op) : base(op)
        {
            
        }
        public override string ToString()
        {
            return ((Operator)Subject).Symbol;
        }
    }
}
