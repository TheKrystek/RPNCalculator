using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class MemoryMinus : Operation
    {
        public MemoryMinus(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

       public override void Execute()
        {
            stack.Memory -= stack.Input.Value;
        }
    }
}
