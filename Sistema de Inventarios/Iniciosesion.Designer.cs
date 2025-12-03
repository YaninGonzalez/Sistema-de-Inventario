namespace InventarioBD
{
    partial class Iniciosesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb_Iniciosesión = new Label();
            lb_Nombreusuario = new Label();
            lb_contraseña = new Label();
            txt_nombreiniciosesion = new TextBox();
            txt_contraseña = new TextBox();
            btn_otc = new Button();
            btn_iniciarsesion = new Button();
            pictureBox1 = new PictureBox();
            toolStrip1 = new ToolStrip();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lb_Iniciosesión
            // 
            lb_Iniciosesión.AutoSize = true;
            lb_Iniciosesión.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Iniciosesión.ForeColor = Color.FromArgb(0, 82, 158);
            lb_Iniciosesión.Location = new Point(113, 70);
            lb_Iniciosesión.Name = "lb_Iniciosesión";
            lb_Iniciosesión.Size = new Size(631, 106);
            lb_Iniciosesión.TabIndex = 0;
            lb_Iniciosesión.Text = "Inicio de Sesión";
            // 
            // lb_Nombreusuario
            // 
            lb_Nombreusuario.AutoSize = true;
            lb_Nombreusuario.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Nombreusuario.Location = new Point(146, 219);
            lb_Nombreusuario.Name = "lb_Nombreusuario";
            lb_Nombreusuario.Size = new Size(134, 41);
            lb_Nombreusuario.TabIndex = 1;
            lb_Nombreusuario.Text = "Usuario:";
            // 
            // lb_contraseña
            // 
            lb_contraseña.AutoSize = true;
            lb_contraseña.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_contraseña.Location = new Point(96, 252);
            lb_contraseña.Name = "lb_contraseña";
            lb_contraseña.Size = new Size(184, 41);
            lb_contraseña.TabIndex = 2;
            lb_contraseña.Text = "Contraseña:";
            // 
            // txt_nombreiniciosesion
            // 
            txt_nombreiniciosesion.BackColor = Color.LightGray;
            txt_nombreiniciosesion.ForeColor = Color.Black;
            txt_nombreiniciosesion.Location = new Point(286, 233);
            txt_nombreiniciosesion.Name = "txt_nombreiniciosesion";
            txt_nombreiniciosesion.Size = new Size(372, 27);
            txt_nombreiniciosesion.TabIndex = 3;
            // 
            // txt_contraseña
            // 
            txt_contraseña.BackColor = Color.LightGray;
            txt_contraseña.Location = new Point(286, 266);
            txt_contraseña.Name = "txt_contraseña";
            txt_contraseña.Size = new Size(372, 27);
            txt_contraseña.TabIndex = 4;
            // 
            // btn_otc
            // 
            btn_otc.BackColor = Color.FromArgb(217, 158, 48);
            btn_otc.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_otc.Location = new Point(371, 299);
            btn_otc.Name = "btn_otc";
            btn_otc.Size = new Size(168, 27);
            btn_otc.TabIndex = 5;
            btn_otc.Text = "¿Olvidaste tu contraseña?";
            btn_otc.UseVisualStyleBackColor = false;
            btn_otc.Click += btn_otc_Click;
            // 
            // btn_iniciarsesion
            // 
            btn_iniciarsesion.BackColor = Color.FromArgb(0, 82, 158);
            btn_iniciarsesion.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_iniciarsesion.ForeColor = Color.White;
            btn_iniciarsesion.Location = new Point(313, 385);
            btn_iniciarsesion.Name = "btn_iniciarsesion";
            btn_iniciarsesion.Size = new Size(294, 88);
            btn_iniciarsesion.TabIndex = 6;
            btn_iniciarsesion.Text = "Iniciar Sesión";
            btn_iniciarsesion.UseVisualStyleBackColor = false;
            btn_iniciarsesion.Click += btn_iniciarsesion_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LOGO_OJO_BUHO_AMARILLO;
            pictureBox1.Location = new Point(822, 124);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(485, 397);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 187, 0);
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1319, 25);
            toolStrip1.TabIndex = 8;
            toolStrip1.Text = "toolStrip1";
            // 
            // Iniciosesion
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(1319, 659);
            Controls.Add(toolStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(btn_iniciarsesion);
            Controls.Add(btn_otc);
            Controls.Add(txt_contraseña);
            Controls.Add(txt_nombreiniciosesion);
            Controls.Add(lb_contraseña);
            Controls.Add(lb_Nombreusuario);
            Controls.Add(lb_Iniciosesión);
            Name = "Iniciosesion";
            Text = "Iniciosesion";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_Iniciosesión;
        private Label lb_Nombreusuario;
        private Label lb_contraseña;
        private TextBox txt_nombreiniciosesion;
        private TextBox txt_contraseña;
        private Button btn_otc;
        private Button btn_iniciarsesion;
        private PictureBox pictureBox1;
        private ToolStrip toolStrip1;
    }
}
