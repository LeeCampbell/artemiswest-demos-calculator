using System;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;

namespace ArtemisWest.Demos.CalculatorClient.Controls
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecuteMethod;
        private readonly Dispatcher _dispatcher;
        private readonly Action<T> _executeMethod;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if ((executeMethod == null) && (canExecuteMethod == null))
            {
                throw new ArgumentNullException("executeMethod", "DelegateCommand delegates cannot be null");
            }
            this._executeMethod = executeMethod;
            this._canExecuteMethod = canExecuteMethod;
            if (Application.Current != null)
            {
                this._dispatcher = Application.Current.Dispatcher;
            }
        }

        public bool CanExecute(T parameter)
        {
            return ((this._canExecuteMethod == null) || this._canExecuteMethod(parameter));
        }

        public void Execute(T parameter)
        {
            if (this._executeMethod != null)
            {
                this._executeMethod(parameter);
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            EventHandler canExecuteChangedHandler = this.CanExecuteChanged;
            if (canExecuteChangedHandler != null)
            {
                if ((this._dispatcher != null) && !this._dispatcher.CheckAccess())
                {
                    this._dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(this.OnCanExecuteChanged));
                }
                else
                {
                    canExecuteChangedHandler(this, EventArgs.Empty);
                }
            }
        }

        public void RaiseCanExecuteChanged()
        {
            this.OnCanExecuteChanged();
        }

        bool ICommand.CanExecute(object parameter)
        {
            if(parameter==null)
            {
                return this.CanExecute(default(T));
            }
            return this.CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute((T)parameter);
        }
    }
}