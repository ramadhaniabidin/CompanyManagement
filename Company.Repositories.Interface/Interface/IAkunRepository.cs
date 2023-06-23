using Company.Models;

namespace Company.Repositories.Interface
{
    public interface IAkunRepository
    {
        public Task<bool> Buat(Akun akun);
        public Task<DataTransferModel> Detail(int idAkun);
        public Task<Akun> Index(int id);
        public Task<bool> Hapus(int idAkun);
        public Task<DataTransferModel> InComplete(int idAkun);
    }
}
