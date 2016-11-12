using Calculator.RPNCalculator.Addititional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class Calculator : ICalculator
    {

        private readonly OperatorList opList;
        public Calculator()
        {
            opList = new OperatorList();
            opList.Add(new Operator("+", 1, OperatorType.Operator, 2, (param) => { return param.Pop() + param.Pop(); }));
            opList.Add(new Operator("-", 1, OperatorType.Operator, 2, (param) => { return param.Pop() - param.Pop(); }));
            opList.Add(new Operator("*", 2, OperatorType.Operator, 2, (param) => { return param.Pop() * param.Pop(); }));
            opList.Add(new Operator("/", 2, OperatorType.Operator, 2, (param) => { return param.Pop() / param.Pop(); }));
            opList.Add(new Operator("(", 0, OperatorType.InBracket));
            opList.Add(new Operator(")", 0, OperatorType.OutBracket));

        }




        public decimal Execute(string expression)
        {
            return Executer.Execute(PostfixNotationParser.Parse(StringParser.Parse(expression), opList), opList);

        }

    }
}
