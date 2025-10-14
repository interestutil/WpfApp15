using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp15.Models
{
    internal class Course_degrees
    {
        [Key, Column(Order =0)]
        public int std_id { get; set; }
        [Key, Column(Order = 1)]
        public int c_id { get; set; }
        [ForeignKey("std_id")]
        public virtual Students Students { get; set; }
        [ForeignKey("c_id")]
        public virtual Courses Courses { get; set; }

        public int? degree { get; set; }
     }
}
