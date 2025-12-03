namespace InventarioBD
{
    partial class Productos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos));
            toolStrip1 = new ToolStrip();
            tsb_volverproductos = new ToolStripButton();
            lb_ProductosNombre = new Label();
            dgvProductos = new DataGridView();
            btn_EliminarProducto = new Button();
            btn_AgregarProducto = new Button();
            btn_ModificarProductos = new Button();
            panel1 = new Panel();
            txt_usuariomodProductos = new TextBox();
            dtp_ultimamodProductos = new DateTimePicker();
            dtp_creacionProductos = new DateTimePicker();
            cb_almacen = new ComboBox();
            lbl_ultimomodifico = new Label();
            lbl_Fechaultimamod = new Label();
            lbl_fechacreacionProductos = new Label();
            lblAlmacenProductos = new Label();
            btnLimpiarFiltros = new Button();
            txtFiltroCantidadMax_Productos = new TextBox();
            txtFiltroCantidadmin_Productos = new TextBox();
            txtFiltroDepartamento_Productos = new TextBox();
            txtFiltroPrecioMax_Productos = new TextBox();
            txtFiltroPreciomin_Productos = new TextBox();
            txtFiltroNombre_Productos = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblResultados = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 187, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsb_volverproductos });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1447, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsb_volverproductos
            // 
            tsb_volverproductos.Alignment = ToolStripItemAlignment.Right;
            tsb_volverproductos.Image = (Image)resources.GetObject("tsb_volverproductos.Image");
            tsb_volverproductos.ImageTransparentColor = Color.Magenta;
            tsb_volverproductos.Name = "tsb_volverproductos";
            tsb_volverproductos.Size = new Size(67, 24);
            tsb_volverproductos.Text = "Atrás";
            tsb_volverproductos.Click += tsb_volverproductos_Click;
            // 
            // lb_ProductosNombre
            // 
            lb_ProductosNombre.AutoSize = true;
            lb_ProductosNombre.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_ProductosNombre.ForeColor = Color.FromArgb(1, 80, 155);
            lb_ProductosNombre.Location = new Point(3, 25);
            lb_ProductosNombre.Name = "lb_ProductosNombre";
            lb_ProductosNombre.Size = new Size(160, 41);
            lb_ProductosNombre.TabIndex = 1;
            lb_ProductosNombre.Text = "Productos";
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(3, 295);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(1419, 411);
            dgvProductos.TabIndex = 2;
            // 
            // btn_EliminarProducto
            // 
            btn_EliminarProducto.BackColor = Color.Red;
            btn_EliminarProducto.ForeColor = Color.Maroon;
            btn_EliminarProducto.Location = new Point(1246, 712);
            btn_EliminarProducto.Name = "btn_EliminarProducto";
            btn_EliminarProducto.Size = new Size(94, 29);
            btn_EliminarProducto.TabIndex = 7;
            btn_EliminarProducto.Text = "Eliminar";
            btn_EliminarProducto.UseVisualStyleBackColor = false;
            btn_EliminarProducto.Click += btn_EliminarProducto_Click;
            // 
            // btn_AgregarProducto
            // 
            btn_AgregarProducto.BackColor = Color.Green;
            btn_AgregarProducto.ForeColor = Color.FromArgb(0, 64, 0);
            btn_AgregarProducto.Location = new Point(1046, 712);
            btn_AgregarProducto.Name = "btn_AgregarProducto";
            btn_AgregarProducto.Size = new Size(94, 29);
            btn_AgregarProducto.TabIndex = 8;
            btn_AgregarProducto.Text = "Agregar";
            btn_AgregarProducto.UseVisualStyleBackColor = false;
            btn_AgregarProducto.Click += btn_AgregarProducto_Click;
            // 
            // btn_ModificarProductos
            // 
            btn_ModificarProductos.BackColor = Color.FromArgb(1, 80, 155);
            btn_ModificarProductos.ForeColor = Color.Navy;
            btn_ModificarProductos.Location = new Point(1146, 712);
            btn_ModificarProductos.Name = "btn_ModificarProductos";
            btn_ModificarProductos.Size = new Size(94, 29);
            btn_ModificarProductos.TabIndex = 9;
            btn_ModificarProductos.Text = "Modificar";
            btn_ModificarProductos.UseVisualStyleBackColor = false;
            btn_ModificarProductos.Click += btn_ModificarProductos_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 80, 155);
            panel1.Controls.Add(txt_usuariomodProductos);
            panel1.Controls.Add(dtp_ultimamodProductos);
            panel1.Controls.Add(dtp_creacionProductos);
            panel1.Controls.Add(cb_almacen);
            panel1.Controls.Add(lbl_ultimomodifico);
            panel1.Controls.Add(lbl_Fechaultimamod);
            panel1.Controls.Add(lbl_fechacreacionProductos);
            panel1.Controls.Add(lblAlmacenProductos);
            panel1.Controls.Add(btnLimpiarFiltros);
            panel1.Controls.Add(txtFiltroCantidadMax_Productos);
            panel1.Controls.Add(txtFiltroCantidadmin_Productos);
            panel1.Controls.Add(txtFiltroDepartamento_Productos);
            panel1.Controls.Add(txtFiltroPrecioMax_Productos);
            panel1.Controls.Add(txtFiltroPreciomin_Productos);
            panel1.Controls.Add(txtFiltroNombre_Productos);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(29, 115);
            panel1.Name = "panel1";
            panel1.Size = new Size(1366, 137);
            panel1.TabIndex = 10;
            panel1.Paint += panel1_Paint;
            // 
            // txt_usuariomodProductos
            // 
            txt_usuariomodProductos.Location = new Point(1156, 12);
            txt_usuariomodProductos.Name = "txt_usuariomodProductos";
            txt_usuariomodProductos.Size = new Size(136, 27);
            txt_usuariomodProductos.TabIndex = 20;
            txt_usuariomodProductos.TextChanged += txt_usuariomodProductos_TextChanged;
            // 
            // dtp_ultimamodProductos
            // 
            dtp_ultimamodProductos.Location = new Point(920, 48);
            dtp_ultimamodProductos.Name = "dtp_ultimamodProductos";
            dtp_ultimamodProductos.Size = new Size(136, 27);
            dtp_ultimamodProductos.TabIndex = 19;
            dtp_ultimamodProductos.ValueChanged += dtp_ultimamodProductos_ValueChanged;
            // 
            // dtp_creacionProductos
            // 
            dtp_creacionProductos.Location = new Point(920, 11);
            dtp_creacionProductos.Name = "dtp_creacionProductos";
            dtp_creacionProductos.Size = new Size(136, 27);
            dtp_creacionProductos.TabIndex = 18;
            dtp_creacionProductos.ValueChanged += dtp_creacionProductos_ValueChanged;
            // 
            // cb_almacen
            // 
            cb_almacen.FormattingEnabled = true;
            cb_almacen.Location = new Point(1156, 47);
            cb_almacen.Name = "cb_almacen";
            cb_almacen.Size = new Size(136, 28);
            cb_almacen.TabIndex = 17;
            cb_almacen.SelectedIndexChanged += cb_almacen_SelectedIndexChanged;
            // 
            // lbl_ultimomodifico
            // 
            lbl_ultimomodifico.AutoSize = true;
            lbl_ultimomodifico.ForeColor = Color.FromArgb(248, 187, 0);
            lbl_ultimomodifico.Location = new Point(1065, 6);
            lbl_ultimomodifico.Name = "lbl_ultimomodifico";
            lbl_ultimomodifico.Size = new Size(92, 40);
            lbl_ultimomodifico.TabIndex = 16;
            lbl_ultimomodifico.Text = "Usuario que \r\n    modificó:";
            // 
            // lbl_Fechaultimamod
            // 
            lbl_Fechaultimamod.AutoSize = true;
            lbl_Fechaultimamod.ForeColor = Color.FromArgb(248, 187, 0);
            lbl_Fechaultimamod.Location = new Point(796, 40);
            lbl_Fechaultimamod.Name = "lbl_Fechaultimamod";
            lbl_Fechaultimamod.Size = new Size(118, 40);
            lbl_Fechaultimamod.TabIndex = 15;
            lbl_Fechaultimamod.Text = "Fecha de última \r\n    modificación:";
            // 
            // lbl_fechacreacionProductos
            // 
            lbl_fechacreacionProductos.AutoSize = true;
            lbl_fechacreacionProductos.ForeColor = Color.FromArgb(248, 187, 0);
            lbl_fechacreacionProductos.Location = new Point(783, 14);
            lbl_fechacreacionProductos.Name = "lbl_fechacreacionProductos";
            lbl_fechacreacionProductos.Size = new Size(131, 20);
            lbl_fechacreacionProductos.TabIndex = 14;
            lbl_fechacreacionProductos.Text = "Fecha de creación:";
            // 
            // lblAlmacenProductos
            // 
            lblAlmacenProductos.AutoSize = true;
            lblAlmacenProductos.ForeColor = Color.FromArgb(248, 187, 0);
            lblAlmacenProductos.Location = new Point(1080, 55);
            lblAlmacenProductos.Name = "lblAlmacenProductos";
            lblAlmacenProductos.Size = new Size(70, 20);
            lblAlmacenProductos.TabIndex = 13;
            lblAlmacenProductos.Text = "Almacén:";
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(248, 187, 0);
            btnLimpiarFiltros.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiarFiltros.Location = new Point(48, 80);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(126, 39);
            btnLimpiarFiltros.TabIndex = 12;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click_1;
            // 
            // txtFiltroCantidadMax_Productos
            // 
            txtFiltroCantidadMax_Productos.Location = new Point(391, 47);
            txtFiltroCantidadMax_Productos.Name = "txtFiltroCantidadMax_Productos";
            txtFiltroCantidadMax_Productos.Size = new Size(136, 27);
            txtFiltroCantidadMax_Productos.TabIndex = 11;
            // 
            // txtFiltroCantidadmin_Productos
            // 
            txtFiltroCantidadmin_Productos.Location = new Point(391, 11);
            txtFiltroCantidadmin_Productos.Name = "txtFiltroCantidadmin_Productos";
            txtFiltroCantidadmin_Productos.Size = new Size(136, 27);
            txtFiltroCantidadmin_Productos.TabIndex = 10;
            // 
            // txtFiltroDepartamento_Productos
            // 
            txtFiltroDepartamento_Productos.Location = new Point(121, 47);
            txtFiltroDepartamento_Productos.Name = "txtFiltroDepartamento_Productos";
            txtFiltroDepartamento_Productos.Size = new Size(136, 27);
            txtFiltroDepartamento_Productos.TabIndex = 9;
            // 
            // txtFiltroPrecioMax_Productos
            // 
            txtFiltroPrecioMax_Productos.Location = new Point(647, 47);
            txtFiltroPrecioMax_Productos.Name = "txtFiltroPrecioMax_Productos";
            txtFiltroPrecioMax_Productos.Size = new Size(136, 27);
            txtFiltroPrecioMax_Productos.TabIndex = 8;
            // 
            // txtFiltroPreciomin_Productos
            // 
            txtFiltroPreciomin_Productos.Location = new Point(647, 10);
            txtFiltroPreciomin_Productos.Name = "txtFiltroPreciomin_Productos";
            txtFiltroPreciomin_Productos.Size = new Size(136, 27);
            txtFiltroPreciomin_Productos.TabIndex = 7;
            // 
            // txtFiltroNombre_Productos
            // 
            txtFiltroNombre_Productos.Location = new Point(121, 11);
            txtFiltroNombre_Productos.Name = "txtFiltroNombre_Productos";
            txtFiltroNombre_Productos.Size = new Size(136, 27);
            txtFiltroNombre_Productos.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.FromArgb(248, 187, 0);
            label6.Location = new Point(259, 50);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 5;
            label6.Text = "Cantidad máxima:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(248, 187, 0);
            label5.Location = new Point(259, 16);
            label5.Name = "label5";
            label5.Size = new Size(126, 20);
            label5.TabIndex = 4;
            label5.Text = "Cantidad mínima:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(248, 187, 0);
            label4.Location = new Point(6, 50);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 3;
            label4.Text = "Departamento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(248, 187, 0);
            label3.Location = new Point(530, 47);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 2;
            label3.Text = "Precio máximo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(248, 187, 0);
            label2.Location = new Point(533, 15);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 1;
            label2.Text = "Precio mínimo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(248, 187, 0);
            label1.Location = new Point(48, 11);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Location = new Point(77, 272);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(84, 20);
            lblResultados.TabIndex = 11;
            lblResultados.Text = "Resultados:";
            // 
            // Productos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblResultados);
            Controls.Add(panel1);
            Controls.Add(btn_ModificarProductos);
            Controls.Add(btn_AgregarProducto);
            Controls.Add(btn_EliminarProducto);
            Controls.Add(dgvProductos);
            Controls.Add(lb_ProductosNombre);
            Controls.Add(toolStrip1);
            Name = "Productos";
            Size = new Size(1447, 839);
            Load += Productos_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private Label lb_ProductosNombre;
        private DataGridView dgvProductos;
        private Button btn_EliminarProducto;
        private Button btn_AgregarProducto;
        private ToolStripButton tsb_volverproductos;
        private Button btn_ModificarProductos;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtFiltroCantidadMax_Productos;
        private TextBox txtFiltroCantidadmin_Productos;
        private TextBox txtFiltroDepartamento_Productos;
        private TextBox txtFiltroPrecioMax_Productos;
        private TextBox txtFiltroPreciomin_Productos;
        private TextBox txtFiltroNombre_Productos;
        private Button btnLimpiarFiltros;
        private Label lblResultados;
        private Label lbl_ultimomodifico;
        private Label lbl_Fechaultimamod;
        private Label lbl_fechacreacionProductos;
        private Label lblAlmacenProductos;
        private DateTimePicker dtp_creacionProductos;
        private ComboBox cb_almacen;
        private TextBox txt_usuariomodProductos;
        private DateTimePicker dtp_ultimamodProductos;
    }
}
