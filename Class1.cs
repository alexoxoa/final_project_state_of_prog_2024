using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace final_project_state_of_prog_2024
{
    public class Reader : Person
    {

        // Словарь для хранения книг и дат их взятия
        public Dictionary<string, DateTime> BorrowedBooks { get; set; } = new Dictionary<string, DateTime>();

        // Конструктор для инициализации ID и полного имени
        public Reader(int id, string fullName)
            : base(id, fullName) { }

        // Реализация абстрактного метода GetInfo
        public override string GetInfo()
        {
            string borrowedBooksInfo = BorrowedBooks.Count > 0
                ? string.Join("\n", BorrowedBooks.Select(b => $"- {b.Key} (Borrowed on: {b.Value:d})"))
                : "No borrowed books.";

            return $"ID: {ID}, Full Name: {FullName}\nBorrowed Books:\n{borrowedBooksInfo}";
        }

        // Метод для добавления взятой книги
        public virtual void BorrowBook(string bookTitle, DateTime borrowDate)
        {
            BorrowedBooks[bookTitle] = borrowDate;
            BookBorrowed?.Invoke(this, new BookActionEventArgs(bookTitle, borrowDate));
        }

        // Метод для возврата книги
        public void ReturnBook(string bookTitle)
        {
            DateTime returnDate = DateTime.Now;
            BorrowedBooks.Remove(bookTitle);
            BookReturned?.Invoke(this, new BookActionEventArgs(bookTitle, returnDate));
        }

        // Метод для сохранения информации о взятой книге в файл
        public void SaveBorrowedBookToFile(string bookTitle, string author, DateTime borrowDate, string filePath)
        {
            string record = $"{FullName} взял(а) книгу '{bookTitle}'  {author}  {borrowDate:d}\n";
            File.AppendAllText(filePath, record);
        }

        // Делегат для обработки событий действия с книгами (взятие или возврат)
        public delegate void BookActionEventHandler(object sender, BookActionEventArgs e);

        // События для уведомления о действиях с книгами
        public event BookActionEventHandler BookBorrowed;
        public event BookActionEventHandler BookReturned;
    }


    //public class VIPReader : Reader
    //{
    //    public VIPReader(int id, string firstName, string lastName)
    //        : base(id, firstName, lastName) { }

    //    // Переопределяем метод BorrowBook для VIPReader
    //    public override void BorrowBook(string bookTitle, DateTime borrowDate)
    //    {
    //        base.BorrowBook(bookTitle, borrowDate);
    //        Console.WriteLine("VIP читатель взял книгу!");
    //    }

    //    // Добавляем дополнительную информацию для VIPReader
    //    public override string GetInfo()
    //    {
    //        return base.GetInfo() + "\nСтатус: VIP";
    //    }
    //}




    // Класс для передачи данных о событии (название книги и дата действия)
    public class BookActionEventArgs : EventArgs
    {
        public string BookTitle { get; }
        public DateTime ActionDate { get; }

        public BookActionEventArgs(string bookTitle, DateTime actionDate)
        {
            BookTitle = bookTitle;
            ActionDate = actionDate;
        }
    }




    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        // Переопределим метод ToString для удобного отображения в listBox1
        public override string ToString()
        {
            return $"{Title} — {Author}";
        }
    }
    public abstract class Person
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public Person(int id, string fullName)
        {
            ID = id;
            FullName = fullName;
        }

        // Абстрактный метод для предоставления информации о человеке
        public abstract string GetInfo();

    }


    public class LibraryEmployee : Person, IEmployeeActions
    {
        public string Position { get; set; }
        public string LibraryAddress { get; set; }

        public LibraryEmployee(int id, string fullName, string position, string libraryAddress)
            : base(id, fullName)
        {
            Position = position;
            LibraryAddress = libraryAddress;
        }

        // Реализация абстрактного метода
        public override string GetInfo()
        {
            return $"ID: {ID}, Имя: {FullName}, Должность: {Position}, Адрес библиотеки: {LibraryAddress}";
        }

        public void ManageBorrowedBooks()
        {
            MessageBox.Show($"{FullName} управляет файлами книг.");
        }

        public void NotifyReaders()
        {
            MessageBox.Show($"{FullName} отправляет уведомления читателям.");
        }

        public List<BorrowedBook> BorrowedBooks { get; set; } = new();

        public void AddBook(BorrowedBook book)
        {
            BorrowedBooks.Add(book);
        }

        public void ListBorrowedBooks(RichTextBox richTextBox)
        {
            if (BorrowedBooks.Count == 0)
            {
                richTextBox.Text = "Список заимствованных книг пуст.";
            }
            else
            {
                richTextBox.Text = string.Join(Environment.NewLine, BorrowedBooks.Select(b => b.GetBookInfo()));
            }
        }

    }


    public class BorrowedBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime BorrowDate { get; set; }

        public BorrowedBook(string title, string author, DateTime borrowDate)
        {
            Title = title;
            Author = author;
            BorrowDate = borrowDate;
        }

        public string GetBookInfo()
        {
            return $"{Title} {Author}, добавлено {BorrowDate.ToShortDateString()}";
        }
    }


    public interface IEmployeeActions
    {
        void ManageBorrowedBooks(); // Управление файлами книг
        void NotifyReaders();       // Отправка уведомлений
    }


}



