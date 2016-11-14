using System.Collections.Generic;

namespace Calculator.RPNCalculator
{
    public interface IStringSeparator
    {
        IEnumerable<string> Separate(string input);
    }
}