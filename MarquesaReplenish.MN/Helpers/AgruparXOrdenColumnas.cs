using MarquesaReplenish.PD.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.MN.Helpers
{
    public class AgruparXOrdenColumnas
    {
        public Dictionary<string, Dictionary<string, InfoValue>> MapearArchivo(string filePath, List<Campo> campos, char delimitador, string NombreAgrupado)
        {
            string line;
            bool isFirstLine = true;
            List<string> ltsMensajes = new List<string>();
            Dictionary<string, Dictionary<string, InfoValue>> indices = new Dictionary<string, Dictionary<string, InfoValue>>();
            try
            {

                using (StreamReader ReaderObject = new StreamReader(filePath, Encoding.Default))
                {
                    int consLinea = 1;
                    while ((line = ReaderObject.ReadLine()) != null)
                    {
                        string[] splitLine = line.Split(delimitador);

                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            ValidarCamposAgrupar(splitLine, campos);
                            consLinea++;
                            continue;
                        }

                        string concatenadoValue = RetornarConcatenado(splitLine, campos.Where(t => t.Value == true).ToList());
                        string concatenadoKey = RetornarConcatenado(splitLine, campos.Where(t => t.Value == false).ToList());   

                        if (indices.ContainsKey(concatenadoKey))
                        {
                            var itemConcatenadoKey = indices[concatenadoKey].LastOrDefault();

                            if ((itemConcatenadoKey.Value.consecutivo + 1) != consLinea)
                            {
                                string mensaje = InformacionMensaje(campos, concatenadoKey, delimitador);
                                ltsMensajes.Add($"Agrupar{NombreAgrupado}: La información {mensaje} no tiene una posicion consecutiva en el archivo, Posicion anterior: {itemConcatenadoKey.Value.consecutivo} Posicion actual : {consLinea}");
                            }

                            if (indices[concatenadoKey].ContainsKey(concatenadoValue))
                            {
                                indices[concatenadoKey][concatenadoValue].Cantidad++;
                                indices[concatenadoKey][concatenadoValue].consecutivo = consLinea;
                                //indices[concatenadoKey][concatenadoValue].InfLinea.Add(splitLine);
                            }
                            else
                            {
                                indices[concatenadoKey].Add(concatenadoValue, new InfoValue { Cantidad = 1, Seleccionado = false, CodValue = concatenadoValue, consecutivo = consLinea/*, InfLinea = new List<string[]>() { splitLine }*/ });
                            }

                        }
                        else
                        {
                            indices.Add(concatenadoKey, new Dictionary<string, InfoValue>() { { concatenadoValue, new InfoValue { Cantidad = 1, Seleccionado = false, CodValue = concatenadoValue, consecutivo = consLinea/*, InfLinea = new List<string[]>() { splitLine }*/ } }});
                        }
                        consLinea++;
                    }
                    ReaderObject.Close();
                }

                if (ltsMensajes.Count > 0)                
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return indices;
        }

        public string RetornarConcatenado(string[] splitLine, List<Campo> campos)
        {
            string concatenado = string.Empty;
            try
            {
                int cons = 0;
                foreach (var item in campos.OrderBy(t => t.Orden))
                {
                    string strInf = splitLine[item.Posicion];
                    
                    concatenado += string.IsNullOrEmpty(concatenado) ? strInf : $"|{strInf}";
                    cons++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
            
            return concatenado;
        }

        public void ValidarCamposAgrupar(string[] splitLine, List<Campo> campos)
        {
            try
            {
                List<string> ltsMensajes = new List<string>();
                splitLine.ToList().ForEach(t => t = t.ToLower());

                foreach (var item in campos)
                {
                    int posicio = Array.IndexOf(splitLine, item.Nombre);

                    if (posicio == -1)
                    {
                        ltsMensajes.Add($"La columna {item.Nombre} con posicion {item.Posicion} no existe");
                    }
                    else if (posicio != item.Posicion)
                    {
                        ltsMensajes.Add($"La columna {item.Nombre} con posicion {item.Posicion} se encuentra en posicion diferente en el archivo.");
                    }
                }

                if (ltsMensajes.Count > 0)
                {
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Campo> ListaCampoAgrupar(Dictionary<string, int> dicColumnasOrden, DataTable datatabletSelectColumn, bool EsAgrupador)
        {
            List<Campo> ltsCampos = new List<Campo>();
            try
            {
                int contador = 1;
                foreach (var item in dicColumnasOrden)
                {
                    if (datatabletSelectColumn.Columns[item.Key] != null)
                    {
                        int posicionColumna = datatabletSelectColumn.Columns[item.Key].Ordinal;

                        if (contador == dicColumnasOrden.Count)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (EsAgrupador)
                                {
                                    ltsCampos.Add(new Campo() { Nombre = item.Key, Orden = item.Value, Posicion = posicionColumna, Value = false });
                                    EsAgrupador = false;
                                }
                                else
                                {
                                    ltsCampos.Add(new Campo() { Nombre = item.Key, Orden = item.Value, Posicion = posicionColumna, Value = true });
                                    break;
                                }
                            }
                        }
                        else
                            ltsCampos.Add(new Campo() { Nombre = item.Key, Orden = item.Value, Posicion = posicionColumna, Value = false });

                    }
                    contador++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ltsCampos;
        }

        public string InformacionMensaje(List<Campo> dicActaInicial, string key, char delimitador)
        {
            string mensaje = string.Empty;
            try
            {
                for (int i = 0; i < dicActaInicial.Count; i++)
                {
                    string[] arrKey = key.Split(delimitador);
                    if (i < arrKey.Length)
                        mensaje += $"{dicActaInicial.ElementAt(i).Nombre}: {arrKey[i]} ";

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return mensaje;
        }
    }

}
