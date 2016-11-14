using Calculator;
using Calculator.RPN;
using Calculator.RPN.Addititional;
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
            opList.Add(new Operator("+", 1, OperatorType.BinaryOperator, (param) => { return param.Pop() + param.Pop(); }));
            opList.Add(new Operator("-", 1, OperatorType.BinaryOperator, (param) => { return param.Pop() - param.Pop(); }));
            opList.Add(new Operator("+", 1, OperatorType.UnaryOperator, (param) => { return param.Pop(); }));
            opList.Add(new Operator("-", 1, OperatorType.UnaryOperator, (param) => { return -param.Pop(); }));
            opList.Add(new Operator("*", 2, OperatorType.BinaryOperator, (param) => { return param.Pop() * param.Pop(); }));
            opList.Add(new Operator("/", 2, OperatorType.BinaryOperator, (param) => { return param.Pop() / param.Pop(); }));
            opList.Add(new Operator("sqrt", 3, OperatorType.UnaryOperator,
                (param) => { return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(param.Pop()))); }));
            opList.Add(new Operator("^", 3, OperatorType.BinaryOperator,
                (param) => { return Convert.ToDecimal(Math.Pow(Convert.ToDouble(param.Pop()), Convert.ToDouble(param.Pop()))); }));
            opList.Add(new Operator("@", 3, OperatorType.UnaryOperator,
             (param) => { return Convert.ToDecimal(Math.Exp(Convert.ToDouble(param.Pop()))); }));
            opList.Add(new Operator("(", 0, OperatorType.InBracket));
            opList.Add(new Operator(")", 0, OperatorType.OutBracket));
            return new RPNCalculator(opList, new StringSeparator(),
                new PostfixNotationParser(), new PostfixNotationExecuter());
        }
    }
}
