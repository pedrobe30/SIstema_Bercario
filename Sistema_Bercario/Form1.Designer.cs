namespace Sistema_Bercario
{
    partial class Form1
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
            this.txtNomeLogin = new System.Windows.Forms.TextBox();
            this.txtSenhaLogin = new System.Windows.Forms.TextBox();
            this.btnEntrarSistema = new System.Windows.Forms.Button();
            this.btnIrCadastro = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNomeLogin
            // 
            this.txtNomeLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNomeLogin.Location = new System.Drawing.Point(150, 120);
            this.txtNomeLogin.MaxLength = 50;
            this.txtNomeLogin.Name = "txtNomeLogin";
            this.txtNomeLogin.Size = new System.Drawing.Size(250, 26);
            this.txtNomeLogin.TabIndex = 0;
            this.txtNomeLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNomeLogin_KeyDown);
            // 
            // txtSenhaLogin
            // 
            this.txtSenhaLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSenhaLogin.Location = new System.Drawing.Point(150, 170);
            this.txtSenhaLogin.MaxLength = 255;
            this.txtSenhaLogin.Name = "txtSenhaLogin";
            this.txtSenhaLogin.PasswordChar = '*';
            this.txtSenhaLogin.Size = new System.Drawing.Size(250, 26);
            this.txtSenhaLogin.TabIndex = 1;
            this.txtSenhaLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenhaLogin_KeyDown);
            // 
            // btnEntrarSistema
            // 
            this.btnEntrarSistema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnEntrarSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrarSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEntrarSistema.ForeColor = System.Drawing.Color.White;
            this.btnEntrarSistema.Location = new System.Drawing.Point(150, 230);
            this.btnEntrarSistema.Name = "btnEntrarSistema";
            this.btnEntrarSistema.Size = new System.Drawing.Size(250, 40);
            this.btnEntrarSistema.TabIndex = 2;
            this.btnEntrarSistema.Text = "Entrar";
            this.btnEntrarSistema.UseVisualStyleBackColor = false;
            this.btnEntrarSistema.Click += new System.EventHandler(this.btnEntrarSistema_Click);
            // 
            // btnIrCadastro
            // 
            this.btnIrCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnIrCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIrCadastro.ForeColor = System.Drawing.Color.White;
            this.btnIrCadastro.Location = new System.Drawing.Point(150, 290);
            this.btnIrCadastro.Name = "btnIrCadastro";
            this.btnIrCadastro.Size = new System.Drawing.Size(250, 35);
            this.btnIrCadastro.TabIndex = 3;
            this.btnIrCadastro.Text = "Cadastrar Novo Administrador";
            this.btnIrCadastro.UseVisualStyleBackColor = false;
            this.btnIrCadastro.Click += new System.EventHandler(this.btnIrCadastro_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(150, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Testar Conexão";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(150, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sistema do Berçário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(150, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuário";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(150, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Senha";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnIrCadastro);
            this.Controls.Add(this.btnEntrarSistema);
            this.Controls.Add(this.txtSenhaLogin);
            this.Controls.Add(this.txtNomeLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Sistema Berçário";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeLogin;
        private System.Windows.Forms.TextBox txtSenhaLogin;
        private System.Windows.Forms.Button btnEntrarSistema;
        private System.Windows.Forms.Button btnIrCadastro;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}