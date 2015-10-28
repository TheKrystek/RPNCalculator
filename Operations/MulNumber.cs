using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class MulNumber : Operation
    {
       public MulNumber(CalculationStack calculationStack)
            : base(calculationStack)
        {}

        public override bool Execute()
        {
            stack.SetInput(stack.Input.Value * stack.Pop());
            return true;
        }
    }
}
