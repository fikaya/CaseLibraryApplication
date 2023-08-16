using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            Reservations = new List<Reservation>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserFullName { get { return UserName + " " + UserSurname; } }
        public string UserEMail { get; set; }
        public string UserIdentityNumber { get; set; }
        public string UserTelephoneNumber { get; set; }
        public int Age { get { return DateTime.Now.Year - UserBirthDate.Year; } }
        public DateTime UserBirthDate { get; set; }
        public virtual ICollection<Reservation> Reservations { get; }
    }
}
