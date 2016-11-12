using Calculator;
using Calculator.RPNCalculator;
using Calculator.RPNCalculator.Addititional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    class Program
    {
        static void Main(string[] args)
        {


            //List<string> expr = new List<string> { "3", "+", "4", "*", "2", "/", "(", "1", "-", "5", ")", "^", "2" };
            //var opList = new OperatorList();
            //opList.Add(new Operator("+", 1, OperatorType.Operator));
            //opList.Add(new Operator("/", 2, OperatorType.Operator));
            //opList.Add(new Operator("-", 1, OperatorType.Operator));
            //opList.Add(new Operator("*", 2, OperatorType.Operator));
            //opList.Add(new Operator("^", 3, OperatorType.Operator));
            //opList.Add(new Operator("(", 0, OperatorType.InBracket));
            //opList.Add(new Operator(")", 0, OperatorType.OutBracket));

            var op = new Operator("+", 1, OperatorType.Operator, 2, (param) => { return param.Pop() + param.Pop(); });

            Queue<PNToken> expr = new Queue<PNToken>(new List<PNToken> { new PNOperandToken(1), new PNOperandToken(2), new PNOperatorToken(op) });
            var opList = new OperatorList();

            opList.Add(op);
            decimal result = Executer.Execute(expr, opList);

            //  var a = PostfixNotationParser.Parse(expr, opList);

        }
    }
}
