using Microsoft.EntityFrameworkCore;
using System.Text;
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
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BookViewModel _viewModel;


        public MainWindow()
        {
            InitializeComponent();

            var context = new LibraryDBContext(); // Создаём контекст для работы с БД
            _viewModel = new BookViewModel(context);

            DataContext = _viewModel;

            // Привязываем коллекцию книг к DataGrid
            BooksDataGrid.ItemsSource = _viewModel.Books;
        }

        // Обработчик для кнопки "Search by Author"
        private void SearchByAuthor_Click(object sender, RoutedEventArgs e)
        {

            _viewModel.SearchBooksByAuthor(AuthorSearchBox.Text);  // Передаем текст в ViewModel для поиска
        }


        // Обработчик для кнопки "Search by Genre"
        private void SearchByGenre_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SearchBooksByGenre(GenreSearchBox.Text);

        }
        private void SearchByName_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SearchBooksByName(SearchByName.Text);
        }

        private void SearchByGenreAndAuthor_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SearchBooksByGenreAndAuthor(GenreSearchBox.Text, AuthorSearchBox.Text);
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBookWindow(new LibraryDBContext()); 
            addBookWindow.ShowDialog();
        }
        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = (Book)BooksDataGrid.SelectedItem;
            if (selectedBook != null)
            {
                var editBookWindow = new EditBookWindow(new LibraryDBContext(), selectedBook); 
                editBookWindow.ShowDialog();
            }
        }

        private void EditAuthors_Click (object sender, RoutedEventArgs e)
        {
            var ManageAuthorsWindow = new ManageAuthorsWindow(new LibraryDBContext());
            ManageAuthorsWindow.ShowDialog();
        }

        private void EditGenres_Click(object sender, RoutedEventArgs e)
        {
            var manageGenresWindow = new MangeGenresWindow(new LibraryDBContext());
            manageGenresWindow.ShowDialog(); // Правильное использование метода ShowDialog
        }


        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = (Book)BooksDataGrid.SelectedItem;
            if (selectedBook != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new LibraryDBContext())
                    {
                        context.Books.Remove(selectedBook); // Удаление книги из базы данных
                        context.SaveChanges();
                    }

                    
                }
            }
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RefreshBooks();
            BooksDataGrid.ItemsSource = _viewModel.Books; 
        }



        private void SearchByGan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}