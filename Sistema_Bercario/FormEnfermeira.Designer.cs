namespace Sistema_Bercario
{
    partial class FormEnfermeira
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnfermeira));
            panel1 = new Panel();
            label1 = new Label();
            txtNomeEnfermeira = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            txtCorenEnfermeira = new TextBox();
            panel3 = new Panel();
            label3 = new Label();
            txtCelEnfermeira = new TextBox();
            panel4 = new Panel();
            label4 = new Label();
            txtTelEnfermeira = new TextBox();
            panel5 = new Panel();
            label5 = new Label();
            txtEmailEnfermeira = new TextBox();
            dtgListEnfermeira = new DataGridView();
            pictureBox1 = new PictureBox();
            panel7 = new Panel();
            btnDeletarEnfermeira = new Button();
            btnAtualizarEnfermeira = new Button();
            btnSalvarEnfermeira = new Button();
            btnLimparCampos = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgListEnfermeira).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtNomeEnfermeira);
            panel1.Location = new Point(28, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 51);
            panel1.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 15);
            label1.Name = "label1";
            label1.Size = new Size(157, 21);
            label1.TabIndex = 8;
            label1.Text = "Nome da Enfermeira";
            // 
            // txtNomeEnfermeira
            // 
            txtNomeEnfermeira.Location = new Point(173, 15);
            txtNomeEnfermeira.Name = "txtNomeEnfermeira";
            txtNomeEnfermeira.Size = new Size(119, 23);
            txtNomeEnfermeira.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtCorenEnfermeira);
            panel2.Location = new Point(362, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 51);
            panel2.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 14);
            label2.Name = "label2";
            label2.Size = new Size(136, 21);
            label2.TabIndex = 10;
            label2.Text = "Numero do Coren";
            // 
            // txtCorenEnfermeira
            // 
            txtCorenEnfermeira.Location = new Point(177, 14);
            txtCorenEnfermeira.Name = "txtCorenEnfermeira";
            txtCorenEnfermeira.Size = new Size(119, 23);
            txtCorenEnfermeira.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.InactiveCaption;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtCelEnfermeira);
            panel3.Location = new Point(28, 119);
            panel3.Name = "panel3";
            panel3.Size = new Size(312, 51);
            panel3.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 14);
            label3.Name = "label3";
            label3.Size = new Size(62, 21);
            label3.TabIndex = 10;
            label3.Text = "Celular";
            // 
            // txtCelEnfermeira
            // 
            txtCelEnfermeira.Location = new Point(177, 14);
            txtCelEnfermeira.Name = "txtCelEnfermeira";
            txtCelEnfermeira.Size = new Size(119, 23);
            txtCelEnfermeira.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.InactiveCaption;
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtTelEnfermeira);
            panel4.Location = new Point(28, 189);
            panel4.Name = "panel4";
            panel4.Size = new Size(312, 51);
            panel4.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(8, 14);
            label4.Name = "label4";
            label4.Size = new Size(71, 21);
            label4.TabIndex = 10;
            label4.Text = "Telefone";
            // 
            // txtTelEnfermeira
            // 
            txtTelEnfermeira.Location = new Point(177, 14);
            txtTelEnfermeira.Name = "txtTelEnfermeira";
            txtTelEnfermeira.Size = new Size(119, 23);
            txtTelEnfermeira.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.InactiveCaption;
            panel5.Controls.Add(label5);
            panel5.Controls.Add(txtEmailEnfermeira);
            panel5.Location = new Point(362, 119);
            panel5.Name = "panel5";
            panel5.Size = new Size(312, 51);
            panel5.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(8, 14);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 10;
            label5.Text = "Email";
            // 
            // txtEmailEnfermeira
            // 
            txtEmailEnfermeira.Location = new Point(177, 14);
            txtEmailEnfermeira.Name = "txtEmailEnfermeira";
            txtEmailEnfermeira.Size = new Size(119, 23);
            txtEmailEnfermeira.TabIndex = 7;
            // 
            // dtgListEnfermeira
            // 
            dtgListEnfermeira.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgListEnfermeira.Location = new Point(28, 266);
            dtgListEnfermeira.Name = "dtgListEnfermeira";
            dtgListEnfermeira.Size = new Size(570, 172);
            dtgListEnfermeira.TabIndex = 19;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(696, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ScrollBar;
            panel7.Controls.Add(btnDeletarEnfermeira);
            panel7.Controls.Add(btnAtualizarEnfermeira);
            panel7.Location = new Point(617, 261);
            panel7.Name = "panel7";
            panel7.Size = new Size(143, 177);
            panel7.TabIndex = 24;
            // 
            // btnDeletarEnfermeira
            // 
            btnDeletarEnfermeira.Location = new Point(32, 98);
            btnDeletarEnfermeira.Name = "btnDeletarEnfermeira";
            btnDeletarEnfermeira.Size = new Size(87, 49);
            btnDeletarEnfermeira.TabIndex = 1;
            btnDeletarEnfermeira.Text = "Deletar";
            btnDeletarEnfermeira.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarEnfermeira
            // 
            btnAtualizarEnfermeira.BackColor = SystemColors.ButtonHighlight;
            btnAtualizarEnfermeira.Location = new Point(32, 30);
            btnAtualizarEnfermeira.Name = "btnAtualizarEnfermeira";
            btnAtualizarEnfermeira.Size = new Size(87, 49);
            btnAtualizarEnfermeira.TabIndex = 0;
            btnAtualizarEnfermeira.Text = "Atualizar";
            btnAtualizarEnfermeira.UseVisualStyleBackColor = false;
            // 
            // btnSalvarEnfermeira
            // 
            btnSalvarEnfermeira.BackColor = SystemColors.ActiveCaptionText;
            btnSalvarEnfermeira.ForeColor = SystemColors.ControlLightLight;
            btnSalvarEnfermeira.Location = new Point(362, 189);
            btnSalvarEnfermeira.Name = "btnSalvarEnfermeira";
            btnSalvarEnfermeira.Size = new Size(135, 52);
            btnSalvarEnfermeira.TabIndex = 25;
            btnSalvarEnfermeira.Text = "Salvar Enfermeira(o)";
            btnSalvarEnfermeira.UseVisualStyleBackColor = false;
            // 
            // btnLimparCampos
            // 
            btnLimparCampos.Location = new Point(503, 189);
            btnLimparCampos.Name = "btnLimparCampos";
            btnLimparCampos.Size = new Size(95, 50);
            btnLimparCampos.TabIndex = 26;
            btnLimparCampos.Text = "Limpar";
            btnLimparCampos.UseVisualStyleBackColor = true;
            // 
            // FormEnfermeira
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLimparCampos);
            Controls.Add(btnSalvarEnfermeira);
            Controls.Add(panel7);
            Controls.Add(pictureBox1);
            Controls.Add(dtgListEnfermeira);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FormEnfermeira";
            Text = "FormEnfermeira";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgListEnfermeira).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtNomeEnfermeira;
        private Panel panel2;
        private Label label2;
        private TextBox txtCorenEnfermeira;
        private Panel panel3;
        private Label label3;
        private TextBox txtCelEnfermeira;
        private Panel panel4;
        private Label label4;
        private TextBox txtTelEnfermeira;
        private Panel panel5;
        private Label label5;
        private TextBox txtEmailEnfermeira;
        private DataGridView dtgListEnfermeira;
        private PictureBox pictureBox1;
        private Panel panel7;
        private Button btnDeletarEnfermeira;
        private Button btnAtualizarEnfermeira;
        private Button btnSalvarEnfermeira;
        private Button btnLimparCampos;
    }
}