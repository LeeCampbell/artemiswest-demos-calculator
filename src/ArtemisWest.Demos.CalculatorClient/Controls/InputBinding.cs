using System.Windows;
using System.Windows.Input;

namespace ArtemisWest.Demos.CalculatorClient.Controls
{
    public class InputBinding : KeyBinding
    {
        #region Fields

        private static readonly DependencyProperty BoundCommandProperty =

            DependencyProperty.Register("BoundCommand", typeof(ICommand), typeof(InputBinding),
                                        new PropertyMetadata(OnBoundCommandChanged));

        #endregion

        #region Properties

        public ICommand BoundCommand
        {
            get { return GetValue(BoundCommandProperty) as ICommand; }
            set { SetValue(BoundCommandProperty, value); }
        }
        #endregion

        #region Methods
        private static void OnBoundCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var binding = obj as InputBinding;
            if (binding == null) return;
            binding.Command = e.NewValue as ICommand;
        }
        #endregion
    }
}