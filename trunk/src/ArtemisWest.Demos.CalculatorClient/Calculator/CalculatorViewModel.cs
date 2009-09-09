using System;
using ArtemisWest.Demos.Calculator;
using ArtemisWest.Demos.CalculatorClient.Controls;
using System.ComponentModel;

namespace ArtemisWest.Demos.CalculatorClient.Calculator
{
    public sealed class CalculatorViewModel : INotifyPropertyChanged
    {
        #region Field
        private double _value;
        private IOperation _currentOperation;
        private Func<IOperation, IOperation, IOperation> _defferedOperation;
        private string _expression;
        private bool _isDirty;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorViewModel"/> class.
        /// </summary>
        public CalculatorViewModel()
        {
            ResetCommand = new ActionCommand(ExecuteReset);

            AddCommand = new ActionCommand(ExecuteAdd);
            SubtractCommand = new ActionCommand(ExecuteSubtract);
            MultiplyCommand = new ActionCommand(ExecuteMultiply);
            DivideCommand = new ActionCommand(ExecuteDivide);

            SinCommand = new ActionCommand(ExecuteSin);
            CosCommand = new ActionCommand(ExecuteCos);
            TanCommand = new ActionCommand(ExecuteTan);

            EqualsCommand = new ActionCommand(EvaluateOperations);
        }

        #region Properties
        /// <summary>
        /// Gets or sets the value for the calculator.
        /// </summary>
        /// <value>The value.</value>
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                _isDirty = true;
                OnPropertyChanged("Value");
            }
        }

        /// <summary>
        /// Gets the current calculation expression.
        /// </summary>
        /// <value>The expression.</value>
        public string Expression
        {
            get { return _expression; }
            private set
            {
                _expression = value;
                OnPropertyChanged("Expression");
            }
        }

        public ActionCommand ResetCommand { get; private set; }
        public ActionCommand EqualsCommand { get; private set; }

        public ActionCommand AddCommand { get; private set; }
        public ActionCommand SubtractCommand { get; private set; }
        public ActionCommand MultiplyCommand { get; private set; }
        public ActionCommand DivideCommand { get; private set; }

        public ActionCommand SinCommand { get; private set; }
        public ActionCommand CosCommand { get; private set; }
        public ActionCommand TanCommand { get; private set; }
        #endregion

        #region Command execute methods
        private void ExecuteReset()
        {
            Value = 0;
            Expression = string.Empty;
            _currentOperation = null;
            _defferedOperation = null;
        }

        private void ExecuteAdd()
        {
            ApplyDefferedOperator(AdditionOperation.Create);
        }
        private void ExecuteSubtract()
        {
            ApplyDefferedOperator(SubtractionOperation.Create);
        }
        private void ExecuteMultiply()
        {
            ApplyDefferedOperator(MultiplicationOperation.Create);
        }
        private void ExecuteDivide()
        {
            ApplyDefferedOperator(DivisionOperation.Create);
        }

        private void ExecuteSin()
        {
            ExecuteUnaryOperator(o => new SineOperation(o));
        }
        private void ExecuteCos()
        {
            ExecuteUnaryOperator(o => new CosineOperation(o));
        }
        private void ExecuteTan()
        {
            ExecuteUnaryOperator(o => new TangentOperation(o));
        }
        #endregion

        #region Private methods
        private void ApplyDefferedOperator(Func<IOperation, IOperation, IOperation> factory)
        {
            EnsureCurrentOperation();
            if (_isDirty)
                EvaluateOperations();
            _defferedOperation = (lhs, rhs) => factory(lhs, rhs);
        }

        private void ExecuteUnaryOperator(Func<IOperation, IOperation> factory)
        {
            EnsureCurrentOperation();
            if (_defferedOperation != null)
            {
                var existingDefferal = _defferedOperation;
                _defferedOperation = (lhs, rhs) => existingDefferal(lhs, factory(rhs));
            }
            else
            {
                SetCurrentOperation(factory(_currentOperation));
            }
        }

        private void EvaluateOperations()
        {
            if (_defferedOperation != null)
            {
                SetCurrentOperation(_defferedOperation(_currentOperation, new NullOperation(Value)));
            }
            _isDirty = false;
        }

        private void EnsureCurrentOperation()
        {
            if (_currentOperation == null)
                _currentOperation = new NullOperation(Value);
        }

        private void SetCurrentOperation(IOperation operation)
        {
            _currentOperation = operation;
            Value = _currentOperation.Value;
            Expression = _currentOperation.Expression;
        }

        #endregion
       
        #region INotifyPropertyChanged implemtation
        public event PropertyChangedEventHandler PropertyChanged;

        //TODO: Replace with AOP.
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
