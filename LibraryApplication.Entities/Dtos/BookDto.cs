using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
    public class BookDto
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
    }
}
