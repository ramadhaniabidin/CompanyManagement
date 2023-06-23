using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories.Repository
{
    public class PeranRepo: IPeranRepo
    {
        private readonly DataContext _dataContext;
        public PeranRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> EditPeran(int id, Peran model)
        {
            var peran = await _dataContext.Peran.FirstOrDefaultAsync(pe => pe.id == id);
            if (peran == null)
            {
                return false;
            }
            _dataContext.Update(peran);
            {
                peran.namaPeran = model.namaPeran;
            }
            if(!await _dataContext.Peran.AnyAsync(pe => pe.namaPeran == model.namaPeran))
            {
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> HapusPeran(int id)
        {
            await _dataContext.Peran.Where(pe => pe.id == id).ExecuteDeleteAsync();
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TambahPeran(Peran model)
        {
            var peran = new Peran();
            await _dataContext.AddAsync(peran);
            {
                peran.namaPeran = model.namaPeran;
            }

            if(!await _dataContext.Peran.AnyAsync(pe => pe.namaPeran == model.namaPeran))
            {
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
