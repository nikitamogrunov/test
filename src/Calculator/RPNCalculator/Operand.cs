using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class Operand
    {
        public string Symbol { get; }
        public int Priority { get; }
        private readonly Func<decimal, decimal?, decimal> _function;

        public Operand(string symbol, int priority, Func<decimal, decimal?, decimal> function)
        {
            _function = function;
            Symbol = symbol;
            Priority = priority;
        }

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
