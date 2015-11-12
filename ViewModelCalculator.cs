using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            createCalculateCommand();
            calculationStack.PropertyChanged += StackChanged;
        }

        private void createCalculateCommand()
        {
            calculate = new CalculateAction(calculationStack, CalculationMode);
        }

        private void StackChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }


        #region Fields
        private CalculationStack calculationStack;
        private CalculationMode calculationMode = CalculationMode.Number;
        private CalculateAction calculate;
        private ICommand changeMode;

        #endregion

        #region Properties
        #region Commands
        public ICommand Calculate
        {
            get { return calculate; }
        }

        public ICommand ChangeModeNext
        {
            get
            {
                return new SimpleAction(() => ChangeModeAction(1), true);
            }
        }
        public ICommand ChangeModePrev
        {
            get
            {
                return new SimpleAction(() => ChangeModeAction(-1), true);
            }
        }

        public ICommand ShowAboutDialog{
            get {return new SimpleAction(() => ShowDialog(), true);}
        }

        private void ChangeModeAction(int direction)
        {
            if (this.CalculationMode == CalculationMode.Number)
            {
                this.CalculationMode = (direction > 0 ? CalculationMode.Date : CalculationMode.Time);
                return;
            }

            if (this.CalculationMode == CalculationMode.Date)
            {
                this.CalculationMode = (direction > 0 ? CalculationMode.Time : CalculationMode.Number);
                return;
            }

            if (this.CalculationMode == CalculationMode.Time)
            {
                this.CalculationMode = (direction > 0 ? CalculationMode.Number : CalculationMode.Date);
                return;
            }
        }

        #endregion

        public string L1 { get { return calculationStack.Input.ToString(); } }
        public double L2 { get { return calculationStack.L2; } }
        public double L3 { get { return calculationStack.L3; } }
        public double L4 { get { return calculationStack.L4; } }
        public double Memory { get { return calculationStack.Memory; } }

        public string Message { get { return calculationStack.Message; } }

        ObservableCollection<KeyValuePair<int, double>> list = new ObservableCollection<KeyValuePair<int, double>>();

        public ObservableCollection<KeyValuePair<int, double>> Items
        {
            get
            {
                if (calculationStack.Items.Count > 3)
                {
                    list.Clear();
                    for (int i = calculationStack.Items.Count - 4; i >=0; i--)
			        {
                        list.Add(new KeyValuePair<int, double>(calculationStack.Items.Count + 1 - i, calculationStack.Items[i]));
			        }
                    return list;
                }
                return null;
            }
        }

        public CalculationMode CalculationMode
        {
            get { return calculationMode; }
            set
            {
                calculationMode = value;
                calculationStack.Message = value.ToString();
                createCalculateCommand();
                OnPropertyChanged("CalculationMode");         
            }
        }
        #endregion

        #region Private methods
        public void ShowDialog(){
            About dialog = new About();
            dialog.Show();
        }

        #endregion

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
