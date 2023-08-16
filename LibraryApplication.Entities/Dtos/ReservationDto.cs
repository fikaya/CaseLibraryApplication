using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
    public class ReservationDto
    {
        public int ReservationID { get; set; }
        public int BookEditionNumberID{ get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public bool? IsItDelivered { get; }
        public DateTime ReservationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? BookReceivedDate { get; set; }
    }
}
