using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace ArtemisWest.Demos.Calculator.Tests
{
    [TestClass]
    public sealed class AdditionOperationFixture
    {
        [TestMethod]
        public void Should_set_value_to_sum_of_base_operator_values()
        {
            //Arrange
            var lhs = MockRepository.GenerateStub<IOperation>();
            lhs.Stub(o => o.Value).Return(1.23);
            var rhs = MockRepository.GenerateStub<IOperation>();
            rhs.Stub(o => o.Value).Return(456);

            //Act
            var add = new AdditionOperation(lhs, rhs);

            //Assert
            var expected = lhs.Value + rhs.Value;
            Assert.AreEqual(expected, add.Value);
        }


        [TestMethod]
        public void Should_set_expression_to_sin_of_baseOperator_expression()
        {
            //Arrange
            var lhs = MockRepository.GenerateStub<IOperation>();
            lhs.Stub(o => o.Expression).Return("left");
            var rhs = MockRepository.GenerateStub<IOperation>();
            rhs.Stub(o => o.Expression).Return("right");

            //Act
            var add = new AdditionOperation(lhs, rhs);

            //Assert
            var expected = "(left) + right";
            Assert.AreEqual(expected, add.Expression);
        }
    }
}
