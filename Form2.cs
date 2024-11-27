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
using static final_project_state_of_prog_2024.Reader;

namespace final_project_state_of_prog_2024
{
    public partial class Form2 : Form
    {
        private Reader reader;
        private Dictionary<string, List<Book>> booksByGenre = new Dictionary<string, List<Book>>()
        {
            { "Фантастика", new List<Book>
                {
                    new Book("Дюна", "Фрэнк Герберт"),
                    new Book("1984", "Джордж Оруэлл"),
                    new Book("451 градус по Фаренгейту", "Рэй Брэдбери")
                }
            },
            { "Детектив", new List<Book>
                {
                    new Book("Шерлок Холмс", "Артур Конан Дойл"),
                    new Book("Убийство в Восточном экспрессе", "Агата Кристи"),
                    new Book("Десять негритят", "Агата Кристи")
                }
            },
            { "Классика", new List<Book>
                {
                    new Book("Война и мир", "Лев Толстой"),
                    new Book("Преступление и наказание", "Фёдор Достоевский"),
                    new Book("Герой нашего времени", "Михаил Лермонтов")
                }
            }
        };


        public Form2()
        {
            InitializeComponent();
            InitializeGenres();
            this.FormClosing += Form1_FormClosing;


        }


       

        // Обработчик события BookReturned - добавляет информацию о возврате книги в лог
        private void OnBookReturned(object sender, BookActionEventArgs e)
        {
            string message = $"[{DateTime.Now:T}] Книга '{e.BookTitle}' была возвращена {e.ActionDate:d}";
            richTextBox1.AppendText(message + Environment.NewLine);
        }

        // Обработчик события BookBorrowed - добавляет информацию о взятии книги в лог
        private void OnBookBorrowed(object sender, BookActionEventArgs e)
        {
            string message = $"[{DateTime.Now:T}] Книга '{e.BookTitle}' была взята {e.ActionDate:d}";
            richTextBox1.AppendText(message + Environment.NewLine);
        }
        // второй обработчик - выводит уведомление в виде MessageBox
        private void OnBookBorrowedNotification(object sender, BookActionEventArgs e)
        {
            MessageBox.Show($"Уведомление: Книга '{e.BookTitle}' была взята.", "Уведомление");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Завершаем все процессы, связанные с текущим приложением
            Process.GetCurrentProcess().Kill();
        }
        private void InitializeGenres()
        {
            comboBox1.Items.AddRange(booksByGenre.Keys.ToArray());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Получение данных из текстовых полей
            string fullName = textBox1.Text + " " + textBox2.Text; // Собираем полное имя
            string bookTitle = textBox3.Text;
            string bookAuthor = textBox4.Text;

            // Формируем строку для поиска
            string recordToRemove = $"{fullName} взял(а) книгу '{bookTitle}' {bookAuthor}";
            string filePath = "borrowed_books.txt";

            // Читаем строки из файла
            List<string> lines = new List<string>(File.ReadAllLines(filePath));
            bool bookReturned = false;

            // Удаляем строку о возврате книги
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                if (lines[i].StartsWith(recordToRemove))
                {
                    lines.RemoveAt(i);
                    bookReturned = true;
                    break;
                }
            }

            if (bookReturned)
            {
                // Создаем объект Reader, передавая ID и полное имя
                int readerId = new Random().Next(1, 1000); // Генерируем случайный ID
                Reader reader = new Reader(readerId, fullName);

                // Подписываемся на событие возврата книги
                reader.BookReturned += OnBookReturned;

                // Возвращаем книгу и вызываем событие
                reader.ReturnBook(bookTitle);

                // Перезаписываем файл с удаленной строкой
                File.WriteAllLines(filePath, lines);

                // Находим жанр книги, чтобы вернуть её в список
                foreach (var genre in booksByGenre)
                {
                    foreach (var book in genre.Value)
                    {
                        if (book.Title == bookTitle && book.Author == bookAuthor)
                        {
                            MessageBox.Show($"Книга '{bookTitle}' возвращена в библиотеку.");
                            return;
                        }
                    }
                }

                // Если книга не найдена, добавляем её в выбранный жанр
                if (comboBox1.SelectedItem != null)
                {
                    string selectedGenre = comboBox1.SelectedItem.ToString();
                    if (!booksByGenre.ContainsKey(selectedGenre))
                        booksByGenre[selectedGenre] = new List<Book>();

                    booksByGenre[selectedGenre].Add(new Book(bookTitle, bookAuthor));

                    // Обновляем listBox1
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(booksByGenre[selectedGenre].ToArray());

                    MessageBox.Show($"Книга '{bookTitle}' была возвращена в библиотеку и добавлена в жанр '{selectedGenre}'.");
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите жанр для возвращенной книги.");
                }
            }
            else
            {
                MessageBox.Show("Книга не найдена среди записей о взятых книгах.");
            }
        }





        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = textBox1.Text + " " + textBox2.Text; // Формируем полное имя

            if (listBox1.SelectedItem is Book selectedBook)
            {
                DateTime borrowDate = DateTime.Now;
                DateTime returnDate = borrowDate.AddDays(14);

                // Генерируем случайный ID для Reader
                int readerId = new Random().Next(1, 1000);

                // Создаем объект Reader с учетом нового конструктора
                Reader reader = new Reader(readerId, fullName);

                // Подписываемся на события
                reader.BookBorrowed += OnBookBorrowed;
                reader.BookBorrowed += OnBookBorrowedNotification;

                // Взятие книги и вызов события
                reader.BorrowBook(selectedBook.Title, borrowDate);

                // Сохранение информации о взятой книге в файл
                reader.SaveBorrowedBookToFile(selectedBook.Title, selectedBook.Author, borrowDate, "borrowed_books.txt");

                // Удаляем книгу из списка
                listBox1.Items.Remove(selectedBook);

                // Показываем сообщение о взятии книги
                MessageBox.Show($"Информация о взятой книге сохранена.\n" +
                                $"Книгу '{selectedBook.Title}' нужно вернуть до: {returnDate:d}",
                                "Информация о взятой книге");
            }
            else
            {
                // Сообщение, если книга не выбрана
                MessageBox.Show("Пожалуйста, выберите книгу из списка.", "Ошибка");
            }
        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenre = comboBox1.SelectedItem.ToString();
            listBox1.Items.Clear();

            if (booksByGenre.ContainsKey(selectedGenre))
            {
                listBox1.Items.AddRange(booksByGenre[selectedGenre].ToArray());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime Time = dateTimePicker1.Value;


            DateTime returnDate = Time.AddDays(14);
            MessageBox.Show($"Книгу нужно вернуть до: {returnDate:d}",
                               "Информация о взятой книге");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
