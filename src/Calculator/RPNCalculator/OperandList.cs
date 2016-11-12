using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class OperandList
    {

        private readonly Dictionary<string, Operand> operandList;

        public OperandList()
        {
            operandList = new Dictionary<string, Operand>();
        }

        public void Add(Operand operand)
        {
            operandList.Add(operand.Symbol, operand);
        }

        public Operand Get(string symbol)
        {
            try
            {
                return operandList[symbol];
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }


    }
}
