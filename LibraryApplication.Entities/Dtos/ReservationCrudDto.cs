using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
    public class ReservationCrudDto
    {
        public int ReservationID { get; set; }
        public int BookEditionNumberID { get; set; }
        public int UserID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? BookReceivedDate { get; set; }
    }
}
