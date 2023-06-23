using Company.Models;

namespace Company.Repositories.Interface
{
    public interface IPenggunaRepository
    {
        public Task<bool> UbahData(Pengguna model, int id);
        public Task<bool> TambahPengguna(Pengguna model, int id);
    }
}
