namespace final_project_state_of_prog_2024
{
    partial class Form2
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
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            listBox1 = new ListBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(153, 27);
            label1.TabIndex = 1;
            label1.Text = "Введите имя";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(229, 27);
            label2.TabIndex = 2;
            label2.Text = "Введите фамилию";
            label2.Click += label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 127);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(350, 27);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.MenuBar;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 277);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(350, 124);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 187);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(350, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 157);
            label3.Name = "label3";
            label3.Size = new Size(194, 27);
            label3.TabIndex = 6;
            label3.Text = "Выберите жанр";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(12, 235);
            label4.Name = "label4";
            label4.Size = new Size(281, 27);
            label4.TabIndex = 7;
            label4.Text = "Список доступных книг";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(12, 421);
            button1.Name = "button1";
            button1.Size = new Size(350, 85);
            button1.TabIndex = 8;
            button1.Text = "Взять книгу";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonFace;
            button2.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(380, 421);
            button2.Name = "button2";
            button2.Size = new Size(350, 85);
            button2.TabIndex = 9;
            button2.Text = "Вернуть книгу";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(380, 283);
            label5.Name = "label5";
            label5.Size = new Size(362, 27);
            label5.TabIndex = 10;
            label5.Text = "Введите название взятой книги";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(380, 317);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(362, 27);
            textBox3.TabIndex = 11;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(380, 377);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(362, 27);
            textBox4.TabIndex = 12;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(380, 347);
            label6.Name = "label6";
            label6.Size = new Size(242, 27);
            label6.TabIndex = 13;
            label6.Text = "Введите имя автора";
            label6.Click += label6_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = SystemColors.MenuBar;
            dateTimePicker1.Location = new Point(380, 67);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(362, 27);
            dateTimePicker1.TabIndex = 14;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(395, 37);
            label7.Name = "label7";
            label7.Size = new Size(335, 27);
            label7.TabIndex = 15;
            label7.Text = "Укажите, когда брали книгу";
            label7.Click += label7_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(380, 97);
            button3.Name = "button3";
            button3.Size = new Size(362, 57);
            button3.TabIndex = 16;
            button3.Text = "Уточнить срок хранения";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.интер;
            pictureBox1.Location = new Point(-5, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(793, 560);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(380, 187);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(362, 75);
            richTextBox1.TabIndex = 19;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 543);
            Controls.Add(richTextBox1);
            Controls.Add(button3);
            Controls.Add(label7);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(listBox1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private ListBox listBox1;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Label label5;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private Button button3;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
    }

}