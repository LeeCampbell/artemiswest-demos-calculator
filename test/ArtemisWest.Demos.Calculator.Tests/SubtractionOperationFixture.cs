using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ArtemisWest.Demos.Calculator.Tests
{
    [TestClass]
    public sealed class SubtractionOperationFixture
    {
        [TestMethod]
        public void Should_set_value_to_firstOperator_value_minus_second_operator_value()
        {
            //Arrange
            var lhs = MockRepository.GenerateStub<IOperation>();
            lhs.Stub(o => o.Value).Return(1.23);
            var rhs = MockRepository.GenerateStub<IOperation>();
            rhs.Stub(o => o.Value).Return(456);

            //Act
            var minus = new SubtractionOperation(lhs, rhs);

            //Assert
            var expected = lhs.Value - rhs.Value;
            Assert.AreEqual(expected, minus.Value);
        }


        [TestMethod]
        public void Should_set_expression_firstOperator_expression_minus_second_operator_expression()
        {
            //Arrange
            var lhs = MockRepository.GenerateStub<IOperation>();
            lhs.Stub(o => o.Expression).Return("left");
            var rhs = MockRepository.GenerateStub<IOperation>();
            rhs.Stub(o => o.Expression).Return("right");

            //Act
            var minus = new SubtractionOperation(lhs, rhs);

            //Assert
            var expected = "(left) - right";
            Assert.AreEqual(expected, minus.Expression);
        }
    }
}
