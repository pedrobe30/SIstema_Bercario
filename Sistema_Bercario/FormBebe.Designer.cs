namespace Sistema_Bercario
{
    partial class FormBebe
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
            txtNomeBebe = new TextBox();
            txtAlturaBebe = new TextBox();
            txtPesoBebe = new TextBox();
            label1 = new Label();
            btnSalvarBebe = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            txtCRM = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            txtCpfMae = new TextBox();
            label5 = new Label();
            panel6 = new Panel();
            dtgListBebe = new DataGridView();
            btnLimparCampos = new Button();
            panel7 = new Panel();
            btnDeletarBebe = new Button();
            btnAtualizarBebe = new Button();
            dateTimePickerBebe = new DateTimePicker();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgListBebe).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // txtNomeBebe
            // 
            txtNomeBebe.Location = new Point(173, 15);
            txtNomeBebe.Name = "txtNomeBebe";
            txtNomeBebe.Size = new Size(119, 23);
            txtNomeBebe.TabIndex = 1;
            // 
            // txtAlturaBebe
            // 
            txtAlturaBebe.Location = new Point(172, 11);
            txtAlturaBebe.Name = "txtAlturaBebe";
            txtAlturaBebe.Size = new Size(117, 23);
            txtAlturaBebe.TabIndex = 2;
            // 
            // txtPesoBebe
            // 
            txtPesoBebe.Location = new Point(176, 10);
            txtPesoBebe.Name = "txtPesoBebe";
            txtPesoBebe.Size = new Size(119, 23);
            txtPesoBebe.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 15);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 8;
            label1.Text = "Nome do Bebê";
            // 
            // btnSalvarBebe
            // 
            btnSalvarBebe.BackColor = SystemColors.ActiveCaptionText;
            btnSalvarBebe.ForeColor = SystemColors.ControlLightLight;
            btnSalvarBebe.Location = new Point(13, 239);
            btnSalvarBebe.Name = "btnSalvarBebe";
            btnSalvarBebe.Size = new Size(135, 52);
            btnSalvarBebe.TabIndex = 9;
            btnSalvarBebe.Text = "Salvar Bebê";
            btnSalvarBebe.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 14);
            label2.Name = "label2";
            label2.Size = new Size(157, 21);
            label2.TabIndex = 10;
            label2.Text = "Data de Nascimento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(7, 10);
            label3.Name = "label3";
            label3.Size = new Size(153, 21);
            label3.TabIndex = 11;
            label3.Text = "Peso do nascimento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 11);
            label4.Name = "label4";
            label4.Size = new Size(163, 21);
            label4.TabIndex = 12;
            label4.Text = "altura do nascimento";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveCaption;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtNomeBebe);
            panel1.Location = new Point(6, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 51);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(dateTimePickerBebe);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(329, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(385, 51);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.InactiveCaption;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtAlturaBebe);
            panel3.Location = new Point(329, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(312, 44);
            panel3.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.InactiveCaption;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(txtPesoBebe);
            panel4.Location = new Point(5, 106);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 46);
            panel4.TabIndex = 18;
            // 
            // txtCRM
            // 
            txtCRM.Location = new Point(150, 20);
            txtCRM.Name = "txtCRM";
            txtCRM.Size = new Size(119, 23);
            txtCRM.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 20);
            label6.Name = "label6";
            label6.Size = new Size(122, 21);
            label6.TabIndex = 14;
            label6.Text = "CRM do Médico";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.InactiveCaption;
            panel5.Controls.Add(label6);
            panel5.Controls.Add(txtCRM);
            panel5.Location = new Point(329, 175);
            panel5.Name = "panel5";
            panel5.Size = new Size(312, 54);
            panel5.TabIndex = 19;
            // 
            // txtCpfMae
            // 
            txtCpfMae.Location = new Point(140, 8);
            txtCpfMae.Name = "txtCpfMae";
            txtCpfMae.Size = new Size(119, 23);
            txtCpfMae.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(8, 8);
            label5.Name = "label5";
            label5.Size = new Size(95, 21);
            label5.TabIndex = 13;
            label5.Text = "CPF da Mãe";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.InactiveCaption;
            panel6.Controls.Add(label5);
            panel6.Controls.Add(txtCpfMae);
            panel6.Location = new Point(5, 176);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 42);
            panel6.TabIndex = 20;
            // 
            // dtgListBebe
            // 
            dtgListBebe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgListBebe.Location = new Point(13, 308);
            dtgListBebe.Name = "dtgListBebe";
            dtgListBebe.Size = new Size(434, 130);
            dtgListBebe.TabIndex = 21;
            // 
            // btnLimparCampos
            // 
            btnLimparCampos.Location = new Point(177, 239);
            btnLimparCampos.Name = "btnLimparCampos";
            btnLimparCampos.Size = new Size(87, 52);
            btnLimparCampos.TabIndex = 22;
            btnLimparCampos.Text = "Limpar";
            btnLimparCampos.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnDeletarBebe);
            panel7.Controls.Add(btnAtualizarBebe);
            panel7.Location = new Point(506, 261);
            panel7.Name = "panel7";
            panel7.Size = new Size(143, 177);
            panel7.TabIndex = 23;
            // 
            // btnDeletarBebe
            // 
            btnDeletarBebe.Location = new Point(32, 98);
            btnDeletarBebe.Name = "btnDeletarBebe";
            btnDeletarBebe.Size = new Size(87, 49);
            btnDeletarBebe.TabIndex = 1;
            btnDeletarBebe.Text = "Deletar";
            btnDeletarBebe.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarBebe
            // 
            btnAtualizarBebe.Location = new Point(32, 30);
            btnAtualizarBebe.Name = "btnAtualizarBebe";
            btnAtualizarBebe.Size = new Size(87, 49);
            btnAtualizarBebe.TabIndex = 0;
            btnAtualizarBebe.Text = "Atualizar";
            btnAtualizarBebe.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBebe
            // 
            dateTimePickerBebe.Location = new Point(171, 15);
            dateTimePickerBebe.Name = "dateTimePickerBebe";
            dateTimePickerBebe.Size = new Size(200, 23);
            dateTimePickerBebe.TabIndex = 11;
            // 
            // FormBebe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(798, 450);
            Controls.Add(panel7);
            Controls.Add(btnLimparCampos);
            Controls.Add(dtgListBebe);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnSalvarBebe);
            Name = "FormBebe";
            Text = "FormBebe";
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
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgListBebe).EndInit();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtNomeBebe;
        private TextBox txtAlturaBebe;
        private TextBox txtPesoBebe;
        private Label label1;
        private Button btnSalvarBebe;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private TextBox txtCRM;
        private Label label6;
        private Panel panel5;
        private TextBox txtCpfMae;
        private Label label5;
        private Panel panel6;
        private DataGridView dtgListBebe;
        private Button btnLimparCampos;
        private Panel panel7;
        private Button btnAtualizarBebe;
        private Button btnDeletarBebe;
        private DateTimePicker dateTimePickerBebe;
    }
}