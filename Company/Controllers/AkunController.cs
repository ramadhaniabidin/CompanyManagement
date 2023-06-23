using Company.Data;
using Company.Models;
using Company.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class AkunController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IAkunService service;
        public AkunController(DataContext dataContext, IAkunService _service)
        {
            _dataContext = dataContext;
            service = _service;
        }

        public IActionResult Buat()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buat(Akun model)
        {
            if (ModelState.IsValid)
            {
                await service.Buat(model);
                return RedirectToAction("DaftarAkun", "Layar");
            }
            return View();
        }


        public async Task<IActionResult> Index(int id)
        {
            return View(await service.Index(id));
        }


        public async Task<IActionResult> InComplete(int idAkun)
        {

            var peran = await (
                from pe in _dataContext.Peran
                join pak in _dataContext.Peran_Akun on pe.id equals pak.idPeran
                where pak.idAkun == idAkun

                select new Peran
                {
                    namaPeran = pe.namaPeran
                }
                ).ToListAsync();

            ViewData["ListPeran"] = peran;

            var kantor = await (
                from k in _dataContext.Kantor
                join pk in _dataContext.Pengguna_Kantor on k.id equals pk.id_Kantor
                join pak in _dataContext.Pengguna_Akun on pk.id_Pengguna equals pak.idPengguna
                where pak.idAkun == idAkun

                select new Kantor
                {
                    namaCabang = k.namaCabang
                }
                ).ToListAsync();
            ViewData["ListKantor"] = kantor;

            //var output = await (
            //    from pa in _dataContext.Peran_Akun
            //    join p in _dataContext.Peran on pa.idPeran equals p.id
            //    where pa.idAkun == idAkun

            //    select new DataTransferModel
            //    {
            //        id = pa.idAkun,
            //        namaPeran = p.namaPeran
            //    }
            //    ).FirstOrDefaultAsync();

            return View(await service.InComplete(idAkun));
        }

        public async Task<IActionResult> Detail(int idAkun)
        {
            int idPengguna = _dataContext.Pengguna_Akun
                .Where(pak => pak.idAkun == idAkun)
                .Select(pak => pak.idPengguna)
                .FirstOrDefault();

            if (idPengguna != 0)
            {
                var peran = await (
                    from pe in _dataContext.Peran
                    join pak in _dataContext.Peran_Akun on pe.id equals pak.idPeran

                    where pak.idAkun == idAkun

                    select new DataTransferModel
                    {

                        idAkun = pak.idAkun,
                        namaPeran = pe.namaPeran,
                        idPeran = pe.id,
                        id = pak.id
                    }
                    ).ToListAsync();
                ViewData["ListPeran"] = peran;

                var kantor = await (
                    from k in _dataContext.Kantor
                    join pk in _dataContext.Pengguna_Kantor on k.id equals pk.id_Kantor

                    where pk.id_Pengguna == idPengguna

                    select new DataTransferModel
                    {
                        idKantor = k.id,
                        namaCabang = k.namaCabang,
                        idPengguna = pk.id_Pengguna,
                        id = pk.id
                    }
                    ).ToListAsync();
                ViewData["ListKantor"] = kantor;

                var akses = await (
                    from l in _dataContext.Layar
                    join al in _dataContext.LayarAkun on l.id equals al.idLayar
                    join a in _dataContext.Akun on al.idAkun equals a.id

                    where a.id == idAkun

                    select new DataTransferModel
                    {
                        id = al.id,
                        idLayar = l.id,
                        namaLayar = l.namaLayar,
                        idAkun = a.id
                    }
                    ).ToListAsync();
                ViewData["Akses"] = akses;

                return View(await service.Detail(idAkun));
            }

            else
            {
                return RedirectToAction("InComplete", "Akun", new { idAkun });
            }
        }

        public async Task<IActionResult> Hapus(int idAkun)
        {

            ViewData["idAkun"] = idAkun;
            int idPengguna = _dataContext.Pengguna_Akun
                            .Where(pak => pak.idAkun == idAkun)
                            .Select(pak => pak.idPengguna)
                            .FirstOrDefault();
            var pengguna = await (
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

            var peran = await (
                from pe in _dataContext.Peran
                join pak in _dataContext.Peran_Akun on pe.id equals pak.idPeran

                where pak.idAkun == idAkun

                select new DataTransferModel
                {

                    idAkun = pak.idAkun,
                    namaPeran = pe.namaPeran,
                    idPeran = pe.id,
                    id = pak.id
                }
                ).ToListAsync();
            ViewData["ListPeran"] = peran;

            var kantor = await (
                from k in _dataContext.Kantor
                join pk in _dataContext.Pengguna_Kantor on k.id equals pk.id_Kantor

                where pk.id_Pengguna == idPengguna

                select new DataTransferModel
                {
                    idKantor = k.id,
                    namaCabang = k.namaCabang,
                    idPengguna = pk.id_Pengguna,
                    id = pk.id
                }
                ).ToListAsync();
            ViewData["ListKantor"] = kantor;

            var akses = await (
                from l in _dataContext.Layar
                join al in _dataContext.LayarAkun on l.id equals al.idLayar
                join a in _dataContext.Akun on al.idAkun equals a.id

                where a.id == idAkun

                select new DataTransferModel
                {
                    id = al.id,
                    idLayar = l.id,
                    namaLayar = l.namaLayar,
                    idAkun = a.id
                }
                ).ToListAsync();
            ViewData["Akses"] = akses;
            return View(pengguna);
        }

        [HttpPost, ActionName("Hapus")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HapusAkun(int idAkun)
        {
            await service.Hapus(idAkun);
            return RedirectToAction("DaftarAkun", "Layar");
        }
    }
}
