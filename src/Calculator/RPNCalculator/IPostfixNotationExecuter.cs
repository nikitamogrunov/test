using Calculator.RPNCalculator.Addititional;
using System.Collections.Generic;

namespace Calculator.RPNCalculator
{
    public interface IPostfixNotationExecuter
    {
        decimal Execute(Queue<PNToken> expression, OperatorList opList);
    }
}