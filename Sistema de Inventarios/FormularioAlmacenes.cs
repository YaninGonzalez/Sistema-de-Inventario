using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioBD
{
    public partial class FormularioAlmacenes : UserControl
    {
        private const string DB_FILE_NAME = "InventarioBD_2.db";

        //conexión con la base de datos
        private string ConnectionString
        {
            get
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DB_FILE_NAME);
                return $"Data Source={dbPath};Version=3;";
            }
        }

        private Control contenedorPadre;
        private int? idAlmacenModificar = null;


        public FormularioAlmacenes()
        {
            InitializeComponent();
        }


        public FormularioAlmacenes(int idAlmacen) : this()
        {
            idAlmacenModificar = idAlmacen;


            if (lblTitulo != null)
                lblTitulo.Text = "Modificar Almacén";

            if (btnGuardarAlamacenes != null)
                btnGuardarAlamacenes.Text = "Guardar Cambios";

            CargarDatosAlmacen(idAlmacen);
        }

        public void SetContenedorPadre(Control contenedor)
        {
            this.contenedorPadre = contenedor;
        }

        private void CargarDatosAlmacen(int idAlmacen)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nombre FROM almacenes WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", idAlmacen);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            txtNombreFormularioAlmacenes.Text = resultado.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el almacén.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            VolverAAlmacenes();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar almacén: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //agregar y modificar almacen

        private void AgregarAlmacen()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO almacenes 
                        (nombre, fecha_hora_creacion, ultimo_usuario_en_modificar)
                        VALUES (@nombre, @fecha_creacion, @usuario)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombreFormularioAlmacenes.Text.Trim());
                        cmd.Parameters.AddWithValue("@fecha_creacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@usuario", SesionActual.NombreUsuario ?? "Admin");

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Almacén agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VolverAAlmacenes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar almacén: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ModificarAlmacen()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE almacenes 
                        SET nombre = @nombre,
                            fecha_hora_ultima_modificacion = @fecha_modificacion,
                            ultimo_usuario_en_modificar = @usuario
                        WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombreFormularioAlmacenes.Text.Trim());
                        cmd.Parameters.AddWithValue("@fecha_modificacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@usuario", SesionActual.NombreUsuario ?? "Admin");
                        cmd.Parameters.AddWithValue("@id", idAlmacenModificar.Value);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Almacén modificado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            VolverAAlmacenes();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el almacén.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar almacén: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //regresar a almacenes
        private void tsb_atrásformularioalmacenes_Click(object sender, EventArgs e)
        {
            VolverAAlmacenes();
        }

        private void VolverAAlmacenes()
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
                MessageBox.Show("Error: No se puede volver a la vista anterior.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //funcionamiento de botones de guardar y cancelar

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreFormularioAlmacenes.Text))
            {
                MessageBox.Show("El nombre del almacén es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreFormularioAlmacenes.Focus();
                return;
            }

            if (idAlmacenModificar == null)
                AgregarAlmacen();
            else
                ModificarAlmacen();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Está seguro que desea cancelar?\nSe perderán los cambios no guardados.",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                VolverAAlmacenes();
            }
        }
        private void btnGuardarAlamacenes_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }

        private void btnCancelarAlmacenes_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(sender, e);
        }

        private void RedondearControl(Control control, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }


        private void FormularioAlmacenes_Load(object sender, EventArgs e)
        {
            RedondearControl(txtNombreFormularioAlmacenes, 8);
            RedondearControl(panel1, 8);
            RedondearControl(btnCancelarAlmacenes, 8);
            RedondearControl(btnGuardarAlamacenes, 8);



        }
    }
}