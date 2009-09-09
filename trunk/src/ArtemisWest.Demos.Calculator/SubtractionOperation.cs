using System.Globalization;

namespace ArtemisWest.Demos.Calculator
{
    public sealed class SubtractionOperation : OperationBase
    {
        public SubtractionOperation(IOperation leftOperation, IOperation rightOperation)
            : base(
                leftOperation.Value - rightOperation.Value,
                string.Format(CultureInfo.CurrentCulture, "({0}) - {1}", leftOperation.Expression, rightOperation.Expression)
                )
        {
        }

        public static IOperation Create(IOperation leftOperation, IOperation rightOperation)
        {
            return new SubtractionOperation(leftOperation, rightOperation);
        }
    }
}