﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class ChangeSign : Operation
    {
       public ChangeSign(CalculationStack calculationStack)
            : base(calculationStack)
        {}

       public override void Execute()
        {
            stack.Input.Value *= -1;
            stack.SetInput(stack.Input.Value);
        }
    }
}
