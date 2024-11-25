using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace final_project_state_of_prog_2024
{
    public class Reader
    {
        // Свойства для хранения информации о читателе
        public string FirstName { get; set; }     // Имя читателя
        public string LastName { get; set; }      // Фамилия читателя

        // Словарь для хранения книг и дат их взятия
        public Dictionary<string, DateTime> BorrowedBooks { get; set; } = new Dictionary<string, DateTime>();

        // Конструктор для инициализации имени и фамилии
        public Reader(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Метод для добавления взятой книги
        //public void BorrowBook(string bookTitle, DateTime borrowDate)
        //{
        //    BorrowedBooks[bookTitle] = borrowDate;  // Добавляем или обновляем книгу с датой
        //}

        // Метод для отображения информации о читателе и взятых книгах
        public string GetReaderInfo()
        {
            string info = $"Reader: {FirstName} {LastName}\nBorrowed Books:\n";
            foreach (var book in BorrowedBooks)
            {
                info += $"- {book.Key} (Borrowed on: {book.Value:d})\n";
            }
            return info;
        }
        public void SaveBorrowedBookToFile(string bookTitle, string author, DateTime borrowDate, string filePath)
        {
            string record = $"{FirstName} {LastName} взял(а) книгу '{bookTitle}' '{author}' {borrowDate:d}\n";

            // Открываем файл в режиме добавления и записываем запись
            File.AppendAllText(filePath, record);
        }

        // Делегат для обработки событий действия с книгами (взятие или возврат)
        public delegate void BookActionEventHandler(object sender, BookActionEventArgs e);

        // Событие для уведомления о взятии книги
        public event BookActionEventHandler BookBorrowed;

        // Событие для уведомления о возврате книги
        public event BookActionEventHandler BookReturned;

        // Метод для взятия книги
        public virtual void BorrowBook(string bookTitle, DateTime borrowDate)
        {
            // Добавляем книгу в список взятых и генерируем событие BookBorrowed
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


    }

    public class VIPReader : Reader
    {
        public VIPReader(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        // Переопределяем метод BorrowBook для VIPReader
        public override void BorrowBook(string bookTitle, DateTime borrowDate)
        {
            // Вызываем базовый метод, чтобы добавить книгу и вызвать событие
            base.BorrowBook(bookTitle, borrowDate);

            // Дополнительная логика для VIPReader
            Console.WriteLine("VIP читатель взял книгу!");
        }
    }



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

    public class Person
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        public Person(int id, string fullName)
        {
            ID = id;
            FullName = fullName;
        }

        // Виртуальный метод для переопределения
        public virtual string GetInfo()
        {
            return $"ID: {ID}, Имя: {FullName}";
        }
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
            return base.GetInfo() + $", Должность: {Position}, Адрес библиотеки: {LibraryAddress}";
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





}



