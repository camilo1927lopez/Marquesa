using MarquesaReplenish.PD.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.MN.Helpers
{
    public class CalculoContenedores
    {
        public List<Contenedor> Generar(Dictionary<string, Dictionary<string, InfoValue>> AgruparXOrdenColumnas, List<TamanoContenedor> cantidadXContenedor, int contadorContenedor, int cantidadXBolsaMaxima)
        {
            List<Contenedor> contenedoresGenerados = new List<Contenedor>();

            List<InfoValue> actasTomadas = new List<InfoValue>();

            string strNumeroContenedor = string.Empty;
            int resultadoContenedor = 0;
            int i = 0;
            while (i < AgruparXOrdenColumnas.Count)
            {
                var iteminstitucion = AgruparXOrdenColumnas.ElementAt(i);
                var iteminstitucionKey = iteminstitucion.Key;
                var iteminstitucionValue = iteminstitucion.Value;

                foreach (var itemValue in iteminstitucionValue)
                {

                    if (itemValue.Value.Seleccionado)
                        continue;

                    resultadoContenedor = resultadoContenedor + itemValue.Value.Cantidad;

                    Contenedor Existecontenedors = contenedoresGenerados.FirstOrDefault(t => t.NumeroContenedor == contadorContenedor.ToString());
                    if (resultadoContenedor <= cantidadXContenedor.Max(t => t.Tamano))
                    {
                        if (Existecontenedors != null)
                        {
                            Existecontenedors.InfoValue.Add(itemValue.Value);
                            Existecontenedors.SumaCantidad += itemValue.Value.Cantidad;
                            //Existecontenedors.NumeroContenedor = contadorContenedor.ToString();
                        }
                        else
                        {
                            Contenedor contenedor = new Contenedor();
                            contenedor.InfoValue = new List<InfoValue>();
                            contenedor.InfoValue.Add(itemValue.Value);
                            contenedor.SumaCantidad += itemValue.Value.Cantidad;
                            contenedor.NumeroContenedor = contadorContenedor.ToString();
                            contenedor.KeyAgrupado = iteminstitucionKey.ToString();
                            contenedoresGenerados.Add(contenedor);
                        }

                        AgruparXOrdenColumnas.ElementAt(i).Value[itemValue.Key].Seleccionado = true;
                    }
                    else
                    {

                        int sobranteContenedor = cantidadXContenedor.Max(t => t.Tamano) - (resultadoContenedor - itemValue.Value.Cantidad);

                        var infActasobrante = AgruparXOrdenColumnas.ElementAt(i).Value.Where(t => t.Value.Cantidad <= sobranteContenedor && sobranteContenedor >= t.Value.Cantidad && t.Value.Seleccionado == false).ToList();

                        foreach (var itemSobrante in infActasobrante)
                        {
                            int resultadoContenedorSobrante = Existecontenedors.SumaCantidad + itemSobrante.Value.Cantidad;
                            if (resultadoContenedorSobrante <= cantidadXContenedor.Max(t => t.Tamano))
                            {
                                Existecontenedors.InfoValue.Add(itemSobrante.Value);
                                Existecontenedors.SumaCantidad += itemSobrante.Value.Cantidad;                                
                                AgruparXOrdenColumnas.ElementAt(i).Value[itemSobrante.Key].Seleccionado = true;
                            }
                        }

                        if (Existecontenedors != null)
                        {
                            var ordenado = cantidadXContenedor.Where(t => Existecontenedors.SumaCantidad <= t.Tamano).OrderBy(t => t.Tamano).ToList();
                            Existecontenedors.TamañoContenedore = ordenado.First();
                        }

                        contadorContenedor++;

                        Contenedor contenedor = new Contenedor();
                        contenedor.InfoValue = new List<InfoValue>();
                        contenedor.InfoValue.Add(itemValue.Value);
                        contenedor.SumaCantidad += itemValue.Value.Cantidad;
                        contenedor.NumeroContenedor = contadorContenedor.ToString();
                        contenedor.KeyAgrupado = iteminstitucionKey.ToString();
                        contenedoresGenerados.Add(contenedor);

                        resultadoContenedor = itemValue.Value.Cantidad;
                        AgruparXOrdenColumnas.ElementAt(i).Value[itemValue.Key].Seleccionado = true;
                    }
                }

                var marcarTamano = contenedoresGenerados.FirstOrDefault(t => t.TamañoContenedore == null);
                if (marcarTamano != null)
                {
                    var ordenadoTamano = cantidadXContenedor.Where(t => marcarTamano.SumaCantidad <= t.Tamano).OrderBy(t => t.Tamano).ToList();
                    marcarTamano.TamañoContenedore = ordenadoTamano.First();
                }

                resultadoContenedor = 0;
                contadorContenedor++;
                i++;
            }

            return contenedoresGenerados;
        }
    }
}
