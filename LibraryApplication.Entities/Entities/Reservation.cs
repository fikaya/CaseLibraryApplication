using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.Entities
{
    [Table("Reservations")]
    public class Reservation
    {
        public Reservation()
        {
            if (BookReceivedDate == null)
                IsItDelivered = null;
            else if (DeliveryDate >= BookReceivedDate)
                IsItDelivered = false;
            else
                IsItDelivered = true;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; }
        [ForeignKey("BookEditionNumber")]
        public int BookEditionNumberID { get; set; }
        public BookEditionNumber BookEditionNumber { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        //İlgili Rezervasyon Da Kitabı Zamanında Teslim Etti Mi?
        //Zamanında Teslim Etti İse True , Zamanında Teslim Etmedi İse False Değer Dönecek. Henüz BookReceivedDate Alanı Boş İse Burası Null olacak.
        public bool? IsItDelivered { get; }

        //Kullanıcı Kitap Alım Tarihi
        //DataFormatString değerini gereken alana o formatta uygulansın mının cevabını ApplyFormatInEditMode alanına veriyoruz ve o uyguluyor.
        //View tarafında DataFormatString yerine input alanında asp-format da kullanılabilirdi.Kullanıcıya bu formatta gösterilecek.
        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }

        //Kitap Teslim Edilmesi Gereken Tarihi
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        //Admin Kitap Geri Alım Tarihi 
        [DataType(DataType.DateTime)]
        public DateTime? BookReceivedDate { get; set; }
    }
}
