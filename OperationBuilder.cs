using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public static class OperationBuilder
    {
        public static Operation Build(CalculationStack stack, CalculationMode mode, OperationType type)
        {
            // zacznij od sprawdzania operacji ktore sa niezalezne od trybu
            switch (type)
            {
                case OperationType.C:
                        return new Erase(stack);
                case OperationType.AC:
                        return new Clear(stack);
                case OperationType.ENTER:
                        return new Enter(stack);
                case OperationType.POP:
                        return new Pop(stack);
                case OperationType.SWAP:
                        return new Swap(stack);
                case OperationType.MC:
                        return new MemoryClear(stack);
                case OperationType.MR:
                        return new MemoryRecall(stack);
                case OperationType.Mplus:
                        return new MemoryPlus(stack);
                case OperationType.Mminus:
                        return new MemoryMinus(stack);
            }




            if (mode == CalculationMode.Date) { 
                     
            }

            if (mode == CalculationMode.Time)
            { 
          
            }

            if (mode == CalculationMode.Number) {
                switch (type)
                {
                    case OperationType.SQRT:
                        return new SqrtNumber(stack);
                    case OperationType.POW:
                        return new PowerNumber(stack);
                    case OperationType.INV_X:
                        return new InvertNumber(stack);
                    case OperationType.PLUS_MINUS:
                        return new ChangeSign(stack);
                    case OperationType.PERCENT:
                        return new PercentNumber(stack);
                    case OperationType.DIV:
                        return new DivNumber(stack);
                    case OperationType.MUL:
                        return new MulNumber(stack);
                    case OperationType.SUB:
                        return new SubNumber(stack);
                    case OperationType.ADD:
                        return new AddNumber(stack);
                    default:
                        break;
                }     
            }
            return null;
        }
    }
}
