using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
    public class BookEditionNumberDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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