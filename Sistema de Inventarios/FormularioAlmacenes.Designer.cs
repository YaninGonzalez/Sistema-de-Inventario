namespace InventarioBD
{
    partial class FormularioAlmacenes
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
            lblTitulo = new ToolStripLabel();
            tsb_atrásformularioalmacenes = new ToolStripButton();
            panel1 = new Panel();
            btnCancelarAlmacenes = new Button();
            btnGuardarAlamacenes = new Button();
            txtNombreFormularioAlmacenes = new TextBox();
            lblNombreFormularioAlmacenes = new Label();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 187, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { lblTitulo, tsb_atrásformularioalmacenes });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(976, 44);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(442, 41);
            lblTitulo.Text = "Agregar/Modificar Almacenes";
            // 
            // tsb_atrásformularioalmacenes
            // 
            tsb_atrásformularioalmacenes.Alignment = ToolStripItemAlignment.Right;
            tsb_atrásformularioalmacenes.Image = Properties.Resources.backicon;
            tsb_atrásformularioalmacenes.ImageTransparentColor = Color.Magenta;
            tsb_atrásformularioalmacenes.Name = "tsb_atrásformularioalmacenes";
            tsb_atrásformularioalmacenes.Size = new Size(67, 41);
            tsb_atrásformularioalmacenes.Text = "Atrás";
            tsb_atrásformularioalmacenes.Click += tsb_atrásformularioalmacenes_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 80, 155);
            panel1.Controls.Add(btnCancelarAlmacenes);
            panel1.Controls.Add(btnGuardarAlamacenes);
            panel1.Controls.Add(txtNombreFormularioAlmacenes);
            panel1.Controls.Add(lblNombreFormularioAlmacenes);
            panel1.Location = new Point(211, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 446);
            panel1.TabIndex = 1;
            // 
            // btnCancelarAlmacenes
            // 
            btnCancelarAlmacenes.BackColor = Color.FromArgb(248, 187, 0);
            btnCancelarAlmacenes.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarAlmacenes.Location = new Point(333, 315);
            btnCancelarAlmacenes.Name = "btnCancelarAlmacenes";
            btnCancelarAlmacenes.Size = new Size(166, 62);
            btnCancelarAlmacenes.TabIndex = 3;
            btnCancelarAlmacenes.Text = "Cancelar";
            btnCancelarAlmacenes.UseVisualStyleBackColor = false;
            btnCancelarAlmacenes.Click += btnCancelarAlmacenes_Click;
            // 
            // btnGuardarAlamacenes
            // 
            btnGuardarAlamacenes.BackColor = Color.FromArgb(248, 187, 0);
            btnGuardarAlamacenes.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarAlamacenes.Location = new Point(75, 315);
            btnGuardarAlamacenes.Name = "btnGuardarAlamacenes";
            btnGuardarAlamacenes.Size = new Size(186, 62);
            btnGuardarAlamacenes.TabIndex = 2;
            btnGuardarAlamacenes.Text = "Guardar";
            btnGuardarAlamacenes.UseVisualStyleBackColor = false;
            btnGuardarAlamacenes.Click += btnGuardarAlamacenes_Click;
            // 
            // txtNombreFormularioAlmacenes
            // 
            txtNombreFormularioAlmacenes.Location = new Point(84, 170);
            txtNombreFormularioAlmacenes.Name = "txtNombreFormularioAlmacenes";
            txtNombreFormularioAlmacenes.Size = new Size(444, 27);
            txtNombreFormularioAlmacenes.TabIndex = 1;
            // 
            // lblNombreFormularioAlmacenes
            // 
            lblNombreFormularioAlmacenes.AutoSize = true;
            lblNombreFormularioAlmacenes.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreFormularioAlmacenes.ForeColor = Color.White;
            lblNombreFormularioAlmacenes.Location = new Point(84, 112);
            lblNombreFormularioAlmacenes.Name = "lblNombreFormularioAlmacenes";
            lblNombreFormularioAlmacenes.Size = new Size(290, 38);
            lblNombreFormularioAlmacenes.TabIndex = 0;
            lblNombreFormularioAlmacenes.Text = "Nombre de almacén:";
            // 
            // FormularioAlmacenes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "FormularioAlmacenes";
            Size = new Size(976, 701);
            Load += FormularioAlmacenes_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel lblTitulo;
        private ToolStripButton tsb_atrásformularioalmacenes;
        private Panel panel1;
        private Button btnCancelarAlmacenes;
        private Button btnGuardarAlamacenes;
        private TextBox txtNombreFormularioAlmacenes;
        private Label lblNombreFormularioAlmacenes;
    }
}
