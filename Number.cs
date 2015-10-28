using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class Number
    {
        double value;
        int precision;
        private bool hasComma = false;

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public bool HasComma {
            get { return hasComma; }
            set { hasComma = value; }
        }

        public int Precision
        {
            get { return precision; }
            set { changePricision(value); }
        }


        public Number(double value = 0, int precision = 0, bool hasComma = false)
        {
            this.value = value;
            this.precision = precision;
            this.hasComma = hasComma;
        }

        private void changePricision(int newPrecision) { 
            int diff = newPrecision - precision;

            // Jezli precyzja jest taka sama to nic nie zmieniaj
            if (diff == 0)
                return;

            value *= (int)Math.Pow(10,diff);
            precision = newPrecision;
        }

        //TODO: poprawić działanie bo przy mnożeniu i dzieleniu nie działa
        private static int equalizePrecision(Number p1, Number p2) {
            int max = Math.Max(p1.Precision, p2.Precision);
            p1.Precision = max;
            p2.Precision = max;
            return max;
        }

        private static bool equalizeComma(Number p1, Number p2)
        {
            bool comma = p1.HasComma || p2.HasComma;
            p1.HasComma = comma;
            p2.HasComma = comma;
            return comma;
        }



        #region Operatory
        public static Number operator +(Number p1, Number p2)
        {
            int max = equalizePrecision(p1,p2);
            bool comma = equalizeComma(p1,p2);
            return new Number(p1.Value + p2.Value, max, comma);
        }

        public static Number operator -(Number p1, Number p2)
        {
            int max = equalizePrecision(p1, p2);
            bool comma = equalizeComma(p1, p2);
            return new Number(p1.Value - p2.Value, max, comma);
        }

        public static Number operator *(Number p1, Number p2)
        {
            int max = equalizePrecision(p1, p2);
            bool comma = equalizeComma(p1, p2);
            return new Number(p1.Value * p2.Value, max, comma);
        }

        public static Number operator /(Number p1, Number p2)
        {
            int max = equalizePrecision(p1, p2);
            bool comma = equalizeComma(p1, p2);
            return new Number(p1.Value / p2.Value, max,comma);
        }


        public static bool operator <(Number p1, Number p2)
        {
            equalizePrecision(p1, p2);
            bool comma = equalizeComma(p1, p2);

            return p1.Value < p2.Value;
        }


        public static bool operator <=(Number p1, Number p2)
        {
            equalizePrecision(p1, p2);
            return p1.Value <= p2.Value;
        }

        public static bool operator >(Number p1, Number p2)
        {
            equalizePrecision(p1, p2);
            return p1.Value > p2.Value;
        }


        public static bool operator >=(Number p1, Number p2)
        {
            equalizePrecision(p1, p2);
            return p1.Value >= p2.Value;
        }


        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Number p = obj as Number;
            if ((Object)p == null)
                return false;

            return (Value == p.Value) && (Precision == p.Precision);
        }

        public bool Equals(Number p)
        {
            if ((object)p == null)
                return false;
            return (Value == p.Value) && (Precision == p.Precision);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Precision.GetHashCode();
        }


        public override string ToString()
        {
            if (precision > 0 && hasComma)
                return string.Format(string.Format("{{0:F{0}}}", precision), Value / Math.Pow(10, precision));
            if (hasComma)
                return string.Format("{0},", Value);
            return Value.ToString();
        }

        #endregion


      
    }
}
