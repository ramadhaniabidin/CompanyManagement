using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class PenggunaController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IPenggunaService _penggunaService;
        public PenggunaController(DataContext dataContext, IPenggunaService penggunaService)
        {
            _dataContext = dataContext;
            _penggunaService = penggunaService;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var pengguna = await _dataContext.Pengguna
                .FirstOrDefaultAsync(p => p.id == id);
            return View(pengguna);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pengguna model)
        {

            await _penggunaService.UbahData(model, id);

            int idAkun = await _dataContext.Pengguna_Akun
                .Where(pak => pak.idPengguna == id)
                .Select(pak => pak.idAkun)
                .FirstOrDefaultAsync();

            return RedirectToAction("Detail", "Akun", new { idAkun });

        }

        public IActionResult Create()
        {
            return View();
            //random edit
            //another random edit
            //again another random edit
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pengguna model, int id)
        {
            await _penggunaService.TambahPengguna(model, id);
            return RedirectToAction("Index", "Akun", new { id });
        }
    }
}
