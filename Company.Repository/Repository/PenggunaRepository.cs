using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories.Repository
{
    public class PenggunaRepository : IPenggunaRepository
    {
        private readonly DataContext _dataContext;
        public PenggunaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> TambahPengguna(Pengguna model, int id)
        {
            var pengguna = new Pengguna();
            await _dataContext.AddAsync(pengguna);
            {
                pengguna.namaPengguna = model.namaPengguna;
                pengguna.alamat = model.alamat;
                pengguna.kodePos = model.kodePos;
                pengguna.provinsi = model.provinsi;
            }
            await _dataContext.SaveChangesAsync();

            var penggunaAkun = new Pengguna_Akun();
            await _dataContext.AddAsync(penggunaAkun);
            {
                penggunaAkun.idAkun = id;
                penggunaAkun.idPengguna = pengguna.id;
            }
            await _dataContext.SaveChangesAsync();

            var penggunaKantor = new Pengguna_Kantor();
            await _dataContext.AddAsync(penggunaKantor);
            {
                penggunaKantor.id_Pengguna = pengguna.id;
                penggunaKantor.id_Kantor = 1;
            }
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UbahData(Pengguna model, int id)
        {
            var pengguna = await _dataContext.Pengguna.FirstOrDefaultAsync(p => p.id == id);
            if(pengguna != null)
            {
                _dataContext.Update(pengguna);
                {
                    pengguna.namaPengguna = model.namaPengguna;
                    pengguna.kodePos = model.kodePos;
                    pengguna.alamat = model.alamat;
                    pengguna.provinsi = model.provinsi;
                }
                await _dataContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
