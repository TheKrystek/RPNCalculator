using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class DivNumber : Operation
    {
       public DivNumber(CalculationStack calculationStack)
            : base(calculationStack)
        {}

       public override void Execute()
        {

            double L1 = stack.Input.Value;
            double L2 = stack.Pop();
            stack.SetInput(L2 / L1);
        }
    }
}
