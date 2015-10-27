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
        private long input = 0;
        private int digitsAfterZero = 0;

        public double Input
        {
            get {
                if (!hasComma)
                    return (double)input;
                return (double)(input / Math.Pow(10, digitsAfterZero));
            }
        }

        private bool hasComma = false; 


        public CalculationStack() {
            stack = new Stack<double>();
        }

        public void Add(double value) {
            stack.Push(value);
        }

        public double Get()
        {
            if (stack.Count == 0)
                return 0;
            return stack.Pop();
        }

        public double AppendInput(int value) {
            if (hasComma)
                digitsAfterZero++;
            input = input * 10 + value;
            return input;
        }

        public bool setComma()
        {
            if (hasComma)
                return false;
            return hasComma = true;
        }


        public void RemoveInput()
        {
            if (hasComma && digitsAfterZero == 0) { 
                hasComma = false;
                return;
            }
            if (digitsAfterZero > 0)
                digitsAfterZero--;
            input /= 10;
        }

    }
}
