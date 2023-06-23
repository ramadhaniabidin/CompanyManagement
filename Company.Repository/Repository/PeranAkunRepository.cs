using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Company.Repositories.Repository
{
    public class PeranAkunRepository : IPeranAkunRepository
    {
        private readonly DataContext _dataContext;
        public PeranAkunRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> HapusPeran(int id)
        {
            await _dataContext.Peran_Akun
                .Where(pak => pak.id == id)
                .ExecuteDeleteAsync();
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TambahPeran(int idAkun, Peran_Akun model)
        {
            var peranAkun = new Peran_Akun()
            {
                idAkun = idAkun,
                idPeran = model.idPeran
            };
            _dataContext.Add(peranAkun);
            if (!await _dataContext.Peran_Akun.Where(pak => pak.idAkun == idAkun)
                .AnyAsync(pak => pak.idPeran == model.idPeran))
            {
                await _dataContext.SaveChangesAsync();
            }
            return true;

        }

        public async Task<bool> UbahPeran(int id, Peran_Akun model)
        {
            var peranAkun = await _dataContext.Peran_Akun
                .FirstOrDefaultAsync(pak => pak.id == id);
            if(peranAkun != null)
            {
                _dataContext.Update(peranAkun);
                {
                    peranAkun.idPeran = model.idPeran;
                }
                int idAkun = peranAkun.idAkun;
                if(!await _dataContext.Peran_Akun.Where(pak => pak.idAkun == idAkun)
                    .AnyAsync(pak => pak.idPeran == model.idPeran))
                {
                    await _dataContext.SaveChangesAsync();
                }
            }
            return true;
        }
    }
}
