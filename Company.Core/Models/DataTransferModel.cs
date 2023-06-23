using System.ComponentModel.DataAnnotations;

namespace Company.Models
{
    public class DataTransferModel: Pengguna
    {
        public int idPengguna { get; set; }
        public int idAkun { get; set; }
        public int idKantor { get; set; }
        public int idPeran { get; set; }
        public int idLayar { get; set; }
        public string namaAkun { get; set; }
        public string namaLayar { get; set; }
        public string password { get; set; }

        [Display(Name = "Tanggal Daftar")]
        [DataType(DataType.Date)]
        public DateTime tanggalDaftar { get; set; }
        public string namaCabang { get; set; }
        public string namaPeran { get; set; }
    }
}
