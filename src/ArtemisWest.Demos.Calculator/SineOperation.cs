using System;
using System.Globalization;

namespace ArtemisWest.Demos.Calculator
{
    public sealed class SineOperation : OperationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SineOperation"/> class.
        /// </summary>
        /// <param name="baseOperation">The base operation.</param>
        public SineOperation(IOperation baseOperation)
            :base(
                Math.Sin(baseOperation.Value),
                string.Format(CultureInfo.CurrentCulture, "sin({0})", baseOperation.Expression)
                )
        {
        }
    }
}