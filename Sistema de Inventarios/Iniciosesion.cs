using BCrypt.Net; //librería para el cifrado de contraseñas
using InventarioBD; // Necesario para Path.Combine
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace InventarioBD
{

    public partial class Iniciosesion : Form
    {
        // define la ruta de la base de datos SQLite.
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



        public Iniciosesion()
        {
            InitializeComponent();


            // configura la contraseña para que no se vean los caracteres
            txt_contraseña.UseSystemPasswordChar = true;
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


        private void Form_Load(object sender, EventArgs e)
        {
            RedondearControl(txt_nombreiniciosesion, 8);
            RedondearControl(txt_contraseña, 8);
            RedondearControl(btn_iniciarsesion, 8);
            RedondearControl(btn_otc, 8);

        }


        public void ReiniciarFormulario()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            txt_contraseña.UseSystemPasswordChar = true;
        }


        private void btn_otc_Click(object sender, EventArgs e)
        {
            // limpia los controles actuales del formulario
            this.Controls.Clear();
            // inicializa el botón de ProblemaTuyoPapics
            ProblemaTuyoPapics ptpUC = new ProblemaTuyoPapics();
            ptpUC.Dock = DockStyle.Fill;
            this.Controls.Add(ptpUC);
        }

        // este botón cifró contraseñas
        // este botón fue eliminado cuando todo fue cifrado
        private void btnCifrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Uso de ConnectionString
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    // Obtuvo los IDs y contraseñas (sin cifrar) de todos los usuarios
                    string query = "SELECT id, contraseña FROM usuarios";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    // almacenó los usuarios temporalmente
                    var usuarios = new List<(int id, string pass)>();
                    while (reader.Read())
                    {
                        usuarios.Add((reader.GetInt32(0), reader.GetString(1)));
                    }
                    reader.Close();

                    // itera sobre cada usuario para cifrar y actualizar
                    foreach (var usuario in usuarios)
                    {
                        // cifró la contraseña usando BCrypt 
                        string passCifrada = BCrypt.Net.BCrypt.HashPassword(usuario.pass);

                        // actualiza la contraseña cifrada en la base de datos.
                        string update = "UPDATE usuarios SET contraseña = @pass WHERE id = @id";

                        SQLiteCommand cmdUpdate = new SQLiteCommand(update, conn);
                        cmdUpdate.Parameters.AddWithValue("@pass", passCifrada);
                        cmdUpdate.Parameters.AddWithValue("@id", usuario.id);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show("¡Contraseñas cifradas!\n\nEliminar botón y probar el login.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // se ejecuta al intentar iniciar sesión.
        private void btn_iniciarsesion_Click(object sender, EventArgs e)
        {
            // limpia espacios en blanco del nombre de usuario y captura la contraseña
            string usuario = txt_nombreiniciosesion.Text.Trim();
            string contraseña = txt_contraseña.Text;

            // campos vacíos.
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "¡Campos vacíos!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // llama a la función de validación para verificar credenciales y obtener el rol.
            var credenciales = ValidarCredenciales(usuario, contraseña);

            if (credenciales.esValido)
            {
                // almacena el nombre y el rol del usuario logeado 
                SesionActual.NombreUsuario = usuario;
                SesionActual.RolUsuario = credenciales.rol;

                // registra la fecha y hora del último inicio de sesión en la Base de datos
                ActualizarUltimaSesion(usuario);

                // mensaje de bienvenida
                MessageBox.Show($"¡Bienvenido {usuario}!\n\nRol: {credenciales.rol}",
                    "¡Inicio exitoso!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // limpia el formulario de inicio de sesión
                this.Controls.Clear();
                // crea la vista principal
                Form1 formUC = new Form1();
                // ajuste para que ocupe el espacio en el formulario
                formUC.Dock = DockStyle.Fill;
                formUC.SetContenedorPadre(this);
                // muestra la vista principal
                this.Controls.Add(formUC);


            }
            else
            {
                // error para inicar sesión
                MessageBox.Show("Usuario o contraseña incorrecto.", "Error de autenticación.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_contraseña.Clear();
                txt_nombreiniciosesion.Focus();
            }
        }

        // función para verificar usuario y contraseña en la base de datos
        private (bool esValido, string rol) ValidarCredenciales(string usuario, string contraseña)
        {
            try
            {
                // Uso de ConnectionString
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    // consulta para obtener la contraseña cifrada y el rol por nombre de usuario
                    string query = "SELECT contraseña, rol FROM usuarios WHERE nombre = @nombre";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", usuario);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // obtiene la contraseña cifrada y el rol de la Base de datos
                                string contraseñaGuardada = reader["contraseña"].ToString();
                                string rol = reader["rol"].ToString();

                                // verifica la contraseña
                                bool esValido = BCrypt.Net.BCrypt.Verify(contraseña, contraseñaGuardada);

                                // retorna el resultado de la validación y el rol
                                return (esValido, rol);
                            }
                        }
                    }

                    // si el usuario no existe
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                // errores de conexión o base de datos
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false, null);
            }
        }

        // actualiza el campo 'ultima_sesion' del usuario.
        private void ActualizarUltimaSesion(string usuario)
        {
            try
            {
                // Uso de ConnectionString
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    // actualizar la columna de última sesión con la fecha actual
                    string query = "UPDATE usuarios SET ultima_sesion = @fecha WHERE nombre = @nombre";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // formato de fecha compatible con SQLite (ISO 8601)
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@nombre", usuario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
        }
    } 
}

// roles

// mantiene el estado del usuario activo en todo el programa
public static class SesionActual
{
    // propiedades para acceder al nombre y rol del usuario logeado
    public static string NombreUsuario { get; set; }
    public static string RolUsuario { get; set; }

    // restablece la sesión (se usaría al cerrar la aplicación o salir)
    public static void CerrarSesion()
    {
        NombreUsuario = null;
        RolUsuario = null;
    }

    // quien puede modificar productos
    public static bool PuedeModificarProductos()
    {
        return RolUsuario == "ADMIN" || RolUsuario == "PRODUCTOS";
    }

    // quien puede modificar almacenes
    public static bool PuedeModificarAlmacenes()
    {
        return RolUsuario == "ADMIN" || RolUsuario == "ALMACENES";
    }

    // verifica si hay un usuario logeado actualmente
    public static bool HaySesionActiva()
    {
        return !string.IsNullOrEmpty(NombreUsuario);
    }

}

