using Calculator.RPN;
using Calculator.RPN.Addititional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Test
{
    public class PostfixNotationParserTest
    {
        [Fact]
        public void PostfixParserTest()
        {
            var op = new Operator("+", 1, OperatorType.BinaryOperator);
            IPostfixNotationParser parser = new PostfixNotationParser();
            List<PNToken> expr = new List<PNToken>
            {
                new PNOperandToken(3),
                new PNOperatorToken(op),
                new PNOperandToken(4)
            };
            var opList = new OperatorList();
            opList.Add(op);

            var res = parser.Parse(expr, opList);
            Assert.Equal(3m, res.Dequeue().Subject);
            Assert.Equal(4m, res.Dequeue().Subject);
            Assert.Equal("+", ((Operator)(res.Dequeue().Subject)).Symbol);
        }
    }
}
