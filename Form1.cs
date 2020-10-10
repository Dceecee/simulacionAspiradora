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
    public partial class formaEntrada : Form
    {
        public class Agente
        {
            public float contadorConfiguracion = 0;
            public float puntuacionActual = 0;
            public float puntuacionMedia = 0;
            public List<float> listaPuntuacion = new List<float>();
            //public 
            public int posiciones = 0;
            public int suciedad = 0;
            public int movimientos = 0;
            public double rendimiento = 0.0d;
            public string last;

            public Agente()
            {
                contadorConfiguracion = 0;
                puntuacionActual = 0;
                puntuacionMedia = 0;
                posiciones = 0;
                suciedad = 0;
                last = "";
            }
        }
        //Creo una instancia del agente para poder utilizarlo en la forma
        Agente agente = new Agente();

        //Actualizo los datos del agente en la forma
        public void actualizarDatos()
        {
            string dump_last = "";
            listBoxPuntuacion.DataSource = null;
            listBoxPuntuacion.Items.Clear();

            puntuacionActualLabel.Text = agente.puntuacionActual.ToString();
            puntuacionMediaLabel.Text = agente.puntuacionMedia.ToString();
            listBoxPuntuacion.DataSource = agente.listaPuntuacion;
            ContenedorRendimiento.Text = agente.rendimiento.ToString();
            ContenedorMovimientos.Text = agente.movimientos.ToString();
            //age
            ContenedorUltimoEstado.Text = agente.last;
        }

        public formaEntrada()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inputEspacios_TextChanged(object sender, EventArgs e)
        {

        }

        private void iniciarSimulacion_Click(object sender, EventArgs e)
        {
            //Verfico que los espacios no esten vacios, que sean mayores a 0 y que el inicio y suciedad no sean mayores a las posiciones 
            if (String.IsNullOrEmpty(inputEspacios.Text) || String.IsNullOrEmpty(inputSuciedad.Text) || String.IsNullOrEmpty(inputPosicion.Text))
                MessageBox.Show("No puedes dejar espacios vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (int.Parse(inputEspacios.Text) <= 0 || int.Parse(inputPosicion.Text) <= 0)
                MessageBox.Show("La cantidad de posiciones y posición \ninicial deben ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (int.Parse(inputEspacios.Text) < int.Parse(inputPosicion.Text) || int.Parse(inputEspacios.Text) < int.Parse(inputSuciedad.Text))
                MessageBox.Show("La posición inicial y la cantidad de \nsuciedad no deben ser mayor a las \nposiciones disponibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //Mando a llamar a la segunda forma pasando parametros
                agente.posiciones = int.Parse(inputPosicion.Text);
                agente.suciedad = int.Parse(inputSuciedad.Text);
                formaSalida frm2 = new formaSalida(int.Parse(inputEspacios.Text), int.Parse(inputSuciedad.Text), int.Parse(inputPosicion.Text), agente);
                frm2.Show();
                
                actualizarDatos();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e) {

        }
    }
}
