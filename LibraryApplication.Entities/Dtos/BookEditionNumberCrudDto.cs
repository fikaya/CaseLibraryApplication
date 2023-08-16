using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
    public class BookEditionNumberCrudDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookEditionNumberID { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        [ForeignKey("EditionNumber")]
        public int EditionNumberID { get; set; }
        public string ISBN { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasePage { get; set; }
        public int NumberOfBook { get; set; }
        public string PicturePath { get; set; }
    }
}
