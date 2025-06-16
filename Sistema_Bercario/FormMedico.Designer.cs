namespace Sistema_Bercario
{
    partial class FormMedico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMedico));
            panel6 = new Panel();
            label5 = new Label();
            txtTelMedico = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            txtNomeMedico = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            txtMedicoEmail = new TextBox();
            panel3 = new Panel();
            label3 = new Label();
            txtCrmMedico = new TextBox();
            panel4 = new Panel();
            label4 = new Label();
            txtMedicoCel = new TextBox();
            panel5 = new Panel();
            label6 = new Label();
            txtEspecialidade = new TextBox();
            dtgListMedico = new DataGridView();
            panel7 = new Panel();
            btnDeletarMedico = new Button();
            btnAtualizarMedico = new Button();
            btnLimparCampos = new Button();
            btnSalvarMedico = new Button();
            pictureBox1 = new PictureBox();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgListMedico).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.InactiveCaption;
            panel6.Controls.Add(label5);
            panel6.Controls.Add(txtTelMedico);
            panel6.Location = new Point(12, 83);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 42);
            panel6.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 8);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 13;
            label5.Text = "Telefone";
            // 
            // txtTelMedico
            // 
            txtTelMedico.Location = new Point(140, 8);
            txtTelMedico.Name = "txtTelMedico";
            txtTelMedico.Size = new Size(119, 23);
            txtTelMedico.TabIndex = 4;
            txtTelMedico.MaxLength = 15;
            txtTelMedico.KeyPress += new KeyPressEventHandler(this.txtTelMedico_KeyPress);
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtNomeMedico);
            panel1.Location = new Point(12, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 42);
            panel1.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(131, 21);
            label1.TabIndex = 13;
            label1.Text = "Nome do Médico";
            // 
            // txtNomeMedico
            // 
            txtNomeMedico.Location = new Point(140, 8);
            txtNomeMedico.Name = "txtNomeMedico";
            txtNomeMedico.Size = new Size(119, 23);
            txtNomeMedico.TabIndex = 4;
            txtNomeMedico.MaxLength = 100;
            txtNomeMedico.KeyPress += new KeyPressEventHandler(this.txtNomeMedico_KeyPress);
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtMedicoEmail);
            panel2.Location = new Point(340, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 42);
            panel2.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 10);
            label2.Name = "label2";
            label2.Size = new Size(51, 21);
            label2.TabIndex = 13;
            label2.Text = "Email";
            // 
            // txtMedicoEmail
            // 
            txtMedicoEmail.Location = new Point(140, 8);
            txtMedicoEmail.Name = "txtMedicoEmail";
            txtMedicoEmail.Size = new Size(119, 23);
            txtMedicoEmail.TabIndex = 4;
            txtMedicoEmail.MaxLength = 100;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.InactiveCaption;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtCrmMedico);
            panel3.Location = new Point(340, 83);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 42);
            panel3.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 10);
            label3.Name = "label3";
            label3.Size = new Size(44, 21);
            label3.TabIndex = 13;
            label3.Text = "CRM";
            // 
            // txtCrmMedico
            // 
            txtCrmMedico.Location = new Point(140, 8);
            txtCrmMedico.Name = "txtCrmMedico";
            txtCrmMedico.Size = new Size(119, 23);
            txtCrmMedico.TabIndex = 4;
            txtCrmMedico.MaxLength = 20;
            txtCrmMedico.KeyPress += new KeyPressEventHandler(this.txtCrmMedico_KeyPress);
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.InactiveCaption;
            panel4.Controls.Add(label4);
            panel4.Controls.Add(txtMedicoCel);
            panel4.Location = new Point(12, 150);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 42);
            panel4.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 10);
            label4.Name = "label4";
            label4.Size = new Size(62, 21);
            label4.TabIndex = 13;
            label4.Text = "Celular";
            // 
            // txtMedicoCel
            // 
            txtMedicoCel.Location = new Point(140, 8);
            txtMedicoCel.Name = "txtMedicoCel";
            txtMedicoCel.Size = new Size(119, 23);
            txtMedicoCel.TabIndex = 4;
            txtMedicoCel.MaxLength = 15;
            txtMedicoCel.KeyPress += new KeyPressEventHandler(this.txtMedicoCel_KeyPress);
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.InactiveCaption;
            panel5.Controls.Add(label6);
            panel5.Controls.Add(txtEspecialidade);
            panel5.Location = new Point(340, 150);
            panel5.Name = "panel5";
            panel5.Size = new Size(300, 42);
            panel5.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 10);
            label6.Name = "label6";
            label6.Size = new Size(108, 21);
            label6.TabIndex = 13;
            label6.Text = "Especialidade";
            // 
            // txtEspecialidade
            // 
            txtEspecialidade.Location = new Point(140, 8);
            txtEspecialidade.Name = "txtEspecialidade";
            txtEspecialidade.Size = new Size(119, 23);
            txtEspecialidade.TabIndex = 4;
            txtEspecialidade.MaxLength = 50;
            // 
            // dtgListMedico
            // 
            dtgListMedico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgListMedico.Location = new Point(12, 288);
            dtgListMedico.Name = "dtgListMedico";
            dtgListMedico.Size = new Size(575, 150);
            dtgListMedico.TabIndex = 22;
            dtgListMedico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgListMedico.BackgroundColor = Color.White;
            dtgListMedico.BorderStyle = BorderStyle.Fixed3D;
            dtgListMedico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgListMedico.MultiSelect = false;
            dtgListMedico.ReadOnly = true;

            dtgListMedico.AllowUserToAddRows = false;
            dtgListMedico.AllowUserToDeleteRows = false;
            dtgListMedico.SelectionChanged += new EventHandler(this.DtgListMedico_SelectionChanged);
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ScrollBar;
            panel7.Controls.Add(btnDeletarMedico);
            panel7.Controls.Add(btnAtualizarMedico);
            panel7.Location = new Point(630, 261);
            panel7.Name = "panel7";
            panel7.Size = new Size(143, 177);
            panel7.TabIndex = 25;
            // 
            // btnDeletarMedico
            // 
            btnDeletarMedico.Location = new Point(32, 98);
            btnDeletarMedico.Name = "btnDeletarMedico";
            btnDeletarMedico.Size = new Size(87, 49);
            btnDeletarMedico.TabIndex = 1;
            btnDeletarMedico.Text = "Deletar";
            btnDeletarMedico.UseVisualStyleBackColor = true;
            btnDeletarMedico.Click += new EventHandler(this.btnDeletarMedico_Click);
            // 
            // btnAtualizarMedico
            // 
            btnAtualizarMedico.BackColor = SystemColors.ButtonHighlight;
            btnAtualizarMedico.Location = new Point(32, 30);
            btnAtualizarMedico.Name = "btnAtualizarMedico";
            btnAtualizarMedico.Size = new Size(87, 49);
            btnAtualizarMedico.TabIndex = 0;
            btnAtualizarMedico.Text = "Atualizar";
            btnAtualizarMedico.UseVisualStyleBackColor = false;
            btnAtualizarMedico.Click += new EventHandler(this.btnAtualizarMedico_Click);
            // 
            // btnLimparCampos
            // 
            btnLimparCampos.Location = new Point(176, 222);
            btnLimparCampos.Name = "btnLimparCampos";
            btnLimparCampos.Size = new Size(95, 50);
            btnLimparCampos.TabIndex = 28;
            btnLimparCampos.Text = "Limpar";
            btnLimparCampos.UseVisualStyleBackColor = true;
            btnLimparCampos.Click += new EventHandler(this.btnLimparCampos_Click);
            // 
            // btnSalvarMedico
            // 
            btnSalvarMedico.BackColor = SystemColors.ActiveCaptionText;
            btnSalvarMedico.ForeColor = SystemColors.ControlLightLight;
            btnSalvarMedico.Location = new Point(20, 220);
            btnSalvarMedico.Name = "btnSalvarMedico";
            btnSalvarMedico.Size = new Size(135, 52);
            btnSalvarMedico.TabIndex = 27;
            btnSalvarMedico.Text = "Salvar Médico";
            btnSalvarMedico.UseVisualStyleBackColor = false;
            btnSalvarMedico.Click += new EventHandler(this.btnSalvarMedico_Click);
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(696, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // FormMedico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(btnLimparCampos);
            Controls.Add(btnSalvarMedico);
            Controls.Add(panel7);
            Controls.Add(dtgListMedico);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel6);
            Name = "FormMedico";
            Text = "Medicos";
            Load += new EventHandler(this.FormMedico_Load);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)dtgListMedico).EndInit();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel6;
        private Label label5;
        private TextBox txtTelMedico;
        private Panel panel1;
        private Label label1;
        private TextBox txtNomeMedico;
        private Panel panel2;
        private Label label2;
        private TextBox txtMedicoEmail;
        private Panel panel3;
        private Label label3;
        private TextBox txtCrmMedico;
        private Panel panel4;
        private Label label4;
        private TextBox txtMedicoCel;
        private Panel panel5;
        private Label label6;
        private TextBox txtEspecialidade;
        private DataGridView dtgListMedico;
        private Panel panel7;
        private Button btnDeletarMedico;
        private Button btnAtualizarMedico;
        private Button btnLimparCampos;
        private Button btnSalvarMedico;
        private PictureBox pictureBox1;
    }
}
