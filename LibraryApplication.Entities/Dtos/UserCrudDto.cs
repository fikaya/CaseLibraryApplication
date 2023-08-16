using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
    public class UserCrudDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEMail { get; set; }
        public string UserIdentityNumber { get; set; }
        public string UserTelephoneNumber { get; set; }
        public DateTime UserBirthDate { get; set; }
    }
}
