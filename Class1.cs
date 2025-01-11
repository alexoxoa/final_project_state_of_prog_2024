using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace final_project_state_of_prog_2024
{
    // Интерфейс для обработки действий с книгами (Borrow, Return)
    public interface IBorrowable
    {
        void BorrowBook(string bookTitle, DateTime borrowDate);
        void ReturnBook(string bookTitle);
    }

    // Интерфейс для обработки действий сотрудников библиотеки
    public interface IEmployeeActions
    {
        void ManageBorrowedBooks();
        void NotifyReaders();
    }

    // Интерфейс для обработки действий пользователя (например, читателя)
    public interface IUserActions
    {
        string GetInfo(); // Получить информацию о пользователе
    }

    public class Reader : Person, IBorrowable, IUserActions
    {
        //Композиция

        public Dictionary<string, DateTime> BorrowedBooks { get; set; } = new Dictionary<string, DateTime>();

        public Person Person
        {
            get => default;
            set
            {
            }
        }

        public Reader(int id, string fullName)
            : base(id, fullName) { }

        public override string GetInfo()
        {
            string borrowedBooksInfo = BorrowedBooks.Count > 0
                ? string.Join("\n", BorrowedBooks.Select(b => $"- {b.Key} (Взяты: {b.Value:d})"))
                : "Нет взятых книг.";

            return $"ID: {ID}, Полное имя: {FullName}\nВзятые книги:\n{borrowedBooksInfo}";
        }

        // Реализация интерфейса IBorrowable
        public void BorrowBook(string bookTitle, DateTime borrowDate)
        {
            BorrowedBooks[bookTitle] = borrowDate;
            BookBorrowed?.Invoke(this, new BookActionEventArgs(bookTitle, borrowDate));
        }

        public void BorrowBook(Book book, DateTime borrowDate)
        {
            BorrowedBooks[book.Title] = borrowDate;
        }
        public void BorrowBook(string bookTitle)
        {
            BorrowBook(bookTitle, DateTime.Now);
        }

        public void ReturnBook(string bookTitle)
        {
            DateTime returnDate = DateTime.Now;
            BorrowedBooks.Remove(bookTitle);
            BookReturned?.Invoke(this, new BookActionEventArgs(bookTitle, returnDate));
        }

        public void SaveBorrowedBookToFile(string bookTitle, string author, DateTime borrowDate, string filePath)
        {
            string record = $"{FullName} взял(а) книгу '{bookTitle}' {author} {borrowDate:d}\n";
            File.AppendAllText(filePath, record);
        }

        public delegate void BookActionEventHandler(object sender, BookActionEventArgs e);
        public event BookActionEventHandler BookBorrowed;
        public event BookActionEventHandler BookReturned;
    }

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

        public override string GetInfo()
        {
            return $"ID: {ID}, Имя: {FullName}, Должность: {Position}, Адрес библиотеки: {LibraryAddress}";
        }

        // Реализация интерфейса IEmployeeActions
        public void ManageBorrowedBooks()
        {
            MessageBox.Show($"{FullName} управляет файлами книг.");
        }

        public void NotifyReaders()
        {
            MessageBox.Show($"{FullName} отправляет уведомления читателям.");
        }
        // Ассоциация
        public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>();

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
                richTextBox.Text += string.Join(Environment.NewLine, BorrowedBooks.Select(b => b.GetBookInfo())) + "\n";
            }
        }

        public BorrowedBook BorrowedBook
        {
            get => default;
            set
            {
            }
        }

        public Person Person
        {
            get => default;
            set
            {
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

    // Класс VipReader, наследник Person
    public class VipReader : Person, IUserActions
    {
        public string VIPLevel { get; set; }

        public Person Person
        {
            get => default;
            set
            {
            }
        }

        public VipReader(int id, string fullName, string vipLevel)
            : base(id, fullName)
        {
            VIPLevel = vipLevel;
        }

        public override string GetInfo()
        {
            return $"VIP Reader: {FullName}, Привилегия: {VIPLevel}\n";
        }
    }

    // Агрегация
    public class VipClient
    {
        private VipReader _vipReader;

        public VipClient(VipReader vipReader)
        {
            _vipReader = vipReader;
        }

        public void GetClientInfo()
        {
             MessageBox.Show(_vipReader.GetInfo());

        }
    }


}
