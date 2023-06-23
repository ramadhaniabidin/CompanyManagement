using Company.Models;

namespace Company.Services.Interface
{
    public interface ILayarAkunService
    {
        public Task<bool> TambahAkses(int idAkun, LayarAkun model);
        public Task<bool> GantiAkses(int id, LayarAkun model);
        public Task<bool> HapusAkses(int id);
    }
}
