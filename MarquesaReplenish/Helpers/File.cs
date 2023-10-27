using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Helpers
{
    public class File
    {
        public bool GenerarArchivo(DataTable tbl, bool incluirEncabezado, string RutaArchivo, string separador)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(RutaArchivo)))
                    Directory.CreateDirectory(Path.GetDirectoryName(RutaArchivo));
                

                using (StreamWriter sw = new StreamWriter(RutaArchivo))
                {
                    if (incluirEncabezado)
                    {
                        string[] arrDatos = new string[tbl.Columns.Count];

                        for (int i = 0; i < tbl.Columns.Count; i++)                        
                            arrDatos[i] = tbl.Columns[i].ColumnName;                       

                        sw.WriteLine(string.Join(separador, arrDatos));

                    }

                    foreach (DataRow row in tbl.Rows)
                    {
                        sw.WriteLine(string.Join(separador, row.ItemArray));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
