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
        private bool pushed = false;

        public Input Input
        {
            get {return input; }
        }

        public double L2 {get { return getLevel(0); }}
        public double L3 { get { return getLevel(1); } }
        public double L4 { get { return getLevel(2); } }

        private double getLevel(int p)
        {
            p = index - p;
            if (p >= 0 && p < stack.Count)
                return stack[p];
            return 0;
        }

        public CalculationStack() {
            stack = new List<double>();
            input = new Input();
        }

        public void Push(double value) {        
            stack.Add(value);
            index++;
            pushed = true;
            OnPropertyChanged();
        }

        public void PushInput()
        {
            Push(input.Value);
        }


        public double Get(int index = -1)
        {
            if (index == -1)
                index = this.index;

            if (index < 0)
                return 0;
            return stack[index];
        }

        public double Pop() {
            return 0;
        }

        public void Append(int p)
        {
            if (pushed)
                input.Clear();

            input.Add(p);
            pushed = false;
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
