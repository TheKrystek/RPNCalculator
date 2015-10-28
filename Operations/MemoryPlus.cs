using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class MemoryPlus : Operation
    {
        public MemoryPlus(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

        public override void Execute()
        {
            stack.Memory += stack.Input.Value;
        }
    }
}
