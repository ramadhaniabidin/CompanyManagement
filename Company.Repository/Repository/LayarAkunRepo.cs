using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories.Repository
{
    public class LayarAkunRepo: ILayarAkunRepo
    {
        private readonly DataContext _dataContext;
        public LayarAkunRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> GantiAkses(int id, LayarAkun model)
        {
            var layarAkun = await _dataContext.LayarAkun
                .FirstOrDefaultAsync(lak => lak.id == id);
            if(layarAkun == null)
            {
                return false;
            }

            int idAkun = layarAkun.idAkun;

            _dataContext.Update(layarAkun);
            {
                layarAkun.idLayar = model.idLayar;
            }

            if(!await _dataContext.LayarAkun.Where(lak => lak.idAkun == idAkun)
                .AnyAsync(lak => lak.idLayar == model.idLayar))
            {
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> HapusAkses(int id)
        {
            await _dataContext.LayarAkun.Where(lak => lak.id == id).ExecuteDeleteAsync();
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TambahAkses(int idAkun, LayarAkun model)
        {
            var layarAkun = new LayarAkun()
            {
                idAkun = idAkun,
                idLayar = model.idLayar
            };
            await _dataContext.AddAsync(layarAkun);

            if(!await _dataContext.LayarAkun.Where(lak => lak.idAkun == idAkun)
                .AnyAsync(lak => lak.idLayar == model.idLayar))
            {
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
