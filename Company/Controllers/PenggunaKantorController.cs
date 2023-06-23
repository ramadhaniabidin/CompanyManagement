using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class PenggunaKantorController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IPenggunaKantorService service;
        public PenggunaKantorController(DataContext dataContext, IPenggunaKantorService _Service)
        {
            _dataContext = dataContext;
            service = _Service;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var penggunaKantor = await _dataContext.Pengguna_Kantor
                .FirstOrDefaultAsync(pk => pk.id == id);

            var kantor = await _dataContext.Kantor.ToListAsync();
            ViewData["ListKantor"] = kantor;

            return View(penggunaKantor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pengguna_Kantor model, int id)
        {
            await service.GantiKantor(id, model);      

            int idAkun = await(
                from pk in _dataContext.Pengguna_Kantor
                join pak in _dataContext.Pengguna_Akun on pk.id_Pengguna equals pak.idPengguna
                where pk.id == id

                select new Pengguna_Akun
                {
                    idAkun = pak.idAkun
                }
                ).Select(pak => pak.idAkun)
                .FirstOrDefaultAsync();

            return RedirectToAction("Detail", "Akun", new { idAkun });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Hapus(int id)
        {
            int idAkun = await (
                from pk in _dataContext.Pengguna_Kantor
                join pa in _dataContext.Pengguna_Akun on pk.id_Pengguna equals pa.idPengguna
                where pk.id == id

                select new Pengguna_Akun
                {
                    idAkun = pa.idAkun
                }
                ).Select(pa => pa.idAkun)
                .FirstOrDefaultAsync();

            await service.HapusKantor(id);
            return RedirectToAction("Detail", "Akun", new { idAkun });
        }

        public async Task<IActionResult> Tambah(int idPengguna)
        {
            ViewData["idPengguna"] = idPengguna;
            var kantor = await _dataContext.Kantor.ToListAsync();
            ViewData["ListKantor"] = kantor;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tambah(int idPengguna, Pengguna_Kantor model)
        {

            await service.TambahKantor(idPengguna, model);

            int idAkun = await _dataContext.Pengguna_Akun
                .Where(pak => pak.idPengguna == idPengguna)
                .Select(pak => pak.idAkun)
                .FirstOrDefaultAsync();

            return RedirectToAction("Detail", "Akun", new { idAkun });
        }
    }
}
