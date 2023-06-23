using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories.Repository
{
    public class PenggunaKantorRepo: IPenggunaKantorRepository
    {
        private readonly DataContext _dataContext;
        public PenggunaKantorRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> GantiKantor(int id, Pengguna_Kantor model)
        {
            var penggunaKantor = await _dataContext.Pengguna_Kantor
                .FirstOrDefaultAsync(pk => pk.id == id);
            if(penggunaKantor != null)
            {
                int idPengguna = penggunaKantor.id_Pengguna;
                _dataContext.Update(penggunaKantor);
                {
                    penggunaKantor.id_Kantor = model.id_Kantor;
                }

                if (!await _dataContext.Pengguna_Kantor.Where(pk => pk.id_Pengguna == idPengguna)
                    .AnyAsync(pk => pk.id_Kantor == model.id_Kantor))
                {
                    await _dataContext.SaveChangesAsync();
                }
            }
            return true;
        }

        public async Task<bool> HapusKantor(int id)
        {
            await _dataContext.Pengguna_Kantor
                .Where(pk => pk.id == id)
                .ExecuteDeleteAsync();
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TambahKantor(int idPengguna, Pengguna_Kantor model)
        {
            var penggunaKantor = new Pengguna_Kantor
            {
                id_Pengguna = idPengguna,
                id_Kantor = model.id_Kantor
            };
            await _dataContext.AddAsync(penggunaKantor);
            if(!await _dataContext.Pengguna_Kantor.Where(pk => pk.id_Pengguna == idPengguna)
                .AnyAsync(pk => pk.id_Kantor == model.id_Kantor))
            {
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
