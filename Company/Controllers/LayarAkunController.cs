using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class LayarAkunController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILayarAkunService _layarAkunService;
        public LayarAkunController(DataContext dataContext, ILayarAkunService service)
        {
            _dataContext = dataContext;
            _layarAkunService = service;
        }

        public async Task<IActionResult> Tambah(int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            var akses = await _dataContext.Layar.ToListAsync();
            ViewData["Akses"] = akses;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tambah(int idAkun, LayarAkun model)
        {
            await _layarAkunService.TambahAkses(idAkun, model);
            return RedirectToAction("Detail", "Akun", new { idAkun });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var akses = await _dataContext.Layar.ToListAsync();
            ViewData["Akses"] = akses;

            var layarAkun = _dataContext.LayarAkun
                .Where(la => la.id == id)
                .FirstOrDefault();

            return View(layarAkun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LayarAkun model, int id)
        {
            int idAkun = await _dataContext.LayarAkun.Where(lak => lak.id == id).Select(lak => lak.idAkun).FirstOrDefaultAsync();
            await _layarAkunService.GantiAkses(id, model);
            return RedirectToAction("Detail", "Akun", new { idAkun });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Hapus(int id)
        {
            int idAkun = await _dataContext.LayarAkun.Where(la => la.id == id).Select(la => la.idAkun).FirstOrDefaultAsync();
            await _layarAkunService.HapusAkses(id);
            return RedirectToAction("Detail", "Akun", new {idAkun});
        }
    }
}
