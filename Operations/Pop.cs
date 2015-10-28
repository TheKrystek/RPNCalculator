using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class Pop : Operation
    {
       public Pop(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

        public override bool Execute()
        {
            stack.Pop();
            return true;
        }
    }
}
