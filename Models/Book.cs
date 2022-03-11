using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetApiRestExample.Models
{
    // Entity de base de datos
    [Table("LIB_BOOKS")]
    public class Book
    {
        [Column("BOO_ID")]
        public int Id { get; set; }
        [Column("BOO_TITLE")]
        public string Title { get; set; }
        [Column("BOO_AUTHOR")]
        public string Author { get; set; }
        [Column("BOO_CREATED")]
        public DateTime Created { get; set; }
        [Column("BOO_PAGES")]
        public int Pages { get; set; }
    }
}
