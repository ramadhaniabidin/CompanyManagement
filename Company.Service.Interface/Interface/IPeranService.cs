using Company.Models;

namespace Company.Services.Interface
{
    public interface IPeranService
    {
        public Task<bool> EditPeran(int id, Peran model);
        public Task<bool> HapusPeran(int id);
        public Task<bool> TambahPeran(Peran model);
    }
}
