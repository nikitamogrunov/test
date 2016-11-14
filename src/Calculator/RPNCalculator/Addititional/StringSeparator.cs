using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator.Addititional
{
    public class StringSeparator : IStringSeparator
    {
        public IEnumerable<string> Separate(string input)
        {
            int pos = 0;
            input = input.Replace(" ", string.Empty);
            while (pos < input.Length)
            {
                StringBuilder s = new StringBuilder(input[pos].ToString());
                {
                    if (char.IsDigit(input[pos]))
                    {
                        for (int i = pos + 1; i < input.Length && (char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s.Append(input[i]);
                    }
                    else
                    {
                        if (char.IsLetter(input[pos]))
                            for (int i = pos + 1; i < input.Length && (char.IsLetter(input[i]) || char.IsDigit(input[i])); i++)
                                s.Append(input[i]);
                    }
                }
                yield return s.ToString();
                pos += s.Length;
            }
        }
    }
}
