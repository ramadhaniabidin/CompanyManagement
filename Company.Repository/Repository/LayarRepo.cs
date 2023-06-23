using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories.Repository
{
    public class LayarRepo: ILayarRepo
    {
        private readonly DataContext _dataContext;
        public LayarRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Akun>> DaftarAkun()
        {
            return await _dataContext.Akun.ToListAsync();
        }

        public async Task<List<Pengguna>> DaftarPengguna()
        {
            return await _dataContext.Pengguna.ToListAsync();            
        }

        public async Task<List<Kantor>> DaftarKantor()
        {
            return await _dataContext.Kantor.ToListAsync();
        }

        public async Task<List<Peran>> DaftarPeran()
        {
            return await _dataContext.Peran.ToListAsync();
        }
    }
}
