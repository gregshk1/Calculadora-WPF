using System;
using System.Collections.Generic;
using System.Data;

namespace CalculadoraCientifica.Models
{
    public class CalculadoraModel
    {
        public double Adicionar(double a, double b) => a + b;
        public double Subtrair(double a, double b) => a - b;
        public double Multiplicar(double a, double b) => a * b;

        public double Dividir(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Divisão por zero não é permitida.");
            return a / b;
        }

        public double CalcularRaizQuadrada(double numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("Não é possível calcular a raiz quadrada de um número negativo.");
            }
            return Math.Sqrt(numero);
        }

        public double Potencia(double baseNum, double expoente)
        {
            return Math.Pow(baseNum, expoente);
        }

        public double Seno(double angulo) => Math.Sin(ConvertToRadians(angulo));
        public double Cosseno(double angulo) => Math.Cos(ConvertToRadians(angulo));
        public double Logaritmo(double numero)
        {
            if (numero <= 0) throw new ArgumentException("O logaritmo só é definido para números positivos.");
            return Math.Log10(numero);
        }

        public double LogaritmoNatural(double numero)
        {
            if (numero <= 0) throw new ArgumentException("O logaritmo natural só é definido para números positivos.");
            return Math.Log(numero);
        }

        private double ConvertToRadians(double angulo) => angulo * (Math.PI / 180);
    }
}
