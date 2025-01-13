using Biblioteca_REST_API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_REST_API.Models
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
