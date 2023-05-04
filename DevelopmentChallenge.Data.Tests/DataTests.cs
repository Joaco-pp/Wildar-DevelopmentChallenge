using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Constants;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                actual: FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), Languages.Español));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                actual: FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), Languages.English));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnPortugues()
        {
            Assert.AreEqual("<h1>Lista vazia de formas!</h1>",
                actual: FormaGeometrica.Imprimir(new List<IFormaGeometrica>(), Languages.Portugues));
        }


        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado() { Lado = 5 }
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Languages.Español);
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnCuadradoPortugues()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado() { Lado = 5 }
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Languages.Portugues);
            Assert.AreEqual("<h1>Relatório de formulários</h1>1 Quadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Area 25", resumen);
        }


        [TestCase]
        public void TestResumenListaTrapecioConCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Trapecio(){ 
                        BaseMayor = 12,
                        Altura = 7.5m ,
                        BaseMenor = 6, 
                        PrimerLado = 7, 
                        SegundoLado = 7.5m },
                new Cuadrado() { Lado = 1 },
                new Cuadrado() { Lado = 3 }
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Languages.English);

            Assert.AreEqual("<h1>Shapes report</h1>" +
                "1 Trapeze | Area 67.5 | Perimeter 32.5 <br/>" +
                "2 Squares | Area 10 | Perimeter 16 <br/>" +
                "TOTAL:<br/>" +
                "3 shapes Perimeter 48.5 Area 77.5", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(){ Lado = 5},
                new Cuadrado() { Lado = 1 },
                new Cuadrado() { Lado = 3 }
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Languages.English);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado() {Lado = 5},
                new Circulo() { Radio = 3 },
                new TrianguloEquilatero() { Lado = 4 },
                new Cuadrado () { Lado = 2 },
                new TrianguloEquilatero () { Lado = 9 },
                new Circulo () { Radio = 2.75m },
                new TrianguloEquilatero () { Lado = 4.2m }
            };

            var resumen = FormaGeometrica.Imprimir(formas, Languages.English);

            Assert.AreEqual(
                "<h1>Shapes report</h1>" +
                "2 Squares | Area 29 | Perimeter 28 <br/>" +
                "2 Circles | Area 13.01 | Perimeter 18.06 <br/>" +
                "3 Triangles | Area 49.64 | Perimeter 51.6 <br/>" +
                "TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado() { Lado= 5 },
                new Circulo(){ Radio =  3 },
                new TrianguloEquilatero () { Lado = 4 },
                new Cuadrado () { Lado = 2 },
                new TrianguloEquilatero () { Lado = 9 },
                new Circulo () { Radio = 2.75m },
                new TrianguloEquilatero () { Lado = 4.2m }
            };

            var resumen = FormaGeometrica.Imprimir(formas, Languages.Español);

            Assert.AreEqual(
                "<h1>Reporte de formas</h1>" +
                "2 Cuadrados | Area 29 | Perimetro 28 <br/>" +
                "2 Círculos | Area 13,01 | Perimetro 18,06 <br/>" +
                "3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>" +
                "TOTAL:<br/>" +
                "7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
