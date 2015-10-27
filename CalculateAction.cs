using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RPN
{
    public class CalculateAction : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        CalculationStack stack;
        CalculationMode mode;

        public CalculateAction(CalculationStack stack, CalculationMode mode) {
            this.stack = stack;
            this.mode = mode;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Wszystkie przyciski obsługiwane są za pomocą tego samego handlera, tylko z różnymi prametrami
        /// w zależności od typu i wartości paramteru wykonywane będą inne operacje
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            handleCommands(parameter);
            handleComma(parameter);
            handleNumbers(parameter);  
        }

        private void handleNumbers(object parameter){
            int number = 0;
            if (int.TryParse(parameter.ToString(), out number))
                stack.Append(number);
        }

        private void handleComma(object parameter)
        {
            if(parameter.ToString().Equals("."))
                stack.SetComma();
        }

       private void handleCommands(object parameter)
        {
            if (parameter is OperationType)
            {
                OperationType type = (OperationType)parameter;
                Operation o = OperationBuilder.Build(stack, mode, type);
                if (o != null)
                    o.Execute();
            }
        }


        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }
}
