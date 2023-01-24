using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaitoss.Data.Models
{
    public class Blog:BaseEntity
    {
        [StringLength(50)]
        public string Title{ get; set; }
        [StringLength(250)]
        public string Details { get; set; }
        [StringLength(150)]
        public string Logo { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
