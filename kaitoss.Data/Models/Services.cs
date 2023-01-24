using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaitoss.Data.Models
{
    public class Services: BaseEntity
    {
        [StringLength(50)]
        public string  Title { get; set; }
        [StringLength(250)]
        public string Details { get; set; }
        [StringLength(50)]
        public string  Logo { get; set; }
    }
}
