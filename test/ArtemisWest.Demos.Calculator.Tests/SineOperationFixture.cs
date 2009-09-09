using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ArtemisWest.Demos.Calculator.Tests
{
    [TestClass]
    public sealed class SineOperationFixture
    {
        [TestMethod]
        public void Should_set_value_to_sine_of_baseOperators_value()
        {
            //Arrange
            var baseOp = MockRepository.GenerateStub<IOperation>();
            baseOp.Stub(o => o.Value).Return(1.23);

            //Act
            var sin = new SineOperation(baseOp);
            
            //Assert
            var expected = Math.Sin(baseOp.Value);
            Assert.AreEqual(expected, sin.Value);
        }


        [TestMethod]
        public void Should_set_expression_to_sin_of_baseOperator_expression()
        {
            //Arrange
            var baseOp = MockRepository.GenerateStub<IOperation>();
            baseOp.Stub(o => o.Expression).Return("ABC");

            //Act
            var sin = new SineOperation(baseOp);

            //Assert
            var expected = "sin(ABC)";
            Assert.AreEqual(expected, sin.Expression);
        }
    }
}
