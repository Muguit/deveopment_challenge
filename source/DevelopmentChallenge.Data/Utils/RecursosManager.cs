using DevelopmentChallenge.Data.Domain.Enumeradores;
using DevelopmentChallenge.Data.Infrastructure.Recursos;

namespace DevelopmentChallenge.Data.Utils
{
    public static class RecursosManager
    {
        public static string Obtener(Idioma idioma, string nombreRecurso)
        {            
            return Recursos.ObtenerTexto(idioma, nombreRecurso);
        }
    }
}
