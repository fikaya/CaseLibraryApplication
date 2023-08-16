using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Dtos
{
   public class UserDto
    {
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserEMail { get; set; }
        public int UserAge { get; set; }
      
    }
}
