using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : IFormaGeometrica
    { 
        public decimal Lado { get; set; }

        public Cuadrado() { }

        public decimal CalcularArea() => Lado * Lado;

        public decimal CalcularPerimetro() => Lado * 4;
    }
}
