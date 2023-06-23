using Company.Models;
using Company.Repositories.Interface;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class PeranAkunService: IPeranAkunService
    {
        private readonly IPeranAkunRepository _repository;
        public PeranAkunService(IPeranAkunRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> HapusPeran(int id)
        {
            return _repository.HapusPeran(id);
        }

        public Task<bool> TambahPeran(int idAkun, Peran_Akun model)
        {
            return _repository.TambahPeran(idAkun, model);
        }

        public Task<bool> UbahPeran(int id, Peran_Akun model)
        {
            return _repository.UbahPeran(id, model);
        }
    }
}
