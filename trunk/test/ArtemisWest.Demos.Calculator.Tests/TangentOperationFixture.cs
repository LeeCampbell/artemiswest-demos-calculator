using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ArtemisWest.Demos.Calculator.Tests
{
    [TestClass]
    public sealed class TangentOperationFixture
    {
        [TestMethod]
        public void Should_set_value_to_tangent_of_baseOperators_value()
        {
            //Arrange
            var baseOp = MockRepository.GenerateStub<IOperation>();
            baseOp.Stub(o => o.Value).Return(1.23);

            //Act
            var tan = new TangentOperation(baseOp);

            //Assert
            var expected = Math.Tan(baseOp.Value);
            Assert.AreEqual(expected, tan.Value);
        }


        [TestMethod]
        public void Should_set_expression_to_tan_of_baseOperator_expression()
        {
            //Arrange
            var baseOp = MockRepository.GenerateStub<IOperation>();
            baseOp.Stub(o => o.Expression).Return("ABC");

            //Act
            var tan = new TangentOperation(baseOp);

            //Assert
            var expected = "tan(ABC)";
            Assert.AreEqual(expected, tan.Expression);
        }
    }
}
