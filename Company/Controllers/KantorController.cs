using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class KantorController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IKantorService kantorService;
        public KantorController(DataContext dataContext, IKantorService kantorService)
        {
            _dataContext = dataContext;
            this.kantorService = kantorService;
        }

        public IActionResult Tambah(int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tambah(Kantor model, int idAkun)
        {
            await kantorService.TambahKantor(model);
            return RedirectToAction("DaftarKantor", "Layar", new {idAkun});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Hapus(int id, int idAkun)
        {
            await kantorService.HapusKantor(id);
           return RedirectToAction("DaftarKantor", "Layar", new {idAkun});
        }

        public async Task<IActionResult> Edit(int id, int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            var kantor = await _dataContext.Kantor
                .Where(k => k.id == id)
                .FirstOrDefaultAsync();

            return View(kantor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int idAkun, Kantor model)
        {
            await kantorService.UbahKantor(id, model);
            return RedirectToAction("DaftarKantor", "Layar", new {idAkun});
        }
    }
}
