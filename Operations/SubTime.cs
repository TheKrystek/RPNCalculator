using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class SubTime: Operation
    {
       public SubTime(CalculationStack calculationStack)
            : base(calculationStack)
        {}

       public override void Execute()
        {
            double B = stack.Input.Value;
            double A = stack.Pop();

            DateTime? date = NumberToDateTimeConverter.NumberToTime(A);
            if (date == null)
            {
                stack.Message = "Not a valid time format";
                return;
            }

            int h = NumberToDateTimeConverter.getNumberOfHours(B);
            int m = NumberToDateTimeConverter.getNumberOfMinutes(B);
            int s = NumberToDateTimeConverter.getNumberOfSeconds(B);

            DateTime newDate = date.Value.AddHours(-h).AddMinutes(-m).AddSeconds(-s);

            stack.SetInput(NumberToDateTimeConverter.NumberFromDate(newDate));
            stack.Message = String.Format("Date: {0:HH:mm:ss}", newDate);

            Console.WriteLine("{0:HH:mm:ss} minus {1} hours {2} minutes and {3} seconds equals {4:HH:mm:ss}", date, h,m,s, newDate);
        }
    }
}
