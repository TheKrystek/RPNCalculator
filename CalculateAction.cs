using System;
using System.Collections.Generic;
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

        public void Execute(object parameter)
        {
            Console.WriteLine(mode + "->" + parameter);
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
