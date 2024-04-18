using DevelopmentChallenge.Data.Domain.Enumeradores;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Application.Interfaces
{
    public interface IFormaGeometrica
    {
        //Tanto Nombre como NombrePlural deben coincidir con el "name" del recurso
        string Nombre { get; }
        string NombrePlural { get; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string ObtenerReporte(Idioma idioma,List<IFormaGeometrica> formas);
    }
}
