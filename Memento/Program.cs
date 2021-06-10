using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Isbn = "12345", Author = "Victor Hugo", Title = "Sefiller" };

            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "6060";
            book.Title = "ORHAN VELİ";
            Console.WriteLine("\n *******************");
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);

            Console.WriteLine("\n *******************");

            book.ShowBook();
            Console.ReadLine();
        }
    }
    class Book
    {
        private string _title;
        private string _author;
        private string _ısbn;
        private DateTime _lastEdited;
        public string Title 
        {
            get { return _title; } 

            set 
            {
                SetLastEdited();
                _title = value;
            }
        }

        public string Author 
        { 
            get { return _author; } 
            set 
            {
                SetLastEdited();
                _author = value;
            } 
        }

        public string Isbn 
        { 
            get { return _ısbn; } 
            set  
            {
                SetLastEdited();
                _ısbn = value;
            } 
        }
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }
        public Memento CreateUndo()
        {
            return new Memento(_ısbn, _author, _title, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _ısbn = memento.Isbn;
            _author = memento.Author;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine(" Başlık : {0}\n Yönetmen : {1}\n Isbn No : {2}\n Güncelleme Tarihi : {3}", Title, Author, Isbn, _lastEdited );
        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string author, string title, DateTime lastEdited)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
