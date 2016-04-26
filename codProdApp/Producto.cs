using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codProdApp
{
    public class Producto
    {
        private string marca;
        private string modelo;
        private string keywords;
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
    }
}
