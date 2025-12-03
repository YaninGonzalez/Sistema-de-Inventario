using System;
using System.Windows.Forms;

namespace InventarioBD
{
    
    public partial class Form1 : UserControl
    {
        
        private Control contenedorPadre;

        
        public Form1()
        {
            InitializeComponent();
        }

        
        public void SetContenedorPadre(Control contenedor)
        {
            this.contenedorPadre = contenedor;
        }

        //botón para ir a productos
        private void tsb_Poductos_Click(object sender, EventArgs e)
        {
            // Verifica que el contenedor padre exista para realizar la navegación
            if (contenedorPadre != null)
            {
                // elimina la vista actual (Form1).
                contenedorPadre.Controls.Clear();

                //la nueva vista (UserControl de Productos).
                Productos productosUC = new Productos();

                //ajusta el tamaño
                productosUC.Dock = DockStyle.Fill;

                //permite a Productos navegar de vuelta
                productosUC.SetContenedorPadre(contenedorPadre);

                //agrega la nueva vista (Productos) al contenedor.
                contenedorPadre.Controls.Add(productosUC);
            }
            else
            {
                //manejo de errores si la referencia al contenedor padre no fue establecida.
                MessageBox.Show("Error: contenedorPadre es NULL");
            }
        }

        //lo mismo pero para almacenes
        private void tsb_Almacenes_Click(object sender, EventArgs e)
        {
            if (contenedorPadre != null)
            {
                contenedorPadre.Controls.Clear();

                Almacenes almacenesUC = new Almacenes();
                
                almacenesUC.Dock = DockStyle.Fill;
                
                almacenesUC.SetContenedorPadre(contenedorPadre);
                
                contenedorPadre.Controls.Add(almacenesUC);
            }
            else
            {
                MessageBox.Show("Error: contenedorPadre es NULL");
            }
        }

        //cerrar sesión y regresar al login
        private void tsb_volverainiciosesion_Click(object sender, EventArgs e)
        {
            //diálogo de confirmación
            var resultado = MessageBox.Show(
            "¿Deseas cerrar sesión?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                //usa FindForm() para obtener el formulario (Form) que contiene a este UserControl.
                Form formPadre = this.FindForm();

                if (formPadre != null)
                {
                    // 2. Intenta convertir el formulario padre al tipo 'Iniciosesion'.
                    Iniciosesion inicioForm = formPadre as Iniciosesion;

                    if (inicioForm != null)
                    {
                        //lama a la función de la clase para limpiar el estado de la sesión.
                        SesionActual.CerrarSesion();

                        //lllama al método de reinicio en el formulario de inicio de sesión, rsto borra la vista actual y recrea la pantalla de login
                        inicioForm.ReiniciarFormulario();
                    }
                }
            }

        }
    }
}