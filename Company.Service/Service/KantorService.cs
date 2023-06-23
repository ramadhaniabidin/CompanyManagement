using Company.Models;
using Company.Repositories.Interface;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class KantorService: IKantorService
    {
        private readonly IKantorRepo kantorRepo;
        public KantorService(IKantorRepo kantorRepo)
        {
            this.kantorRepo = kantorRepo;
        }

        public Task<bool> HapusKantor(int id)
        {
            return kantorRepo.HapusKantor(id);
        }

        public Task<bool> TambahKantor(Kantor model)
        {
            return kantorRepo.TambahKantor(model);
        }

        public Task<bool> UbahKantor(int id, Kantor model)
        {
            return kantorRepo.UbahKantor(id, model);
        }
    }
}
