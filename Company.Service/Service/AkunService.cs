using Company.Models;
using Company.Repositories.Interface;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class AkunService : IAkunService
    {
        private readonly IAkunRepository akun;
        public AkunService(IAkunRepository _akun)
        {
            akun = _akun;
        }
        public Task<bool> Buat(Akun model)
        {
            return akun.Buat(model);
        }

        public Task<DataTransferModel> Detail(int idAkun)
        {
            return akun.Detail(idAkun);
        }

        public Task<bool> Hapus(int idAkun)
        {
            return akun.Hapus(idAkun);
        }

        public Task<DataTransferModel> InComplete(int idAkun)
        {
            return akun.InComplete(idAkun);
        }

        public Task<Akun> Index(int id)
        {
            return akun.Index(id);
        }
    }
}
