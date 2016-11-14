using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class OperatorList
    {
        private readonly Dictionary<string, Operator> _operatorList;

        public OperatorList()
        {
            _operatorList = new Dictionary<string, Operator>();
        }

        public void Add(Operator operand)
        {
            _operatorList.Add(operand.Symbol, operand);
        }

        public void Remove(string sym)
        {
            _operatorList.Remove(sym);
        }

        public void Remove(Operator op)
        {
            _operatorList.Remove(op.Symbol);
        }

        public Operator Get(string symbol)
        {
            try
            {
                return _operatorList[symbol];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
