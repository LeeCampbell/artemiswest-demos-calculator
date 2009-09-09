using System;

namespace ArtemisWest.Demos.CalculatorClient.Controls
{
    /// <summary>
    /// Provides data for the <see cref="CanExecuteEventHandler"/>.
    /// </summary>
    public sealed class CanExecuteEventArgs : EventArgs
    {
        private readonly object _parameter;
        private bool _canExecute = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CanExecuteEventArgs"/> class.
        /// </summary>
        public CanExecuteEventArgs()
        {
            _parameter = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanExecuteEventArgs"/> class.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public CanExecuteEventArgs(object parameter)
        {
            _parameter = parameter;
        }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>The parameter.</value>
        public object Parameter
        {
            get { return _parameter; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can execute.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can execute; otherwise, <c>false</c>.
        /// </value>
        public bool CanExecute
        {
            get { return _canExecute; }
            set { _canExecute = value; }
        }
    }
}
