using System.Globalization;

namespace ArtemisWest.Demos.Calculator
{
    public sealed class DivisionOperation : OperationBase
    {
        public DivisionOperation(IOperation leftOperation, IOperation rightOperation)
            : base(
                leftOperation.Value / rightOperation.Value,
                string.Format(CultureInfo.CurrentCulture, "({0}) / {1}", leftOperation.Expression, rightOperation.Expression)
                )
        {
        }

        public static IOperation Create(IOperation leftOperation, IOperation rightOperation)
        {
            return new DivisionOperation(leftOperation, rightOperation);
        }
    }
}