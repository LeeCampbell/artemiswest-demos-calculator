namespace ArtemisWest.Demos.Calculator
{
    public abstract class OperationBase : IOperation
    {
        private readonly double _value;
        private readonly string _expression;

        protected OperationBase(double value, string expression)
        {
            _value = value;
            _expression = expression;
        }

        #region Implementation of IOperation
        public double Value
        {
            get { return _value; }
        }

        public string Expression
        {
            get { return _expression; }
        }

        #endregion
    }
}