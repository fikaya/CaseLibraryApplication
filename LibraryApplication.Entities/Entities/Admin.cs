using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Entities
{
    [Table("Admins")]
   public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Display(Name = "Kullanıcı Adı", Prompt = "Lütfen Kullanıcı Adını Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string UserName { get; set; }
        [Display(Name = "Kullanıcı Mail Adresi", Prompt = "Lütfen Kullanıcı Mail Adresini Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [StringLength(maximumLength: 40, MinimumLength = 10, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string AdminEMail { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}

 
