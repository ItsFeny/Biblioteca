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
    public partial class Cliente : Form
    {

        SqlConnection Conexion = new SqlConnection("Data Source=JUNIORMATOS\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True");
        public Cliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Consulta = "INSERT INTO Cliente (ID_Cliente,Nombre,Apellido,Cedula,Telefono) VALUES (@ID_Cliente,@Nombre,@Apellido,@Cedula,@Telefono)";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Cliente", T1.Text);
            Comando.Parameters.AddWithValue("@Nombre", T2.Text);
            Comando.Parameters.AddWithValue("@Apellido", T3.Text);
            Comando.Parameters.AddWithValue("@Cedula", T4.Text);
            Comando.Parameters.AddWithValue("@Telefono", T5.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Insertado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Consulta = "DELETE FROM Cliente WHERE ID_Cliente=@ID_Cliente";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Cliente", T1.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Eliminados");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Consulta = "UPDATE Cliente SET Nombre=@Nombre,Apellido=@Apellido,Cedula=@Cedula,Telefono=@Telefono  WHERE ID_Cliente=@ID_Cliente ";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Cliente", T1.Text);
            Comando.Parameters.AddWithValue("@Nombre", T2.Text);
            Comando.Parameters.AddWithValue("@Apellido", T3.Text);
            Comando.Parameters.AddWithValue("@Cedula", T4.Text);
            Comando.Parameters.AddWithValue("@Telefono", T5.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Modificados");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand Comando = new SqlCommand("Select * from Cliente", Conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = Comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reporte_Cliente R = new Reporte_Cliente();
            R.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Prestamo P = new Prestamo();
            P.Show();
            this.Hide();
        }
    }
}
