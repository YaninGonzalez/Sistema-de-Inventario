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
    public partial class FormularioProducto : UserControl
    {
        private const string DB_FILE_NAME = "InventarioBD_2.db"; 

        
        private string ConnectionString
        {
            get
            {
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DB_FILE_NAME);
                return $"Data Source={dbPath};Version=3;";
            }
        }

        private Control contenedorPadre;
        private int? idProductoModificar = null;

        
        public FormularioProducto()
        {
            InitializeComponent();
            CargarAlmacenes();
        }

        
        public FormularioProducto(int idProducto) : this()
        {
            idProductoModificar = idProducto;

           
            if (label1 != null)
                label1.Text = "Modificar Producto";

            if (btn_Guardar != null)
                btn_Guardar.Text = "Guardar Cambios";

            CargarDatosProducto(idProducto);
        }

        public void SetContenedorPadre(Control contenedor)
        {
            this.contenedorPadre = contenedor;
        }

        private void CargarAlmacenes()
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

                    cboAlmacen.DisplayMember = "nombre";
                    cboAlmacen.ValueMember = "id";
                    cboAlmacen.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar almacenes: " + ex.Message, "Error");
                }
            }
        }

        private void CargarDatosProducto(int idProducto)
        {
            // Se usa ConnectionString en lugar de connectionString
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nombre, precio, cantidad, departamento, almacen FROM productos WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", idProducto);
                        SQLiteDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            txtNombreFormularioProducto.Text = reader["nombre"].ToString();
                            txtPrecioFormularioProducto.Text = reader["precio"].ToString();
                            txtCantidadFormularioProducto.Text = reader["cantidad"].ToString();
                            txtDepartamentoFormularioProducto.Text = reader["departamento"].ToString();
                            cboAlmacen.SelectedValue = Convert.ToInt32(reader["almacen"]);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            VolverAProductos();
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar producto: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void AgregarProducto()
        {
            
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO productos 
                        (nombre, precio, cantidad, departamento, almacen, fecha_hora_creacion, ultimo_usuario_en_modificar)
                        VALUES (@nombre, @precio, @cantidad, @departamento, @almacen, @fecha_creacion, @usuario)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombreFormularioProducto.Text.Trim());
                        cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecioFormularioProducto.Text));
                        cmd.Parameters.AddWithValue("@cantidad", int.Parse(txtCantidadFormularioProducto.Text));
                        cmd.Parameters.AddWithValue("@departamento", txtDepartamentoFormularioProducto.Text.Trim());
                        cmd.Parameters.AddWithValue("@almacen", cboAlmacen.SelectedValue);
                        cmd.Parameters.AddWithValue("@fecha_creacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@usuario", SesionActual.NombreUsuario ?? "Admin");

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Producto agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VolverAProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ModificarProducto()
        {
            
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE productos 
                        SET nombre = @nombre, precio = @precio, cantidad = @cantidad,
                            departamento = @departamento, almacen = @almacen,
                            fecha_hora_ultima_modificacion = @fecha_modificacion,
                            ultimo_usuario_en_modificar = @usuario
                        WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombreFormularioProducto.Text.Trim());
                        cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecioFormularioProducto.Text));
                        cmd.Parameters.AddWithValue("@cantidad", int.Parse(txtCantidadFormularioProducto.Text));
                        cmd.Parameters.AddWithValue("@departamento", txtDepartamentoFormularioProducto.Text.Trim());
                        cmd.Parameters.AddWithValue("@almacen", cboAlmacen.SelectedValue);
                        cmd.Parameters.AddWithValue("@fecha_modificacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@usuario", SesionActual.NombreUsuario ?? "Admin");
                        cmd.Parameters.AddWithValue("@id", idProductoModificar.Value);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Producto modificado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            VolverAProductos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar el producto.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            VolverAProductos();
        }

        private void VolverAProductos()
        {
            if (contenedorPadre != null)
            {
                contenedorPadre.Controls.Clear();
                Productos productosUC = new Productos();
                productosUC.Dock = DockStyle.Fill;
                productosUC.SetContenedorPadre(contenedorPadre);
                contenedorPadre.Controls.Add(productosUC);
            }
            else
            {
                MessageBox.Show("Error: No se puede volver a la vista anterior.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombreFormularioProducto.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecioFormularioProducto.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un precio válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidadFormularioProducto.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDepartamentoFormularioProducto.Text))
            {
                MessageBox.Show("El departamento es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cboAlmacen.Text))
            {
                MessageBox.Show("El Almacén es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idProductoModificar == null)
                AgregarProducto();
            else
                ModificarProducto();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {

            var resultado = MessageBox.Show(
                "¿Está seguro que desea cancelar?\nSe perderán los cambios no guardados.",
                "Confirmar cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                VolverAProductos();
            }
        }

        private void tsb_volveraproductos_Click(object sender, EventArgs e)
        {
            VolverAProductos();
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


        private void FormularioProductos_Load(object sender, EventArgs e)
        {
            RedondearControl(txtCantidadFormularioProducto, 8);
            RedondearControl(txtDepartamentoFormularioProducto, 8);
            RedondearControl(txtNombreFormularioProducto, 8);
            RedondearControl(txtPrecioFormularioProducto, 8);
            RedondearControl(btn_Cancelar, 8);
            RedondearControl(btn_Guardar, 8);
            RedondearControl(panel1, 8);


        }
    }
}