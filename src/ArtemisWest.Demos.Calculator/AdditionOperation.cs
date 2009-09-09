using System.Globalization;

namespace ArtemisWest.Demos.Calculator
{
    public sealed class AdditionOperation : OperationBase
    {
        public AdditionOperation(IOperation leftOperation, IOperation rightOperation)
            : base(
                leftOperation.Value + rightOperation.Value,
                string.Format(CultureInfo.CurrentCulture, "({0}) + {1}", leftOperation.Expression, rightOperation.Expression)
                )
        {
        }

        public static AdditionOperation Create(IOperation leftOperation, IOperation rightOperation)
        {
            return new AdditionOperation(leftOperation, rightOperation);
        }
    }
}