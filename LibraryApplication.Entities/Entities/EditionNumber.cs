using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.Entities
{
    [Table("EditionNumbers")]
    public class EditionNumber
    {

        public EditionNumber()
        {
            BookEditionNumbers = new List<BookEditionNumber>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EditionNumberID { get; set; }
        [Display(Name = "Basım Numarası", Prompt = "Lütfen Basım Numarası Değerini Giriniz.")]
        [Range(1, 100000, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public string EditionNumberBook { get; set; }
        public virtual ICollection<BookEditionNumber> BookEditionNumbers { get; }
    }

}
