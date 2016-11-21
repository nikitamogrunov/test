using Calculator.RPN;
using Calculator.RPN.Addititional;
using Calculator.RPN.Operators;
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
            IPostfixNotationExecuter executer = new PostfixNotationExecuter();
            var op = new AddOperator();

            Queue<PNToken> expr = new Queue<PNToken>(new List<PNToken> { new PNOperandToken(1), new PNOperandToken(2), new PNOperatorToken(op) });
            var opList = new OperatorList();

            opList.Add(op);
            decimal result = executer.Execute(expr, opList);

            Assert.Equal(3, result);
        }

    }
}
