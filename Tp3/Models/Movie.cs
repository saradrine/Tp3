using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Tp3.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
        public ICollection<Customer>? Customers { get; set; }

    }
}
