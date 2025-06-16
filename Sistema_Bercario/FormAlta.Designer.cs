namespace Sistema_Bercario
{
    partial class FormAlta
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
            dateTimePickerAlta = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dateTimePickerHora = new DateTimePicker();
            comboBoxMedico = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            txtCpfMae = new TextBox();
            label5 = new Label();
            txtCodigoBebe = new TextBox();
            dtgListAltas = new DataGridView();
            panel7 = new Panel();
            btnDeletarAlta = new Button();
            btnAtualizarAlta = new Button();
            btnLimparCampos = new Button();
            btnSalvarAlta = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgListAltas).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePickerAlta
            // 
            dateTimePickerAlta.Location = new Point(12, 47);
            dateTimePickerAlta.Name = "dateTimePickerAlta";
            dateTimePickerAlta.Size = new Size(200, 23);
            dateTimePickerAlta.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 1;
            label1.Text = "Data da Alta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(117, 25);
            label2.TabIndex = 2;
            label2.Text = "Hora da Alta";
            // 
            // dateTimePickerHora
            // 
            dateTimePickerHora.Location = new Point(12, 114);
            dateTimePickerHora.Name = "dateTimePickerHora";
            dateTimePickerHora.Size = new Size(200, 23);
            dateTimePickerHora.TabIndex = 3;
            // 
            // comboBoxMedico
            // 
            comboBoxMedico.FormattingEnabled = true;
            comboBoxMedico.Location = new Point(12, 181);
            comboBoxMedico.Name = "comboBoxMedico";
            comboBoxMedico.Size = new Size(168, 23);
            comboBoxMedico.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 157);
            label3.Name = "label3";
            label3.Size = new Size(200, 21);
            label3.TabIndex = 5;
            label3.Text = "Médico responsável da Alta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(277, 22);
            label4.Name = "label4";
            label4.Size = new Size(92, 21);
            label4.TabIndex = 6;
            label4.Text = "CPF da mãe";
            // 
            // txtCpfMae
            // 
            txtCpfMae.Location = new Point(277, 46);
            txtCpfMae.Name = "txtCpfMae";
            txtCpfMae.Size = new Size(145, 23);
            txtCpfMae.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(277, 90);
            label5.Name = "label5";
            label5.Size = new Size(120, 21);
            label5.TabIndex = 8;
            label5.Text = "Codigo do Bebê";
            // 
            // txtCodigoBebe
            // 
            txtCodigoBebe.Location = new Point(277, 114);
            txtCodigoBebe.Name = "txtCodigoBebe";
            txtCodigoBebe.Size = new Size(145, 23);
            txtCodigoBebe.TabIndex = 9;
            // 
            // dtgListAltas
            // 
            dtgListAltas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgListAltas.Location = new Point(12, 274);
            dtgListAltas.Name = "dtgListAltas";
            dtgListAltas.Size = new Size(591, 150);
            dtgListAltas.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ScrollBar;
            panel7.Controls.Add(btnDeletarAlta);
            panel7.Controls.Add(btnAtualizarAlta);
            panel7.Location = new Point(635, 261);
            panel7.Name = "panel7";
            panel7.Size = new Size(143, 177);
            panel7.TabIndex = 25;
            // 
            // btnDeletarAlta
            // 
            btnDeletarAlta.Location = new Point(32, 98);
            btnDeletarAlta.Name = "btnDeletarAlta";
            btnDeletarAlta.Size = new Size(87, 49);
            btnDeletarAlta.TabIndex = 1;
            btnDeletarAlta.Text = "Deletar";
            btnDeletarAlta.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarAlta
            // 
            btnAtualizarAlta.BackColor = SystemColors.ButtonHighlight;
            btnAtualizarAlta.Location = new Point(32, 30);
            btnAtualizarAlta.Name = "btnAtualizarAlta";
            btnAtualizarAlta.Size = new Size(87, 49);
            btnAtualizarAlta.TabIndex = 0;
            btnAtualizarAlta.Text = "Atualizar";
            btnAtualizarAlta.UseVisualStyleBackColor = false;
            // 
            // btnLimparCampos
            // 
            btnLimparCampos.Location = new Point(433, 193);
            btnLimparCampos.Name = "btnLimparCampos";
            btnLimparCampos.Size = new Size(95, 50);
            btnLimparCampos.TabIndex = 30;
            btnLimparCampos.Text = "Limpar";
            btnLimparCampos.UseVisualStyleBackColor = true;
            // 
            // btnSalvarAlta
            // 
            btnSalvarAlta.BackColor = SystemColors.ActiveCaptionText;
            btnSalvarAlta.ForeColor = SystemColors.ControlLightLight;
            btnSalvarAlta.Location = new Point(277, 191);
            btnSalvarAlta.Name = "btnSalvarAlta";
            btnSalvarAlta.Size = new Size(135, 52);
            btnSalvarAlta.TabIndex = 29;
            btnSalvarAlta.Text = "Gerar Alta";
            btnSalvarAlta.UseVisualStyleBackColor = false;
            // 
            // FormAlta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLimparCampos);
            Controls.Add(btnSalvarAlta);
            Controls.Add(panel7);
            Controls.Add(dtgListAltas);
            Controls.Add(txtCodigoBebe);
            Controls.Add(label5);
            Controls.Add(txtCpfMae);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxMedico);
            Controls.Add(dateTimePickerHora);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerAlta);
            Name = "FormAlta";
            Text = "FormAlta";
            ((System.ComponentModel.ISupportInitialize)dtgListAltas).EndInit();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerAlta;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePickerHora;
        private ComboBox comboBoxMedico;
        private Label label3;
        private Label label4;
        private TextBox txtCpfMae;
        private Label label5;
        private TextBox txtCodigoBebe;
        private DataGridView dtgListAltas;
        private Panel panel7;
        private Button btnDeletarAlta;
        private Button btnAtualizarAlta;
        private Button btnLimparCampos;
        private Button btnSalvarAlta;
    }
}