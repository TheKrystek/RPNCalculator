using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public abstract class Operation : IOperation
    {
        protected CalculationStack stack;
        public Operation( CalculationStack stack) {
            this.stack = stack;
        }

        public abstract void Execute();
    }
}
