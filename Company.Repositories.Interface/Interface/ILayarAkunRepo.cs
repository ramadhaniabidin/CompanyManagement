using Company.Models;

namespace Company.Repositories.Interface
{
    public interface ILayarAkunRepo
    {
        public Task<bool> TambahAkses(int idAkun, LayarAkun model);
        public Task<bool> GantiAkses(int id, LayarAkun model);
        public Task<bool> HapusAkses(int id);
    }
}
