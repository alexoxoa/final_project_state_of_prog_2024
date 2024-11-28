using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project_state_of_prog_2024
{
    public partial class Form3 : Form
    {
        private LibraryEmployee employee;
        public Form3()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Завершаем все процессы, связанные с текущим приложением
            Process.GetCurrentProcess().Kill();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "borrowed_books.txt"; // Укажите путь к файлу

            // Проверяем, существует ли файл
            if (File.Exists(filePath))
            {
                // Читаем все строки из файла
                string[] lines = File.ReadAllLines(filePath);

                // Очищаем ListBox перед загрузкой новых данных
                richTextBox1.Clear();

                // Добавляем строки в ListBox
                foreach (string line in lines)
                {
                    richTextBox1.Text = File.ReadAllText(filePath);
                }
            }
            else
            {
                MessageBox.Show($"Файл {filePath} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string per = textBox1.Text;
            string ter = textBox2.Text;
            employee = new LibraryEmployee(1, per, ter, "ул. Пушкина, д. 10");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string per = textBox1.Text;
            string ter = textBox2.Text;
            string name = textBox3.Text;
            string author = textBox4.Text;
            employee = new LibraryEmployee(1, per, ter, "ул. Пушкина, д. 10");
            employee.AddBook(new BorrowedBook(name, author, DateTime.Now.AddDays(0)));

            employee.ListBorrowedBooks(richTextBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string per = textBox1.Text;
            string ter = textBox2.Text;
            employee = new LibraryEmployee(1, per, ter, "ул. Пушкина, д. 10");
            employee.NotifyReaders();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Создаем объект VipReader
            int readerID = new Random().Next(1, 1000); ; // Пример ID
            string readerName = textBox6.Text + " " + textBox5.Text; // Пример имени
            string vipLevel = textBox7.Text; // Пример VIP уровня

            VipReader vipReader = new VipReader(readerID, readerName, vipLevel);
            VipClient vipClient = new VipClient(vipReader);

            // Получаем информацию о VipReader
            string info = vipReader.GetInfo();

            // Выводим информацию в richTextBox2
            richTextBox2.Text += info;
            // Получаем информацию о VipClient
            vipClient.GetClientInfo();


        }
    }


}
