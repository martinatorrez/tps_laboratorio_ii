using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// borra los datos de los TextBox, ComboBox y Label de la pantalla
        /// </summary>
        private void Limpiar() 
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = null;
            this.txtNumero2.Text = null;
            this.cmbOperador.SelectedItem = null;

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// llama al metodo Operar de la calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>retorna el resultado</returns>
        private static double Operar(string numero1, string numero2, string operador) 
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            char operadorChar;
            double retorno = 0;
            char.TryParse(operador, out operadorChar);

            retorno = Calculadora.Operar(n1, n2 , operadorChar);
            return retorno;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text.ToString();
            string numero2 = txtNumero2.Text.ToString();
            string operador = cmbOperador.Text.ToString();
            double resultado = 0;
            resultado = Operar(numero1, numero2, operador);
            this.lblResultado.Text = resultado.ToString();
            this.lstOperaciones.Items.Add(txtNumero1.Text + " " + cmbOperador.Text + " " + txtNumero2.Text + " " + "=" + " " + resultado);
            if (resultado == double.MinValue)
            {
                MessageBox.Show("No es posible dividir por cero", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text);
        }
    }
}
