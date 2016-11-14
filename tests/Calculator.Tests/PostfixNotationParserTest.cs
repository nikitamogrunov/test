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
            IPostfixNotationParser parser = new PostfixNotationParser();
            List<string> expr = new List<string> { "3", "+", "4" };
            var opList = new OperatorList();
            opList.Add(new Operator("+", 1, OperatorType.BinaryOperator));

            var res = parser.Parse(expr, opList);
            Assert.Equal(3m, res.Dequeue().Subject);
            Assert.Equal(4m, res.Dequeue().Subject);
            Assert.Equal("+", ((Operator)(res.Dequeue().Subject)).Symbol);
        }
    }
}
