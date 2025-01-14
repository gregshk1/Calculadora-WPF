using CalculadoraCientifica.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CalculadoraWPF
{
    public class CalculadoraViewModel : INotifyPropertyChanged
    {
        private readonly CalculadoraModel _calculadoraModel; // Instância da CalculadoraModel

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _entrada = string.Empty;
        private string _resultado = string.Empty;

        public string Entrada
        {
            get => _entrada;
            set
            {
                _entrada = value;
                OnPropertyChanged(nameof(Entrada));
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        public ICommand AdicionarEntradaCommand { get; }
        public ICommand CalcularCommand { get; }
        public ICommand RaizQuadradaCommand { get; }
        public ICommand PotenciaCommand { get; } // Comando para potenciação
        public ICommand ApagarCommand { get; }
        public ICommand LimparCommand { get; }

        // Construtor
        public CalculadoraViewModel()
        {
            _calculadoraModel = new CalculadoraModel(); // Inicializa a instância
            AdicionarEntradaCommand = new RelayCommand(AdicionarEntrada);
            CalcularCommand = new RelayCommand(Calcular);
            RaizQuadradaCommand = new RelayCommand(CalcularRaizQuadrada);
            PotenciaCommand = new RelayCommand(parametro => AdicionarEntrada("^"));
            ApagarCommand = new RelayCommand(Apagar);
            LimparCommand = new RelayCommand(Limpar);
        }

        private void AdicionarEntrada(object parametro)
        {
            Entrada += parametro?.ToString();
        }

        private void Apagar(object parametro)
        {
            if (Entrada.Length > 0)
            {
                Entrada = Entrada.Substring(0, Entrada.Length - 1);
            }
        }

        private void Limpar(object parametro)
        {
            Entrada = string.Empty;
            Resultado = string.Empty;
        }

        private void Calcular(object parametro)
        {
            try
            {
                // Verifica se há o operador ^ na entrada
                if (Entrada.Contains("^"))
                {
                    var partes = Entrada.Split('^');
                    if (partes.Length == 2 &&
                        double.TryParse(partes[0], out double baseNum) &&
                        double.TryParse(partes[1], out double expoente))
                    {
                        var resultado = _calculadoraModel.Potencia(baseNum, expoente);
                        Resultado = resultado.ToString("G");
                        return;
                    }
                    else
                    {
                        Resultado = "Erro! Formato inválido.";
                        return;
                    }
                }

                // Processa outros cálculos genéricos
                var resultadoCalculado = new System.Data.DataTable().Compute(Entrada, null);
                Resultado = resultadoCalculado.ToString();
            }
            catch (Exception)
            {
                Resultado = "Erro!";
            }
        }


        private void CalcularRaizQuadrada(object parametro)
        {
            try
            {
                if (double.TryParse(Entrada, out double numero))
                {
                    if (numero < 0)
                    {
                        Resultado = "Erro! Raiz de número negativo.";
                    }
                    else
                    {
                        var resultado = _calculadoraModel.CalcularRaizQuadrada(numero);
                        Resultado = resultado.ToString("G");
                    }
                }
                else
                {
                    Resultado = "Erro! Entrada inválida.";
                }
            }
            catch (Exception ex)
            {
                Resultado = $"Erro: {ex.Message}";
            }
        }

        private void CalcularPotencia(object parametro)
        {
            try
            {
                var partes = Entrada.Split('^');
                if (partes.Length == 2 &&
                    double.TryParse(partes[0], out double baseNum) &&
                    double.TryParse(partes[1], out double expoente))
                {
                    var resultado = _calculadoraModel.Potencia(baseNum, expoente);
                    Resultado = resultado.ToString("G");
                }
                else
                {
                    Resultado = "Erro! Formato inválido.";
                }
            }
            catch (Exception ex)
            {
                Resultado = $"Erro: {ex.Message}";
            }
        }
    }
}
