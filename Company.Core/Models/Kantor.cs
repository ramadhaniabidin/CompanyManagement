using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class Kantor
    {
        public int id { get; set; }
        [Display(Name = "Kantor")]
        public string namaCabang { get; set; }
    }
}
