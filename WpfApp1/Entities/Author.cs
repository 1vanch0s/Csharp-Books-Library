using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entities
{
    public class Author
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string FullName => FirstName + " " + LastName;

        public DateTime BirthDate { get; set; }

        public string Country { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new List<Book>();
        
    }
}
