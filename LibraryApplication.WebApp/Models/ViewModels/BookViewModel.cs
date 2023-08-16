using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class BookViewModel
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string PublisherName { get; set; }

    }
}
