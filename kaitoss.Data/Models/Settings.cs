using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaitoss.Data.Models
{
    public class Settings:BaseEntity
    {
        [StringLength(50)]
        public string phone{ get; set; }
        [StringLength(30)]
        public string Email{ get; set; }
        [StringLength(50)]
        public string Address{ get; set; }
        [StringLength(150)]
        public string Schedule { get; set; }
    }
}
