using Company.Models;

namespace Company.Services.Interface
{
    public interface IPenggunaKantorService
    {
        public Task<bool> GantiKantor(int id, Pengguna_Kantor model);
        public Task<bool> HapusKantor(int id);
        public Task<bool> TambahKantor(int idPengguna, Pengguna_Kantor model);
    }
}
