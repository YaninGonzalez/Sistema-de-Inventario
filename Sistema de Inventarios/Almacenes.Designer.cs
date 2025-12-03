
namespace InventarioBD
{
    partial class Almacenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Almacenes));
            toolStrip1 = new ToolStrip();
            tbn_almacenes = new ToolStripButton();
            lb_Almacenes = new Label();
            dgvAlmacenes = new DataGridView();
            btn_EliminarAlmacenes = new Button();
            btn_AgregarAlmacenes = new Button();
            btn_ModificarAlmacenes = new Button();
            panelFiltros_Almacenes = new Panel();
            txt_usuariomodAlmacenes = new TextBox();
            lblusuarioquemodAlmacenes = new Label();
            lbl_fechaultimamodalmacenes = new Label();
            btnLimpiarFiltros_Almacenes = new Button();
            dtp_creacionAlmacenes = new DateTimePicker();
            label = new Label();
            dtp_ultimamodAlmacenes = new DateTimePicker();
            txtFiltroNombre_Almacenes = new TextBox();
            lbl_fechacreacionAlmacenes = new Label();
            lblResultados_Almacenes = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlmacenes).BeginInit();
            panelFiltros_Almacenes.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 187, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tbn_almacenes });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1364, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tbn_almacenes
            // 
            tbn_almacenes.Alignment = ToolStripItemAlignment.Right;
            tbn_almacenes.Image = (Image)resources.GetObject("tbn_almacenes.Image");
            tbn_almacenes.ImageTransparentColor = Color.Magenta;
            tbn_almacenes.Name = "tbn_almacenes";
            tbn_almacenes.Size = new Size(67, 24);
            tbn_almacenes.Text = "Atrás";
            tbn_almacenes.Click += tbn_almacenes_Click;
            // 
            // lb_Almacenes
            // 
            lb_Almacenes.AutoSize = true;
            lb_Almacenes.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Almacenes.ForeColor = Color.FromArgb(1, 80, 155);
            lb_Almacenes.Location = new Point(0, 27);
            lb_Almacenes.Name = "lb_Almacenes";
            lb_Almacenes.Size = new Size(168, 41);
            lb_Almacenes.TabIndex = 1;
            lb_Almacenes.Text = "Almacenes";
            // 
            // dgvAlmacenes
            // 
            dgvAlmacenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlmacenes.Location = new Point(161, 210);
            dgvAlmacenes.Name = "dgvAlmacenes";
            dgvAlmacenes.RowHeadersWidth = 51;
            dgvAlmacenes.Size = new Size(1070, 357);
            dgvAlmacenes.TabIndex = 2;
            // 
            // btn_EliminarAlmacenes
            // 
            btn_EliminarAlmacenes.BackColor = Color.Red;
            btn_EliminarAlmacenes.ForeColor = Color.Maroon;
            btn_EliminarAlmacenes.Location = new Point(1201, 573);
            btn_EliminarAlmacenes.Name = "btn_EliminarAlmacenes";
            btn_EliminarAlmacenes.Size = new Size(94, 29);
            btn_EliminarAlmacenes.TabIndex = 5;
            btn_EliminarAlmacenes.Text = "Eliminar";
            btn_EliminarAlmacenes.UseVisualStyleBackColor = false;
            btn_EliminarAlmacenes.Click += btn_EliminarAlmacenes_Click_1;
            // 
            // btn_AgregarAlmacenes
            // 
            btn_AgregarAlmacenes.BackColor = Color.Green;
            btn_AgregarAlmacenes.ForeColor = Color.FromArgb(0, 64, 0);
            btn_AgregarAlmacenes.Location = new Point(1001, 573);
            btn_AgregarAlmacenes.Name = "btn_AgregarAlmacenes";
            btn_AgregarAlmacenes.Size = new Size(94, 29);
            btn_AgregarAlmacenes.TabIndex = 6;
            btn_AgregarAlmacenes.Text = "Agregar";
            btn_AgregarAlmacenes.UseVisualStyleBackColor = false;
            btn_AgregarAlmacenes.Click += btnAgregarAlmacen_Click;
            // 
            // btn_ModificarAlmacenes
            // 
            btn_ModificarAlmacenes.BackColor = Color.FromArgb(1, 80, 155);
            btn_ModificarAlmacenes.ForeColor = Color.Navy;
            btn_ModificarAlmacenes.Location = new Point(1101, 573);
            btn_ModificarAlmacenes.Name = "btn_ModificarAlmacenes";
            btn_ModificarAlmacenes.Size = new Size(94, 29);
            btn_ModificarAlmacenes.TabIndex = 7;
            btn_ModificarAlmacenes.Text = "Modificar";
            btn_ModificarAlmacenes.UseVisualStyleBackColor = false;
            btn_ModificarAlmacenes.Click += btn_ModificarAlmacenes_Click;
            // 
            // panelFiltros_Almacenes
            // 
            panelFiltros_Almacenes.BackColor = Color.FromArgb(1, 80, 155);
            panelFiltros_Almacenes.Controls.Add(txt_usuariomodAlmacenes);
            panelFiltros_Almacenes.Controls.Add(lblusuarioquemodAlmacenes);
            panelFiltros_Almacenes.Controls.Add(lbl_fechaultimamodalmacenes);
            panelFiltros_Almacenes.Controls.Add(btnLimpiarFiltros_Almacenes);
            panelFiltros_Almacenes.Controls.Add(dtp_creacionAlmacenes);
            panelFiltros_Almacenes.Controls.Add(label);
            panelFiltros_Almacenes.Controls.Add(dtp_ultimamodAlmacenes);
            panelFiltros_Almacenes.Controls.Add(txtFiltroNombre_Almacenes);
            panelFiltros_Almacenes.Controls.Add(lbl_fechacreacionAlmacenes);
            panelFiltros_Almacenes.Location = new Point(214, 89);
            panelFiltros_Almacenes.Name = "panelFiltros_Almacenes";
            panelFiltros_Almacenes.Size = new Size(944, 87);
            panelFiltros_Almacenes.TabIndex = 8;
            // 
            // txt_usuariomodAlmacenes
            // 
            txt_usuariomodAlmacenes.Location = new Point(135, 21);
            txt_usuariomodAlmacenes.Name = "txt_usuariomodAlmacenes";
            txt_usuariomodAlmacenes.Size = new Size(125, 27);
            txt_usuariomodAlmacenes.TabIndex = 7;
            txt_usuariomodAlmacenes.TextChanged += txt_usuariomodAlmacenes_TextChanged;
            // 
            // lblusuarioquemodAlmacenes
            // 
            lblusuarioquemodAlmacenes.AutoSize = true;
            lblusuarioquemodAlmacenes.ForeColor = Color.FromArgb(248, 187, 0);
            lblusuarioquemodAlmacenes.Location = new Point(40, 8);
            lblusuarioquemodAlmacenes.Name = "lblusuarioquemodAlmacenes";
            lblusuarioquemodAlmacenes.Size = new Size(92, 40);
            lblusuarioquemodAlmacenes.TabIndex = 6;
            lblusuarioquemodAlmacenes.Text = "Usuario que \r\n    modificó:";
            // 
            // lbl_fechaultimamodalmacenes
            // 
            lbl_fechaultimamodalmacenes.AutoSize = true;
            lbl_fechaultimamodalmacenes.ForeColor = Color.FromArgb(248, 187, 0);
            lbl_fechaultimamodalmacenes.Location = new Point(587, 61);
            lbl_fechaultimamodalmacenes.Name = "lbl_fechaultimamodalmacenes";
            lbl_fechaultimamodalmacenes.Size = new Size(208, 20);
            lbl_fechaultimamodalmacenes.TabIndex = 4;
            lbl_fechaultimamodalmacenes.Text = "Fecha de última modificación:";
            // 
            // btnLimpiarFiltros_Almacenes
            // 
            btnLimpiarFiltros_Almacenes.BackColor = Color.FromArgb(248, 187, 0);
            btnLimpiarFiltros_Almacenes.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiarFiltros_Almacenes.Location = new Point(295, 8);
            btnLimpiarFiltros_Almacenes.Name = "btnLimpiarFiltros_Almacenes";
            btnLimpiarFiltros_Almacenes.Size = new Size(131, 40);
            btnLimpiarFiltros_Almacenes.TabIndex = 2;
            btnLimpiarFiltros_Almacenes.Text = "Limpiar";
            btnLimpiarFiltros_Almacenes.UseVisualStyleBackColor = false;
            // 
            // dtp_creacionAlmacenes
            // 
            dtp_creacionAlmacenes.Location = new Point(429, 57);
            dtp_creacionAlmacenes.Name = "dtp_creacionAlmacenes";
            dtp_creacionAlmacenes.Size = new Size(125, 27);
            dtp_creacionAlmacenes.TabIndex = 4;
            dtp_creacionAlmacenes.ValueChanged += dtp_creacionAlmacenes_ValueChanged;
            // 
            // label
            // 
            label.AutoSize = true;
            label.ForeColor = Color.FromArgb(248, 187, 0);
            label.Location = new Point(21, 58);
            label.Name = "label";
            label.Size = new Size(111, 20);
            label.TabIndex = 0;
            label.Text = "Buscar nombre:";
            // 
            // dtp_ultimamodAlmacenes
            // 
            dtp_ultimamodAlmacenes.Location = new Point(801, 54);
            dtp_ultimamodAlmacenes.Name = "dtp_ultimamodAlmacenes";
            dtp_ultimamodAlmacenes.Size = new Size(125, 27);
            dtp_ultimamodAlmacenes.TabIndex = 5;
            dtp_ultimamodAlmacenes.ValueChanged += dtp_ultimamodAlmacenes_ValueChanged;
            // 
            // txtFiltroNombre_Almacenes
            // 
            txtFiltroNombre_Almacenes.Location = new Point(135, 58);
            txtFiltroNombre_Almacenes.Name = "txtFiltroNombre_Almacenes";
            txtFiltroNombre_Almacenes.Size = new Size(125, 27);
            txtFiltroNombre_Almacenes.TabIndex = 1;
            // 
            // lbl_fechacreacionAlmacenes
            // 
            lbl_fechacreacionAlmacenes.AutoSize = true;
            lbl_fechacreacionAlmacenes.ForeColor = Color.FromArgb(248, 187, 0);
            lbl_fechacreacionAlmacenes.Location = new Point(295, 61);
            lbl_fechacreacionAlmacenes.Name = "lbl_fechacreacionAlmacenes";
            lbl_fechacreacionAlmacenes.Size = new Size(131, 20);
            lbl_fechacreacionAlmacenes.TabIndex = 3;
            lbl_fechacreacionAlmacenes.Text = "Fecha de creación:";
            // 
            // lblResultados_Almacenes
            // 
            lblResultados_Almacenes.AutoSize = true;
            lblResultados_Almacenes.Location = new Point(220, 186);
            lblResultados_Almacenes.Name = "lblResultados_Almacenes";
            lblResultados_Almacenes.Size = new Size(96, 20);
            lblResultados_Almacenes.TabIndex = 9;
            lblResultados_Almacenes.Text = "Resultados: 0";
            // 
            // Almacenes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblResultados_Almacenes);
            Controls.Add(panelFiltros_Almacenes);
            Controls.Add(btn_ModificarAlmacenes);
            Controls.Add(btn_AgregarAlmacenes);
            Controls.Add(btn_EliminarAlmacenes);
            Controls.Add(dgvAlmacenes);
            Controls.Add(lb_Almacenes);
            Controls.Add(toolStrip1);
            Name = "Almacenes";
            Size = new Size(1364, 706);
            Load += Almacenes_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlmacenes).EndInit();
            panelFiltros_Almacenes.ResumeLayout(false);
            panelFiltros_Almacenes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tbn_almacenes;
        private Label lb_Almacenes;
        private DataGridView dgvAlmacenes;
        private Button btn_EliminarAlmacenes;
        private Button btn_AgregarAlmacenes;
        private Button btn_ModificarAlmacenes;
        private Panel panelFiltros_Almacenes;
        private TextBox txtFiltroNombre_Almacenes;
        private Label label;
        private Button btnLimpiarFiltros_Almacenes;
        private Label lblResultados_Almacenes;
        private Label lbl_fechacreacionAlmacenes;
        private Label lbl_fechaultimamodalmacenes;
        private DateTimePicker dtp_creacionAlmacenes;
        private DateTimePicker dtp_ultimamodAlmacenes;
        private TextBox txt_usuariomodAlmacenes;
        private Label lblusuarioquemodAlmacenes;
    }
}