using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserEMail { get; set; }
        public int Age { get; set; }
    }
}
