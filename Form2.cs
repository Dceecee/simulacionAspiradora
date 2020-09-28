using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulacionAspiradora
{
    public partial class formaSalida : Form
    {
        public int espacios;
        public int suciedad;
        public int posicion;
        public static string newline = Environment.NewLine;
        public formaSalida(int espaciosTemp, int suciedadTemp, int posicionTemp)
        {
            InitializeComponent();
            espacios = espaciosTemp;
            suciedad = suciedadTemp;
            posicion = posicionTemp-1;

        }

        public class Aspiradora
        {
            public int posicionInicial;
            public int posicionActual;
            public int sizeLista;

            public Aspiradora()
            {
                posicionInicial = -1;
                posicionActual = -1;
            }

            public void crearAspiradora(int size, int pos)
            {
                posicionInicial = pos;
                posicionActual = pos;
                sizeLista = size;
            }

            public string crearLinea(List<string> listaAmbiente)
            {
                string cadena="";
                for (int x = 0; x < sizeLista; x++)
                    cadena += listaAmbiente[x] + " ";
                return cadena;
            }

            public string revisarLista(List<string> listaAmbiente, List<string> listaEstados)
            {
                //Voy validando empezando por la posicion inicial si la posicion actual en la lista aparece como sucia o no, la limpio 
                //en caso necesario y me muevo a la derecha hasta llegar al final de la lista. Luego empiezo a hacer lo mismo moviendome
                //a la izquierda hasta llegar al principio de la lista.
                string salida="";
                int j=posicionActual+1;
                listaEstados.Add(crearLinea(listaAmbiente));
                for (; posicionActual < sizeLista; posicionActual++, j = posicionActual + 1)
                {
                    salida += "POSICIÓN ACTUAL: " + j + newline;
                    salida += "ESTADO POSICIÓN " + j + ": " + listaAmbiente[posicionActual] + newline;
                    if (listaAmbiente[posicionActual] == "Sucio")
                    {
                        salida += "LIMPIANDO POSICIÓN " + j + newline;
                        listaAmbiente[posicionActual] = "Limpio";
                        salida += "POSICIÓN " + j + " LIMPIA" + newline;
                    }
                    salida += "RECORRIDO A LA DERECHA" + newline + newline;
                    listaEstados.Add(crearLinea(listaAmbiente));
                }
                salida += "NO SE PUEDE RECORRER A LA DERECHA, RECORRIDO A LA IZQUIERDA" + newline + newline;
                posicionActual-=2;
                j = posicionActual + 1;
                for (; posicionActual >= 0; posicionActual--, j = posicionActual + 1)
                {
                    salida += "POSICIÓN ACTUAL: " + j + newline;
                    salida += "ESTADO POSICIÓN " + j + ": " + listaAmbiente[posicionActual] + newline;
                    if (listaAmbiente[posicionActual] == "Sucio")
                    {
                        salida += "LIMPIANDO POSICIÓN " + j + newline;
                        listaAmbiente[posicionActual] = "Limpio";
                        salida += "POSICIÓN " + j + " LIMPIA" + newline;
                    }
                    salida += "RECORRIDO A LA IZQUIERDA" + newline + newline;
                    listaEstados.Add(crearLinea(listaAmbiente));
                }
                salida += "NO SE PUEDE RECORRER A LA iZQUIERDA, LIMPIEZA TERMINADA" + newline + newline;
                
                return salida;
            }
        }

        public class Ambiente
        {
            public int sizeLista;
            public List<string> listaAmbiente = new List<string>();
            public List<string> listaEstados = new List<string>();

            public Ambiente()
            {
                sizeLista = -1;
            }

            public void crearAmbiente(int size, int cantSucio)
            {
                //Creo la lista de posiciones con posiciones limpias y sucias
                sizeLista = size;
                var random = new Random();
                var b = random.Next(2);
                for (int i = 0; i < sizeLista; i++)
                {
                    if (b == 0 && i < cantSucio || b == 1 && i >= (sizeLista-cantSucio))
                        listaAmbiente.Add("Sucio");
                    else
                        listaAmbiente.Add("Limpio");
                }
            }

        }

        private void formaSalida_Load(object sender, EventArgs e)
        {
            //Creo los objetos de ambiente y aspiradora, muestro los estados de las posiciones y la posicion inicial de la aspiradora
            string salida;
            Ambiente ambiente = new Ambiente();
            ambiente.crearAmbiente(espacios, suciedad);
            Aspiradora aspiradora = new Aspiradora();
            aspiradora.crearAspiradora(espacios, posicion);
            for (int i = 0, j; i < espacios; i++)
            {
                j = i + 1;
                textoDisplay.Text += "ESTADO POSICIÓN " + j + ": " + ambiente.listaAmbiente[i] + newline;
            }
            textoDisplay.Text += "POSICIÓN INICIAL ASPIRADORA : " + aspiradora.posicionInicial + newline + newline;
            //Llamo a la funcion de la aspiradora
            salida = aspiradora.revisarLista(ambiente.listaAmbiente, ambiente.listaEstados);
            textoDisplay.Text += salida;
            listBoxAmbiente.DataSource = ambiente.listaEstados;
        }
    }
}
