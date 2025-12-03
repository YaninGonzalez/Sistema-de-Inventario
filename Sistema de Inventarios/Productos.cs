using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InventarioBD
{
    public partial class Productos : UserControl
    {
        private const string DB_FILE_NAME = "InventarioBD_2.db";

        // Conexión con la base de datos
        private string ConnectionString
        {
            get
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DB_FILE_NAME);
                return $"Data Source={dbPath};Version=3;";
            }
        }

        private Control contenedorPadre;

        public Productos()
        {
            InitializeComponent();
            CargarAlmacenesEnCombo();
            CargarProductos();

            //configurar permisos según el rol del usuario
            ConfigurarPermisos();

            dgvProductos.CellFormatting += DgvProductos_CellFormatting;

            //conecta cada campo de filtro para que al cambiar su valor se filtren automáticamente los productos
            if (txtFiltroNombre_Productos != null)
                txtFiltroNombre_Productos.TextChanged += AplicarFiltros;
            if (txtFiltroPreciomin_Productos != null)
                txtFiltroPreciomin_Productos.TextChanged += AplicarFiltros;
            if (txtFiltroPrecioMax_Productos != null)
                txtFiltroPrecioMax_Productos.TextChanged += AplicarFiltros;
            if (txtFiltroDepartamento_Productos != null)
                txtFiltroDepartamento_Productos.TextChanged += AplicarFiltros;
            if (txtFiltroCantidadmin_Productos != null)
                txtFiltroCantidadmin_Productos.TextChanged += AplicarFiltros;
            if (txtFiltroCantidadMax_Productos != null)
                txtFiltroCantidadMax_Productos.TextChanged += AplicarFiltros;
            if (txt_usuariomodProductos != null)
                txt_usuariomodProductos.TextChanged += AplicarFiltros;
            if (dtp_creacionProductos != null)
                dtp_creacionProductos.ValueChanged += AplicarFiltros;
            if (dtp_ultimamodProductos != null)
                dtp_ultimamodProductos.ValueChanged += AplicarFiltros;
            if (cb_almacen != null)
                cb_almacen.SelectedIndexChanged += AplicarFiltros;
        }

        //configurar permisos por rol
        private void ConfigurarPermisos()
        {
            bool puedeModificar = SesionActual.PuedeModificarProductos();

            // Mostrar u ocultar botones según permisos
            if (btn_AgregarProducto != null)
                btn_AgregarProducto.Visible = puedeModificar;

            if (btn_ModificarProductos != null)
                btn_ModificarProductos.Visible = puedeModificar;

            if (btn_EliminarProducto != null)
                btn_EliminarProducto.Visible = puedeModificar;
        }

        public void SetContenedorPadre(Control contenedor)
        {
            this.contenedorPadre = contenedor;
        }

        //para que el filtro de almacenes se vea con nombre y no id
        private void CargarAlmacenesEnCombo()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nombre FROM almacenes ORDER BY nombre";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DataRow rowTodos = dataTable.NewRow();
                    rowTodos["id"] = 0;
                    rowTodos["nombre"] = "-- Todos los almacenes --";
                    dataTable.Rows.InsertAt(rowTodos, 0);

                    if (cb_almacen != null)
                    {
                        cb_almacen.DisplayMember = "nombre";
                        cb_almacen.ValueMember = "id";
                        cb_almacen.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar almacenes: " + ex.Message);
                }
            }
        }

        //carga todo sin filtros
        private void CargarProductos()
        {
            CargarProductosConFiltros("", "", null, null, null, null, null, null, null, null);
        }

        //carga con filtros específocos
        private void CargarProductosConFiltros(string nombre, string departamento,
            decimal? precioMin, decimal? precioMax, int? cantidadMin, int? cantidadMax,
            DateTime? fechaCreacion, DateTime? fechaModificacion, string usuarioMod, int? almacenId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    StringBuilder query = new StringBuilder();

                    query.Append(@"SELECT 
                        p.id,
                        p.nombre,
                        p.precio,
                        p.cantidad,
                        p.departamento,
                        p.fecha_hora_creacion,
                        p.fecha_hora_ultima_modificacion,
                        p.ultimo_usuario_en_modificar,
                        a.nombre AS almacen
                    FROM productos p
                    LEFT JOIN almacenes a ON p.almacen = a.id
                    WHERE 1=1");


                    //agrega condiciones a la consulta según los filtros
                    if (!string.IsNullOrEmpty(nombre))
                        query.Append(" AND p.nombre LIKE @nombre");
                    if (!string.IsNullOrEmpty(departamento))
                        query.Append(" AND p.departamento LIKE @departamento");
                    if (precioMin.HasValue)
                        query.Append(" AND p.precio >= @precioMin");
                    if (precioMax.HasValue)
                        query.Append(" AND p.precio <= @precioMax");
                    if (cantidadMin.HasValue)
                        query.Append(" AND p.cantidad >= @cantidadMin");
                    if (cantidadMax.HasValue)
                        query.Append(" AND p.cantidad <= @cantidadMax");
                    if (fechaCreacion.HasValue)
                        query.Append(" AND DATE(p.fecha_hora_creacion) = @fechaCreacion");
                    if (fechaModificacion.HasValue)
                        query.Append(" AND DATE(p.fecha_hora_ultima_modificacion) = @fechaModificacion");
                    if (!string.IsNullOrEmpty(usuarioMod))
                        query.Append(" AND p.ultimo_usuario_en_modificar LIKE @usuarioMod");
                    if (almacenId.HasValue && almacenId.Value > 0)
                        query.Append(" AND p.almacen = @almacenId");

                    query.Append(" ORDER BY p.nombre");

                    SQLiteCommand cmd = new SQLiteCommand(query.ToString(), connection);

                    //agrega los valores de los parámetros a la consulta
                    if (!string.IsNullOrEmpty(nombre))
                        cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    if (!string.IsNullOrEmpty(departamento))
                        cmd.Parameters.AddWithValue("@departamento", "%" + departamento + "%");
                    if (precioMin.HasValue)
                        cmd.Parameters.AddWithValue("@precioMin", precioMin.Value);
                    if (precioMax.HasValue)
                        cmd.Parameters.AddWithValue("@precioMax", precioMax.Value);
                    if (cantidadMin.HasValue)
                        cmd.Parameters.AddWithValue("@cantidadMin", cantidadMin.Value);
                    if (cantidadMax.HasValue)
                        cmd.Parameters.AddWithValue("@cantidadMax", cantidadMax.Value);
                    if (fechaCreacion.HasValue)
                        cmd.Parameters.AddWithValue("@fechaCreacion", fechaCreacion.Value.ToString("yyyy-MM-dd"));
                    if (fechaModificacion.HasValue)
                        cmd.Parameters.AddWithValue("@fechaModificacion", fechaModificacion.Value.ToString("yyyy-MM-dd"));
                    if (!string.IsNullOrEmpty(usuarioMod))
                        cmd.Parameters.AddWithValue("@usuarioMod", "%" + usuarioMod + "%");
                    if (almacenId.HasValue && almacenId.Value > 0)
                        cmd.Parameters.AddWithValue("@almacenId", almacenId.Value);

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvProductos.DataSource = dataTable;
                    dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvProductos.Columns.Count > 0)
                    {
                        dgvProductos.Columns["id"].HeaderText = "ID";
                        dgvProductos.Columns["nombre"].HeaderText = "Nombre";
                        dgvProductos.Columns["precio"].HeaderText = "Precio";
                        dgvProductos.Columns["cantidad"].HeaderText = "Cantidad";
                        dgvProductos.Columns["departamento"].HeaderText = "Departamento";
                        dgvProductos.Columns["almacen"].HeaderText = "Almacén";
                        dgvProductos.Columns["fecha_hora_creacion"].HeaderText = "Fecha Creación";
                        dgvProductos.Columns["fecha_hora_ultima_modificacion"].HeaderText = "Última Modificación";
                        dgvProductos.Columns["ultimo_usuario_en_modificar"].HeaderText = "Usuario Modificó";

                        dgvProductos.Columns["id"].Visible = true;
                    }

                    if (lblResultados != null)
                    {
                        lblResultados.Text = $"Resultados: {dataTable.Rows.Count} productos";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message);
                }
            }
        }

        private void DgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "fecha_hora_creacion" ||
                dgvProductos.Columns[e.ColumnIndex].Name == "fecha_hora_ultima_modificacion")
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

        private void AplicarFiltros(object sender, EventArgs e)
        {
            string nombre = txtFiltroNombre_Productos?.Text.Trim() ?? "";
            string departamento = txtFiltroDepartamento_Productos?.Text.Trim() ?? "";
            string usuarioMod = txt_usuariomodProductos?.Text.Trim() ?? "";

            decimal? precioMin = null;
            if (txtFiltroPreciomin_Productos != null &&
                !string.IsNullOrEmpty(txtFiltroPreciomin_Productos.Text) &&
                decimal.TryParse(txtFiltroPreciomin_Productos.Text, out decimal pMin))
            {
                precioMin = pMin;
            }

            decimal? precioMax = null;
            if (txtFiltroPrecioMax_Productos != null &&
                !string.IsNullOrEmpty(txtFiltroPrecioMax_Productos.Text) &&
                decimal.TryParse(txtFiltroPrecioMax_Productos.Text, out decimal pMax))
            {
                precioMax = pMax;
            }

            int? cantidadMin = null;
            if (txtFiltroCantidadmin_Productos != null &&
                !string.IsNullOrEmpty(txtFiltroCantidadmin_Productos.Text) &&
                int.TryParse(txtFiltroCantidadmin_Productos.Text, out int cMin))
            {
                cantidadMin = cMin;
            }

            int? cantidadMax = null;
            if (txtFiltroCantidadMax_Productos != null &&
                !string.IsNullOrEmpty(txtFiltroCantidadMax_Productos.Text) &&
                int.TryParse(txtFiltroCantidadMax_Productos.Text, out int cMax))
            {
                cantidadMax = cMax;
            }

            DateTime? fechaCreacion = null;
            if (dtp_creacionProductos != null && dtp_creacionProductos.Checked)
            {
                fechaCreacion = dtp_creacionProductos.Value.Date;
            }

            DateTime? fechaModificacion = null;
            if (dtp_ultimamodProductos != null && dtp_ultimamodProductos.Checked)
            {
                fechaModificacion = dtp_ultimamodProductos.Value.Date;
            }

            int? almacenId = null;
            if (cb_almacen != null && cb_almacen.SelectedValue != null)
            {
                if (int.TryParse(cb_almacen.SelectedValue.ToString(), out int idAlmacen))
                {
                    almacenId = idAlmacen;
                }
            }

            CargarProductosConFiltros(nombre, departamento, precioMin, precioMax,
                cantidadMin, cantidadMax, fechaCreacion, fechaModificacion, usuarioMod, almacenId);
        }

        private void EliminarProducto(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM productos WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Producto eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsb_volverproductos_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnLimpiarFiltros_Click_1(object sender, EventArgs e)
        {
            if (txtFiltroNombre_Productos != null)
                txtFiltroNombre_Productos.Clear();
            if (txtFiltroPreciomin_Productos != null)
                txtFiltroPreciomin_Productos.Clear();
            if (txtFiltroPrecioMax_Productos != null)
                txtFiltroPrecioMax_Productos.Clear();
            if (txtFiltroDepartamento_Productos != null)
                txtFiltroDepartamento_Productos.Clear();
            if (txtFiltroCantidadmin_Productos != null)
                txtFiltroCantidadmin_Productos.Clear();
            if (txtFiltroCantidadMax_Productos != null)
                txtFiltroCantidadMax_Productos.Clear();
            if (txt_usuariomodProductos != null)
                txt_usuariomodProductos.Clear();
            if (dtp_creacionProductos != null)
                dtp_creacionProductos.Checked = false;
            if (dtp_ultimamodProductos != null)
                dtp_ultimamodProductos.Checked = false;
            if (cb_almacen != null)
                cb_almacen.SelectedIndex = 0;

            CargarProductos();
        }

        private void btn_AgregarProducto_Click(object sender, EventArgs e)
        {
            
            if (contenedorPadre != null)
            {
                contenedorPadre.Controls.Clear();
                FormularioProducto formulario = new FormularioProducto();
                formulario.Dock = DockStyle.Fill;
                formulario.SetContenedorPadre(contenedorPadre);
                contenedorPadre.Controls.Add(formulario);
            }
        }

        private void btn_ModificarProductos_Click(object sender, EventArgs e)
        {

            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["id"].Value);

                if (contenedorPadre != null)
                {
                    contenedorPadre.Controls.Clear();
                    FormularioProducto formulario = new FormularioProducto(idProducto);
                    formulario.Dock = DockStyle.Fill;
                    formulario.SetContenedorPadre(contenedorPadre);
                    contenedorPadre.Controls.Add(formulario);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para modificar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_EliminarProducto_Click(object sender, EventArgs e)
        {


            if (dgvProductos.SelectedRows.Count > 0)
            {
                var resultado = MessageBox.Show(
                    "¿Está seguro de eliminar este producto?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    int idProducto = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["id"].Value);
                    EliminarProducto(idProducto);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtp_creacionProductos_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtp_ultimamodProductos_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txt_usuariomodProductos_TextChanged(object sender, EventArgs e)
        {
        }

        private void cb_almacen_SelectedIndexChanged(object sender, EventArgs e)
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


        private void Productos_Load(object sender, EventArgs e)
        {
            RedondearControl(txtFiltroCantidadMax_Productos, 8);
            RedondearControl(txtFiltroCantidadmin_Productos, 8);
            RedondearControl(txtFiltroDepartamento_Productos, 8);
            RedondearControl(txtFiltroNombre_Productos, 8);
            RedondearControl(txtFiltroPrecioMax_Productos, 8);
            RedondearControl(txtFiltroPreciomin_Productos, 8);
            RedondearControl(btnLimpiarFiltros, 8);
            RedondearControl(txt_usuariomodProductos, 8);
            RedondearControl(cb_almacen, 8);
            RedondearControl(dtp_creacionProductos, 8);
            RedondearControl(dtp_ultimamodProductos, 8);
            RedondearControl(dgvProductos, 8);
            RedondearControl(panel1, 8);

        }
    }
}