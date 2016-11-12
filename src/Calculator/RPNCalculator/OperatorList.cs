using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class OperatorList
    {

        private readonly Dictionary<string, Operator> operatorList;

        public OperatorList()
        {
            operatorList = new Dictionary<string, Operator>();
        }

        public void Add(Operator operand)
        {
            operatorList.Add(operand.Symbol, operand);
        }

        public Operator Get(string symbol)
        {
            try
            {
                return operatorList[symbol];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        //public bool HasOperator(string symbol)
        //{
        //    return operatorList.ContainsKey(symbol);

        //}


    }
}
