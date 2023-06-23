using Company.Models;
using Company.Repositories.Interface;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class PeranService:IPeranService
    {
        private readonly IPeranRepo peranRepo;
        public PeranService(IPeranRepo peranRepo)
        {
            this.peranRepo = peranRepo;
        }

        public Task<bool> EditPeran(int id, Peran model)
        {
            return peranRepo.EditPeran(id, model);
        }

        public Task<bool> HapusPeran(int id)
        {
            return peranRepo.HapusPeran(id);
        }

        public Task<bool> TambahPeran(Peran model)
        {
            return peranRepo.TambahPeran(model);
        }
    }
}
