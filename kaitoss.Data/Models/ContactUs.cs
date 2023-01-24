using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaitoss.Data.Models
{
    public class ContactUs :BaseEntity
    {
        [StringLength(50)]
        public string Name{ get; set; }
        [StringLength(30)]
        public string Email{ get; set; }
        [StringLength(20)]
        public string Phone{ get; set; }
        [StringLength(50)]
        public string Subject{ get; set; }
        [StringLength(255)]
        public string Message{ get; set; }

    }
}
