using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp15.Models
{
    internal class Courses
    {
        [Key]
        public int c_id { get; set; }
        public string name { get; set; }
    }
}
