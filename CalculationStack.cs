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
            public double L2 { get { return getLevel(0); } }
            public double L3 { get { return getLevel(1); } }
            public double L4 { get { return getLevel(2); } }
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
                OnPropertyChanged();
            }

            /// <summary>
            /// Wstaw wartość bufora wejściowego na stos
            /// </summary>
            public void PushInput()
            {
                Push(input.Value);
            }

            /// <summary>
            /// Pobiera itą wartość ze stosu
            /// Domyślnie pobiera ostatni element
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            public double Get(int index = -1)
            {
                if (index == -1)
                    index = this.index;

                if (index < 0)
                    return 0;
                return stack[index];
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }

            /// <summary>
            /// Wstawia kropkę dziesiętną
            /// </summary>
            public void SetComma()
            {
                input.SetComma();
                OnPropertyChanged();
            }

            /// <summary>
            /// Usuwa ostatni element buforu tekstowego
            /// </summary>
            public void Erase()
            {
                input.Erase();
                OnPropertyChanged();
            }

            /// <summary>
            /// Czyści bufor wejściowy
            /// </summary>
            public void Clear()
            {
                input.Clear();
                OnPropertyChanged();
            }
        #endregion

        #region Metody prywatne i chronione
            private double getLevel(int p)
            {
                p = index - p;
                if (p >= 0 && p < stack.Count)
                    return stack[p];
                return 0;
            }


            protected void OnPropertyChanged(string name = "")
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
