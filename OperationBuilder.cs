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
            }




            if (mode == CalculationMode.Date) { 
                     
            }

            if (mode == CalculationMode.Time)
            { 
          
            }

            if (mode == CalculationMode.Number) {
                switch (type)
                {
                    case OperationType.MC:
                        break;
                    case OperationType.MR:
                        break;
                    case OperationType.Mminus:
                        break;
                    case OperationType.Mplus:
                        break;
                    case OperationType.SQRT:
                        break;
                    case OperationType.POW:
                        break;
                    case OperationType.AC:
                        break;
                    case OperationType.POP:
                        break;
                    case OperationType.INV_X:
                        break;
                    case OperationType.SWAP:
                        break;
                    case OperationType.PLUS_MINUS:
                        return new ChangeSign(stack);
                    case OperationType.PERCENT:
                        break;
                    case OperationType.DIV:
                        return new DivNumber(stack);
                        break;
                    case OperationType.MUL:
                        return new MulNumber(stack);
                        break;
                    case OperationType.SUB:
                        return new SubNumber(stack);
                    case OperationType.ADD:
                        return new AddNumber(stack);
                    case OperationType.ENTER:
                        break;
                    default:
                        break;
                }     
            }
            return null;
        }
    }
}
