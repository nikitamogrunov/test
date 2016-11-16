using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.RPN.Addititional
{
    public abstract class PNToken
    {
        public object Subject { get; }

        public PNToken(object sub)
        {
            Subject = sub;
        }
      
    }
}
