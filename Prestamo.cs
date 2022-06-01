using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca_2
{
    public partial class Prestamo : Form
    {
        SqlConnection Conexion = new SqlConnection("Data Source=JUNIORMATOS\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True");
        public Prestamo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void T4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Consulta = "INSERT INTO Prestamo (ID_Prestamo,ID_Libro,ID_Cliente,ID_Empleado,Fecha_Prestamo,Fecha_Devolucion,Cantidad) VALUES (@ID_Prestamo,@ID_Libro,@ID_Cliente,@ID_Empleado,@Fecha_Prestamo,@Fecha_Devolucion,@Cantidad)";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Prestamo", T1.Text);
            Comando.Parameters.AddWithValue("@ID_Libro", T3.Text);
            Comando.Parameters.AddWithValue("@ID_Cliente", T4.Text);
            Comando.Parameters.AddWithValue("@ID_Empleado", T2.Text);
            Comando.Parameters.AddWithValue("@Fecha_Prestamo", T5.Text);
            Comando.Parameters.AddWithValue("@Fecha_Devolucion", T6.Text);
            Comando.Parameters.AddWithValue("@Cantidad", T7.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Insertado");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            String Consulta = "DELETE FROM Prestamo WHERE ID_Prestamo=@ID_Prestamo";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Prestamo", T1.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Eliminados");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Consulta = "UPDATE Prestamo SET ID_Libro=@ID_Libro,ID_Cliente=@ID_Cliente,ID_Empleado=@ID_Empleado,Fecha_Prestamo=@Fecha_Prestamo,Fecha_Devolucion=@Fecha_Devolucion,Cantidad=@Cantidad  WHERE ID_Prestamo=@ID_Prestamo";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Prestamo", T1.Text);
            Comando.Parameters.AddWithValue("@ID_Libro", T2.Text);
            Comando.Parameters.AddWithValue("@ID_Cliente", T3.Text);
            Comando.Parameters.AddWithValue("@ID_Empleado", T4.Text);
            Comando.Parameters.AddWithValue("@Fecha_Prestamo", T5.Text);
            Comando.Parameters.AddWithValue("@Fecha_Devolucion", T6.Text);
            Comando.Parameters.AddWithValue("@Cantidad", T7.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Modificados");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand Comando = new SqlCommand("Select * from Prestamo", Conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = Comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reporte_Prestamo RP = new Reporte_Prestamo();
            RP.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Libro L = new Libro();
            L.Show();
            this.Hide();
        }
    }
}
