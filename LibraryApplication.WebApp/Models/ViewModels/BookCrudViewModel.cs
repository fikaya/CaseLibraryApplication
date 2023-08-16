using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class BookCrudViewModel
    {
        public int BookID { get; set; }

        [Display(Name = "Kitap Adı", Prompt = "Lütfen Kitap Adını Giriniz.")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez.")]
        [StringLength(maximumLength: 150, MinimumLength = 2, ErrorMessage = "{0} Alanı Max {1} ve Min {2} Karakter Olabilir.")]
        public string BookName { get; set; }
        public string PublisherName { get; set; }
        [Display(Name = "Yayınevi Adı", Prompt = "Lütfen Yayınevi Seçiniz.")]
        [Required(ErrorMessage = "Yayınevi Adı Alanı Boş Geçilemez.")]
        public int PublisherID { get; set; }
        [Display(Name = "Yazar Adı", Prompt = "Lütfen Yazarı Seçiniz.")]
        [Required(ErrorMessage = "Yazar Adı Alanı Boş Geçilemez.")]
        public int AuthorID { get; set; }
    }
}

