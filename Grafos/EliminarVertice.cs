using System;
using System.Windows.Forms;

namespace Grafos
{
    public partial class EliminarVertice : Form
    {
        public bool Econtrol;

        public EliminarVertice()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string valor = txtVertice.Text.ToUpper().Trim();
            if ((valor == "") || (valor == " "))
            {
                MessageBox.Show("Debes ingresar un valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void EliminarVertice_Load(object sender, EventArgs e)
        {
            txtVertice.Focus();
        }

        private void EliminarVertice_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void EliminarVertice_Shown(object sender, EventArgs e)
        {
            txtVertice.Clear();
            txtVertice.Focus();
        }

        private void txtEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEliminar_Click(null, null);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EliminarVertice_Load_1(object sender, EventArgs e)
        {

        }
    }
}
