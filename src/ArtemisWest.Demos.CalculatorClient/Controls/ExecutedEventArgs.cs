using System;

namespace ArtemisWest.Demos.CalculatorClient.Controls
{
    public sealed class ExecutedEventArgs : EventArgs
    {
        private readonly object _parameter;

        public ExecutedEventArgs()
        {
            _parameter = null;
        }

        public ExecutedEventArgs(object parameter)
        {
            _parameter = parameter;
        }

        public object Parameter
        {
            get { return _parameter; }
        }
    }
}
