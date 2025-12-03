namespace InventarioBD
{
    partial class ProblemaTuyoPapics
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
            pictureBox1 = new PictureBox();
            toolStrip1 = new ToolStrip();
            tsb_ptpiniciosesion = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.problema_tuyo_papi;
            pictureBox1.Location = new Point(217, 130);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(962, 495);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 187, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsb_ptpiniciosesion });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1360, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsb_ptpiniciosesion
            // 
            tsb_ptpiniciosesion.Alignment = ToolStripItemAlignment.Right;
            tsb_ptpiniciosesion.Image = Properties.Resources.backicon;
            tsb_ptpiniciosesion.ImageTransparentColor = Color.Magenta;
            tsb_ptpiniciosesion.Name = "tsb_ptpiniciosesion";
            tsb_ptpiniciosesion.Size = new Size(74, 24);
            tsb_ptpiniciosesion.Text = "Volver";
            tsb_ptpiniciosesion.Click += tsb_ptpiniciosesion_Click;
            // 
            // ProblemaTuyoPapics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip1);
            Controls.Add(pictureBox1);
            Name = "ProblemaTuyoPapics";
            Size = new Size(1360, 789);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsb_ptpiniciosesion;
    }
}
