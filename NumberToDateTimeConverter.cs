using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{

    // Format daty w liczbie to dd.mmyyyy np 18.02.1992 -> 18.021992
    public static class NumberToDateTimeConverter
    {
        #region Data

        public static DateTime? NumberToDate(double input)
        {
            int days = getNumberOfDays(input);
            int months = getNumberOfMonths(input);
            int years = getNumberOfYears(input);

            try 
	        {
                return new DateTime(years,months,days);
	        }
	        catch (Exception)
	        {
                return null;
	        }
        }


        /// <summary>
        /// Pobierz liczbe dni
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int getNumberOfDays(double input)
        {
            return (int)input;
        }

        /// <summary>
        /// Pobierz liczbe miesiecy
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int getNumberOfMonths(double input)
        {
            input -= getNumberOfDays(input);
            return (int)(input * 100);
        }

        /// <summary>
        /// Pobierz liczbe lat
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int getNumberOfYears(double input)
        {
            double result = input - getNumberOfDays(input);
            result *= 100;
            result -= getNumberOfMonths(input);
            return (int)(result * 10000);
        }


        public static double NumberFromDate(DateTime date)
        {
            int months = date.Month;
            int years = date.Year;
            double result = date.Day;
            result *= 100;
            result += months;
            result *= 10000;
            result += years;
            return result / 1000000;
        }

        #endregion

        #region Time
        public static DateTime? NumberToTime(double input)
        {
            int hours = getNumberOfHours(input);
            int minutes = getNumberOfMinutes(input);
            int seconds = getNumberOfSeconds(input);

            try
            {
                return new DateTime(1970,1,1,hours,minutes,seconds);
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Pobierz liczbe godzin
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int getNumberOfHours(double input)
        {
            return (int)input;
        }

        /// <summary>
        /// Pobierz liczbe miesiecy
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int getNumberOfMinutes(double input)
        {
            input -= getNumberOfHours(input);
            return (int)(input * 100);
        }

        /// <summary>
        /// Pobierz liczbe lat
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int getNumberOfSeconds(double input)
        {
            double result = input - getNumberOfHours(input);
            result *= 100;
            result -= getNumberOfMinutes(input);
            return (int)(result * 100);
        }


        public static double NumberFromTime(DateTime date)
        {
            int minutes = date.Minute;
            int seconds = date.Second;
            double result = date.Hour;
            result *= 100;
            result += minutes;
            result *= 100;
            result += seconds;
            return result / 10000;
        }
        #endregion
    }
}
