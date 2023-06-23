using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class Pengguna
    {
        public int id { get; set; }
        [Display(Name = "Nama")]
        public string? namaPengguna { get; set; }
        [Display(Name = "Alamat")]
        public string? alamat { get; set; }
        [Display(Name = "Kode Pos")]
        public string? kodePos { get; set; }
        [Display(Name = "Provinsi")]
        public string? provinsi { get; set; }
    }
}
