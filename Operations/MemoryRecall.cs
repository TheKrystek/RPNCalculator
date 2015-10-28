using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class MemoryRecall : Operation
    {
        public MemoryRecall(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

        public override void Execute()
        {
            stack.Input.Value = stack.Memory;
            stack.RefreshMemory();
        }
    }
}
