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

        public override bool Execute()
        {

            Number L1 = stack.Input.Value;
            Number L2 = stack.Pop();
            stack.SetInput(L2 / L1);
            return true;
        }
    }
}
