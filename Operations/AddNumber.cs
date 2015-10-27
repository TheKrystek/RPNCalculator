using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class AddNumber : Operation
    {
        public AddNumber(CalculationStack calculationStack)
            : base(calculationStack)
        {

            Console.WriteLine("wykonano konstruktor");
        }

        public override bool Execute()
        {
            Console.WriteLine("ExampleTimeCommand.CalculateTime()");
            return true;
        }
    }
}
