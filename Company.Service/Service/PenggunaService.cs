using Company.Models;
using Company.Repositories.Interface;
using Company.Repositories.Repository;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class PenggunaService : IPenggunaService
    {
        private readonly IPenggunaRepository _penggunaRepository;
        public PenggunaService(IPenggunaRepository penggunaRepository)
        {
            _penggunaRepository = penggunaRepository;
        }

        public Task<bool> TambahPengguna(Pengguna model, int id)
        {
            return _penggunaRepository.TambahPengguna(model, id);
        }

        public Task<bool> UbahData(Pengguna model, int id)
        {
            return _penggunaRepository.UbahData(model, id);
        }
    }
}
