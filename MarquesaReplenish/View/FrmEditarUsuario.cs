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
    public partial class FrmEditarUsuario : Form
    {
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private TblRolModel _tblRolModel = new TblRolModel();
        private TblUsuarioModel _tblUsuarioPadreModel = null;
        private TblRolModel _tblRolPadreModel = null;
        private UCUsuarioCrearEditar uCUsuarioCrearEditar = null;

        public FrmEditarUsuario(TblUsuarioModel tblUsuarioModel, TblRolModel tblRolModel)
        {
            this._tblUsuarioModel = tblUsuarioModel;
            this._tblRolModel = tblRolModel;

            InitializeComponent();

            uCUsuarioCrearEditar = new UCUsuarioCrearEditar(this._tblUsuarioModel, this._tblRolModel);
            addUserControl(uCUsuarioCrearEditar);
        }

        public FrmEditarUsuario(TblUsuarioModel tblUsuarioModel, TblRolModel tblRolModel, TblUsuarioModel tblUsuarioPadreModel, TblRolModel tblRolPadreModel)
        {
            this._tblUsuarioModel = tblUsuarioModel;
            this._tblRolModel = tblRolModel;
            this._tblUsuarioPadreModel = tblUsuarioPadreModel;
            this._tblRolPadreModel = tblRolPadreModel;

            InitializeComponent();

            uCUsuarioCrearEditar = new UCUsuarioCrearEditar(this._tblUsuarioModel, this._tblRolModel, this._tblUsuarioPadreModel, this._tblRolPadreModel);
            addUserControl(uCUsuarioCrearEditar);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            //this.Controls.Clear();
            this.Controls.Add(userControl);
            this.BringToFront();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            uCUsuarioCrearEditar.GuardarEditar();

            if (this._tblUsuarioPadreModel != null && this._tblRolPadreModel != null)
                this.Close();
        }
    }
}
