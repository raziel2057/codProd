using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codProdApp
{
    public class Parametro
    {
        private string nombre;
        private string valor;

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Parametro(string nombre, string valor)
        {
            this.nombre = nombre;
            this.valor = valor;
        }
    }
}
