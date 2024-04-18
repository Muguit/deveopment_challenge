using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Application
{
    public static class PresentadorInforme
    {
        public static string Presentar(string informe)
        {
            // Lógica para presentar el informe
            return $"<html><body>{informe}</body></html>";
        }
    }
}
