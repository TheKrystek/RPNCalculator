using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class SqrtNumber : Operation
    {
       public SqrtNumber(CalculationStack calculationStack)
            : base(calculationStack)
        {}

       public override void Execute()
        {
            double L1 = stack.Input.Value;
            stack.SetInput(Math.Sqrt(L1));
        }
    }
}
