using Company.Models;

namespace Company.Services.Interface
{
    public interface IAkunService
    {
        public Task<bool> Buat(Akun model);
        public Task<DataTransferModel> Detail(int idAkun);
        public Task<DataTransferModel> InComplete(int idAkun);
        public Task<Akun> Index(int id);
        public Task<bool> Hapus(int idAkun);
    }
}
