using System;
using System.Globalization;

namespace ArtemisWest.Demos.Calculator
{
    public sealed class CosineOperation : OperationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CosineOperation"/> class.
        /// </summary>
        /// <param name="baseOperation">The base operation.</param>
        public CosineOperation(IOperation baseOperation)
            : base(
                Math.Cos(baseOperation.Value),
                string.Format(CultureInfo.CurrentCulture, "cos({0})", baseOperation.Expression)
                )
        {
        }
    }
}