using MarquesaReplenish.PD.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Helpers
{
    public class CruceContenedores
    {
        public List<Contenedor> ltContenedores { get; set; }
        public List<TamanoContenedor> CantidadMaximoXContenedor { get; set; }
        public List<string> ltsMensajes { get; set; }
        public Dictionary<string, int> dicContenedorInicial { get; set; }
        public int cantidadColumnas { get; set; }
        public List<string> ltsNombresValorAgregar { get; set; }
        public List<string[]> NuevasColumnas { get; set; }
        public List<string[]> NuevasColumnasSalida { get; set; }
        public string _PrefijoColmnaBolsa { get; set; }
        public Dictionary<string, Dictionary<string, string>> ColumnasPrefijoNumeracion { get; set; }
        public char delimitador { get; set; }

        public async Task Generar() 
        {
            for (int Contenedores = 0; Contenedores < ltContenedores.Count; Contenedores++)
            {
                try
                {
                    if (ltContenedores[Contenedores].SumaCantidad > CantidadMaximoXContenedor.Max(t => t.Tamano))
                    {
                        string mensaje = await InformacionMensaje(dicContenedorInicial, ltContenedores[Contenedores].KeyAgrupado, delimitador);
                        ltsMensajes.Add($"El agrupado {mensaje} con cantidad de agrupado {ltContenedores[Contenedores].SumaCantidad}, sobre pasa la cantidad maxima por contenedor '{CantidadMaximoXContenedor.Max(t => t.Tamano)}'");
                        continue;
                    }


                    //if (Contenedores == 0)
                    //{
                    //    string[] bc = new string[cantidadColumnas + ltsNombresValorAgregar.Count];
                    //    bc = RetornaArryStrig(NuevasColumnas[Contenedores], ltsNombresValorAgregar);
                    //    NuevasColumnasSalida[Contenedores] = bc;
                    //}

                    for (int y = 0; y < ltContenedores[Contenedores].InfoValue.Count; y++)
                    {
                        InfoValue itemInfoValue = ltContenedores[Contenedores].InfoValue[y];

                        //}

                        //foreach (var itemInfoValue in ltContenedores.ElementAt(Contenedores).InfoValue)
                        //{
                        string[] bc = new string[cantidadColumnas + ltsNombresValorAgregar.Count];

                        string[] infBuscar = new string[] { itemInfoValue.CodValue, $"{_PrefijoColmnaBolsa}{itemInfoValue.CodValue}" };
                        List<int> listaIndex = NuevasColumnas.Select((value, index) => new { value, index }).Where(x => x.value[0] == infBuscar[0] && x.value[1] == infBuscar[1]).Select(x => x.index).ToList();

                        for (int i = 0; i < listaIndex.Count; i++)
                        {
                            ltsNombresValorAgregar = new List<string>();
                            ltsNombresValorAgregar.Add(ltContenedores[Contenedores].NumeroContenedor);

                            if (ltContenedores[Contenedores].SumaCantidad > 0)
                            {
                                foreach (var item in ColumnasPrefijoNumeracion)
                                {
                                    string strKey = item.Value.FirstOrDefault().Key;
                                    string strValor = item.Value.FirstOrDefault().Value;
                                    ltsNombresValorAgregar.Add($"{strKey}{strValor.PadLeft(strValor.Length, '0')}");
                                    int valor = Convert.ToInt32(strValor) + 1;
                                    ColumnasPrefijoNumeracion[item.Key][strKey] = valor.ToString().PadLeft(strValor.Length, '0');
                                }

                                bc = await RetornaArryStrig(NuevasColumnas[listaIndex[i]], ltsNombresValorAgregar);
                            }
                            else
                            {
                                foreach (var item in ColumnasPrefijoNumeracion)
                                    ltsNombresValorAgregar.Add("0");

                                bc = await RetornaArryStrig(NuevasColumnas[listaIndex[i]], ltsNombresValorAgregar);
                            }
                            ltContenedores[Contenedores].SumaCantidad = 0;
                            NuevasColumnasSalida[listaIndex[i]] = bc;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private async Task<string> InformacionMensaje(Dictionary<string, int> dicActaInicial, string key, char delimitador)
        {
            string mensaje = string.Empty;
            try
            {
                for (int i = 0; i < dicActaInicial.Count; i++)
                {
                    string[] arrKey = key.Split(delimitador);
                    if (i < arrKey.Length)
                        mensaje += $"{dicActaInicial.ElementAt(i).Key}: {arrKey[i]} ";

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return mensaje;
        }

        private async Task<string[]> RetornaArryStrig(string[] arry, List<string> nuevoValor)
        {
            string[] bc = new string[arry.Length + nuevoValor.Count];
            try
            {
                int posicionNuevoValor = 0;
                for (int x = 0; x < bc.Length; x++)
                {
                    if (x >= arry.Length)
                    {
                        if (posicionNuevoValor < nuevoValor.Count)
                        {
                            bc[x] = nuevoValor[posicionNuevoValor];
                            posicionNuevoValor++;
                            continue;
                        }
                    }
                    bc[x] = arry[x];
                }
            }
            catch (Exception)
            {

                throw;
            }

            return bc;
        }
    }
}
