using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class MemoryClear : Operation
    {
        public MemoryClear(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

        public override void Execute()
        {
            stack.Memory = 0;
        }
    }
}
