using System;
using System.Globalization;
using System.Windows.Controls;

namespace ArtemisWest.Demos.CalculatorClient.Controls
{
    public sealed class DoubleValidationRule : ValidationRule
    {
        #region Overrides of ValidationRule

        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Windows.Controls.ValidationResult"/> object.
        /// </returns>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = value == null ? string.Empty : value.ToString();
            double convertedvalue;
            if (Double.TryParse(s, out convertedvalue))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Value is not a valid number");
        }

        #endregion
    }
}
