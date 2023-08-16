using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class BookEditionNumberCrudViewModel
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookEditionNumberID { get; set; }
        [Display(Name = "Kitap Adı", Prompt = "Lütfen Kitap Adını Seçiniz.")]
        [Required(ErrorMessage = "Kitap Adı Alanı Boş Geçilemez.")]
        public int BookID { get; set; }
        [Display(Name = "Kitap Basım Numarası", Prompt = "Lütfen Basım Numarasını Seçiniz.")]
        [Required(ErrorMessage = "Basım Numrası Alanı Boş Geçilemez.")]
        public int EditionNumberID { get; set; }
        //Kitap ISBN Numarası
        [Display(Name = "ISBN Değeri", Prompt = "Lütfen ISBN Değerini Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        [StringLength(maximumLength: 13, MinimumLength = 13, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string ISBN { get; set; }
        //Kitap Yayın Tarihi
        //DataFormatString değerini gereken alana o formatta uygulansın mının cevabını ApplyFormatInEditMode alanına veriyoruz ve o uyguluyor.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Kitap Yayın Tarihi")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public DateTime ReleaseDate { get; set; }
        //Kitap Yayın Sayfa Sayısı
        [Display(Name = "Kitap Yayın Sayfa Sayısı", Prompt = "Lütfen Kitap Yayın Sayfa Sayısını Giriniz.")]
        [Range(1, 100000, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public int ReleasePage { get; set; }
        //Kitap Adeti
        [Display(Name = "Kitap Adeti", Prompt = "Lütfen Kitap Adetini Giriniz.")]
        [Range(1, 100000, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public int NumberOfBook { get; set; }
        //Kitap Resmi
        public string PicturePath { get; set; }
    }
}

