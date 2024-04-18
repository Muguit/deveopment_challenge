using DevelopmentChallenge.Data.Domain.Enumeradores;
using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Infrastructure.Recursos
{
    public static class Recursos
    {
        // TODO: cambiar por resx con con los idiomas como corresponde        
        private static readonly Dictionary<Idioma, Dictionary<string, string>> _recursosPorIdioma = new Dictionary<Idioma, Dictionary<string, string>>
        {
            {
                Idioma.es, new Dictionary<string, string>
                {
                    {"area", "Area"},
                    {"perimetro", "Perimetro"},
                    {"cuadrado", "Cuadrado"},
                    {"cuadrados", "Cuadrados"},
                    {"circulo", "Círculo"},
                    {"circulos", "Círculos"},
                    {"triangulo", "Triángulo"},
                    {"triangulos", "Triángulos"},                    
                    {"titulo_reporte", "Reporte de Formas"},
                    {"formas", "formas"},
                    {"lista_formas_vacia", "Lista vacía de formas!" }
                }
            },
            {
                Idioma.en, new Dictionary<string, string>
                {
                    {"area", "Area"},
                    {"perimetro", "Perimeter"},
                    {"cuadrado", "Square"},
                    {"cuadrados", "Squares"},
                    {"circulo", "Circle"},
                    {"circulos", "Circles"},
                    {"triangulo", "Triangle"},
                    {"triangulos", "Triangles"},
                    {"titulo_reporte", "Shapes report"},
                    {"formas", "shapes"},
                    {"lista_formas_vacia", "Empty list of shapes!" }
                }
            },
            {
                Idioma.it, new Dictionary<string, string>
                {
                    {"area", "Area"},
                    {"perimetro", "Perimeter"},
                    {"cuadrado", "Quadrato"},
                    {"cuadrados", "Quadrati"},
                    {"circulo", "Cerchio"},
                    {"circulos", "Cerchi"},
                    {"triangulo", "Triangolo"},
                    {"triangulos", "Triangoli"},
                    {"titulo_reporte", "Rapporto forme"},
                    {"formas", "forme"},
                    {"lista_formas_vacia", "Lista vuota di forme!" }
                }
            }
        };

        public static string ObtenerTexto(Idioma idioma, string clave)
        {
            // Verifica si el idioma está soportado
            if (!_recursosPorIdioma.ContainsKey(idioma))
            {
                throw new KeyNotFoundException($"El idioma '{idioma}' no está soportado.");
            }

            // Verifica si la clave existe en el diccionario de recursos para el idioma especificado
            if (!_recursosPorIdioma[idioma].ContainsKey(clave))
            {
                throw new KeyNotFoundException($"La clave '{clave}' no está definida para el idioma '{idioma}'.");
            }

            // Retorna el texto correspondiente a la clave y el idioma
            return _recursosPorIdioma[idioma][clave];
        }
    }
}