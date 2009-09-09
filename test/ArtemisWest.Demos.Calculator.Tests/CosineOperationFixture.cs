using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ArtemisWest.Demos.Calculator.Tests
{
    [TestClass]
    public sealed class CosineOperationFixture
    {
        [TestMethod]
        public void Should_set_value_to_cosine_of_baseOperators_value()
        {
            //Arrange
            var baseOp = MockRepository.GenerateStub<IOperation>();
            baseOp.Stub(o => o.Value).Return(1.23);

            //Act
            var cos = new CosineOperation(baseOp);

            //Assert
            var expected = Math.Cos(baseOp.Value);
            Assert.AreEqual(expected, cos.Value);
        }


        [TestMethod]
        public void Should_set_expression_to_cos_of_baseOperator_expression()
        {
            //Arrange
            var baseOp = MockRepository.GenerateStub<IOperation>();
            baseOp.Stub(o => o.Expression).Return("ABC");

            //Act
            var cos = new CosineOperation(baseOp);

            //Assert
            var expected = "cos(ABC)";
            Assert.AreEqual(expected, cos.Expression);
        }
    }
}
