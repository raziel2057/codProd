using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace codProdApp
{
    public class Utils
    {
        private StreamReader lector;
        private List<string> listadoCadenas;

        public StreamReader Lector
        {
            get { return lector; }
            set { lector = value; }
        }

        public void inicializar(String url)
        {
            this.lector = new StreamReader(url);
            this.listadoCadenas = new List<string>();
        }

        public List<string> leerCadenas(String url)
        {
            StreamReader readFile = new StreamReader(url);
            List<string> lista = new List<string>();
            string line;

            

            while ((line = readFile.ReadLine()) != null)
            {
                lista.Add(line);
                
            }

            readFile.Close();
            return lista;
        }

        public List<Tipo> leerTipos()
        {
            List<Tipo> listaTipos = new List<Tipo>();
            List<string> lista = this.leerCadenas("tipos.txt");
            for (int i = 0; i < lista.Count; i++)
            {
                string[] words = lista[i].Split('|');
                if (words.Count() == 3)
                {
                    Tipo p = new Tipo();
                    p.Codigo = words[0];
                    p.CadenaAlias = words[1];
                    p.Nombre = words[2];
                    listaTipos.Add(p);
                }
            }

                return listaTipos;
        }
        public List<Final> leerFinales()
        {
            List<Final> listaTipos = new List<Final>();
            List<string> lista = this.leerCadenas("finales.txt");
            for (int i = 0; i < lista.Count; i++)
            {
                string[] words = lista[i].Split('|');
                if (words.Count() == 2)
                {
                    Final p = new Final();
                    p.CodigoTipo = words[0];
                    p.CadenaComp = words[1];  
                    listaTipos.Add(p);
                }
            }

            return listaTipos;
        }

        public List<Producto> leerProductos()
        {
            List<Tipo> tipos = this.leerTipos();
            List<Final> finales = this.leerFinales();

            List<Producto> listaProductos = new List<Producto>();
            List<string> lista = this.leerCadenas("cadenas.txt");
            for (int i = 0; i < lista.Count; i++)
            {
                string[] words = lista[i].Split(' ');
                words = this.eliminarBarras(words);
                bool ban = true;
                for (int j = 0; j < tipos.Count; j++)
                {
                    bool flagFound = false;
                    int aumento = 0;
                    
                    
                    
                    if (tipos[j].CadenaAlias.Contains(words[0] + " " + words[1] + " " + words[2]))
                    {
                        aumento = 2;
                        flagFound = true;
                    }
                    else if (tipos[j].CadenaAlias.Contains(words[0] + " " + words[1]))
                    {
                        aumento = 1;
                        flagFound = true;
                    }
                    else if (tipos[j].CadenaAlias.Contains(words[0]))
                    {
                        aumento = 0;
                        flagFound = true;
                    }

                    if (flagFound)
                    {
                        Final final = finales.Find(x => x.CodigoTipo.Equals(tipos[j].Codigo));

                        for (int k = 1 + aumento; k < words.Count(); k++)
                        {

                            if (final.CadenaComp.Contains(words[k].Trim()) && words[k].Trim().Length>1)
                            {
                                if (tipos[j].Nombre.Equals("COMPUTER"))
                                    Console.WriteLine();
                                Producto p = new Producto();
                                p.Marca = words[1 + aumento];
                                p.Modelo = "";
                                p.Keywords = tipos[j].Nombre + " " + p.Marca + " ";
                                p.Estado = "TERMINADO";

                                for (int l = 2 + aumento; l < k+aumento; l++)
                                {
                                    p.Modelo += words[l] + " ";
                                    p.Keywords += words[l] + " ";
                                }
                                listaProductos.Add(p);
                                ban = false;
                                break;

                            }
                        }
                        break;
                    }
                    
                }

                if (ban)
                    {
                        Producto p = new Producto();
                        p.Marca = "";
                        p.Modelo = "";
                        p.Keywords = lista[i];
                        p.Estado = "ERROR";
                        listaProductos.Add(p);
                    }
            }
            Console.WriteLine();
            return listaProductos;
        }

        private string[] eliminarBarras(string[] words)
        {
            
            string numToRemove = "-";
            string numToRemove2 = "";
            words = words.Where(val => val != numToRemove).ToArray();
            words = words.Where(val => val != numToRemove2).ToArray();
            return words;
            
        }

        public void ExportarCSV(List<Producto> productos)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";//***Se asigna un filtro para la pantalla de dialogo para guardar el archivo en el directorio de tu preferencia***//

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && saveFileDialog1.FileName.Length > 0)//***Aqui se evalua si le damos click en el boton 'ok' de la ventana y si escribimos el nombre del archivo***//
            {
                int ban = 0;//***Esta es una variable bandera, que indicara si el archivo fue creado o no lo fue.***//              
                try
                {
                    FileInfo t = new FileInfo(saveFileDialog1.FileName);//***Se crea un objeto de la clase FileInfo que recibe como parametro el nombre del Archivo***//
                    StreamWriter Tex = t.CreateText();//***Creamos un objeto StreamWriter donde se guardara lo que vayamos escribiendo o el contenido del archivo CSV ***//
                    string cadena = "Fuente,Modelo,Nombre,DescCorta,DescLarga,Tags,Marca";//*** En la variable 'cadena' tipo string debe ir lo que ira en el primer renglon separado por ',' (COMAS), cada coma indica la separacion de las columnas***//                    
                    Tex.WriteLine(cadena);//***Agrega el renglon al archivo StreamWrite***//
                    //Tex.Write(Tex.NewLine);//***Escribe una nueva linea en el archivo***//

                    foreach (Producto p in productos)
                    {
                        string tags = p.Keywords.Trim().Replace(" ",",");
                        string descC = "";
                        string descL = "";

                        cadena = "TECNOMEGA"
                                     + "," + encodeToBase64(p.Modelo)
                                     + "," + encodeToBase64(p.Keywords )
                                     + "," + encodeToBase64(descC )
                                     + "," + encodeToBase64(descL )
                                     + "," + encodeToBase64(tags )
                                     + "," + encodeToBase64(p.Marca);
                        Tex.WriteLine(cadena);
                        //Tex.Write(Tex.NewLine);
                    }
                    
                    Tex.Close();//***Cierra el archivo***//
                }
                catch (Exception ex)
                {
                    ban = 1;//Si existe algun error en el codigo del Try enciende la Bandera//
                }
                if (ban == 0)//Se evalua la Bandera, si no hubo error dice que el archio se creo satisfactoriamente, en caso contrario dice que lo vuelvas a intentar
                    MessageBox.Show("El Archivo " + saveFileDialog1.FileName + " ha sido creado");
                else
                    MessageBox.Show("No se pudo crear el archivo. Intente de Nuevo");
            }
        }

        private string encodeToBase64(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

    }
}
