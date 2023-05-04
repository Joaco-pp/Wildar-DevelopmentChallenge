using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        public decimal Radio { get; set; }

        public Circulo() { }
        
        public decimal CalcularArea() => (decimal)Math.PI * (Radio / 2) * (Radio / 2);

        public decimal CalcularPerimetro() => (decimal)Math.PI * Radio;
    }
}
