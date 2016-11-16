using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN
{
    public class OperatorList
    {
        private readonly List<Operator> _operatorList;

        public OperatorList()
        {
            _operatorList = new List<Operator>();
        }
        /// <summary>
        /// Adding +, -, unary+, unary-, *, /, sqrt, ^, @ - symbolic exp, (, ).
        /// </summary>
        public void AddDefaultOperators()
        {
            _operatorList.Add(new Operator("+", 1, OperatorType.BinaryOperator, (param) => { return param.Pop() + param.Pop(); }));
            _operatorList.Add(new Operator("-", 1, OperatorType.BinaryOperator, (param) => { return param.Pop() - param.Pop(); }));
            _operatorList.Add(new Operator("+", 1, OperatorType.UnaryOperator, (param) => { return param.Pop(); }));
            _operatorList.Add(new Operator("-", 1, OperatorType.UnaryOperator, (param) => { return -param.Pop(); }));
            _operatorList.Add(new Operator("*", 2, OperatorType.BinaryOperator, (param) => { return param.Pop() * param.Pop(); }));
            _operatorList.Add(new Operator("/", 2, OperatorType.BinaryOperator, (param) => { return param.Pop() / param.Pop(); }));
            _operatorList.Add(new Operator("sqrt", 3, OperatorType.UnaryOperator,
                (param) => { return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(param.Pop()))); }));
            _operatorList.Add(new Operator("^", 3, OperatorType.BinaryOperator,
                (param) => { return Convert.ToDecimal(Math.Pow(Convert.ToDouble(param.Pop()), Convert.ToDouble(param.Pop()))); }));
            _operatorList.Add(new Operator("@", 3, OperatorType.UnaryOperator,
             (param) => { return Convert.ToDecimal(Math.Exp(Convert.ToDouble(param.Pop()))); }));
            _operatorList.Add(new Operator("(", 0, OperatorType.InBracket));
            _operatorList.Add(new Operator(")", 0, OperatorType.OutBracket));
        }

        public void Add(Operator op)
        {
            if (_operatorList.Where(e => e.Symbol == op.Symbol && e.OperatorType == op.OperatorType).Count() > 0)
            {
                throw new ArgumentException("Попытка добавления повторяющегося оператора!");
            }

            _operatorList.Add(op);
        }

        public Operator Get(string symbol)
        {
            return _operatorList.SingleOrDefault(e => e.Symbol == symbol);
        }

        public bool HasManyOverload(string symbol)
        {
            return _operatorList.Where(e => e.Symbol == symbol).Count() > 1;
        }

        public Operator GetByType(string symbol, OperatorType type)
        {
            return _operatorList.Where(e => e.Symbol == symbol && e.OperatorType == type).SingleOrDefault();
        }
    }
}
