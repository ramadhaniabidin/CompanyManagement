using Company.Models;
using Company.Repositories.Interface;
using Company.Services.Interface;

namespace Company.Services.Service
{
    public class LayarAkunService: ILayarAkunService
    {
        private readonly ILayarAkunRepo _repo;
        public LayarAkunService(ILayarAkunRepo repo)
        {
            _repo = repo;
        }

        public Task<bool> GantiAkses(int id, LayarAkun model)
        {
            return _repo.GantiAkses(id, model);
        }

        public Task<bool> HapusAkses(int id)
        {
            return _repo.HapusAkses(id);
        }

        public Task<bool> TambahAkses(int idAkun, LayarAkun model)
        {
            return _repo.TambahAkses(idAkun, model);
        }

    }
}
