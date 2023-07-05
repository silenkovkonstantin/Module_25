using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.DAL.Entities
{
    public class BookDescription
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        // Внешний ключ
        public int BookId { get; set; }
        // Навигационное свойство
        public Book Book { get; set; }
    }
}
