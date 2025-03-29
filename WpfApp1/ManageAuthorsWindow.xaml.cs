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
    /// Логика взаимодействия для ManageAuthorsWindow.xaml
    /// </summary>
    public partial class ManageAuthorsWindow : Window
    {
        private readonly LibraryDBContext _context;

        public ManageAuthorsWindow(LibraryDBContext context)
        {
            InitializeComponent();
            _context = context;
            LoadAuthors();
        }

        public ObservableCollection<Author> Authors { get; set; }

        private void LoadAuthors()
        {
            Authors = new ObservableCollection<Author>(_context.Authors.ToList());
            AuthorsListBox.ItemsSource = Authors;
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            string authorName = AuthorNameTextBox.Text;
            string[] nameParts = authorName.Split(' ');

            if (nameParts.Length < 2)
            {
                MessageBox.Show("Please, enter author's First and Last names");
                return;
            }

            var author = new Author
            {
                FirstName = nameParts[0],
                LastName = nameParts[1]
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
            LoadAuthors();
        }

        private void EditAuthor_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = (Author)AuthorsListBox.SelectedItem;
            if (selectedAuthor != null)
            {
                string authorName = AuthorNameTextBox.Text;
                string[] nameParts = authorName.Split(' ');

                if (nameParts.Length < 2)
                {
                    MessageBox.Show("Please, enter author's First and Last names");
                    return;
                }

                selectedAuthor.FirstName = nameParts[0];
                selectedAuthor.LastName = nameParts[1];

                _context.SaveChanges();
                LoadAuthors();
            }
        }

        private void DeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = (Author)AuthorsListBox.SelectedItem;
            if (selectedAuthor != null)
            {
                _context.Authors.Remove(selectedAuthor);
                _context.SaveChanges();
                LoadAuthors();
            }
        }
        private void AuthorsListBox_SelectionChangedd(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedAuthor = (Author)AuthorsListBox.SelectedItem;
            if (selectedAuthor != null)
            {
                AuthorNameTextBox.Text = selectedAuthor.FirstName + " " + selectedAuthor.LastName;
            }
        }

    }
}

