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
                    if (resStack.Count < op.OperandCount)
                        throw new InvalidOperationException("В выражении не хватает операндов!");
                    resStack.Push(op.Execute(resStack));
                }
            }

            return resStack.Count > 0 ? resStack.Pop() : 0;
        }
    }
}
