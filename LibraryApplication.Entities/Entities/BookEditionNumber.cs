using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.Entities
{
    [Table("BookEditionNumbers")]
    public class BookEditionNumber
    {
        public BookEditionNumber()
        {
            Reservations = new List<Reservation>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookEditionNumberID { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        [ForeignKey("EditionNumber")]
        public int EditionNumberID { get; set; }
        public virtual EditionNumber EditionNumber { get; set; }
        public int NumberOfBook { get; set; }
        //Kitap ISBN Numarası
        public string ISBN { get; set; }
        //Kitap Yayın Tarihi
        //DataFormatString değerini gereken alana o formatta uygulansın mının cevabını ApplyFormatInEditMode alanına veriyoruz ve o uyguluyor.
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        //Kitap Yayın Sayfa Sayısı
        public int ReleasePage { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
