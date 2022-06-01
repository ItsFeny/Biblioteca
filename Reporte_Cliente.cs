using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_2
{
    public partial class Reporte_Cliente : Form
    {
        public Reporte_Cliente()
        {
            InitializeComponent();
        }

        private void Reporte_Cliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.Cliente' Puede moverla o quitarla según sea necesario.
            this.ClienteTableAdapter.Fill(this.DataSet1.Cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
