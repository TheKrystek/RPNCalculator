using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class Clear : Operation
    {
       public Clear(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

       public override void Execute()
        {
            stack.Clear();
        }
    }
}
