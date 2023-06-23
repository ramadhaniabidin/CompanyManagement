using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class PeranController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IPeranService peranService;
        public PeranController(DataContext dataContext, IPeranService peranService)
        {
            _dataContext = dataContext;
            this.peranService = peranService;
        }

        public async Task<IActionResult> Edit(int id, int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            var peran = await _dataContext.Peran
                .Where(p => p.id == id)
                .FirstOrDefaultAsync();
            return View(peran);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Peran model, int idAkun)
        {
            await peranService.EditPeran(id, model);
            return RedirectToAction("DaftarPeran", "Layar", new { idAkun });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Hapus(int id, int idAkun)
        {
            await peranService.HapusPeran(id);
            return RedirectToAction("DaftarPeran", "Layar", new {idAkun});
        }


        public IActionResult Tambah(int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tambah(Peran model, int idAkun)
        {
            await peranService.TambahPeran(model);
            return RedirectToAction("DaftarPeran", "Layar", new {idAkun});
        }
    }
}
