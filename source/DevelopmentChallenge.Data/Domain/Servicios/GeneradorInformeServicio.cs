using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Application.Interfaces;
using DevelopmentChallenge.Data.Domain.Entidades;
using DevelopmentChallenge.Data.Domain.Enumeradores;
using DevelopmentChallenge.Data.Domain.Servicios.Interfaces;
using DevelopmentChallenge.Data.Utils;
using Microsoft.SqlServer.Server;

namespace DevelopmentChallenge.Data.Domain.Servicios
{
    public class GeneradorInformeServicio : IGeneradorInformeServicio
    {
        
        private decimal CalcularAreaTotal(List<IFormaGeometrica> formas)
        {
            decimal areaTotal = 0;

            foreach (var forma in formas)
            {
                areaTotal += forma.CalcularArea();
            }

            return areaTotal;
        }

        private decimal CalcularPermitroTotal(List<IFormaGeometrica> formas)
        {
            decimal perimetroTotal = 0;

            foreach (var forma in formas)
            {
                perimetroTotal += forma.CalcularPerimetro();
            }

            return perimetroTotal;
        }

        private string ObtenerLinea(List<IFormaGeometrica> formas, Idioma idioma)
        {
            if (formas.Count > 0)
            {
                //TODO: Mejorrar no me gusta mucho queda pero lo arranque entendiendo que era una linea por forma
                var forma = formas.First();                
                return forma.ObtenerReporte(idioma,formas);                
            }
            return string.Empty;
        }

        public string GenerarInforme(List<IFormaGeometrica> formas, Idioma idioma)
        {
            var sb = new StringBuilder();
            if (!formas.Any())
            {   
                //TODO: podría pasar los nombres de los recursos a constantes...
                sb.Append($"<h1>{ RecursosManager.Obtener(idioma, "lista_formas_vacia")}</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER                
                sb.Append($"<h1>{RecursosManager.Obtener(idioma, "titulo_reporte")}</h1>");                
                var formasAgrupadas = formas.GroupBy(forma => forma.GetType().Name);
                foreach (var grupo in formasAgrupadas)
                {
                    sb.Append(ObtenerLinea(grupo.ToList(), idioma));
                }
                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append($"{formas.Count} {RecursosManager.Obtener(idioma, "formas")} ");
                sb.Append($"{RecursosManager.Obtener(idioma, "perimetro")} {CalcularPermitroTotal(formas):#.##} ");
                sb.Append($"{RecursosManager.Obtener(idioma, "area")} {CalcularAreaTotal(formas):#.##}");                
            }

            return sb.ToString();
        }
    }
}

