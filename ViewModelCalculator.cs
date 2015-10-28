using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace RPN
{
    class ViewModelCalculator : INotifyPropertyChanged 
    {

        public ViewModelCalculator()
        {
            calculationStack = new CalculationStack();
            calculate = new CalculateAction(calculationStack, calculationMode);
            calculationStack.PropertyChanged += StackChanged;
        }

        private void StackChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }



        #region Fields
            CalculationStack calculationStack;
            CalculationMode calculationMode;
            CalculateAction calculate;
        #endregion
        
        #region Properties
        #region Commands
        public ICommand Calculate
        {
            get { return calculate; }
        }
        #endregion

        public string L1 { get { return calculationStack.Input.ToString(); } }
        public double L2 { get { return calculationStack.L2; } }
        public double L3 { get { return calculationStack.L3; } }
        public double L4 { get { return calculationStack.L4; } }
        public double Memory { get { return calculationStack.Memory; } }


        public CalculationMode CalculationMode
        {
            get { return calculationMode; }
            set
            {
                calculationMode = value;
            }
        }
        #endregion

        #region Private methods


        #endregion

        protected void OnPropertyChanged(string name)
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
