﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class Enter : Operation
    {
       public Enter(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

       public override void Execute()
        {
            stack.PushInput();
        }
    }
}
