using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class ReservationCrudViewModel
    {
        public int ReservationID { get; set; }
        [Display(Name = "Kitap Basım Numarası", Prompt = "Lütfen Kitap Basım Numarasını Seçiniz.")]
        [Required(ErrorMessage = "Basım Numrası Alanı Boş Geçilemez.")]
        public int BookEditionNumberID { get; set; }
        [Display(Name = "Kullanıcı Adı", Prompt = "Lütfen Kullanıcı Adını Seçiniz.")]
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Geçilemez.")]
        public int UserID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Kitap Alım Tarihi")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public DateTime ReservationDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Kitap Teslim Tarihi")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez")]
        public DateTime DeliveryDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true, NullDisplayText = "Henüz Kitap Teslimi Yapılmadı.")]
        [Display(Name = "Kullanıcı Geri Alım Tarihi")]
        public DateTime? BookReceivedDate { get; set; }

    }
}

