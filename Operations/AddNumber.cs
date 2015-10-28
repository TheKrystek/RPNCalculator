using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class AddNumber : Operation
    {
        public AddNumber(CalculationStack calculationStack)
            : base(calculationStack)
        {}

        public override void Execute()
        {
            stack.SetInput(stack.Input.Value + stack.Pop());
        }
    }
}
