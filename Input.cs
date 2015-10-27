using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    class Input
    {
        private long input;
        private int digitsAfterZero;
        private bool hasComma;

        public Input() {
            Clear();
        }

        public double Value
        {
            get
            {
                if (!hasComma)
                    return (double)input;
                return (double)(input / Math.Pow(10, digitsAfterZero));
            }
        }
    
        /// <summary>
        /// Dodaj cyfrę na sam koniec
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Add(int value)
        {
            if (hasComma)
                digitsAfterZero++;
            input = input * 10 + value;
            return input;
        }

        /// <summary>
        /// Skasuj wartość na ostatnim miejscu
        /// </summary>
        public void Erase()
        {
            if (hasComma && digitsAfterZero == 0)
            {
                hasComma = false;
                return;
            }
            if (digitsAfterZero > 0)
                digitsAfterZero--;
            input /= 10;
        }

        /// <summary>
        /// Wyczyść wartość bufora wejściowego 
        /// </summary>
        public void Clear()
        {
            input = 0;
            hasComma = false;
            digitsAfterZero = 0;
        }


        /// <summary>
        /// Postaw przecinek
        /// </summary>
        /// <returns></returns>
        public bool SetComma()
        {
            if (hasComma)
                return false;
            return hasComma = true;
        }

    }
}
