using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codProdApp
{
    public class Tipo
    {
        private string codigo;
        private string cadenaAlias;
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string CadenaAlias
        {
            get { return cadenaAlias; }
            set { cadenaAlias = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
}
