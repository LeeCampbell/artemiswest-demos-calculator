using System;
using System.Globalization;

namespace ArtemisWest.Demos.Calculator
{
    public sealed class TangentOperation : OperationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TangentOperation"/> class.
        /// </summary>
        /// <param name="baseOperation">The base operation.</param>
        public TangentOperation(IOperation baseOperation)
            : base(
                Math.Tan(baseOperation.Value),
                string.Format(CultureInfo.CurrentCulture, "tan({0})", baseOperation.Expression)
                )
        {
        }
    }
}