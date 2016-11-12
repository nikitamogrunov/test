using Calculator.RPNCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests
{
    public class OperandListTest
    {
        [Fact]
        void AddAndGetInOperandListTest()
        {
            OperandList opList = new OperandList();

            opList.Add(new Operand("(", 0, null));
            Operand op = opList.Get("(");
         

            Assert.Equal("(", op.Symbol);
          

        }

        [Fact]
        void GetNullFromOperandListTest()
        {
            OperandList opList = new OperandList();

            Operand op1 = opList.Get("+");
            Assert.Null(op1);

        }

        [Fact]
        void AddSecondInOperandListFailTest()
        {
            OperandList opList = new OperandList();

            opList.Add(new Operand("(", 0, null));
          //  opList.Add(new Operand("(", 0, null));

            Assert.Throws(typeof(ArgumentException), () => opList.Add(new Operand("(", 0, null)));

        }

     

    }
}
