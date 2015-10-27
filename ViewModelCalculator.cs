using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace RPN
{
    class ViewModelCalculator
    {

        public ViewModelCalculator()
        {
            calculationStack = new CalculationStack();
            calculate = new CalculateAction(calculationStack, calculationMode);
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


        public CalculationMode CalculationMode
        {
            get { return calculationMode; }
            set
            {
                calculationMode = value;
                Console.WriteLine("ustawiono " + value);
            }
        }
        #endregion

        #region Private methods


        #endregion
        
    }
}
