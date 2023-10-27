using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Helpers
{
    public class Conexion
    {
        public bool AmbienteProduccion { get; set; }

        public string ambiente
        {
            get
            {
                try
                {
                    if (ConfigurationManager.AppSettings["AmbienteEjecucion"] != null)
                    {
                        if (ConfigurationManager.AppSettings["AmbienteEjecucion"].ToString().Trim() == "Pruebas")
                            return ConfigurationManager.AppSettings["AmbienteEjecucion"].ToString().Trim();
                        else
                            return string.Empty;
                    }
                    else
                        return string.Empty;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        public Conexion()
        {
            try
            {
                if (string.IsNullOrEmpty(ambiente))                                   
                    AmbienteProduccion = true;       
                else               
                    AmbienteProduccion = false;            
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error al obtener la configuración de conexion:{0}", Environment.NewLine, ex.Message));
            }
        }
    }
}
