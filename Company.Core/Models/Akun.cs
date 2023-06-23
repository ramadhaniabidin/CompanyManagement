using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class Akun
    {
        public int id { get; set; }
        [Display(Name = "Username")]
        public string namaAkun { get; set; }

        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Tanggal Daftar")]
        [DataType(DataType.Date)]
        public DateTime tanggalDaftar { get; set; }
    }
}
