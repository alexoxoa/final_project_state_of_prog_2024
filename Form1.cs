using System.Diagnostics;

namespace final_project_state_of_prog_2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��������� ��� ��������, ��������� � ������� �����������
            Process.GetCurrentProcess().Kill();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 readerForm = new Form3();  // ������� ��������� Form2
            readerForm.Show();                // ���������� Form2
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 readerForm = new Form2();  // ������� ��������� Form2
            readerForm.Show();                // ���������� Form2
            this.Hide();                      // �������� Form1
        }
    }
}
