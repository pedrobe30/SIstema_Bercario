namespace Sistema_Bercario
{
    partial class CadastrarAdm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarAdm));
            pictureBox1 = new PictureBox();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            textBox3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(325, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(291, 145);
            label2.Name = "label2";
            label2.Size = new Size(263, 32);
            label2.TabIndex = 4;
            label2.Text = "Cadastro Berçario Feliz";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(335, 201);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 29);
            textBox1.TabIndex = 7;
            textBox1.Text = "Seu nome";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(335, 250);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(165, 29);
            textBox2.TabIndex = 9;
            textBox2.Text = "Crie sua Senha";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 192);
            button1.Location = new Point(325, 351);
            button1.Name = "button1";
            button1.Size = new Size(188, 43);
            button1.TabIndex = 11;
            button1.Text = "CADASTRO";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(335, 300);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(165, 29);
            textBox3.TabIndex = 12;
            textBox3.Text = "Codigo do Hosipital";
            // 
            // CadastrarAdm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(802, 471);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Name = "CadastrarAdm";
            Text = "CadastrarAdm";
            Load += CadastrarAdm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private TextBox textBox3;
    }
}