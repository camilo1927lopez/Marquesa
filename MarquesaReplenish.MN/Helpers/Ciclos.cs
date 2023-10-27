using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarquesaReplenish.PD.Model;

namespace MarquesaReplenish.MN.Helpers
{
    public class Ciclos
    {
        public List<TblParteCicloModel> Validar(List<TblParteCicloModel> ltsTblParteCicloModel) 
        {
            try
            {
                List<string> ltsMensajes = new List<string>();

                var agrupadoxInicialYFinal = from pc in ltsTblParteCicloModel
                               group pc by new { pc.RangoInical, pc.RangoFinal } into nuevogrupo
                               orderby nuevogrupo.Count()
                               select new { RangoFinal = nuevogrupo.Key.RangoFinal, RangoInical = nuevogrupo.Key.RangoInical, Cantidad = nuevogrupo.Count() };

                var agrupadoxInicial = from pc in ltsTblParteCicloModel
                                             group pc by new { pc.RangoInical } into nuevogrupo
                                             orderby nuevogrupo.Count()
                                             select new { RangoInical = nuevogrupo.Key.RangoInical, Cantidad = nuevogrupo.Count() };

                var agrupadoxFinal = from pc in ltsTblParteCicloModel
                                       group pc by new { pc.RangoFinal } into nuevogrupo
                                       orderby nuevogrupo.Count()
                                       select new { RangoFinal = nuevogrupo.Key.RangoFinal, Cantidad = nuevogrupo.Count() };

                foreach (var item in agrupadoxInicialYFinal.Where(t => t.Cantidad > 1))                
                    ltsMensajes.Add($"El rango inicial: {item.RangoInical} y el rango final: {item.RangoFinal} se encuentra {item.Cantidad} veces.");

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                foreach (var item in agrupadoxInicial.Where(t => t.Cantidad > 1))
                    ltsMensajes.Add($"El rango inicial: {item.RangoInical} se encuentra {item.Cantidad} veces.");

                foreach (var item in agrupadoxFinal.Where(t => t.Cantidad > 1))
                    ltsMensajes.Add($"El rango final: {item.RangoFinal} se encuentra {item.Cantidad} veces.");

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                for (int i = 0; i < ltsTblParteCicloModel.Count; i++)
                {
                    List<TblParteCicloModel> ltsParteCiclo = ltsTblParteCicloModel.Where(t => (ltsTblParteCicloModel[i].RangoInical > t.RangoInical  && ltsTblParteCicloModel[i].RangoInical < t.RangoFinal) || (ltsTblParteCicloModel[i].RangoFinal > t.RangoInical && ltsTblParteCicloModel[i].RangoFinal < t.RangoFinal)).ToList();

                    if (ltsParteCiclo.Count > 0)
                    {
                        ltsMensajes.Add($"{Environment.NewLine}* El rango inicial: {ltsTblParteCicloModel[i].RangoInical} y el rango final: {ltsTblParteCicloModel[i].RangoFinal} contiene numeración incluida en los siguiente rangos.");

                        foreach (var item in ltsParteCiclo)                        
                            ltsMensajes.Add($"\t ° Rango inicial: {item.RangoInical} Rango final: {item.RangoFinal}");
                        
                    }
                }

                if (ltsMensajes.Count > 0)                
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ltsTblParteCicloModel;
        }
    }
}
