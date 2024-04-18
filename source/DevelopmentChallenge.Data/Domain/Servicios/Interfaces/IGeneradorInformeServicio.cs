using DevelopmentChallenge.Data.Application.Interfaces;
using DevelopmentChallenge.Data.Domain.Enumeradores;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Domain.Servicios.Interfaces
{
    public interface IGeneradorInformeServicio
    {
        string GenerarInforme(List<IFormaGeometrica> formas, Idioma idioma);        
    }
}
