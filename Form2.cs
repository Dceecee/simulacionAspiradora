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
        
        public int puntos = 0;
        public formaEntrada.Agente agenteLocal;
        public static string newline = Environment.NewLine;
        public formaSalida(int espaciosTemp, int suciedadTemp, int posicionTemp, formaEntrada.Agente agente)
        {
            InitializeComponent();
            espacios = espaciosTemp;
            suciedad = suciedadTemp;
            posicion = posicionTemp-1;
            agenteLocal = agente;
        }

        //Actualizo los datos del agente utilizando la cantidad de puntos obtenidos dependiendo de la cantidad de movimientos que se hicieron
        public void cambiarValoresAgente(int puntos, int movimientos, string l)
        {
            float total = 0;
            agenteLocal.contadorConfiguracion++;
            agenteLocal.puntuacionActual = agenteLocal.suciedad - puntos;
            agenteLocal.listaPuntuacion.Add(agenteLocal.puntuacionActual);
            for (int j = 0; j < agenteLocal.contadorConfiguracion; j++)
            {
                total = total + agenteLocal.listaPuntuacion[j];
            }
            agenteLocal.puntuacionMedia = total / agenteLocal.contadorConfiguracion;
            agenteLocal.movimientos = movimientos;
            agenteLocal.rendimiento = (double)agenteLocal.suciedad / (double)movimientos;
            agenteLocal.last = l;
        }

        public class Aspiradora
        {
            public int posicionInicial;
            public int posicionActual;
            public int sizeLista;
            public int puntosLocal;
            public int movimientos;
            public double rendimiento;
            public bool is_dirt = false;
            public List<string> last_state = new List<string>();
            public string L_S = "";
            public Aspiradora()
            {
                posicionInicial = -1;
                posicionActual = -1;
                puntosLocal = -1;
                movimientos = 0;
                rendimiento = 0.0d;
 
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
                if (cadena.Contains("Sucio"))
                    L_S = cadena;
                return cadena;
            }

            public string revisarLista(List<string> listaAmbiente, List<string> listaEstados)
            {
                //Voy validando empezando por la posicion inicial si la posicion actual en la lista aparece como sucia o no, la limpio 
                //en caso necesario y me muevo a la derecha hasta llegar al final de la lista. Luego empiezo a hacer lo mismo moviendome
                //a la izquierda hasta llegar al principio de la lista.
                if (listaAmbiente.Contains("Sucio")) {
                    last_state = listaAmbiente;
                }
                puntosLocal = 0;
                string salida="";
                int j=posicionActual+1;
                listaEstados.Add(crearLinea(listaAmbiente));
                for (; posicionActual < sizeLista; posicionActual++, j = posicionActual + 1)
                {
                    salida += "POSICIÓN ACTUAL: " + j + newline;
                    salida += "ESTADO POSICIÓN " + j + ": " + listaAmbiente[posicionActual] + newline;
                    if (listaAmbiente[posicionActual] == "Sucio") {
                        salida += "LIMPIANDO POSICIÓN " + j + newline;
                        listaAmbiente[posicionActual] = "Limpio";
                        salida += "POSICIÓN " + j + " LIMPIA" + newline;
                        movimientos = movimientos + 1;
                    }
                    else {
                        movimientos = movimientos + 1;
                    }
                    salida += "RECORRIDO A LA DERECHA" + newline + newline;
                    listaEstados.Add(crearLinea(listaAmbiente));
                    puntosLocal++;
                }
                salida += "NO SE PUEDE RECORRER A LA DERECHA, RECORRIDO A LA IZQUIERDA" + newline + newline;
                posicionActual-=2;
                j = posicionActual + 1;
                for (; posicionActual >= 0; posicionActual--, j = posicionActual + 1)
                {
                    salida += "POSICIÓN ACTUAL: " + j + newline;
                    salida += "ESTADO POSICIÓN " + j + ": " + listaAmbiente[posicionActual] + newline;
                    if (listaAmbiente[posicionActual] == "Sucio") {
                        salida += "LIMPIANDO POSICIÓN " + j + newline;
                        listaAmbiente[posicionActual] = "Limpio";
                        salida += "POSICIÓN " + j + " LIMPIA" + newline;
                        movimientos = movimientos + 1;
                    }
                    else {
                        movimientos = movimientos + 1;
                    }
                    salida += "RECORRIDO A LA IZQUIERDA" + newline + newline;
                    listaEstados.Add(crearLinea(listaAmbiente));
                    puntosLocal++;
                }
                puntosLocal--;
                salida += "NO SE PUEDE RECORRER A LA iZQUIERDA, LIMPIEZA TERMINADA" + newline + newline;
                return salida;
            }
        }

        public class Ambiente
        {
            public int sizeLista;
            public List<string> listaAmbiente = new List<string>();
            public List<string> listaEstados = new List<string>();
            public List<Int64> posiciones_suciedad = new List<Int64>();

            public Ambiente()
            {
                sizeLista = -1;
            }

            public void crearAmbiente(int size, int cantSucio)
            {
                //Creo la lista de posiciones con posiciones limpias y sucias
                int temp_sucio = cantSucio;
                sizeLista = size;
                Random rand = new Random();
                while(temp_sucio > 0) {
                    
                    int b = rand.Next(size-1);
                    if (b < sizeLista) {
                        if (posiciones_suciedad.Count == 0) {
                            posiciones_suciedad.Add(b);
                            temp_sucio--;
                        }
                        else {
                            if (!posiciones_suciedad.Contains(b)) {
                                posiciones_suciedad.Add(b);
                                temp_sucio--;
                            }
                        }
                    }
                }
                for (int i = 0; i < sizeLista; i++)
                {
                    
                    //if (b == 0 && i < cantSucio || b == 1 && i >= (sizeLista-cantSucio))
                    if (posiciones_suciedad.Contains(i))
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
            cambiarValoresAgente(aspiradora.puntosLocal, aspiradora.movimientos, aspiradora.L_S);
        }
    }
}
