using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class LayarController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILayarService _layarService;
        public LayarController(DataContext dataContext, ILayarService layarService)
        {
            _dataContext = dataContext;
            _layarService = layarService;
        }

        public async Task<IActionResult> DaftarPengguna(int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            return View(await _layarService.DaftarPengguna());
        }

        public async Task<IActionResult> DaftarKantor(int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            return View(await _layarService.DaftarKantor());
        }

        public async Task<IActionResult> DaftarAkun(int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            return View(await _layarService.DaftarAkun());
        }

        public async Task<IActionResult> DaftarPeran(int idAkun)
        {
            ViewData["idAkun"] = idAkun;
            return View(await _layarService.DaftarPeran());
        }

        public IActionResult CariAkun()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CariAkun(Cari model)
        {
            int idAkun = await _dataContext.Akun
                .Where(a => a.namaAkun == model.namaAkun)
                .Select(a => a.id)
                .FirstOrDefaultAsync();

            if(idAkun != 0)
            {
                return RedirectToAction("Index", "Akun", new { id = idAkun });
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
