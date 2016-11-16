using Calculator.RPN.Addititional;
using System.Collections.Generic;

namespace Calculator.RPN
{
    public interface IStringSeparator
    {
        IEnumerable<PNToken> Separate(string input, OperatorList opList);
    }
}