using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN
{
    public abstract class Operator
    {
        public string Symbol { get; }
        public int Priority { get; }
        public OperatorType OperatorType { get; }

        public int OperandCount
        {
            get
            {
                int count = 0;
                switch (OperatorType)
                {
                    case OperatorType.InBracket:
                    case OperatorType.OutBracket:
                        count = 0; break;
                    case OperatorType.BinaryOperator:
                        count = 2; break;
                    case OperatorType.UnaryOperator:
                        count = 1; break;
                }
                return count;
            }
        }

        public Operator(string symbol, int priority, OperatorType type)
        {
            Symbol = symbol;
            Priority = priority;
            OperatorType = type;
        }

        public abstract decimal Execute(Stack<decimal> param);
    }
}
