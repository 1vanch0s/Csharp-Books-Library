using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp1.Data;
using WpfApp1.Entities;

namespace WpfApp1
{
    public partial class EditBookWindow : Window
    {
        private readonly LibraryDBContext _context;
        private readonly Book _bookToEdit;

        public EditBookWindow(LibraryDBContext context, Book book)
        {
            InitializeComponent();
            _context = context;
            _bookToEdit = book;

            // Заполняем поля
            TitleTextBox.Text = _bookToEdit.Title;
            AuthorTextBox.Text = $"{_bookToEdit.Author.FirstName} {_bookToEdit.Author.LastName}";
            GenreTextBox.Text = _bookToEdit.Genre.Name;
            PublishYearTextBox.Text = _bookToEdit.PublishYear.ToString();
            IBSNTextBox.Text = _bookToEdit.IBSN;
            QuantityTextBox.Text = _bookToEdit.QuantityInStock.ToString();
        }

        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            string authorName = AuthorTextBox.Text;
            string[] nameParts = authorName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
            if ((PublishYearTextBox.Text.Length) > 4)
            {
                MessageBox.Show("Please, enter valid Year of publishment");
                return;
            }
            ;

            // Обновляем книгу
            _bookToEdit.Title = TitleTextBox.Text;
            _bookToEdit.Author = author;
            _bookToEdit.Genre = genre;
            _bookToEdit.PublishYear = int.Parse(PublishYearTextBox.Text);
            _bookToEdit.IBSN = IBSNTextBox.Text;
            _bookToEdit.QuantityInStock = int.Parse(QuantityTextBox.Text);

            _context.SaveChanges(); // Сохраняем изменения в БД

            this.Close();
        }
    }
}