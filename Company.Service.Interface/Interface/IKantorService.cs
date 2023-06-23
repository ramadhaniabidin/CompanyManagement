using Company.Models;

namespace Company.Services.Interface
{
    public interface IKantorService
    {
        public Task<bool> UbahKantor(int id, Kantor model);
        public Task<bool> HapusKantor(int id);
        public Task<bool> TambahKantor(Kantor model);
    }
}
