using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class ReservationViewModel
    {
        public int ReservationID { get; set; }
        public int BookEditionNumberID { get; set; }
        public string EditionNumberBook { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string PubliserName { get; set; }
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public bool? IsItDelivered { get; }
        public DateTime ReservationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? BookReceivedDate { get; set; }
    }
}
