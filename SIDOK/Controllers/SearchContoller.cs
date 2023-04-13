using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDOK.Services;
using SIDOK.Services.Interfaces;

namespace SIDOK.Controllers
{
    public class SearchContoller : Controller
    {
        private readonly IDokterService _dokterService;
        private readonly IPoliServices _poliService;
        private readonly IJadwalService _jadwalService;
        private readonly ISpesialisasiService _spesialisasiService;
        public SearchContoller(IDokterService dokterService,IPoliServices poliServices,IJadwalService jadwalService,ISpesialisasiService spesialisasiService) 
        {
            _dokterService = dokterService;
            _poliService = poliServices;
            _jadwalService = jadwalService;
            _spesialisasiService = spesialisasiService;
        }


        public async Task<IActionResult> Cari() 
        {
            ViewData["Spesialisasi"] = await _spesialisasiService.SelectSpesialisasi();
            ViewData["Poli"] = await _poliService.SelectAll();
            return View();
        }

        // GET: SearchContoller
        public ActionResult Index()
        {
            return View();
        }

        // GET: SearchContoller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchContoller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchContoller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchContoller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
