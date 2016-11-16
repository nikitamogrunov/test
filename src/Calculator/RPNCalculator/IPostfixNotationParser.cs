using System.Collections.Generic;
using Calculator.RPN.Addititional;

namespace Calculator.RPN
{
    public interface IPostfixNotationParser
    {
        Queue<PNToken> Parse(IEnumerable<PNToken> expr, OperatorList opList);
    }
}