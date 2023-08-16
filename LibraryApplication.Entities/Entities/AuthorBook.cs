using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.Entities
{
    [Table("AuthorBooks")]
    public class AuthorBook
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorBookID { get; set; }
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }

}
