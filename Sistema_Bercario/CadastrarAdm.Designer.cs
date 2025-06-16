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
            this.txtNomeAdm = new System.Windows.Forms.TextBox();
            this.txtSenhaAdm = new System.Windows.Forms.TextBox();
            this.txtCodigoHosp = new System.Windows.Forms.TextBox();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnIrLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeAdm
            // 
            this.txtNomeAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNomeAdm.Location = new System.Drawing.Point(150, 120);
            this.txtNomeAdm.MaxLength = 50;
            this.txtNomeAdm.Name = "txtNomeAdm";
            this.txtNomeAdm.Size = new System.Drawing.Size(300, 26);
            this.txtNomeAdm.TabIndex = 0;
            this.txtNomeAdm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomeAdm_KeyDown);
            // 
            // txtSenhaAdm
            // 
            this.txtSenhaAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSenhaAdm.Location = new System.Drawing.Point(150, 180);
            this.txtSenhaAdm.MaxLength = 255;
            this.txtSenhaAdm.Name = "txtSenhaAdm";
            this.txtSenhaAdm.PasswordChar = '*';
            this.txtSenhaAdm.Size = new System.Drawing.Size(300, 26);
            this.txtSenhaAdm.TabIndex = 1;
            this.txtSenhaAdm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenhaAdm_KeyDown);
            // 
            // txtCodigoHosp
            // 
            this.txtCodigoHosp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCodigoHosp.Location = new System.Drawing.Point(150, 240);
            this.txtCodigoHosp.MaxLength = 8;
            this.txtCodigoHosp.Name = "txtCodigoHosp";
            this.txtCodigoHosp.Size = new System.Drawing.Size(300, 26);
            this.txtCodigoHosp.TabIndex = 2;
            this.txtCodigoHosp.TextChanged += new System.EventHandler(this.txtCodigoHosp_TextChanged);
            this.txtCodigoHosp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoHosp_KeyDown);
            this.txtCodigoHosp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoHosp_KeyPress);
            // 
            // btnCadastro
            // 
            this.btnCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCadastro.ForeColor = System.Drawing.Color.White;
            this.btnCadastro.Location = new System.Drawing.Point(150, 300);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(300, 40);
            this.btnCadastro.TabIndex = 3;
            this.btnCadastro.Text = "Cadastrar Administrador";
            this.btnCadastro.UseVisualStyleBackColor = false;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnIrLogin
            // 
            this.btnIrLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnIrLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIrLogin.ForeColor = System.Drawing.Color.White;
            this.btnIrLogin.Location = new System.Drawing.Point(150, 360);
            this.btnIrLogin.Name = "btnIrLogin";
            this.btnIrLogin.Size = new System.Drawing.Size(300, 35);
            this.btnIrLogin.TabIndex = 4;
            this.btnIrLogin.Text = "Voltar para Login";
            this.btnIrLogin.UseVisualStyleBackColor = false;
            this.btnIrLogin.Click += new System.EventHandler(this.btnIrLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(150, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cadastrar Administrador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(150, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome do Usuário (*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(150, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Senha (*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(150, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Código do Hospital (*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.label5.Location = new System.Drawing.Point(150, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Todos os campos (*) são obrigatórios";
            // 
            // CadastrarAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIrLogin);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.txtCodigoHosp);
            this.Controls.Add(this.txtSenhaAdm);
            this.Controls.Add(this.txtNomeAdm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CadastrarAdm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro - Sistema Berçário";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadastrarAdm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeAdm;
        private System.Windows.Forms.TextBox txtSenhaAdm;
        private System.Windows.Forms.TextBox txtCodigoHosp;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnIrLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}