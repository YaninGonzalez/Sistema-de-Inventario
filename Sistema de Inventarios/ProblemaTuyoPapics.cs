using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioBD
{
    public partial class ProblemaTuyoPapics : UserControl
    {
        public ProblemaTuyoPapics()
        {
            InitializeComponent();
        }

        private void tsb_ptpiniciosesion_Click(object sender, EventArgs e)
        {
            Form formPadre = this.FindForm();

            if (formPadre != null)
            {
                Iniciosesion inicioForm = formPadre as Iniciosesion;

                if (inicioForm != null)
                {
                    inicioForm.ReiniciarFormulario();
                }
            }
        }

    
    
    }
}
