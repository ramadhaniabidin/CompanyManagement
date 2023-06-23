using Company.Models;
using Company.Repositories.Interface;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class LayarService: ILayarService
    {
        private readonly ILayarRepo _repo;
        public LayarService(ILayarRepo repo)
        {
            _repo = repo;
        }

        public Task<List<Akun>> DaftarAkun()
        {
            return _repo.DaftarAkun();
        }

        public Task<List<Kantor>> DaftarKantor()
        {
            return _repo.DaftarKantor();
        }

        public Task<List<Pengguna>> DaftarPengguna()
        {
            return _repo.DaftarPengguna();
        }

        public Task<List<Peran>> DaftarPeran()
        {
            return _repo.DaftarPeran();
        }
    }
}
