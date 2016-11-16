using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Addititional
{
    public class PNOperandToken : PNToken
    {
        public PNOperandToken(decimal op) : base(op)
        {

        }

        public override string ToString()
        {
            return ((decimal)Subject).ToString();
        }
    }
}
