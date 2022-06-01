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
    public partial class Reporte_Prestamo : Form
    {
        public Reporte_Prestamo()
        {
            InitializeComponent();
        }

        private void Reporte_Prestamo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet2.Prestamo' Puede moverla o quitarla según sea necesario.
            this.PrestamoTableAdapter.Fill(this.DataSet2.Prestamo);

            this.reportViewer1.RefreshReport();
        }
    }
}
