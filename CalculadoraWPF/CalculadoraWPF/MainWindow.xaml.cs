using System.Windows;

namespace CalculadoraWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSomar_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtNumero1.Text, out double num1) &&
                double.TryParse(txtNumero2.Text, out double num2))
            {
                lblResultado.Content = $"Resultado: {num1 + num2}";
            }
            else
            {
                MessageBox.Show("Por favor, insira números válidos.");
            }
        }

        private void btnSubtrair_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtNumero1.Text, out double num1) &&
                double.TryParse(txtNumero2.Text, out double num2))
            {
                lblResultado.Content = $"Resultado: {num1 - num2}";
            }
            else
            {
                MessageBox.Show("Por favor, insira números válidos.");
            }
        }

        private void btnMultiplicar_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtNumero1.Text, out double num1) &&
                double.TryParse(txtNumero2.Text, out double num2))
            {
                lblResultado.Content = $"Resultado: {num1 * num2}";
            }
            else
            {
                MessageBox.Show("Por favor, insira números válidos.");
            }
        }

        private void btnDividir_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtNumero1.Text, out double num1) &&
                double.TryParse(txtNumero2.Text, out double num2))
            {
                if (num2 != 0)
                {
                    lblResultado.Content = $"Resultado: {num1 / num2}";
                }
                else
                {
                    MessageBox.Show("Erro: Divisão por zero não é permitida.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira números válidos.");
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Content = "Resultado:";
        }
    }
}
