using Microsoft.AspNetCore.Mvc;
using SIDOK.Models;
using SIDOK.Repository.Interfaces;
using SIDOK.Services.Interfaces;
using System.Diagnostics;

namespace SIDOK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDokterService _dokterService;
        private readonly IPoliServices _poliService;
        private readonly IJadwalService _jadwalService;
        private readonly ISpesialisasiService _spesialisasiService;

        public HomeController(ILogger<HomeController> logger, IDokterService dokterService, IPoliServices poliServices, IJadwalService jadwalService, ISpesialisasiService spesialisasiService)
        {
            _logger = logger;
            _dokterService = dokterService;
            _poliService = poliServices;
            _jadwalService = jadwalService;
            _spesialisasiService = spesialisasiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Cari()
        {
            ViewData["Spesialisasi"] = await _spesialisasiService.SelectSpesialisasi();
            ViewData["Poli"] = await _poliService.SelectAll();
            return View();
        }
    }
}