using Company.Models;

namespace Company.Repositories.Interface
{
    public interface IPeranAkunRepository
    {
        public Task<bool> UbahPeran(int id, Peran_Akun model);
        public Task<bool> HapusPeran(int id);
        public Task<bool> TambahPeran(int idAkun, Peran_Akun model);
    }
}
