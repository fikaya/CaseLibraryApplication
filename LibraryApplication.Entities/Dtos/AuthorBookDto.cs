using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
   public class AuthorBookDto
    {
        public int AuthorBookID { get; set; }
        public int AuthorID { get; set; }
        public string AuthorFullName { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }

    }
}
