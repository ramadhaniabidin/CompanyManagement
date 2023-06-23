using Company.Data;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;
        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var peran = _dataContext.Peran.ToList();
            ViewData["ListPeran"] = peran;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login model)
        {


            int idAkun = await (
                from a in _dataContext.Akun
                join pa in _dataContext.Peran_Akun on a.id equals pa.idAkun
                join pe in _dataContext.Peran on pa.idPeran equals pe.id

                where a.namaAkun == model.Username && a.password == model.Password && pe.namaPeran == model.Peran

                select new Akun
                {
                    id = a.id
                }
                ).Select(a => a.id)
                .FirstOrDefaultAsync();

            if (idAkun != 0)
            {
                return RedirectToAction("Index", "Akun", new {id = idAkun});
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
