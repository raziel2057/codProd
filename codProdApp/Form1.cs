using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;

namespace codProdApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utils obj = new Utils();

            dtGVResultado.DataSource = obj.leerProductos();
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Utils obj = new Utils();

            dtGVResultado.DataSource = obj.leerProductos();
        }
        private string cadena()
        {
            return null;
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            Utils obj = new Utils();
            obj.ExportarCSV(obj.leerProductos());
        }
    }
}
