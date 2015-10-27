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
                    case OperationType.C:
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
                        break;
                    case OperationType.PERCENT:
                        break;
                    case OperationType.DIV:
                        break;
                    case OperationType.MUL:
                        break;
                    case OperationType.SUB:
                        break;
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
