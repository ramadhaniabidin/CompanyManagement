using Company.Models;

namespace Company.Services.Interface
{
    public interface IPenggunaService
    {
        public Task<bool> UbahData(Pengguna model, int id);
        public Task<bool> TambahPengguna(Pengguna model, int id);
    }
}
