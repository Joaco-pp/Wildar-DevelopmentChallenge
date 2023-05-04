using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        public decimal Lado { get; set; }

        public TrianguloEquilatero() { }

        public decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;


        public decimal CalcularPerimetro() => Lado * 3;
    }
}
