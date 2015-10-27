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
        private Input input; 

        public double Input
        {
            get {return input.Value; }
        }

        private bool hasComma = false; 


        public CalculationStack() {
            stack = new Stack<double>();
            input = new Input();
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


        public void Append(int p)
        {
            input.Add(p);
        }

        public void setComma()
        {
            input.SetComma();
        }

        public void Erase()
        {
            input.Erase();
        }

        public void Clear()
        {
            input.Clear();
        }
    }
}
