using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// <summary>
    /// Логика взаимодействия для MangeGenresWindow.xaml
    /// </summary>
    public partial class MangeGenresWindow : Window
    {
        private readonly LibraryDBContext _context;
        public MangeGenresWindow(LibraryDBContext context)
        {
            InitializeComponent();
            _context = context;
            LoadGenres();
        }
        public ObservableCollection<Genre> Genres { get; set; }

        private void LoadGenres()
        {
            Genres = new ObservableCollection<Genre>(_context.Genres.ToList());
            GenresListBox.ItemsSource = Genres;
        }

        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            string genreName = GenreNameTextBox.Text;

            if (string.IsNullOrEmpty(genreName))
            {
                MessageBox.Show("Please, enter a genre name.");
                return;
            }

            var genre = new Genre
            {
                Name = genreName
            };

            _context.Genres.Add(genre);
            _context.SaveChanges();
            LoadGenres();
        }

        private void EditGenre_Click(object sender, RoutedEventArgs e)
        {
            var selectedGenre = (Genre)GenresListBox.SelectedItem;
            if (selectedGenre != null)
            {
                string genreName = GenreNameTextBox.Text;

                if (string.IsNullOrEmpty(genreName))
                {
                    MessageBox.Show("Please, enter a genre name.");
                    return;
                }

                selectedGenre.Name = genreName;

                _context.SaveChanges();
                LoadGenres();
            }
        }

        private void DeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            var selectedGenre = (Genre)GenresListBox.SelectedItem;
            if (selectedGenre != null)
            {
                _context.Genres.Remove(selectedGenre);
                _context.SaveChanges();
                LoadGenres();
            }
        }
    }
}
