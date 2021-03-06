﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class PowerNumber : Operation
    {
       public PowerNumber(CalculationStack calculationStack)
            : base(calculationStack)
        {}

       public override void Execute()
        {

            double L1 = stack.Input.Value;
            double L2 = stack.Pop();
            stack.SetInput(Math.Pow(L2,L1));
        }
    }
}
