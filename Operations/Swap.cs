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

        public override bool Execute()
        {
            double tmpImput = stack.Input.Value;
            double tmpL2 = stack.Pop();
            stack.Pop();
            stack.Input.Value = tmpL2;
            stack.Push(tmpImput);
            return true;
        }
    }
}
