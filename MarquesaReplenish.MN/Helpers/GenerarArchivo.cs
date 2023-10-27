using MarquesaReplenish.PD.Model.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.MN.Helpers
{
    public class GenerarArchivo
    {
        public List<string> GenerarListaFile(List<Contenedor> contenedoresInstitucion)
        {
            List<string> ltsFile = new List<string>();
            try
            {
                foreach (var item in contenedoresInstitucion)
                {
                    foreach (var itemInfoActa in item.InfoValue)
                    {
                        for (int i = 0; i < itemInfoActa.Cantidad; i++)
                        {
                            ltsFile.Add($"{item.NumeroContenedor}|{item.KeyAgrupado}|{itemInfoActa.CodValue}|{itemInfoActa.Cantidad}");
                            //ltsFile.Add($"{item.NumeroContenedor}|{string.Join("|",itemInfoActa.InfLinea)}|{itemInfoActa.Cantidad}");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ltsFile;
        }
        public List<string> GenerarListaFile(Dictionary<string, Dictionary<string, InfoValue>> keyValuePairs)
        {
            List<string> ltsFile = new List<string>();
            try
            {
                foreach (var item in keyValuePairs)
                {
                    foreach (var itemInfoActa in item.Value)
                    {
                        for (int i = 0; i < itemInfoActa.Value.Cantidad; i++)
                        {
                            ltsFile.Add($"{itemInfoActa.Value.CodValue}|{itemInfoActa.Value.Cantidad}");                           
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ltsFile;
        }
        public List<string> AgregarNuevaColumna(string archivoSeleccionado, List<string[]> nuevasColumnas, char Delimitador)
        {
            List<string> ltsNuevoArchivo = new List<string>();
            try
            {

                using (StreamReader reader = new StreamReader(archivoSeleccionado, Encoding.Default))
                {
                    String linea;
                    int contador = 0;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] arrLines = linea.Split(Delimitador);

                        ltsNuevoArchivo.Add($"{string.Join(Delimitador.ToString(), arrLines)}{Delimitador}{string.Join(Delimitador.ToString(), nuevasColumnas[contador])}");
                        contador++;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ltsNuevoArchivo;
        }
    }
}
