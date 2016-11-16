using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Addititional
{
    public class StringSeparator : IStringSeparator
    {
        public IEnumerable<PNToken> Separate(string input, OperatorList opList)
        {
            int pos = 0;
            input = input.Replace(" ", string.Empty);
            PNToken token;
            bool mayNextUnary = true;
            while (pos < input.Length)
            {
                StringBuilder s = new StringBuilder(input[pos].ToString());
                if (char.IsDigit(input[pos]))
                {
                    for (int i = pos + 1; i < input.Length && (char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                        s.Append(input[i]);

                    decimal res = decimal.Parse(s.ToString().Replace(".", ","), NumberStyles.AllowDecimalPoint,
                        new NumberFormatInfo() { NumberDecimalSeparator = "," });
                    token = new PNOperandToken(res);
                    mayNextUnary = false;
                }
                else
                {
                    if (char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length && (char.IsLetter(input[i]) || char.IsDigit(input[i])); i++)
                            s.Append(input[i]);

                    Operator op = GetOperator(opList, s.ToString(), mayNextUnary);
                    if (op == null)
                        throw new InvalidOperationException(string.Format("Оператор \"{0}\" не поддерживается!", s));
                    mayNextUnary = MayNextUnary(op);
                    token = new PNOperatorToken(op);
                }
                yield return token;
                pos += s.Length;
            }
        }

        private Operator GetOperator(OperatorList opList, string sym, bool mayNextUnary)
        {
            Operator op;
            if (opList.HasManyOverload(sym))
            {
                if (mayNextUnary)
                {
                    op = opList.GetByType(sym, OperatorType.UnaryOperator);
                }
                else
                {
                    op = opList.GetByType(sym, OperatorType.BinaryOperator);
                }
            }
            else
            {
                op = opList.Get(sym);
            }
            return op;
        }

        private bool MayNextUnary(Operator op)
        {

            switch (op.OperatorType)
            {
                case OperatorType.InBracket:
                case OperatorType.BinaryOperator:
                case OperatorType.UnaryOperator:
                    return true;
                case OperatorType.OutBracket:
                    return false;
            }
            return false;
        }
    }
}
