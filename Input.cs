using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class Input
    {
        private double value;
        private string text;
        private bool isDouble;

        public Input() {
            Clear();
        }


        public double Value
        {
            get
            {
                if (string.IsNullOrEmpty(text))
                    return 0;

                if (text[text.Length - 1] == ',')
                   Erase();
                try
                {
                    return double.Parse(text);

                }
                catch (Exception)
                {
                    return 0;
                }
            }
            set {
                this.value = value;
                this.text = this.value.ToString();
            } 
        }


        /// <summary>
        /// Dodaj cyfrę na sam koniec
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Add(int value)
        {
            if (text == "0")
                text = "";
            text += value.ToString();
        }

        /// <summary>
        /// Skasuj wartość na ostatnim miejscu
        /// </summary>
        public void Erase()
        {
            if (string.IsNullOrEmpty(text))
                return;

            if (text[text.Length - 1] == ',')
                isDouble = false;

            text = text.Substring(0,text.Length - 1);
        }

        /// <summary>
        /// Wyczyść wartość bufora wejściowego 
        /// </summary>
        public void Clear()
        {
            value = 0;
            text = "0";
            isDouble = false;
        }

        /// <summary>
        /// Postaw przecinek
        /// </summary>
        /// <returns></returns>
        public bool SetComma()
        {
            if (isDouble)
                return false;
            text += ",";
            return isDouble = true;
        }

        public override string ToString()
        {
            return text;
        }

    }
}
