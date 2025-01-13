using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_REST_API.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
