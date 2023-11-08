using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comestibles.BE;
namespace Comestibles.FE
{
    public partial class Form1 : Form
    {
        private int n = 0;

        StockComestibles Stock = new StockComestibles();
        public Form1()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            //Instanciar
            Comestible comestible;  //defino un objeto como clase comestible
                                    //para usarla se inicializa el objeto comestible
            //Inicializar
            comestible = new Comestible();

            comestible.Nombre = txtNombre.Text;
            comestible.Codigo = txtCodigo.Text;
            comestible.Cantidad =Convert.ToDecimal(txtCantidad.Text);

            Stock.AgregarComestible(comestible);

            lblResultado.Text = Stock.Control();

            //Adicionamos nuevo renglon

            int n = dtaLista.Rows.Add();
            // colocamos la informacion

            dtaLista.Rows[n].Cells[0].Value = txtNombre.Text;
            dtaLista.Rows[n].Cells[1].Value = txtCodigo.Text;
            dtaLista.Rows[n].Cells[2].Value = txtCodigo.Text;

            //limpiamos los textos
            txtNombre.Text = " ";
            txtCodigo.Text = " ";
            txtCantidad.Text = " ";

        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
             Comestible comestible = Stock.BuscarComestible(txtCodigo.Text);
             lblResultado.Text=comestible.Control();



        }

        private void dtaLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;

            if (n != -1)
            {
                lblInformacion.Text = (string)dtaLista.Rows[n].Cells[1].Value;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (n != -1)
            {
                dtaLista.Rows.RemoveAt(n);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
         
                //Creamos la variable leer e indicamos la direccion donde guardaremos el archivo
                StreamWriter escribir = new StreamWriter(@"C:\Users\karla\Archivos.txt", true);



                try
                {
                    //Escribimos lo que contiene los Textbox
                    escribir.WriteLine("Nombre: " + txtNombre.Text);
                    escribir.WriteLine("Codigo: " + txtCodigo.Text);
                    escribir.WriteLine("Cantidad: " + txtCantidad.Text);
                    escribir.WriteLine("\n");
                }
                catch
                {
                    // mensaje de Error
                    MessageBox.Show("Error");
                }
                // Cerramos procesos
                escribir.Close();
        }
    }
    
}
 