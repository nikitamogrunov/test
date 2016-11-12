using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class Operand
    {

        public Operand(Func<decimal, decimal?, decimal> function)
        {
            _function = function;
        }

        public string Symbol { get; private set; }
        private readonly Func<decimal, decimal?, decimal> _function;

        public decimal Execute(decimal in1, decimal? in2 = null)
        {
            return _function(in1, in2);
        }



    }

    //InBracket,
    //    OutBracket,
    //    Add,
    //    Sub,
    //    Mul,
    //    Div,
    //    Exp
}
