using System;
using ArtemisWest.Demos.CalculatorClient.Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtemisWest.Demos.CalculatorClientTest
{
    [TestClass]
    public class CalculatorViewModelFixture
    {
        [TestMethod]
        public void Should_leave_value_un_changed_when_first_operation()
        {
            //Arrange
            var expected = 123.54;
            var vm = new CalculatorViewModel();
            vm.Value = expected;
            //Act
            vm.AddCommand.Execute();
            //Assert
            Assert.AreEqual(expected, vm.Value);
        }

        [TestMethod]
        public void Should_perform_last_calculation_when_not_first_calculation()
        {
            //Arrange
            var vm = new CalculatorViewModel();
            
            //Act
            vm.Value = 1;
            vm.AddCommand.Execute();
            vm.Value = 2;
            vm.AddCommand.Execute();

            //Assert
            Assert.AreEqual(3, vm.Value);
        }

        [TestMethod]
        public void Should_override_last_operation_if_no_change_to_value_was_made()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.AddCommand.Execute();
            vm.SubtractCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(-1, vm.Value);
        }

        [TestMethod]
        public void Should_perform_trig_functions_immediately_on_value()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.AddCommand.Execute();
            vm.Value = 2;
            vm.SinCommand.Execute();
            vm.EqualsCommand.Execute();

            //Assert
            Console.WriteLine(vm.Expression);
            var expected = (1.0 + Math.Sin(2));
            Assert.AreEqual(expected, vm.Value);
        }

        [TestMethod]
        public void Should_sum_values_from_AddCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.AddCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(3, vm.Value);
        }

        [TestMethod]
        public void Should_set_expression_to_sum_of_values_from_AddCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.AddCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual("(1) + 2", vm.Expression);
        }

        [TestMethod]
        public void Should_get_difference_of_values_from_SubtractCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.SubtractCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(-1, vm.Value);
        }

        [TestMethod]
        public void Should_set_expression_to_difference_of_values_from_SubtractCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.SubtractCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual("(1) - 2", vm.Expression);
        }

        [TestMethod]
        public void Should_get_product_of_values_from_MultiplyCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.MultiplyCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(10, vm.Value);
        }

        [TestMethod]
        public void Should_set_expression_to_product_of_values_from_MultiplyCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.MultiplyCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual("(1) x 2", vm.Expression);
        }

        [TestMethod]
        public void Should_divide_values_from_DivideCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.DivideCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(2.5, vm.Value);
        }

        [TestMethod]
        public void Should_set_expression_to_dvision_of_values_from_DivideCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 1;
            vm.DivideCommand.Execute();
            vm.Value = 2;
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual("(1) / 2", vm.Expression);
        }

        [TestMethod]
        public void Should_get_sin_of_value_from_SinCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.SinCommand.Execute();
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(Math.Sin(5), vm.Value);
        }

        [TestMethod]
        public void Should_set_expression_to_sin_of_value_from_SinCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.SinCommand.Execute();
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual("sin(5)", vm.Expression);
        }

        [TestMethod]
        public void Should_get_cos_of_value_from_CosCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.CosCommand.Execute();
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(Math.Cos(5), vm.Value);
        }

        [TestMethod]
        public void Should_set_expression_to_cos_of_value_from_CosCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.CosCommand.Execute();
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual("cos(5)", vm.Expression);
        }

        [TestMethod]
        public void Should_get_tan_of_value_from_TanCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.TanCommand.Execute();
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual(Math.Tan(5), vm.Value);
        }

        [TestMethod]
        public void Should_set_expression_to_tan_of_value_from_TanCommand()
        {
            //Arrange
            var vm = new CalculatorViewModel();

            //Act
            vm.Value = 5;
            vm.TanCommand.Execute();
            vm.EqualsCommand.Execute();

            //Assert
            Assert.AreEqual("tan(5)", vm.Expression);
        }
    }
}
