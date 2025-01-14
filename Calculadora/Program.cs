using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA ===");
                Console.WriteLine("Selecione uma operação:");
                Console.WriteLine("1 - Adição (+)");
                Console.WriteLine("2 - Subtração (-)");
                Console.WriteLine("3 - Multiplicação (*)");
                Console.WriteLine("4 - Divisão (/)");
                Console.WriteLine("5 - Sair");

                Console.Write("Escolha uma opção: ");
                string escolha = Console.ReadLine();

                if (escolha == "5")
                {
                    Console.WriteLine("Encerrando a calculadora. Até mais!");
                    break;
                }

                Console.Write("Digite o primeiro número: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Entrada inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Digite o segundo número: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Entrada inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    continue;
                }

                double resultado = 0;
                bool operacaoValida = true;

                switch (escolha)
                {
                    case "1":
                        resultado = Somar(num1, num2);
                        break;
                    case "2":
                        resultado = Subtrair(num1, num2);
                        break;
                    case "3":
                        resultado = Multiplicar(num1, num2);
                        break;
                    case "4":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Erro: Divisão por zero não é permitida.");
                            operacaoValida = false;
                        }
                        else
                        {
                            resultado = Dividir(num1, num2);
                        }
                        break;
                    default:
                        Console.WriteLine("Operação inválida. Pressione qualquer tecla para tentar novamente.");
                        operacaoValida = false;
                        break;
                }

                if (operacaoValida)
                {
                    Console.WriteLine($"O resultado é: {resultado}");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static double Somar(double a, double b) => a + b;

        static double Subtrair(double a, double b) => a - b;

        static double Multiplicar(double a, double b) => a * b;

        static double Dividir(double a, double b) => a / b;
    }
}
