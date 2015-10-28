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
    public class InputTests
    {
        [TestMethod()]
        public void ValueSet_SetInteger()
        {
            Input input = new Input();
            input.Value = 10;
            Assert.AreEqual(10,input.Value);
        }

        [TestMethod()]
        public void ValueSet_SetDouble()
        {
            Input input = new Input();
            input.Value = new ;
            Assert.AreEqual(3.1415, input.Value);
        }

        [TestMethod()]
        public void ValueSet_SetDoubleAndAppend()
        {
            Input input = new Input();
            input.Value = 3.1415;
            input.Add(7);
            Assert.AreEqual(3.14157, input.Value);
        }
    }
}
