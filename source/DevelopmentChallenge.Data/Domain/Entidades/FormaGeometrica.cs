using DevelopmentChallenge.Data.Application.Interfaces;
using DevelopmentChallenge.Data.Domain.Enumeradores;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Domain.Entidades
{
    //TODO: hacer un archivo por clase
    public class FormaGeometrica : IFormaGeometrica
    {
        public virtual  string Nombre => throw new NotImplementedException();

        public virtual string NombrePlural => throw new NotImplementedException();

        public virtual decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public virtual decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public virtual string ObtenerReporte(Idioma idioma, List<IFormaGeometrica> formas)
        {   
            string tipo = formas.Count > 1 ? RecursosManager.Obtener(idioma, NombrePlural) : RecursosManager.Obtener(idioma, Nombre);
            decimal totalArea = 0,totalPermitro = 0;
            foreach(var forma in formas)
            {
                totalArea += forma.CalcularArea();
            }
            foreach (var forma in formas)
            {
                totalPermitro+= forma.CalcularPerimetro();
            }
            return $"{formas.Count} {tipo} | {RecursosManager.Obtener(idioma, "area")} {totalArea:#.##} | {RecursosManager.Obtener(idioma, "perimetro")} {totalPermitro:#.##} <br/>";
        }
    }


    
    public class Cuadrado : FormaGeometrica
    {
        public override string Nombre => "cuadrado";
        public override string NombrePlural => "cuadrados";
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }

    public class Circulo : FormaGeometrica
    {
        public override string Nombre => "circulo";
        public override string NombrePlural => "circulos";
        private readonly decimal _lado;

        public Circulo(decimal lado)
        {
            //TODO:es el diametro... pero así esta en el ejercicio original
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _lado;
        }
    }


    public class TrianguloEquilatero : FormaGeometrica
    {        
        public override string Nombre => "triangulo";
        public override string NombrePlural => "triangulos";
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
        
    }
}
