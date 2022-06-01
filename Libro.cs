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
    public partial class Libro : Form
    {
        SqlConnection Conexion = new SqlConnection("Data Source=JUNIORMATOS\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True");
        

        public Libro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
          
            string Consulta = "INSERT INTO Libro (ID_Libro,Nombre,Autor,Fecha_Lanzamiento,Tipo,Editora,Cantidad,Imagen) VALUES (@ID_Libro,@Nombre,@Autor,@Fecha_Lanzamiento,@Tipo,@Editora,@Cantidad,@Imagen)";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Libro", T1.Text);
            Comando.Parameters.AddWithValue("@Nombre", T2.Text);
            Comando.Parameters.AddWithValue("@Autor", T3.Text);
            Comando.Parameters.AddWithValue("@Fecha_Lanzamiento", T4.Text);
            Comando.Parameters.AddWithValue("@Tipo", T5.Text);
            Comando.Parameters.AddWithValue("@Editora", T6.Text);
            Comando.Parameters.AddWithValue("@Cantidad", T7.Text);
            Comando.Parameters.AddWithValue("@Imagen",arr);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Insertado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Consulta = "DELETE FROM Libro WHERE ID_Libro=@ID_Libro";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Libro", T1.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Eliminados");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            String Consulta = "UPDATE Libro SET Nombre=@Nombre,Autor=@Autor,Fecha_Lanzamiento=@Fecha_Lanzamiento,Tipo=@Tipo,Editora=@Editora,Cantidad=@Cantidad  WHERE ID_Libro=@ID_Libro ";
            Conexion.Open();
            SqlCommand Comando = new SqlCommand(Consulta, Conexion);
            Comando.Parameters.AddWithValue("@ID_Libro", T1.Text);
            Comando.Parameters.AddWithValue("@Nombre", T2.Text);
            Comando.Parameters.AddWithValue("@Autor", T3.Text);
            Comando.Parameters.AddWithValue("@Fecha_Lanzamiento", T4.Text);
            Comando.Parameters.AddWithValue("@Tipo", T5.Text);
            Comando.Parameters.AddWithValue("@Editora", T6.Text);
            Comando.Parameters.AddWithValue("@Cantidad", T7.Text);
            Comando.ExecuteNonQuery();
            Conexion.Close();
            MessageBox.Show("Datos Modificados");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*SqlCommand Comando = new SqlCommand("Select * from Libro", Conexion);
             adaptador.SelectCommand = Comando;*/

            string Categotias = "SELECT * FROM Libro";
            SqlDataAdapter adaptador = new SqlDataAdapter(Categotias,Conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    pictureBox1.Load(this.openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO es posible cargar la img: " + ex.ToString());
            }
        }

        private void Libro_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bibliotecaDataSet1.Libro' Puede moverla o quitarla según sea necesario.
            this.libroTableAdapter.Fill(this.bibliotecaDataSet1.Libro);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Reporte_Libro R = new Reporte_Libro();
            R.Show();
            this.Hide();
        }
    }
}

