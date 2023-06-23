using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories.Repository
{
    public class KantorRepo:IKantorRepo
    {
        private readonly DataContext _dataContext;
        public KantorRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> HapusKantor(int id)
        {
            await _dataContext.Kantor.Where(k => k.id == id).ExecuteDeleteAsync();
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TambahKantor(Kantor model)
        {
            var kantor = new Kantor();      
            await _dataContext.AddAsync(kantor);
            {
                kantor.namaCabang = model.namaCabang;
            }
            if(!await _dataContext.Kantor.AnyAsync(k => k.namaCabang == model.namaCabang))
            {
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UbahKantor(int id, Kantor model)
        {
            var kantor = await _dataContext.Kantor.FirstOrDefaultAsync(k => k.id == id);
            if (kantor == null)
            {
                return false;
            }
            _dataContext.Update(kantor);
            {
                kantor.namaCabang = model.namaCabang;
            }
            if(!await _dataContext.Kantor.AnyAsync(k => k.namaCabang == model.namaCabang)){
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
