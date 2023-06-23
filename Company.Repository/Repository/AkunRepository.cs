using Company.Data;
using Company.Models;
using Company.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Company.Repositories.Repository
{
    public class AkunRepository : IAkunRepository
    {
        private readonly DataContext _dataContext;
        public AkunRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Buat(Akun model)
        {
            var akun = new Akun();
            TimeZoneInfo wibTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime utc = DateTime.UtcNow;
            DateTime utcKind = DateTime.SpecifyKind(utc, DateTimeKind.Utc);
            DateTime wibDateTime = TimeZoneInfo.ConvertTime(utcKind, TimeZoneInfo.Utc, wibTimeZone);

            _dataContext.Add(akun);
            {
                akun.namaAkun = model.namaAkun;
                akun.password = model.password;
                akun.tanggalDaftar = wibDateTime;
            }
            await _dataContext.SaveChangesAsync();

            var peranAkun = new Peran_Akun();
            _dataContext.Add(peranAkun);
            {
                peranAkun.idPeran = 1;
                peranAkun.idAkun = akun.id;
            }
            await _dataContext.SaveChangesAsync();

            return true;

        }

        public async Task<DataTransferModel> Detail(int idAkun)
        {
            var output = await (
                from p in _dataContext.Pengguna
                join pak in _dataContext.Pengguna_Akun on p.id equals pak.idPengguna
                where pak.idAkun == idAkun

                select new DataTransferModel
                {
                    idPengguna = p.id,
                    namaPengguna = p.namaPengguna,
                    alamat = p.alamat,
                    kodePos = p.kodePos,
                    provinsi = p.provinsi,
                    idAkun = pak.idAkun
                }
                ).FirstOrDefaultAsync();
            return output;
        }

        public async Task<bool> Hapus(int idAkun)
        {
            int idPengguna = await _dataContext.Pengguna_Akun
                .Where(pa => pa.idAkun == idAkun)
                .Select(pa => pa.idPengguna)
                .FirstOrDefaultAsync();

            await _dataContext.Akun.Where(a => a.id == idAkun).ExecuteDeleteAsync();
            await _dataContext.Pengguna.Where(p => p.id == idPengguna).ExecuteDeleteAsync();
            await _dataContext.SaveChangesAsync();

            await _dataContext.LayarAkun.Where(la => la.idAkun == idAkun).ExecuteDeleteAsync();
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<DataTransferModel> InComplete(int idAkun)
        {
            var output = await (
                from pa in _dataContext.Peran_Akun
                join pe in _dataContext.Peran on pa.idPeran equals pe.id
                where pa.idAkun == idAkun

                select new DataTransferModel
                {
                    id = pa.idAkun,
                    namaPeran = pe.namaPeran
                }
                ).FirstOrDefaultAsync();

            return output;
        }

        public async Task<Akun> Index(int id)
        {
            var akun = await _dataContext.Akun.FirstOrDefaultAsync(a => a.id == id);
            return akun;
        }
    }
}
