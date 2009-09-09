using System.Globalization;
namespace ArtemisWest.Demos.Calculator
{
    public sealed class NullOperation : OperationBase
    {
        public NullOperation(double value)
            : base(value, string.Format(CultureInfo.CurrentCulture, "{0}", value))
        {
        }
    }
}