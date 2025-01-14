using System.Windows;

namespace CalculadoraWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CalculadoraViewModel();
        }
    }
}
