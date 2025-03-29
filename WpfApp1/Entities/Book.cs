using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entities;


namespace WpfApp1.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId {  get; set; }
        public Author Author { get; set; } = null!;

        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        [Required, MaxLength(4)]
        public int PublishYear { get; set; }

        [Required, MaxLength(13)]
        public string IBSN { get; set; } = string.Empty;

        public int QuantityInStock {  get; set; }
        
    }
}
