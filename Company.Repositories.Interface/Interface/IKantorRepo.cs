using Company.Models;

namespace Company.Repositories.Interface
{
    public interface IKantorRepo
    {
        public Task<bool> UbahKantor(int id, Kantor model);
        public Task<bool> HapusKantor(int id);
        public Task<bool> TambahKantor(Kantor model);
    }
}
