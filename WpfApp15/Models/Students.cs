using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp15.Models
{
    internal class Students
    {
        [Key]
        public int std_id {  get; set; }
        public string name { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
