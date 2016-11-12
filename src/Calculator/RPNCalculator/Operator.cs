using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class Operator
    {
        public string Symbol { get; }
        public int Priority { get; }
        public OperatorType OperatorType { get; }
        private readonly Func<decimal, decimal?, decimal> _function;

        public Operator(string symbol, int priority, OperatorType type, Func<decimal, decimal?, decimal> function = null)
        {
            _function = function;
            Symbol = symbol;
            Priority = priority;
            OperatorType = type;
        }

        public decimal Execute(decimal in1, decimal? in2 = null)
        {
            if (_function != null)
                return _function(in1, in2);
            throw new InvalidOperationException("Невозможно вычислить значение для данного оператора!");
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
