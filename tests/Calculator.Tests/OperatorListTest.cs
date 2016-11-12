using Calculator.RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class OperatorListTest
    {
        [Fact]
        void AddAndGetInOperatorListTest()
        {
            OperatorList opList = new OperatorList();

            opList.Add(new Operator("(", 0, OperatorType.InBracket, null));
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

        //[Fact]
        //void HasOperatorInListTest()
        //{
        //    OperatorList opList = new OperatorList();
        //    opList.Add(new Operator("(", 0, null));
            
        //    Assert.True(opList.HasOperator("("));
        //    Assert.False(opList.HasOperator("+"));
        //}

        [Fact]
        void AddSecondInOperatorListFailTest()
        {
            OperatorList opList = new OperatorList();

            opList.Add(new Operator("(", 0, OperatorType.InBracket, null));
          //  opList.Add(new Operand("(", 0, null));

            Assert.Throws(typeof(ArgumentException), () => opList.Add(new Operator("(", 0, OperatorType.InBracket, null)));

        }

     

    }
}
