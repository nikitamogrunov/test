using Calculator;
using Calculator.RPN;
using Calculator.RPN.Addititional;
using Calculator.RPN.Operators.OperatorListExtension;
using System;
using System.Collections.Generic;


namespace Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = CreateCalculator();
            Console.WriteLine("Для выхода введите Exit");
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите выражение:");
                    var expression = Console.ReadLine();
                    if (expression.ToLower() == "exit")
                        break;
                    Console.WriteLine("Результат выражения: {0}", calc.Execute(expression));
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Ошибка! {0}", ex.Message);
                }
            }
        }
        private static ICalculator CreateCalculator()
        {
            OperatorList opList = new OperatorList();
            opList.InitWithDefaultOperators();
            return new RPNCalculator(opList, new StringSeparator(),
                new PostfixNotationParser(), new PostfixNotationExecuter());
        }
    }
}
