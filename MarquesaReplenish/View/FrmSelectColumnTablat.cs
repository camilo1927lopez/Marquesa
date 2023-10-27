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
    public partial class FrmSelectColumnTablat : Form
    {
        public List<ColumnaPosicion> _ListaColumnaSelect = new List<ColumnaPosicion>();
        public string _ColumnasPosicionSeleccionadas = null;
        public bool _IncluirUltimaColumnaAgrupado = false;


        public class ColumnaPosicion 
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }
        public FrmSelectColumnTablat()
        {
            InitializeComponent();
            _ListaColumnaSelect = new List<ColumnaPosicion>();
        }

        private void dgvSelectColumn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSelectColumn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0)
                    return;

                string strNombreColumna = dgvSelectColumn.Columns[e.ColumnIndex].Name;

                if (_ListaColumnaSelect.FirstOrDefault(t => t.Key == strNombreColumna) != null) 
                {                    
                    string strColumnaMensaje = $"Columna '{strNombreColumna}' Seleccionada";
                    if (MessageBox.Show($"Ya existe seleccionada la columna '{strNombreColumna}', ¿deseas quitar la selección?.", strColumnaMensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        string strMensaje = $"Ya existe seleccionada la columna '{strNombreColumna}', ¿deseas cambiarle de posicion?{Environment.NewLine}{Environment.NewLine}" +
                                            $"Porsición Actual: {_ListaColumnaSelect.FirstOrDefault(t => t.Key == strNombreColumna).Value:00}{Environment.NewLine}" +
                                            $"Porsición Nueva: {(_ListaColumnaSelect.Count - 1):00}{Environment.NewLine}";

                        if (MessageBox.Show(strMensaje, strColumnaMensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {                            
                            _ListaColumnaSelect.Remove(_ListaColumnaSelect.FirstOrDefault(t => t.Key == strNombreColumna));
                            ColumnaPosicion columnaPosicion = new ColumnaPosicion() { Key = strNombreColumna, Value = _ListaColumnaSelect.Count };
                            _ListaColumnaSelect.Add(columnaPosicion);
                        }
                    }
                    else
                    {
                        _ListaColumnaSelect.Remove(_ListaColumnaSelect.FirstOrDefault(t => t.Key == strNombreColumna));
                        dgvSelectColumn.Columns[strNombreColumna].Selected = false;
                    }
                }
                else
                {
                    ColumnaPosicion columnaPosicion = new ColumnaPosicion() { Key = strNombreColumna, Value = _ListaColumnaSelect.Count };
                    _ListaColumnaSelect.Add(columnaPosicion);
                }                                    

                List<string> ltsColumnaPosicion = new List<string>();

                //OrdenarPosiciones(_DicColumnaSelect);

                foreach (var item in OrdenarPosiciones(_ListaColumnaSelect)) 
                {
                    dgvSelectColumn.Columns[item.Key].Selected = true;
                    ltsColumnaPosicion.Add($"{item.Key}[{item.Value:00}]");
                }
                _ColumnasPosicionSeleccionadas = string.Join(" | ", ltsColumnaPosicion);
                txtColumnasSeleccionadas.Text = _ColumnasPosicionSeleccionadas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar columnas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ColumnaPosicion> OrdenarPosiciones(List<ColumnaPosicion> ListaColumnaSelect)
        {
            try
            {
                for (int i = 0; i < ListaColumnaSelect.Count; i++)
                {
                    var item = ListaColumnaSelect[i];
                    string key = item.Key;
                    int val = item.Value;

                    if (val != i)
                    {
                        ListaColumnaSelect[i].Value = i;
                    }

                }

                return ListaColumnaSelect;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSelectColumnTablat_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> ListaColumnaSelect = new List<string>();
                if (_ListaColumnaSelect.Count > 0)
                    for (int i = 0; i < dgvSelectColumn.Columns.Count; i++)
                        if (_ListaColumnaSelect.FirstOrDefault(t => t.Key.Trim() == dgvSelectColumn.Columns[i].Name.Trim()) != null) 
                        {
                            ListaColumnaSelect.Add($"{dgvSelectColumn.Columns[i].Name.Trim()}[{_ListaColumnaSelect.FirstOrDefault(t => t.Key.Trim() == dgvSelectColumn.Columns[i].Name.Trim()).Value:00}]");
                            dgvSelectColumn.Columns[i].Selected = true;
                        }

                _ColumnasPosicionSeleccionadas = string.Join(" | ", ListaColumnaSelect);
                txtColumnasSeleccionadas.Text = _ColumnasPosicionSeleccionadas;
                checkBox1.Checked = _IncluirUltimaColumnaAgrupado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error al cargar la tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            _IncluirUltimaColumnaAgrupado = checkBox1.Checked;
        }
    }
}
