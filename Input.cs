using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class Input
    {
        private Number input;

        public Input() {
            Clear();
        }


        public Number Value
        {
            get
            {
                return input;
            }
            set {
                input = value;
            } 
        }


        /// <summary>
        /// Dodaj cyfrę na sam koniec
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Number Add(int value)
        {
            if (input.HasComma)
                input.Precision++;
            else
                input.Value *= 10;

            input.Value += value;
            return input;
        }

        /// <summary>
        /// Skasuj wartość na ostatnim miejscu
        /// </summary>
        public void Erase()
        {
            if (input.HasComma && input.Precision == 0)
            {
                input.HasComma = false;
                return;
            }
            if (input.Precision > 0)
                input.Precision--;
            input.Value /= 10;
        }

        /// <summary>
        /// Wyczyść wartość bufora wejściowego 
        /// </summary>
        public void Clear()
        {
            input = new Number();
            input.HasComma = false;
        }

        /// <summary>
        /// Postaw przecinek
        /// </summary>
        /// <returns></returns>
        public bool SetComma()
        {
            Console.WriteLine(input.Precision);
            if (input.HasComma)
                return false;
            return input.HasComma = true;
        }

        public override string ToString()
        {
            return input.ToString();
        }

    }
}
