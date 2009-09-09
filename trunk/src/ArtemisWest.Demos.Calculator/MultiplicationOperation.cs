using System.Globalization;

namespace ArtemisWest.Demos.Calculator
{
    public sealed class MultiplicationOperation : OperationBase
    {
        public MultiplicationOperation(IOperation leftOperation, IOperation rightOperation)
            : base(
                leftOperation.Value * rightOperation.Value,
                string.Format(CultureInfo.CurrentCulture, "({0}) x {1}", leftOperation.Expression, rightOperation.Expression)
                )
        {
        }

        public static IOperation Create(IOperation leftOperation, IOperation rightOperation)
        {
            return new MultiplicationOperation(leftOperation, rightOperation);
        }
    }
}