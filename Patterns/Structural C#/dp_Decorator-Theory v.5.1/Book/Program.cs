using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    /// <summary>
    /// Абстрактний клас Component
    /// </summary>
    abstract class LibraryItem
    {
        public int NumCopies { get; set; }

        public abstract void Display();
    }

    /// <summary>
    /// Клас ConcreteComponent
    /// </summary>
    class Book : LibraryItem
    {
        private string _author;
        private string _title;
        private int _year;

        public Book(string author, string title, int year, int numCopies)
        {
            this._author = author;
            this._title = title;
            this._year = year;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" Year: {0}", _year);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }
    //Оскільки ми додаємо лише одну декорацію(список тих, хто позичив елемент), то немає необхідності визначати абстрактний клас Decorator - пересилання запитів здійснюватимемо відразу в класі конкретної реалізації декорації.

    /// <summary>
    /// Клас ConcreteDecorator
    /// </summary>
    class Borrowable : LibraryItem
    {
        private LibraryItem _libraryItem;
        protected List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem libraryItem)
        {
            _libraryItem = libraryItem;
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            _libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            _libraryItem.NumCopies++;
        }

        public override void Display()
        {
            _libraryItem.Display();
            foreach (string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }
    //    У класі конкретної декорації ми додали посилання на об'єкт LibraryItem, який декоруємо, і список, в якому зберігатимемо тих, хто позичив книгу. Також, у цьому класі визначено два додаткових методи BorrowItem та ReturnItem. BorrowItem декрементує кількість копій елемента і додає в список того, хто її позичив, а ReturnItem - інкрементує кількість копій елемента та видаляє зі списку того, хто повернув книгу.

    //Тепер можна розглянути клієнтський код:
    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкт Book
            Book book = new Book("Gang of four", "Design patterns", 2013, 10);

            // Виводимо інформацію про книгу
            book.Display();

            // Огортаємо щойно створену книгу
            Borrowable borrowableBook = new Borrowable(book);

            // Зичимо книгу
            borrowableBook.BorrowItem("Customer #1");
            // Зичимо ще раз
            borrowableBook.BorrowItem("Customer #2");

            // Виводимо інформацію про книгу
            Console.WriteLine("\nAfter borrowing");
            borrowableBook.Display();

            // Віддаємо книгу
            borrowableBook.BorrowItem("Customer #2");

            // Виводимо інформацію про книгу ще раз
            Console.WriteLine("\nAfter returning");
            borrowableBook.Display();

            Console.ReadKey();
        }
    }
}

//Виведення програми:

//Book ------
// Author: Gang of four
// Title: Design Patterns
// Year: 2013
// # Copies: 10

//After borrowing
//Book ------
// Author: Gang of four
// Title: Design Patterns
// Year: 2013
// # Copies: 8
// borrower: Customer #1
// borrower: Customer #2

//After returning
//Book ------ 
// Author: Gang of four
// Title: Design Patterns
// Year: 2013
// # Copies: 9
// borrower: Customer #1
