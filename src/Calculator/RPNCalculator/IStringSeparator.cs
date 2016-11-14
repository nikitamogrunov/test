using System.Collections.Generic;

namespace Calculator.RPN
{
    public interface IStringSeparator
    {
        IList<string> Separate(string input);
    }
}