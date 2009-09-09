namespace ArtemisWest.Demos.CalculatorClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();
            var vm = new Calculator.CalculatorViewModel();
            this.Content = vm;
        }
    }
}
