using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class InvertNumber : Operation
    {
       public InvertNumber(CalculationStack calculationStack)
            : base(calculationStack)
        {}

       public override void Execute()
        {
            double L1 = stack.Input.Value;
            stack.SetInput(1 / L1);
        }
    }
}
