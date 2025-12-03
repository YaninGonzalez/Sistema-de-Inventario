namespace InventarioBD
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            tsb_Productos = new ToolStripButton();
            tsb_Almacenes = new ToolStripButton();
            tsb_volverainiciosesion = new ToolStripButton();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 187, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsb_Productos, tsb_Almacenes, tsb_volverainiciosesion });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1362, 48);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsb_Productos
            // 
            tsb_Productos.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsb_Productos.Image = (Image)resources.GetObject("tsb_Productos.Image");
            tsb_Productos.ImageTransparentColor = Color.Magenta;
            tsb_Productos.Name = "tsb_Productos";
            tsb_Productos.Size = new Size(184, 45);
            tsb_Productos.Text = "Productos";
            tsb_Productos.Click += tsb_Poductos_Click;
            // 
            // tsb_Almacenes
            // 
            tsb_Almacenes.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsb_Almacenes.Image = (Image)resources.GetObject("tsb_Almacenes.Image");
            tsb_Almacenes.ImageTransparentColor = Color.Magenta;
            tsb_Almacenes.Name = "tsb_Almacenes";
            tsb_Almacenes.Size = new Size(192, 45);
            tsb_Almacenes.Text = "Almacenes";
            tsb_Almacenes.Click += tsb_Almacenes_Click;
            // 
            // tsb_volverainiciosesion
            // 
            tsb_volverainiciosesion.Alignment = ToolStripItemAlignment.Right;
            tsb_volverainiciosesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsb_volverainiciosesion.Image = Properties.Resources.backicon;
            tsb_volverainiciosesion.ImageTransparentColor = Color.Magenta;
            tsb_volverainiciosesion.Name = "tsb_volverainiciosesion";
            tsb_volverainiciosesion.Size = new Size(71, 45);
            tsb_volverainiciosesion.Text = "Inicio";
            tsb_volverainiciosesion.Click += tsb_volverainiciosesion_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.escudo_med_lema__1_;
            pictureBox1.Location = new Point(443, 102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(493, 384);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(1, 80, 155);
            label1.Location = new Point(364, 489);
            label1.Name = "label1";
            label1.Size = new Size(630, 81);
            label1.TabIndex = 2;
            label1.Text = "Sistema de Inventarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(1, 80, 155);
            label2.Location = new Point(591, 570);
            label2.Name = "label2";
            label2.Size = new Size(202, 20);
            label2.TabIndex = 3;
            label2.Text = "Ashly Yanin González Herrera";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Size = new Size(1362, 699);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsb_Productos;
        private ToolStripButton tsb_Almacenes;
        private PictureBox pictureBox1;
        private ToolStripButton tsb_volverainiciosesion;
        private Label label1;
        private Label label2;
    }
}
