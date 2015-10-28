using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{

    /// <summary>
    /// Klasa obsługująca stos kalkulatora
    /// Implementuje interfejs INotifyPropertyChanged w celu powiadamiania GUI o zmianach
    /// </summary>
    public class CalculationStack : INotifyPropertyChanged
    {

        #region Pola
        private List<double> stack;
        private Input input;
        private bool pushed = false;
        private double memory,prevMemory = 0;


        public double Memory
        {
            get { return memory; }
            set
            {
                prevMemory = memory;
                memory = value;
                NotifyPropertyChanged();
            }
        }


        #endregion

        #region Properties
        /// <summary>
        /// Wskaznik na ostatni element stosu
        /// </summary>
        private int index
        {
            get
            {
                if (stack != null)
                    return stack.Count - 1;
                return 0;
            }
        }

        public bool Pushed
        {
            get { return pushed; }
            set { pushed = value; }
        }

        /// <summary>
        /// Udostępnia bufor do którego wczytywane są dane z klawiatury
        /// </summary>
        public Input Input
        {
            get { return input; }
        }

        /// <summary>
        /// Zwraca 3 pierwsze poziomy ze stosu
        /// </summary>
        public double L2 { get { return Get(0); } }
        public double L3 { get { return Get(1); } }
        public double L4 { get { return Get(2); } }
        #endregion

        #region Metody publiczne
        /// <summary>
        /// Domyślny konstruktor
        /// </summary>
        public CalculationStack()
        {
            stack = new List<double>();
            input = new Input();
        }

        /// <summary>
        /// Wstaw podaną wartość na stos
        /// </summary>
        /// <param name="value"></param>
        public void Push(double value)
        {
            stack.Add(value);
            pushed = true;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// Wstaw wartość bufora wejściowego na stos
        /// </summary>
        public void PushInput()
        {
            Push(input.Value);
        }

        /// <summary>
        /// Pobiera itą wartość ze stosu licząc od końca listy
        /// Domyślnie pobiera ostatni element
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double Get(int index = -1)
        {
            if (index < 0)
                index = this.index;
            else
                index = this.index - index;

            if (index >= 0 && index < stack.Count)
                return stack[index];
            return 0;
        }

        /// <summary>
        /// Ustawia wartość itej pozycji na stosie, jeżeli element stosu nie istnieje do dodaj
        /// Domyślnie ustawia ostatni element
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public void Set(double value, int index = -1)
        {
            if (index < 0)
                index = this.index;
            else
                index = this.index - index;

            if (index >= 0 && index < stack.Count)
                stack[index] = value;

            if (index == -1)
                Push(value);

            NotifyPropertyChanged();
        }


        /// <summary>
        /// Ściąga wartość ze stosu i wstawia do buforu wejściowego
        /// </summary>
        /// <returns>Aktualną wartość buforu wejściowego</returns>
        public double Pop()
        {
            if (index < 0)
                return 0;
            input.Value = stack[index];
            stack.RemoveAt(index);
            NotifyPropertyChanged();
            return input.Value;
        }

        /// <summary>
        /// Dodaje cyfrę na końcu buforu wejściowego
        /// </summary>
        /// <param name="p"></param>
        public void Append(int p)
        {
            if (pushed)
                input.Clear();

            input.Add(p);
            pushed = false;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// Wstawia kropkę dziesiętną
        /// </summary>
        public void SetComma()
        {
            input.SetComma();
            NotifyPropertyChanged();
        }

        /// <summary>
        /// Usuwa ostatni element buforu tekstowego
        /// </summary>
        public void Erase()
        {
            input.Erase();
            NotifyPropertyChanged();
        }

        /// <summary>
        /// Czyści bufor wejściowy
        /// </summary>
        public void Clear()
        {
            input.Clear();
            NotifyPropertyChanged();
        }

        public void RefreshMemory() {
            NotifyPropertyChanged();
        }

        public void SetInput(double value)
        {
            input.Value = value;
            NotifyPropertyChanged();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stack:");
            foreach (var item in stack)
                sb.AppendLine(item.ToString());
            return sb.ToString();
        }
        #endregion

        #region Metody prywatne i chronione

        protected void NotifyPropertyChanged(string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
