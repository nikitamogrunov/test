using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Operators.OperatorListExtension
{
    public static class OperatorListExtension
    {
        public static string InitWithDefaultOperators(this OperatorList list)
        {
            var operatorTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == "Calculator.RPN.Operators");
            StringBuilder result = new StringBuilder("");
            foreach (Type item in operatorTypes)
            {
                list.Add((Operator)Activator.CreateInstance(item));
            }
            return result.ToString();
        }

    }
}
