using Calculator.RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Test
{
    public class OperatorListTest
    {
        [Fact]
        void AddAndGetInOperatorListTest()
        {
            OperatorList opList = new OperatorList();
            opList.Add(new Operator("(", 0, OperatorType.InBracket));
            Operator op = opList.Get("(");
            Assert.Equal("(", op.Symbol);
        }

        [Fact]
        void GetNullFromOperatorListTest()
        {
            OperatorList opList = new OperatorList();
            Operator op1 = opList.Get("+");
            Assert.Null(op1);
        }

        [Fact]
        void AddSecondInOperatorListFailTest()
        {
            OperatorList opList = new OperatorList();
            opList.Add(new Operator("(", 0, OperatorType.InBracket));
            Assert.Throws(typeof(ArgumentException), () => opList.Add(new Operator("(", 0, OperatorType.InBracket)));
        }
    }
}
