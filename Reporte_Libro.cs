﻿using System;
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
    public partial class Reporte_Libro : Form
    {
        public Reporte_Libro()
        {
            InitializeComponent();
        }

        private void Reporte_Libro_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet3.Libro' Puede moverla o quitarla según sea necesario.
            this.LibroTableAdapter.Fill(this.DataSet3.Libro);

            this.reportViewer1.RefreshReport();
        }
    }
}
