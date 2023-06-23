using Company.Models;

namespace Company.Services.Interface
{
    public interface IPeranAkunService
    {
        public Task<bool> UbahPeran(int id, Peran_Akun model);
        public Task<bool> HapusPeran(int id);
        public Task<bool> TambahPeran(int idAkun, Peran_Akun model);
    }
}
