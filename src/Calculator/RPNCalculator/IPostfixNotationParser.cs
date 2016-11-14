using System.Collections.Generic;
using Calculator.RPNCalculator.Addititional;

namespace Calculator.RPNCalculator
{
    public interface IPostfixNotationParser
    {
        Queue<PNToken> Parse(IEnumerable<string> expr, OperatorList opList);
    }
}