using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator.Addititional
{
    public class PostfixNotationExecuter : IPostfixNotationExecuter
    {
        public decimal Execute(Queue<PNToken> expression, OperatorList opList)
        {
            Stack<decimal> resStack = new Stack<decimal>();

            while (expression.Count > 0)
            {
                var item = expression.Dequeue();
                if (item is PNOperandToken)
                {
                    resStack.Push((decimal)item.Subject);
                }

                if (item is PNOperatorToken)
                {
                    var op = (Operator)item.Subject;
                    List<decimal> tmp = new List<decimal>(op.OperandCount);
                    for (int i = 0; i < op.OperandCount; i++)
                    {
                        tmp.Add(resStack.Pop());
                    }
                    Stack<decimal> operandStack = new Stack<decimal>();
                    tmp.Reverse();
                    tmp.ForEach(e => operandStack.Push(e));
                    resStack.Push(op.Execute(operandStack));
                }
            }
            return resStack.Pop();
        }
    }
}
