using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.MsSql
{
    public class AppSetting
    {
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEMail { get; set; }

    }
}
