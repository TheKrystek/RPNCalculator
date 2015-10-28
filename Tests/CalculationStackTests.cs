using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace RPN.Tests
{
    [TestClass()]
    public class CalculationStackTests
    {
        [TestMethod()]
        public void Append_SimpleIntegerValue()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(1);
            Assert.AreEqual(1, stack.Input.Value);
        }

        [TestMethod()]
        public void Append_MoreComplexIntegerValue()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(1);
            stack.Append(2);
            stack.Append(3);
            Assert.AreEqual(123, stack.Input.Value);
        }

        [TestMethod()]
        public void Append_LeadingZeroesIntegerValue()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(0);
            stack.Append(0);
            stack.Append(1);
            stack.Append(2);
            stack.Append(3);
            Assert.AreEqual(123, stack.Input.Value);
        }

        [TestMethod()]
        public void Append_DoubleValue()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(1);
            stack.Append(2);
            stack.Append(3);
            stack.SetComma();
            stack.Append(0);
            stack.Append(5);
            stack.Append(1);
            Assert.AreEqual(123.051, stack.Input.Value);
        }


        [TestMethod()]
        public void Erase_IntegerValue()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(1);
            stack.Append(2);
            stack.Erase();
            Assert.AreEqual(1, stack.Input.Value);
        }


        [TestMethod()]
        public void Erase_MoreComplexIntegerValue()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(1);
            stack.Append(2);
            stack.Append(2);
            stack.Erase();
            Assert.AreEqual(12, stack.Input.Value);
        }


        [TestMethod()]
        public void Erase_ToZero()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(1);
            stack.Append(2);
            stack.Append(2);
            stack.Erase();
            stack.Erase();
            stack.Erase();
            stack.Erase();
            Assert.AreEqual(0, stack.Input.Value);
        }


        [TestMethod()]
        public void Erase_DoubleValue()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(1);
            stack.Append(2);
            stack.Append(3);
            stack.SetComma();
            stack.Append(0);
            stack.Append(5);
            stack.Append(1);
            stack.Erase();
            Assert.AreEqual(123.05, stack.Input.Value);
        }

        [TestMethod()]
        public void Erase_TillZeroAndAppendAgain()
        {
            CalculationStack stack = new CalculationStack();
            stack.Append(3);
            stack.SetComma();
            stack.Append(0);
            stack.Append(4);
            stack.Append(2);
            stack.Append(1); 
            stack.Erase();
            stack.Erase();
            stack.Erase();
            stack.Erase();
            stack.Append(1);
            stack.Append(4);
            stack.Append(1);
            stack.Append(5);

            Assert.AreEqual(3.1415, stack.Input.Value);
        }


    }
}
