namespace InventarioBD
{
    partial class FormularioProducto
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
            toolStrip1 = new ToolStrip();
            tsb_volveraproductos = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            panel1 = new Panel();
            btn_Guardar = new Button();
            btn_Cancelar = new Button();
            cboAlmacen = new ComboBox();
            txtDepartamentoFormularioProducto = new TextBox();
            txtCantidadFormularioProducto = new TextBox();
            txtPrecioFormularioProducto = new TextBox();
            txtNombreFormularioProducto = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 187, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsb_volveraproductos, toolStripLabel1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1355, 44);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsb_volveraproductos
            // 
            tsb_volveraproductos.Alignment = ToolStripItemAlignment.Right;
            tsb_volveraproductos.Image = Properties.Resources.backicon;
            tsb_volveraproductos.ImageTransparentColor = Color.Magenta;
            tsb_volveraproductos.Name = "tsb_volveraproductos";
            tsb_volveraproductos.Size = new Size(67, 41);
            tsb_volveraproductos.Text = "Atrás";
            tsb_volveraproductos.Click += tsb_volveraproductos_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(421, 41);
            toolStripLabel1.Text = "Agregar/Modificar Producto";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 80, 155);
            panel1.Controls.Add(btn_Guardar);
            panel1.Controls.Add(btn_Cancelar);
            panel1.Controls.Add(cboAlmacen);
            panel1.Controls.Add(txtDepartamentoFormularioProducto);
            panel1.Controls.Add(txtCantidadFormularioProducto);
            panel1.Controls.Add(txtPrecioFormularioProducto);
            panel1.Controls.Add(txtNombreFormularioProducto);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(222, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(856, 582);
            panel1.TabIndex = 1;
            // 
            // btn_Guardar
            // 
            btn_Guardar.BackColor = Color.FromArgb(248, 187, 0);
            btn_Guardar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Guardar.Location = new Point(151, 502);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(168, 50);
            btn_Guardar.TabIndex = 12;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = false;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.BackColor = Color.FromArgb(248, 187, 0);
            btn_Cancelar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Cancelar.Location = new Point(537, 502);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(168, 50);
            btn_Cancelar.TabIndex = 11;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.UseVisualStyleBackColor = false;
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // cboAlmacen
            // 
            cboAlmacen.FormattingEnabled = true;
            cboAlmacen.Location = new Point(374, 405);
            cboAlmacen.Name = "cboAlmacen";
            cboAlmacen.Size = new Size(206, 28);
            cboAlmacen.TabIndex = 9;
            // 
            // txtDepartamentoFormularioProducto
            // 
            txtDepartamentoFormularioProducto.Location = new Point(374, 314);
            txtDepartamentoFormularioProducto.Name = "txtDepartamentoFormularioProducto";
            txtDepartamentoFormularioProducto.Size = new Size(238, 27);
            txtDepartamentoFormularioProducto.TabIndex = 8;
            // 
            // txtCantidadFormularioProducto
            // 
            txtCantidadFormularioProducto.Location = new Point(374, 222);
            txtCantidadFormularioProducto.Name = "txtCantidadFormularioProducto";
            txtCantidadFormularioProducto.Size = new Size(125, 27);
            txtCantidadFormularioProducto.TabIndex = 7;
            // 
            // txtPrecioFormularioProducto
            // 
            txtPrecioFormularioProducto.Location = new Point(374, 133);
            txtPrecioFormularioProducto.Name = "txtPrecioFormularioProducto";
            txtPrecioFormularioProducto.Size = new Size(125, 27);
            txtPrecioFormularioProducto.TabIndex = 6;
            // 
            // txtNombreFormularioProducto
            // 
            txtNombreFormularioProducto.Location = new Point(374, 50);
            txtNombreFormularioProducto.Name = "txtNombreFormularioProducto";
            txtNombreFormularioProducto.Size = new Size(297, 27);
            txtNombreFormularioProducto.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(229, 395);
            label5.Name = "label5";
            label5.Size = new Size(139, 38);
            label5.TabIndex = 4;
            label5.Text = "Almacén:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(151, 303);
            label4.Name = "label4";
            label4.Size = new Size(217, 38);
            label4.TabIndex = 3;
            label4.Text = "Departamento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(226, 211);
            label3.Name = "label3";
            label3.Size = new Size(142, 38);
            label3.TabIndex = 2;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(262, 122);
            label2.Name = "label2";
            label2.Size = new Size(106, 38);
            label2.TabIndex = 1;
            label2.Text = "Precio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(235, 39);
            label1.Name = "label1";
            label1.Size = new Size(133, 38);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // FormularioProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "FormularioProducto";
            Size = new Size(1355, 759);
            Load += FormularioProductos_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsb_volveraproductos;
        private Panel panel1;
        private ToolStripLabel toolStripLabel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCantidadFormularioProducto;
        private TextBox txtPrecioFormularioProducto;
        private TextBox txtNombreFormularioProducto;
        private Label label5;
        private Label label4;
        private Button btn_Cancelar;
        private ComboBox cboAlmacen;
        private TextBox txtDepartamentoFormularioProducto;
        private Button btn_Guardar;
    }
}
