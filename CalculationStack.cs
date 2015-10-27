using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class CalculationStack
    {
        private Stack<double> stack;

        public void Add(double value) {
            stack.Push(value);
        }

        public double Get()
        {
            if (stack.Count == 0)
                return 0;
            return stack.Pop();
        }

    }
}
