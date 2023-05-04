using DevelopmentChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : IFormaGeometrica
    {
        public decimal Altura { get; set; }

        public decimal BaseMenor { get; set; }

        public decimal BaseMayor { get; set; }

        public decimal PrimerLado { get; set; }

        public decimal SegundoLado { get; set; } 

        public Trapecio() { }

        public decimal CalcularArea() => (Altura * (BaseMenor + BaseMayor)) / 2;



        public decimal CalcularPerimetro() => BaseMenor + BaseMayor + PrimerLado + SegundoLado;
    }
}
