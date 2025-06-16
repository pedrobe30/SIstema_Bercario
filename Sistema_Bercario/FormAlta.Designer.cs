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
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            panel7 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 47);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
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
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(12, 114);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 181);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 23);
            comboBox1.TabIndex = 4;
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
            // textBox1
            // 
            textBox1.Location = new Point(277, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 23);
            textBox1.TabIndex = 7;
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
            // textBox2
            // 
            textBox2.Location = new Point(277, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(145, 23);
            textBox2.TabIndex = 9;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 274);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(538, 150);
            dataGridView1.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.ScrollBar;
            panel7.Controls.Add(button4);
            panel7.Controls.Add(button3);
            panel7.Location = new Point(609, 261);
            panel7.Name = "panel7";
            panel7.Size = new Size(143, 177);
            panel7.TabIndex = 25;
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
            button3.BackColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(32, 30);
            button3.Name = "button3";
            button3.Size = new Size(87, 49);
            button3.TabIndex = 0;
            button3.Text = "Atualizar";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Location = new Point(433, 193);
            button1.Name = "button1";
            button1.Size = new Size(95, 50);
            button1.TabIndex = 30;
            button1.Text = "Limpar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(277, 191);
            button2.Name = "button2";
            button2.Size = new Size(135, 52);
            button2.TabIndex = 29;
            button2.Text = "Gerar Relatorio";
            button2.UseVisualStyleBackColor = false;
            // 
            // FormAlta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(panel7);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Name = "FormAlta";
            Text = "FormAlta";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel7.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Panel panel7;
        private Button button4;
        private Button button3;
        private Button button1;
        private Button button2;
    }
}