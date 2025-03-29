using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfApp1.Data;
using WpfApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace WpfApp1.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly LibraryDBContext _context;

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                if (_books != value)
                {
                    _books = value;
                    OnPropertyChanged(nameof(Books));  // Уведомление об изменении свойства
                }
            }
        }

        public BookViewModel(LibraryDBContext context)
        {
            _context = context;
            Books = new ObservableCollection<Book>(_context.Books.Include(b => b.Author).Include(b => b.Genre).ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadBooksFromDatabase()
        {
            var booksFromDb = _context.Books.ToList();
            foreach (var book in booksFromDb)
            {
                Books.Add(book);
            }
        }
        public void SearchBooksByName(string Name)
        {
            var filteredBooks = _context.Books
            .Where(b => b.Title.Contains(Name))
            .ToList();
            Books.Clear();
            foreach (var book in filteredBooks)
            {
                Books.Add(book);
            }

        }
        public void SearchBooksByAuthor(string authorName)
        {

            if (!string.IsNullOrEmpty(authorName))
            {
                string[] nameParts = authorName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                var filteredBooks = _context.Books
                    .Where(b => nameParts.Length > 0 &&
                        b.Author.FirstName.Contains(nameParts[0]) &&
                        (nameParts.Length == 1 || b.Author.LastName.Contains(nameParts[1])))
                    .Include(b => b.Author)
                    .ToList();

                Books.Clear();
                foreach (var book in filteredBooks)
                {
                    Books.Add(book);
                }
                //Books = new ObservableCollection<Book>(filteredBooks);  // Обновляем коллекцию
            }
            else
            {
                MessageBox.Show("Please enter a valid search term.");
                Books = new ObservableCollection<Book>(_context.Books.Include(b => b.Author).ToList());
            }
        }

        public void SearchBooksByGenreAndAuthor(string genreName, string authorName)
        {
            if (!string.IsNullOrEmpty(authorName))
            {
                SearchBooksByAuthor(authorName);  // Используем уже существующую функцию для поиска по автору
            }

            if (!string.IsNullOrEmpty(genreName))
            {
                SearchBooksByGenre(genreName);  // Используем уже существующую функцию для поиска по жанру
            }
        }


        public void SearchBooksByGenre(string genreName)
        {
            var result = _context.Books.Where(b => b.Genre.Name.Contains(genreName)).ToList();

            Books.Clear();
            foreach (var book in result)
            {
                Books.Add(book);
            }
        }

        public void SaveBooks()
        {
            var booksList = Books.ToList();
        }

        public void RefreshBooks()
        {
            Books = new ObservableCollection<Book>(_context.Books.Include(b => b.Author).Include(b => b.Genre).ToList());
        }

        
    }
}
