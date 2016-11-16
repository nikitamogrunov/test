using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Addititional
{
    public class PostfixNotationParser : IPostfixNotationParser
    {
        public Queue<PNToken> Parse(IEnumerable<PNToken> expr, OperatorList opList)
        {
            Queue<PNToken> outString = new Queue<PNToken>();
            Stack<Operator> operatorStack = new Stack<Operator>();
            foreach (var item in expr)
            {
                if (item is PNOperandToken)
                {
                    outString.Enqueue(item);
                }
                else
                {
                    Operator op = (Operator)item.Subject;

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
                        case OperatorType.BinaryOperator:
                        case OperatorType.UnaryOperator:
                            while (operatorStack.Count > 0 && op.Priority <= operatorStack.Peek().Priority)
                                outString.Enqueue(new PNOperatorToken(operatorStack.Pop()));
                            operatorStack.Push(op);
                            continue;
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                var op = operatorStack.Pop();
                if (op.OperatorType != OperatorType.BinaryOperator && op.OperatorType != OperatorType.UnaryOperator)
                    throw new InvalidOperationException("Несогласованные скобки в выражении!");
                outString.Enqueue(new PNOperatorToken(op));
            }
            return outString;
        }


    }
}
