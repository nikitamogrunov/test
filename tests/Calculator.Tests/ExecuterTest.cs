using Calculator.RPNCalculator;
using Calculator.RPNCalculator.Addititional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Test
{
    public class ExecuterTest
    {
        [Fact]
        void ExecuteTest()
        {
            IPostfixNotationExecuter executer =new PostfixNotationExecuter();
            var op = new Operator("+", 1, OperatorType.Operator, 2, (param) => { return param.Pop() + param.Pop(); });

            Queue<PNToken> expr = new Queue<PNToken>(new List<PNToken> { new PNOperandToken(1), new PNOperandToken(2), new PNOperatorToken(op) });
            var opList = new OperatorList();

            opList.Add(op);
            decimal result = executer.Execute(expr, opList);

            Assert.Equal(3, result);
        }

    }
}
