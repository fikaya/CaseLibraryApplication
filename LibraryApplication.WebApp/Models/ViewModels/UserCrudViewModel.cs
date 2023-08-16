using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class UserCrudViewModel
    {
        public int UserID { get; set; }
        [Display(Name = "Kullanıcı Adı", Prompt = "Lütfen Kullanıcı Adını Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez.")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string UserName { get; set; }
        [Display(Name = "Kullanıcı Soyadı", Prompt = "Lütfen Kullanıcı Soyadını Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez.")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string UserSurname { get; set; }
        [EmailAddress]
        [Display(Name = "Kullanıcı Mail Adresi", Prompt = "Lütfen Kullanıcı Mail Adresini Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez.")]
        [StringLength(maximumLength: 40, MinimumLength = 10, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string UserEMail { get; set; }
        [Display(Name = "Kullanıcı Türkiye Cumhuriyeti Kimlik Numarası", Prompt = "Lütfen Kullanıcı Mail Adresini Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez.")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string UserIdentityNumber { get; set; }
        [Phone]
        [Display(Name = "Kullanıcı Telefon Numarası", Prompt = "Lütfen Kullanıcı Telefon Numrasını Giriniz.")]
         [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        [RegularExpression(@"^(05(\d{9}))$", ErrorMessage = "Lütfen Kullanıcı Telefon Numrasını Doğru Bir Formatta Giriniz.(05xxxxxxxxx)")]
        public string UserTelephoneNumber { get; set; }
        //DataFormatString değerini gereken alana o formatta uygulansın mının cevabını ApplyFormatInEditMode alanına veriyoruz ve o uyguluyor.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Kullanıcı Doğum Tarihi")]
         public DateTime UserBirthDate { get; set; }
    }
}
