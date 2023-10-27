using BDManager;
using MarquesaReplenish.PD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarquesaReplenish.View
{
    public partial class ClaseBase : Form
    {
        protected ConexionHelper _conexHelper = new ConexionHelper();

        public TblUsuarioModel usuarioModel { get; set; }
        public TblPermisosModel permisosModel { get; set; }
        public TblRolModel rolModel { get; set; }
        public List<TblDetalleRolPermisosModel> DetalleRolPermisosModel { get; set; }

        public ClaseBase()
        {

        }

        private void ClaseBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ClaseBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
