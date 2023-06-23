using Company.Models;

namespace Company.Services.Interface
{
    public interface ILayarService
    {
        public Task<List<Pengguna>> DaftarPengguna();
        public Task<List<Akun>> DaftarAkun();
        public Task<List<Kantor>> DaftarKantor();
        public Task<List<Peran>> DaftarPeran();
    }
}
