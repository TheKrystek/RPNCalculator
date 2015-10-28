using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class ChangeSign : Operation
    {
       public ChangeSign(CalculationStack calculationStack)
            : base(calculationStack)
        {}

        public override bool Execute()
        {
            stack.Input.Value.Value *= -1;
            stack.SetInput(stack.Input.Value);
            return true;
        }
    }
}
