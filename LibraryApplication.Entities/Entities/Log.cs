using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Entities.Entities
{
   public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("İşlem Tarihi")]
        public DateTime Date { get; set; }

        [Required, StringLength(20), DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }

        [StringLength(100), DisplayName("Action")]
        public string ActionName { get; set; }
        [StringLength(100000), DisplayName("Path")]
        public string Path { get; set; }

        [StringLength(100), DisplayName("Controller")]
        public string ControllerName { get; set; }

        [StringLength(250), DisplayName("Bilgi")]
        public string Description { get; set; }
    }
}
