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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox7 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            textBox5 = new TextBox();
            label6 = new Label();
            panel5 = new Panel();
            textBox4 = new TextBox();
            label5 = new Label();
            panel6 = new Panel();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            panel7 = new Panel();
            button4 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(173, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(119, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(172, 11);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(117, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(176, 10);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(119, 23);
            textBox3.TabIndex = 3;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(177, 14);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(119, 23);
            textBox7.TabIndex = 7;
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
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(13, 239);
            button2.Name = "button2";
            button2.Size = new Size(135, 52);
            button2.TabIndex = 9;
            button2.Text = "Gerar Relatorio";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
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
            label2.Click += label2_Click;
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
            label3.Click += label3_Click;
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
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(6, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 51);
            panel1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.InactiveCaption;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox7);
            panel2.Location = new Point(329, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 51);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.InactiveCaption;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(textBox2);
            panel3.Location = new Point(329, 107);
            panel3.Name = "panel3";
            panel3.Size = new Size(312, 44);
            panel3.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.InactiveCaption;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(textBox3);
            panel4.Location = new Point(5, 106);
            panel4.Name = "panel4";
            panel4.Size = new Size(300, 46);
            panel4.TabIndex = 18;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(150, 20);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(119, 23);
            textBox5.TabIndex = 5;
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
            panel5.Controls.Add(textBox5);
            panel5.Location = new Point(329, 175);
            panel5.Name = "panel5";
            panel5.Size = new Size(312, 54);
            panel5.TabIndex = 19;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(140, 8);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(119, 23);
            textBox4.TabIndex = 4;
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
            panel6.Controls.Add(textBox4);
            panel6.Location = new Point(5, 176);
            panel6.Name = "panel6";
            panel6.Size = new Size(300, 42);
            panel6.TabIndex = 20;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 308);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(434, 130);
            dataGridView1.TabIndex = 21;
            // 
            // button1
            // 
            button1.Location = new Point(177, 239);
            button1.Name = "button1";
            button1.Size = new Size(87, 52);
            button1.TabIndex = 22;
            button1.Text = "Limpar";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.Controls.Add(button4);
            panel7.Controls.Add(button3);
            panel7.Location = new Point(506, 261);
            panel7.Name = "panel7";
            panel7.Size = new Size(143, 177);
            panel7.TabIndex = 23;
            // 
            // button4
            // 
            button4.Location = new Point(32, 98);
            button4.Name = "button4";
            button4.Size = new Size(87, 49);
            button4.TabIndex = 1;
            button4.Text = "Deletar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(32, 30);
            button3.Name = "button3";
            button3.Size = new Size(87, 49);
            button3.TabIndex = 0;
            button3.Text = "Atualizar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FormBebe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(798, 450);
            Controls.Add(panel7);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button2);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox7;
        private Label label1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private TextBox textBox5;
        private Label label6;
        private Panel panel5;
        private TextBox textBox4;
        private Label label5;
        private Panel panel6;
        private DataGridView dataGridView1;
        private Button button1;
        private Panel panel7;
        private Button button3;
        private Button button4;
    }
}