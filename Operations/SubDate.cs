using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class SubDate: Operation
    {
       public SubDate(CalculationStack calculationStack)
            : base(calculationStack)
        {}

       public override void Execute()
        {
            double B = stack.Input.Value;
            double A = stack.Pop();

            DateTime? date = NumberToDateTimeConverter.NumberToDate(A);
            if (date == null)
            {
                stack.Message = "Not a valid date format";
                return;
            }

            int d = NumberToDateTimeConverter.getNumberOfDays(B);
            int m = NumberToDateTimeConverter.getNumberOfMonths(B);
            int y = NumberToDateTimeConverter.getNumberOfYears(B);

            DateTime newDate = date.Value.AddDays(-d).AddMonths(-m).AddYears(-y);

            stack.SetInput(NumberToDateTimeConverter.NumberFromDate(newDate));
            stack.Message = String.Format("Date: {0:dd.MM.yyyy}", newDate);

            Console.WriteLine("{0:dd.MM.yyyy} minus {1} days {2} months and {3} years equals {4:dd.MM.yyyy}", date, d, m, y, newDate);
        }
    }
}
