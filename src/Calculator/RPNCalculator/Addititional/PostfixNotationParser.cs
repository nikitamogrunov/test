using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator.Addititional
{
    public static class PostfixNotationParser
    {


        public static Queue<PNToken> Parse(IEnumerable<string> expr, OperatorList opList)
        {
            Queue<PNToken> outString = new Queue<PNToken>();
            Stack<Operator> operatorStack = new Stack<Operator>();

            foreach (var sym in expr)
            {
                decimal res;
    
                if (decimal.TryParse(sym.Replace(".", ","), NumberStyles.AllowDecimalPoint, new NumberFormatInfo() { NumberDecimalSeparator = "," }, out res))
                {
                    outString.Enqueue(new PNOperandToken(res));
                    continue;
                }

                var op = opList.Get(sym);
                if (op != null)
                {
                    switch (op.OperatorType)
                    {
                        case OperatorType.InBracket:
                            operatorStack.Push(op);
                            continue;
                        case OperatorType.OutBracket:
                            var popOperator = operatorStack.Pop();
                            while (popOperator.OperatorType != OperatorType.InBracket)
                            {
                                outString.Enqueue(new PNOperatorToken(popOperator));
                                popOperator = operatorStack.Pop();
                            }
                            continue;
                        case OperatorType.Operator:
                            while (operatorStack.Count > 0 && op.Priority <= operatorStack.Peek().Priority)
                                outString.Enqueue(new PNOperatorToken(operatorStack.Pop()));
                            operatorStack.Push(op);
                            continue;
                    }

                }
                throw new InvalidOperationException("Недопустимое значение!");
            }
            while (operatorStack.Count > 0)
            {
                outString.Enqueue(new PNOperatorToken(operatorStack.Pop()));
            }
            return outString;
        }
    }
}
