using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class Calculator : ICalculator
    {
        private readonly List<decimal> outString;
        private readonly Stack<Operand> operandStack;

        public Calculator()
        {
            outString = new List<decimal>();
            operandStack = new Stack<Operand>();
        }




        public string Execute(string expression)
        {
            //foreach (var sym in StringParser.Parse(expression))
            //{
            //    decimal res;
            //    if (decimal.TryParse(sym, out res))
            //    {
            //        outString.Add(res);
            //        continue;
            //    }
                
            //    if (sym == "(")
            //    {
            //        continue;
            //    }
            //    if (sym == ")")
            //    {
            //        string s = operandStack.Pop();
            //        while (s != "(")
            //        {
            //            outString.Add(s);
            //            s = operandStack.Pop();
            //        }
            //    }
            //    if (op)
            //    {
            //    }



            //}
            return "";
        }

    }
}
