using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class Swap : Operation
    {
        public Swap(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

        public override void Execute()
        {
            double tmpImput = stack.Input.Value;
            stack.Input.Value = stack.L2;
            stack.Set(tmpImput);
        }
    }
}
