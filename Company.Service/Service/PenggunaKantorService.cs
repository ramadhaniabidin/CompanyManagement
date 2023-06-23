using Company.Models;
using Company.Repositories.Interface;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class PenggunaKantorService: IPenggunaKantorService
    {
        private readonly IPenggunaKantorRepository _repository;
        public PenggunaKantorService(IPenggunaKantorRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> GantiKantor(int id, Pengguna_Kantor model)
        {
            return _repository.GantiKantor(id, model);
        }

        public Task<bool> HapusKantor(int id)
        {
            return _repository.HapusKantor(id);
        }

        public Task<bool> TambahKantor(int idPengguna, Pengguna_Kantor model)
        {
            return _repository.TambahKantor(idPengguna, model);
        }
    }
}
