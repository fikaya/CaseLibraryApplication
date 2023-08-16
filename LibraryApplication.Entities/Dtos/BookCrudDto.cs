using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
    public class BookCrudDto
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int PublisherID { get; set; }
    }
}
