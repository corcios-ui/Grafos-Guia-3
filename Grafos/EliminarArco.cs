using System;
using System.Windows.Forms;

namespace Grafos
{
    public partial class EliminarArco : Form
    {
        public bool Econtrol;

        public EliminarArco()
        {
            InitializeComponent();
            Econtrol = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string valorOrigen = txtVerticeOrigen.Text.ToUpper().Trim();
            string valorDestino = txtVerticeDestino.Text.ToUpper().Trim();
            if ((valorOrigen == "") || (valorOrigen == " ") || (valorDestino == "") || (valorDestino == " "))
            {
                MessageBox.Show("No deje ningun campo vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Econtrol = true;
                Hide();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Econtrol = false;
            Hide();
        }

        private void EliminarArco_Load(object sender, EventArgs e)
        {
            txtVerticeOrigen.Focus();
            txtVerticeDestino.Focus();
        }

        private void EliminarArco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void EliminarArco_Shown(object sender, EventArgs e)
        {
            txtVerticeOrigen.Clear();
            txtVerticeDestino.Clear();
            txtVerticeOrigen.Focus();
            txtVerticeDestino.Focus();
        }

        private void txtVerticeDestino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEliminar_Click(null, null);
            }
        }

        private void txtVerticeOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEliminar_Click(null, null);
            }
        }

        private void EliminarArco_Load_1(object sender, EventArgs e)
        {

        }
    }
}
