using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPN;

namespace Tests
{
    [TestClass]
    public class OperationBuilderTests
    {
        Operation operation;

        [TestMethod]
        public void AddNumber_NotNull()
        {
            operation = OperationBuilder.Build(new CalculationStack(), CalculationMode.Number, OperationType.ADD);
            AddNumber a = operation as AddNumber;
            a.Execute();
            Assert.IsNotNull(a);
        }
    }
}
