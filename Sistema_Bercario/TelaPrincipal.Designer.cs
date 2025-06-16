namespace Sistema_Bercario
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnEnfermeirasNavegation = new Button();
            btnMaeNavegation = new Button();
            btnBebesNavegation = new Button();
            panel1 = new Panel();
            btnaltaNavegation = new Button();
            btnMedicosNavegation = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(325, 9);
            label1.Name = "label1";
            label1.Size = new Size(217, 26);
            label1.TabIndex = 0;
            label1.Text = "BERÇARIO FELIZ";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(104, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnEnfermeirasNavegation
            // 
            btnEnfermeirasNavegation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnfermeirasNavegation.Location = new Point(19, 204);
            btnEnfermeirasNavegation.Name = "btnEnfermeirasNavegation";
            btnEnfermeirasNavegation.Size = new Size(331, 38);
            btnEnfermeirasNavegation.TabIndex = 1;
            btnEnfermeirasNavegation.Text = "Enfermeiras";
            btnEnfermeirasNavegation.UseVisualStyleBackColor = true;
            btnEnfermeirasNavegation.Click += btnEnfermeirasNavegation_Click;
            // 
            // btnMaeNavegation
            // 
            btnMaeNavegation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMaeNavegation.Location = new Point(19, 291);
            btnMaeNavegation.Name = "btnMaeNavegation";
            btnMaeNavegation.Size = new Size(331, 41);
            btnMaeNavegation.TabIndex = 6;
            btnMaeNavegation.Text = "Mães";
            btnMaeNavegation.UseVisualStyleBackColor = true;
            btnMaeNavegation.Click += btnMaeNavegation_Click;
            // 
            // btnBebesNavegation
            // 
            btnBebesNavegation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBebesNavegation.Location = new Point(19, 248);
            btnBebesNavegation.Name = "btnBebesNavegation";
            btnBebesNavegation.Size = new Size(331, 37);
            btnBebesNavegation.TabIndex = 7;
            btnBebesNavegation.Text = "Bebês";
            btnBebesNavegation.UseVisualStyleBackColor = true;
            btnBebesNavegation.Click += btnBebesNavegation_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(btnaltaNavegation);
            panel1.Controls.Add(btnMedicosNavegation);
            panel1.Controls.Add(btnBebesNavegation);
            panel1.Controls.Add(btnMaeNavegation);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnEnfermeirasNavegation);
            panel1.Location = new Point(246, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(371, 399);
            panel1.TabIndex = 8;
            // 
            // btnaltaNavegation
            // 
            btnaltaNavegation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnaltaNavegation.Location = new Point(19, 338);
            btnaltaNavegation.Name = "btnaltaNavegation";
            btnaltaNavegation.Size = new Size(331, 41);
            btnaltaNavegation.TabIndex = 9;
            btnaltaNavegation.Text = "Altas";
            btnaltaNavegation.UseVisualStyleBackColor = true;
            btnaltaNavegation.Click += btnAltaNavegation_Click;
            // 
            // btnMedicosNavegation
            // 
            btnMedicosNavegation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMedicosNavegation.Location = new Point(19, 156);
            btnMedicosNavegation.Name = "btnMedicosNavegation";
            btnMedicosNavegation.Size = new Size(331, 42);
            btnMedicosNavegation.TabIndex = 8;
            btnMedicosNavegation.Text = "Medicos";
            btnMedicosNavegation.UseVisualStyleBackColor = true;
            btnMedicosNavegation.Click += btnMedicosNavegation_Click;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "TelaPrincipal";
            Text = "TelaPrincipal";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Button btnEnfermeirasNavegation;
        private Button btnMaeNavegation;
        private Button btnBebesNavegation;
        private Panel panel1;
        private Button btnaltaNavegation;
        private Button btnMedicosNavegation;
    }
}