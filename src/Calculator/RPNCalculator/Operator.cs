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
        public int OperandCount { get; }
        private readonly Func<Stack<decimal>, decimal> _function;

        public Operator(string symbol, int priority, OperatorType type, int operandCount = 0, Func<Stack<decimal>, decimal> function = null)
        {
            _function = function;
            Symbol = symbol;
            Priority = priority;
            OperatorType = type;
            OperandCount = operandCount;
        }

        public decimal Execute(Stack<decimal> param )
        {
            if (_function != null)
                return _function(param);
            throw new InvalidOperationException("Невозможно вычислить значение для данного оператора!");
        }

    }
}
