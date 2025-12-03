using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace InventarioBD
{
    public partial class Almacenes : UserControl
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

        public Almacenes()
        {
            InitializeComponent();

            


            if (dgvAlmacenes != null)
            {
                dgvAlmacenes.CellFormatting += DgvAlmacenes_CellFormatting;
            }

            CargarAlmacenes();

            //configura permisos según el rol del usuario
            ConfigurarPermisos();

            //configura los eventos de los filtros

            if (txtFiltroNombre_Almacenes != null)
            {
                txtFiltroNombre_Almacenes.TextChanged += AplicarFiltros;
            }

            if (txt_usuariomodAlmacenes != null)
            {
                txt_usuariomodAlmacenes.TextChanged += AplicarFiltros;
            }

            if (dtp_creacionAlmacenes != null)
            {
                dtp_creacionAlmacenes.ValueChanged += AplicarFiltros;
            }

            if (dtp_ultimamodAlmacenes != null)
            {
                dtp_ultimamodAlmacenes.ValueChanged += AplicarFiltros;
            }
            //limpiar filtros
            if (btnLimpiarFiltros_Almacenes != null)
            {
                btnLimpiarFiltros_Almacenes.Click += btnLimpiarFiltros_Click;
            }
        }

        //configurar permisos
        private void ConfigurarPermisos()
        {
            bool puedeModificar = SesionActual.PuedeModificarAlmacenes();

            //mostrar y ocultar botones
            if (btn_AgregarAlmacenes != null)
                btn_AgregarAlmacenes.Visible = puedeModificar;

            if (btn_ModificarAlmacenes != null)
                btn_ModificarAlmacenes.Visible = puedeModificar;

            if (btn_EliminarAlmacenes != null)
                btn_EliminarAlmacenes.Visible = puedeModificar;
        }
        //para navegar entre los user control
        public void SetContenedorPadre(Control contenedor)
        {
            this.contenedorPadre = contenedor;
        }

        //aplicación de filtros
        private void CargarAlmacenes()
        {
            CargarAlmacenesConFiltros("", null, null, "");
        }

        private void CargarAlmacenesConFiltros(string nombre, DateTime? fechaCreacion,
          DateTime? fechaModificacion, string usuarioMod)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT id, nombre, fecha_hora_creacion, fecha_hora_ultima_modificacion, ultimo_usuario_en_modificar FROM almacenes WHERE 1=1");

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        query.Append(" AND nombre LIKE @nombre");
                    }

                    if (fechaCreacion.HasValue)
                    {
                        query.Append(" AND DATE(fecha_hora_creacion) = @fechaCreacion");
                    }

                    if (fechaModificacion.HasValue)
                    {
                        query.Append(" AND DATE(fecha_hora_ultima_modificacion) = @fechaModificacion");
                    }

                    if (!string.IsNullOrEmpty(usuarioMod))
                    {
                        query.Append(" AND ultimo_usuario_en_modificar LIKE @usuarioMod");
                    }

                    query.Append(" ORDER BY nombre");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), connection);

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    }

                    if (fechaCreacion.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@fechaCreacion", fechaCreacion.Value.ToString("yyyy-MM-dd"));
                    }

                    if (fechaModificacion.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@fechaModificacion", fechaModificacion.Value.ToString("yyyy-MM-dd"));
                    }

                    if (!string.IsNullOrEmpty(usuarioMod))
                    {
                        cmd.Parameters.AddWithValue("@usuarioMod", "%" + usuarioMod + "%");
                    }

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvAlmacenes.DataSource = dataTable;
                    dgvAlmacenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvAlmacenes.Columns.Count > 0)
                    {
                        dgvAlmacenes.Columns["id"].HeaderText = "ID";
                        dgvAlmacenes.Columns["nombre"].HeaderText = "Nombre del Almacén";

                        if (dgvAlmacenes.Columns.Contains("fecha_hora_creacion"))
                        {
                            dgvAlmacenes.Columns["fecha_hora_creacion"].HeaderText = "Fecha de Creación";
                        }

                        if (dgvAlmacenes.Columns.Contains("fecha_hora_ultima_modificacion"))
                        {
                            dgvAlmacenes.Columns["fecha_hora_ultima_modificacion"].HeaderText = "Última Modificación";
                        }

                        if (dgvAlmacenes.Columns.Contains("ultimo_usuario_en_modificar"))
                        {
                            dgvAlmacenes.Columns["ultimo_usuario_en_modificar"].HeaderText = "Usuario Modificó";
                        }

                        dgvAlmacenes.Columns["id"].Visible = true;
                    }

                    if (lblResultados_Almacenes != null)
                    {
                        lblResultados_Almacenes.Text = $"Resultados: {dataTable.Rows.Count} almacenes";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar almacenes: " + ex.Message, "Error de BD");
                }
            }
        }
        //formateo de celda para las fechas
        private void DgvAlmacenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvAlmacenes.Columns[e.ColumnIndex].Name == "fecha_hora_creacion" ||
              dgvAlmacenes.Columns[e.ColumnIndex].Name == "fecha_hora_ultima_modificacion")
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    if (DateTime.TryParse(e.Value.ToString(), out DateTime fecha))
                    {
                        e.Value = fecha.ToString("dd/MM/yyyy HH:mm");
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = string.Empty;
                        e.FormattingApplied = true;
                    }
                }
            }
        }
        //llama a cargaralmacenesconfiltros
        private void AplicarFiltros(object sender, EventArgs e)
        {
            string nombre = txtFiltroNombre_Almacenes?.Text.Trim() ?? "";
            string usuarioMod = txt_usuariomodAlmacenes?.Text.Trim() ?? "";

            DateTime? fechaCreacion = null;
            if (dtp_creacionAlmacenes != null && dtp_creacionAlmacenes.Checked)
            {
                fechaCreacion = dtp_creacionAlmacenes.Value.Date;
            }

            DateTime? fechaModificacion = null;
            if (dtp_ultimamodAlmacenes != null && dtp_ultimamodAlmacenes.Checked)
            {
                fechaModificacion = dtp_ultimamodAlmacenes.Value.Date;
            }
            //recargar la lista
            CargarAlmacenesConFiltros(nombre, fechaCreacion, fechaModificacion, usuarioMod);
        }

        //limmia los filtros
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            if (txtFiltroNombre_Almacenes != null)
            {
                txtFiltroNombre_Almacenes.Clear();
            }

            if (txt_usuariomodAlmacenes != null)
            {
                txt_usuariomodAlmacenes.Clear();
            }

            if (dtp_creacionAlmacenes != null)
            {
                dtp_creacionAlmacenes.Checked = false;
            }

            if (dtp_ultimamodAlmacenes != null)
            {
                dtp_ultimamodAlmacenes.Checked = false;
            }

            CargarAlmacenes();
        }

        private void btnAgregarAlmacen_Click(object sender, EventArgs e)
        { 

            if (contenedorPadre != null)
            {
                contenedorPadre.Controls.Clear();
                FormularioAlmacenes formulario = new FormularioAlmacenes();
                formulario.Dock = DockStyle.Fill;
                formulario.SetContenedorPadre(contenedorPadre);
                contenedorPadre.Controls.Add(formulario);
            }
        }

        private void tbn_almacenes_Click(object sender, EventArgs e)
        {
            if (contenedorPadre != null)
            {
                contenedorPadre.Controls.Clear();
                Form1 formUC = new Form1();
                formUC.Dock = DockStyle.Fill;
                formUC.SetContenedorPadre(contenedorPadre);
                contenedorPadre.Controls.Add(formUC);
            }
        }

        private void btn_ModificarAlmacenes_Click(object sender, EventArgs e)
        {

            if (dgvAlmacenes.SelectedRows.Count > 0)
            {
                int idAlmacen = Convert.ToInt32(dgvAlmacenes.SelectedRows[0].Cells["id"].Value);

                if (contenedorPadre != null)
                {
                    contenedorPadre.Controls.Clear();
                    FormularioAlmacenes formulario = new FormularioAlmacenes(idAlmacen);
                    formulario.Dock = DockStyle.Fill;
                    formulario.SetContenedorPadre(contenedorPadre);
                    contenedorPadre.Controls.Add(formulario);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un almacén para modificar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarAlmacen(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM almacenes WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Almacén eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAlmacenes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar almacén: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_EliminarAlmacenes_Click_1(object sender, EventArgs e)
        {

            if (dgvAlmacenes.SelectedRows.Count > 0)
            {
                var resultado = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este almacén?\n\nADVERTENCIA: Esto puede afectar los productos asociados.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    int idAlmacen = Convert.ToInt32(dgvAlmacenes.SelectedRows[0].Cells["id"].Value);
                    EliminarAlmacen(idAlmacen);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un almacén para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_usuariomodAlmacenes_TextChanged(object sender, EventArgs e)
        {
        }

        private void dtp_creacionAlmacenes_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtp_ultimamodAlmacenes_ValueChanged(object sender, EventArgs e)
        {
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

        private void Almacenes_Load(object sender, EventArgs e)
        {
            RedondearControl(txtFiltroNombre_Almacenes, 8);
            RedondearControl(txt_usuariomodAlmacenes, 8);
            RedondearControl(btnLimpiarFiltros_Almacenes, 8);
            RedondearControl(dtp_creacionAlmacenes, 8);
            RedondearControl(dtp_ultimamodAlmacenes, 8);
            RedondearControl(dgvAlmacenes, 8);
            RedondearControl(panelFiltros_Almacenes, 8);

        }
    }
}