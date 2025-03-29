using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Data;
using WpfApp1.Entities;

namespace WpfApp1
{
    public partial class AddBookWindow : Window
    {
        private readonly LibraryDBContext _context;

        public AddBookWindow(LibraryDBContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            string authorName = AuthorTextBox.Text;
            string[] nameParts = authorName.Split(' ');

            if (nameParts.Length < 2)
            {
                MessageBox.Show("Please, enter author's First and Last names");
                return;
            }

            // Поиск или создание автора
            var author = _context.Authors.FirstOrDefault(a => a.FirstName == nameParts[0] && a.LastName == nameParts[1]);
            if (author == null)
            {
                author = new Author
                {
                    FirstName = nameParts[0],
                    LastName = nameParts[1]
                };
                _context.Authors.Add(author);
            }

            // Поиск или создание жанра
            var genre = _context.Genres.FirstOrDefault(g => g.Name == GenreTextBox.Text);
            if (genre == null)
            {
                genre = new Genre
                {
                    Name = GenreTextBox.Text
                };
                _context.Genres.Add(genre);
            }
            if ( (PublishYearTextBox.Text.Length) > 4)
            {
                MessageBox.Show("Please, enter valid Year of publishment");
                return;
            };

            // Создаем новую книгу
            var newBook = new Book
            {
                Title = TitleTextBox.Text,
                Author = author,
                Genre = genre,
                PublishYear = int.Parse(PublishYearTextBox.Text),
                IBSN = IBSNTextBox.Text,
                QuantityInStock = int.Parse(QuantityTextBox.Text)
            };

            _context.Books.Add(newBook);
            _context.SaveChanges(); // Сохраняем изменения в БД

            this.Close();
        }
    }
}