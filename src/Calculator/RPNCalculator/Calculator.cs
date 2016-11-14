﻿using Calculator.RPNCalculator.Addititional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPNCalculator
{
    public class Calculator : ICalculator
    {
        private readonly OperatorList _opList;
        private readonly IStringSeparator _stringSeparator;
        private readonly IPostfixNotationParser _pnParser;
        private readonly IPostfixNotationExecuter _pnExecuter;

        public Calculator(OperatorList opList, IStringSeparator stringSeparator, IPostfixNotationParser pnParser, PostfixNotationExecuter pnExecuter)
        {
            _opList = opList;
            _stringSeparator = stringSeparator;
            _pnParser = pnParser;
            _pnExecuter = pnExecuter;
        }

        public decimal Execute(string expression)
        {
            return _pnExecuter.Execute(_pnParser.Parse(_stringSeparator.Separate(expression), _opList), _opList);
        }

    }
}
