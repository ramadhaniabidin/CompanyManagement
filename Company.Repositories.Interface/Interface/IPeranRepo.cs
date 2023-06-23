using Company.Models;

namespace Company.Repositories.Interface
{
    public interface IPeranRepo
    {
        public Task<bool> EditPeran(int id, Peran model);
        public Task<bool> HapusPeran(int id);
        public Task<bool> TambahPeran(Peran model);
    }
}
