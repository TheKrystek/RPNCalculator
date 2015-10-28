﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
   public class Erase : Operation
    {
       public Erase(CalculationStack calculationStack)
            : base(calculationStack)
        {
        }

        public override bool Execute()
        {
            stack.Erase();
            return true;
        }
    }
}