using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Addititional
{
    public class StringSeparator : IStringSeparator
    {
        public IList<string> Separate(string input)
        {
            int pos = 0;
            input = input.Replace(" ", string.Empty);
            List<string> result = new List<string>();
            while (pos < input.Length)
            {
                StringBuilder s = new StringBuilder(input[pos].ToString());
                if (char.IsDigit(input[pos]))
                {
                    for (int i = pos + 1; i < input.Length && (char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                        s.Append(input[i]);
                    s = s.Replace(".", ",");
                }
                else
                {
                    if (char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length && (char.IsLetter(input[i]) || char.IsDigit(input[i])); i++)
                            s.Append(input[i]);
                }
                result.Add(s.ToString());
                pos += s.Length;
            }
            return result;
        }
    }
}
