using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class PeranAkunController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IPeranAkunService _peranAkunService;
        public PeranAkunController(DataContext dataContext, IPeranAkunService peranAkunService)
        {
            _dataContext = dataContext;
            _peranAkunService = peranAkunService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var listPeran = await _dataContext.Peran.ToListAsync();
            ViewData["ListPeran"] = listPeran;

            var peranAkun = await _dataContext.Peran_Akun.FirstOrDefaultAsync(pak => pak.id == id);
            return View(peranAkun);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Peran_Akun model)
        {

            await _peranAkunService.UbahPeran(id, model);
            int idAkun = await _dataContext.Peran_Akun
                .Where(pak => pak.id == id)
                .Select(pak => pak.idAkun)
                .FirstOrDefaultAsync();

            return RedirectToAction("Detail", "Akun", new { idAkun });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Hapus(int id)
        {
            int idAkun = await _dataContext.Peran_Akun
                .Where(pak => pak.id == id)
                .Select(pak => pak.idAkun)
                .FirstOrDefaultAsync();

            await _peranAkunService.HapusPeran(id);
            return RedirectToAction("Detail", "Akun", new { idAkun });

        }


        public async Task<IActionResult> Tambah(int idAkun)
        {
            var peran = await _dataContext.Peran.ToListAsync();
            ViewData["ListPeran"] = peran;
            ViewData["idAkun"] = idAkun;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Tambah(int idAkun, Peran_Akun model)
        {
            await _peranAkunService.TambahPeran(idAkun, model);

            return RedirectToAction("Detail", "Akun", new {idAkun});
        }
    }
}
