using Calculator.RPN.Addititional;
using System.Collections.Generic;

namespace Calculator.RPN
{
    public interface IPostfixNotationExecuter
    {
        decimal Execute(Queue<PNToken> expression, OperatorList opList);
    }
}