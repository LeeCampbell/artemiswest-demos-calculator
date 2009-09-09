using System;
using System.Windows.Input;

namespace ArtemisWest.Demos.CalculatorClient.Controls
{
    public sealed class ActionCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public ActionCommand(Action action)
            : this(action, null)
        { }

        public ActionCommand(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute ?? new Func<bool>(() => true);
        }

        public void Execute()
        {
            _action();
        }

        public bool CanExecute()
        {
            return _canExecute();
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #region Implementation of ICommand

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.
        ///                 </param>
        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.
        ///                 </param>
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}