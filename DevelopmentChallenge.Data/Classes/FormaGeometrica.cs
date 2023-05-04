/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo.
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * OPCIONAL: Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;

namespace DevelopmentChallenge.Data.Classes
{
    public static class FormaGeometrica
    {
        public static string Imprimir(List<IFormaGeometrica> formas, string idioma)
        {
            StringBuilder sb = new StringBuilder();
            ResourceManager rm = SetLaguage(idioma);

            if (!formas.Any())
            {
                sb.Append($"<h1>{rm.GetString("EmptyList")}</h1>");
            }
            else
            {
                sb.Append($"<h1>{rm.GetString("ShapesReport")}</h1>");

                IEnumerable<CalculosFormas> resultados = formas
                                                        .GroupBy(f => f.GetType().Name)
                                                        .Select(g => new CalculosFormas()
                                                            {
                                                                Forma = g.Key,
                                                                Cantidad = g.Count(),
                                                                SumaPerimetros = g.Sum(f => f.CalcularPerimetro()),
                                                                SumaAreas = g.Sum(f => f.CalcularArea())
                                                            }); ;

                decimal parametroTotal = 0m;
                decimal areaTotal = 0m;

                foreach (CalculosFormas obj in resultados) 
                {
                    sb.Append($"{obj.Cantidad} {rm.GetString(obj.Forma)}{(obj.Cantidad > 1 ? "s" : "")} | Area {obj.SumaAreas:#.##} | {rm.GetString("Perimeter")} {obj.SumaPerimetros:#.##} <br/>");
                    parametroTotal += obj.SumaPerimetros;
                    areaTotal += obj.SumaAreas;
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(formas.Count + " " + rm.GetString("Shape") + " ");
                sb.Append($"{rm.GetString("Perimeter")} {parametroTotal:#.##} ");
                sb.Append($"Area {areaTotal:#.##}");
            }

          

            return sb.ToString();
        }

        private static ResourceManager SetLaguage(string idioma)
        {
            CultureInfo culture = new CultureInfo(idioma);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            ResourceManager resource = new ResourceManager(typeof(Resources.Resources));

            return resource;

        }

    }
}
