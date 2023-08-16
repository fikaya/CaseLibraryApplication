using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class BookEditionNumberViewModel
    {
        public int BookEditionNumberID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int EditionNumberID { get; set; }
        public string EditionNumber { get; set; }
        public string ISBN { get; set; }
        public int NumberOfBook { get; set; }
        public int ReleasePage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PicturePath { get; set; }

    }
}