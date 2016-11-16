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
        public Queue<PNToken> Parse(IList<string> expr, OperatorList opList)
        {
            Queue<PNToken> outString = new Queue<PNToken>();
            Stack<Operator> operatorStack = new Stack<Operator>();
            bool mayNextUnary = true;
            foreach (var sym in expr)
            {

                decimal res;

                if (decimal.TryParse(sym, NumberStyles.AllowDecimalPoint,
                    new NumberFormatInfo() { NumberDecimalSeparator = "," }, out res))
                {
                    outString.Enqueue(new PNOperandToken(res));
                    mayNextUnary = false;
                    continue;
                }

                Operator op = GetOperator(opList, sym, mayNextUnary);
                
                if (op != null)
                {
                    switch (op.OperatorType)
                    {
                        case OperatorType.InBracket:
                            operatorStack.Push(op);
                            mayNextUnary = true;
                            continue;
                        case OperatorType.OutBracket:
                            mayNextUnary = false;
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
                            mayNextUnary = true;
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
                if (op.OperatorType != OperatorType.BinaryOperator && op.OperatorType != OperatorType.UnaryOperator)
                    throw new InvalidOperationException("Несогласованные скобки в выражении!");
                outString.Enqueue(new PNOperatorToken(op));
            }
            return outString;
        }

        private Operator GetOperator(OperatorList opList, string sym, bool mayNextUnary)
        {
            Operator op;
            if (opList.HasManyOverload(sym))
            {
                if (mayNextUnary)
                {
                    op = opList.GetByType(sym, OperatorType.UnaryOperator);
                }
                else
                {
                    op = opList.GetByType(sym, OperatorType.BinaryOperator);
                }
            }
            else
            {
                op = opList.Get(sym);
            }
            return op;
        }
    }
}
