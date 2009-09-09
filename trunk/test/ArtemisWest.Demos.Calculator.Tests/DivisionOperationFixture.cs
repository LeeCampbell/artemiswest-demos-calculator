using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ArtemisWest.Demos.Calculator.Tests
{
    [TestClass]
    public sealed class DivisionOperationFixture
    {
        [TestMethod]
        public void Should_set_value_to_firstOperator_value_divided_by_second_operator_value()
        {
            //Arrange
            var lhs = MockRepository.GenerateStub<IOperation>();
            lhs.Stub(o => o.Value).Return(1.23);
            var rhs = MockRepository.GenerateStub<IOperation>();
            rhs.Stub(o => o.Value).Return(456);

            //Act
            var divide = new DivisionOperation(lhs, rhs);

            //Assert
            var expected = lhs.Value / rhs.Value;
            Assert.AreEqual(expected, divide.Value);
        }


        [TestMethod]
        public void Should_set_expression_firstOperator_expression_divided_by_second_operator_expression()
        {
            //Arrange
            var lhs = MockRepository.GenerateStub<IOperation>();
            lhs.Stub(o => o.Expression).Return("left");
            var rhs = MockRepository.GenerateStub<IOperation>();
            rhs.Stub(o => o.Expression).Return("right");

            //Act
            var divide = new DivisionOperation(lhs, rhs);

            //Assert
            var expected = "(left) / right";
            Assert.AreEqual(expected, divide.Expression);
        }
    }
}
