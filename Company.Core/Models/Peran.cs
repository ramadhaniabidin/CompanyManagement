using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Company.Models
{
    public class Peran
    {
        public int id { get; set; }
        [Display(Name = "Peran")]
        public string namaPeran { get; set; } 
    }
}
