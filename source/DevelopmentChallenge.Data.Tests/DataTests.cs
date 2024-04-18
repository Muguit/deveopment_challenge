using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Application.Interfaces;

using DevelopmentChallenge.Data.Domain.Entidades;
using DevelopmentChallenge.Data.Domain.Enumeradores;
using DevelopmentChallenge.Data.Domain.Servicios;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        GeneradorInformeServicio _informe = new GeneradorInformeServicio();

        [SetUp]
        public void SetUp()
        {
            _informe = new GeneradorInformeServicio();
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                _informe.GenerarInforme(new List<IFormaGeometrica>(), Idioma.es));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                _informe.GenerarInforme(new List<IFormaGeometrica>(), Idioma.en));
            
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };
            var resumen = _informe.GenerarInforme(cuadrados, Idioma.es);
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = _informe.GenerarInforme(cuadrados, Idioma.en);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = _informe.GenerarInforme(formas, Idioma.en);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = _informe.GenerarInforme(formas, Idioma.es);
            var resultadoEsperado = "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65";
            Assert.AreEqual(resultadoEsperado,resumen);
        }

        /*Agrego test en italiano*/

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(6),
                new Circulo(2),
                new TrianguloEquilatero(5),
                new Cuadrado(1),
                new TrianguloEquilatero(10),
                new Circulo(2.8m),
                new TrianguloEquilatero(4.9m)
            };

            var resumen = _informe.GenerarInforme(formas, Idioma.it);
            var resultadoEsperado = "<h1>Rapporto forme</h1>2 Quadrati | Area 37 | Perimeter 28 <br/>2 Cerchi | Area 9,3 | Perimeter 15,08 <br/>3 Triangoli | Area 64,52 | Perimeter 59,7 <br/>TOTAL:<br/>7 forme Perimeter 102,78 Area 110,82";
            Assert.AreEqual(resultadoEsperado, resumen);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            var resumen = _informe.GenerarInforme(new List<IFormaGeometrica>(), Idioma.it);
            Assert.AreEqual("<h1>Lista vuota di forme!</h1>", resumen);
        }
    }
}
