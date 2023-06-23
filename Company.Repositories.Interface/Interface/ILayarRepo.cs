using Company.Models;

namespace Company.Repositories.Interface
{
    public interface ILayarRepo
    {
        public Task<List<Pengguna>> DaftarPengguna();
        public Task<List<Akun>> DaftarAkun();
        public Task<List<Kantor>> DaftarKantor();
        public Task<List<Peran>> DaftarPeran();
    }
}
