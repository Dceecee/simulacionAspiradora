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
                formaSalida frm2 = new formaSalida(int.Parse(inputEspacios.Text), int.Parse(inputSuciedad.Text), int.Parse(inputPosicion.Text));
                frm2.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
