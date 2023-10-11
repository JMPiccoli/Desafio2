using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new frmUsuarios();
            formulario.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new frmProductos();
            formulario.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new frmVentas();
            formulario.Show();
        }
    }
}
