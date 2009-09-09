using System;
using Core;
using Core.Factory;
using Core.UIItems;
using Core.UIItems.WindowItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArtemisWest.Demos.CalculatorClientGUITest
{
    [TestClass]
    public class CalculatorFixture
    {
        private Application _app;
        private Window _window;
        private TextBox _valueText;
        private TextBox _expressionText;
        private Button _equalsButton;

        [TestInitialize]
        public void Setup()
        {
            string appPath = @"..\..\..\..\src\ArtemisWest.Demos.CalculatorClient\bin\Debug\ArtemisWest.Demos.CalculatorClient.exe";
            _app = Application.Launch(appPath);
            _window = _app.GetWindow("Calculator", InitializeOption.NoCache);

            _valueText = _window.Get<TextBox>("ValueText");
            _expressionText = _window.Get<TextBox>("ExpressionText");
            _equalsButton = _window.Get<Button>("EqualsButton");
        }

        [TestMethod]
        public void Should_set_value_to_sum_when_AddButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var addButton = _window.Get<Button>("AddButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            addButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _valueText.Text;
            var expected = (firstValue + secondValue).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_expression_to_sum_when_AddButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var addButton = _window.Get<Button>("AddButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            addButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _expressionText.Text;
            var expected = string.Format("({0}) + {1}", firstValue, secondValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_value_to_difference_when_SubtractButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var subtractButton = _window.Get<Button>("SubtractButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            subtractButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _valueText.Text;
            var expected = (firstValue - secondValue).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_expression_to_difference_when_SubtractButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var subtractButton = _window.Get<Button>("SubtractButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            subtractButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _expressionText.Text;
            var expected = string.Format("({0}) - {1}", firstValue, secondValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_value_to_product_when_MultiplyButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var multiplyButton = _window.Get<Button>("MultiplyButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            multiplyButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _valueText.Text;
            var expected = (firstValue * secondValue).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_expression_to_product_when_MultiplyButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var multiplyButton = _window.Get<Button>("MultiplyButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            multiplyButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _expressionText.Text;
            var expected = string.Format("({0}) x {1}", firstValue, secondValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_value_to_quotient_when_DivideButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var divideButton = _window.Get<Button>("DivideButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            divideButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _valueText.Text;
            var expected = (firstValue / secondValue).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_expression_to_quotient_when_DivideButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var divideButton = _window.Get<Button>("DivideButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            divideButton.Click();
            _valueText.BulkText = secondValue.ToString();
            _equalsButton.Click();

            //Assert
            var actual = _expressionText.Text;
            var expected = string.Format("({0}) / {1}", firstValue, secondValue);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_value_to_sin_when_SinButton_is_used()
        {
            //Arrange
            var value = 15.5;
            var sinButton = _window.Get<Button>("SinButton");

            //Act
            _valueText.BulkText = value.ToString();
            sinButton.Click();
            _equalsButton.Click();

            //Assert
            var actual = _valueText.Text;
            var expected = Math.Sin(value).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_expression_to_sin_when_SinButton_is_used()
        {
            //Arrange
            var value = 15.5;
            var sinButton = _window.Get<Button>("SinButton");

            //Act
            _valueText.BulkText = value.ToString();
            sinButton.Click();
            _equalsButton.Click();

            //Assert
            var actual = _expressionText.Text;
            var expected = string.Format("sin({0})", value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_value_to_cos_when_CosButton_is_used()
        {
            //Arrange
            var value = 15.5;
            var cosButton = _window.Get<Button>("CosButton");

            //Act
            _valueText.BulkText = value.ToString();
            cosButton.Click();
            _equalsButton.Click();

            //Assert
            var actual = _valueText.Text;
            var expected = Math.Cos(value).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_expression_to_cos_when_CosButton_is_used()
        {
            //Arrange
            var value = 15.5;
            var cosButton = _window.Get<Button>("CosButton");

            //Act
            _valueText.BulkText = value.ToString();
            cosButton.Click();
            _equalsButton.Click();

            //Assert
            var actual = _expressionText.Text;
            var expected = string.Format("cos({0})", value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_value_to_tan_when_TanButton_is_used()
        {
            //Arrange
            var value = 15.5;
            var tanButton = _window.Get<Button>("TanButton");

            //Act
            _valueText.BulkText = value.ToString();
            tanButton.Click();
            _equalsButton.Click();

            //Assert
            var actual = _valueText.Text;
            var expected = Math.Tan(value).ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_expression_to_Tan_when_TanButton_is_used()
        {
            //Arrange
            var value = 15.5;
            var tanButton = _window.Get<Button>("TanButton");

            //Act
            _valueText.BulkText = value.ToString();
            tanButton.Click();
            _equalsButton.Click();

            //Assert
            var actual = _expressionText.Text;
            var expected = string.Format("tan({0})", value);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_set_clear_expression_text_when_ResetButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var addButton = _window.Get<Button>("AddButton");
            var ResetButton = _window.Get<Button>("ResetButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            addButton.Click();
            _valueText.BulkText = secondValue.ToString();
            addButton.Click();
            _valueText.BulkText = firstValue.ToString();
            addButton.Click();
            _valueText.BulkText = secondValue.ToString();
            ResetButton.Click();

            //Assert
            Assert.AreEqual(string.Empty, _expressionText.Text);
        }

        [TestMethod]
        public void Should_set_value_text_to_zero_when_ResetButton_is_used()
        {
            //Arrange
            var firstValue = 15.5;
            var secondValue = 2.89;
            var addButton = _window.Get<Button>("AddButton");
            var ResetButton = _window.Get<Button>("ResetButton");

            //Act
            _valueText.BulkText = firstValue.ToString();
            addButton.Click();
            _valueText.BulkText = secondValue.ToString();
            addButton.Click();
            _valueText.BulkText = firstValue.ToString();
            addButton.Click();
            _valueText.BulkText = secondValue.ToString();
            ResetButton.Click();

            //Assert
            var expected = "0";
            Assert.AreEqual(expected, _valueText.Text);
        }

        [TestCleanup]
        public void TearDown()
        {
            _window.Dispose();
            _app.Dispose();
        }
    }
}
