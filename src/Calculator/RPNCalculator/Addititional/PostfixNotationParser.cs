using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator.Addititional
{
    public class PostfixNotationParser : IPostfixNotationParser
    {
        public Queue<PNToken> Parse(IEnumerable<string> expr, OperatorList opList)
        {
            Queue<PNToken> outString = new Queue<PNToken>();
            Stack<Operator> operatorStack = new Stack<Operator>();

            foreach (var sym in expr)
            {
                decimal res;

                if (decimal.TryParse(sym.Replace(".", ","), NumberStyles.AllowDecimalPoint,
                    new NumberFormatInfo() { NumberDecimalSeparator = "," }, out res))
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
                            bool inBracketFound = false;
                            while (operatorStack.Count > 0)
                            {
                                Operator popOperator = operatorStack.Pop();
                                if (popOperator.OperatorType != OperatorType.InBracket)
                                    outString.Enqueue(new PNOperatorToken(popOperator));
                                else
                                {
                                    inBracketFound = true;
                                    break;
                                }
                            }
                            if (!inBracketFound)
                                throw new InvalidOperationException("Несогласованные скобки в выражении!");
                            continue;
                        case OperatorType.Operator:
                            while (operatorStack.Count > 0 && op.Priority <= operatorStack.Peek().Priority)
                                outString.Enqueue(new PNOperatorToken(operatorStack.Pop()));
                            operatorStack.Push(op);
                            continue;
                    }
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Оператор \"{0}\" не поддерживается!", sym));
                }
            }
            while (operatorStack.Count > 0)
            {
                var op = operatorStack.Pop();
                if (op.OperatorType != OperatorType.Operator)
                    throw new InvalidOperationException("Несогласованные скобки в выражении!");
                outString.Enqueue(new PNOperatorToken(op));
            }
            return outString;
        }
    }
}
