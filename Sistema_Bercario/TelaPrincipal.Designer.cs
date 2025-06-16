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
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            panel1 = new Panel();
            button5 = new Button();
            button2 = new Button();
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
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(19, 204);
            button1.Name = "button1";
            button1.Size = new Size(331, 38);
            button1.TabIndex = 1;
            button1.Text = "Enfermeiras";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(19, 291);
            button3.Name = "button3";
            button3.Size = new Size(331, 41);
            button3.TabIndex = 6;
            button3.Text = "Mães";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(19, 248);
            button4.Name = "button4";
            button4.Size = new Size(331, 37);
            button4.TabIndex = 7;
            button4.Text = "Bebês";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(246, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(371, 399);
            panel1.TabIndex = 8;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(19, 156);
            button5.Name = "button5";
            button5.Size = new Size(331, 42);
            button5.TabIndex = 8;
            button5.Text = "Medicos";
            button5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(19, 338);
            button2.Name = "button2";
            button2.Size = new Size(331, 41);
            button2.TabIndex = 9;
            button2.Text = "Altas";
            button2.UseVisualStyleBackColor = true;
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
        private Button button1;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Button button2;
        private Button button5;
    }
}