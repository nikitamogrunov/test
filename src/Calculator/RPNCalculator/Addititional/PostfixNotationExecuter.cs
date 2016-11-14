using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Addititional
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
                    if (resStack.Count < op.OperandCount)
                        throw new InvalidOperationException("В выражении не хватает операндов!");
                    var opStack = new Stack<decimal>();
                    for (int i = 0; i < op.OperandCount; i++)
                    {
                        opStack.Push(resStack.Pop());
                    }
                    resStack.Push(op.Execute(opStack));
                }
            }
            if (resStack.Count > 1)
                throw new InvalidOperationException("В выражении не хватает операторов!");
            return resStack.Count > 0 ? resStack.Pop() : 0;
        }
    }
}
