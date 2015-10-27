using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class CalculationStack : INotifyPropertyChanged
    {
        private List<double> stack;
        private Input input;
        private int index = -1; // wskaznik na ostatni element


        public string Input
        {
            get {return input.Text; }
        }

        public double L2 {get { return getLevel(2); }}
        public double L3 { get { return getLevel(3); } }
        public double L4 { get { return getLevel(4); } }

        private double getLevel(int p)
        {
            p--;
            p = index - p;
            if (p >= 0 && p < stack.Count)
                return stack[p];
            return p * input.Value;
        }


        private bool hasComma = false; 


        public CalculationStack() {
            stack = new List<double>();
            input = new Input();
        }

        public void Add(double value) {        
            stack.Add(value);
            index++;
        }

        public double Get(int index = -1)
        {
            if (index == -1)
                index = this.index;

            if (index < 0)
                return 0;
            return stack[index];
        }


        public void Append(int p)
        {
            input.Add(p);
            OnPropertyChanged();
        }

        public void SetComma()
        {
            input.SetComma();
            OnPropertyChanged();
        }

        public void Erase()
        {
            input.Erase();
            OnPropertyChanged();
        }

        public void Clear()
        {
            input.Clear();
            OnPropertyChanged();
        }



        protected void OnPropertyChanged(string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
