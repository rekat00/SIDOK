using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Services;
using SIDOK.Services.Interfaces;

namespace SIDOK.Controllers
{
    public class DoktersController : Controller
    {
        private readonly IDokterService _dokterService;
        private readonly IJadwalService _jadwalService;
        private readonly ISpesialisasiService _spesialisasiService;
        private readonly IPoliServices _poliService;

        public DoktersController(IDokterService dokterService, IJadwalService jadwalService, ISpesialisasiService spesialisasiService, IPoliServices poliService)
        {
            _dokterService = dokterService;
            _jadwalService = jadwalService;
            _spesialisasiService = spesialisasiService;
            _poliService = poliService;
        }

        //===============INDEX===============================
        [HttpGet]
        public async Task<IActionResult> Index(string? Spesialis, string Search)
        {
            var dokter = await _dokterService.SelectAll();
            ViewData["Spesialisasi"] = await _spesialisasiService.SelectSpesialisasi();

            //search
            Search = Search ?? string.Empty;
            if (!String.IsNullOrEmpty(Search))
            {
                dokter = dokter.Where(s => s.Nama.ToLower()!.Contains(Search.ToLower()));
            }
            if (!String.IsNullOrEmpty(Spesialis))
            {
                dokter = dokter.Where(x => x.Spesialisasi.ToLower() == Spesialis.ToLower());
            }


            return View(dokter);

        }


        //==================GET DETAILS=======================
        public async Task<IActionResult> Details(int id)
        {
            ViewData["Poli_Hari"] = await _jadwalService.SelectAllByDoctorId(id);
            var dokter = await _dokterService.SelectById(id);

            return View(dokter);
        }

        //===================GET CREATE=====================
        public async Task<IActionResult> Create()
        {
            ViewData["Spesialisasi"] = await _spesialisasiService.SelectSpesialisasi();

            return View();
        }

        //===================POST CREATE====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DokterSpesialisasiDTO dokter)
        {
            ViewData["Spesialisasi"] = _spesialisasiService.SelectSpesialisasi();
            if (ModelState.IsValid)
            {
                await _dokterService.Insert(dokter);


                return RedirectToAction(nameof(Index));
            }

            return View(dokter);
        }

        //===================TAMBAH JADWAL=====================
        public async Task<IActionResult> Schedule(int id)
        {
            var dokter = await _dokterService.SelectById(id);
            ViewData["Poli"] = await _poliService.SelectAll();
            return View();
        }

        //===================TAMBAH JADWAL====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Schedule(PoliDTO dokter,int id)
        {
            if (ModelState.IsValid)
            {
                await _jadwalService.Tambah(dokter, id);
                return RedirectToAction(nameof(Index));
            }
            return View(dokter);
        }

        //============GET EDIT=============================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Spesialisasi"] = await _spesialisasiService.SelectSpesialisasi();
            var dokter = await _dokterService.SelectById(id);

            if (dokter == null)
            {
                return NotFound();
            }
            return View(dokter);
        }


        //===============POST EDIT=========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DokterSpesialisasiDTO dokter)
        {
            ViewData["Spesialisasi"] = await _spesialisasiService.SelectSpesialisasi();
            if (id != dokter.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                await _dokterService.Update(dokter, id);

                TempData["swalMessage"] = "Update data";
                TempData["swalType"] = "question";
                TempData["swalTitle"] = "Success!";

                return RedirectToAction(nameof(Index));
            }
            return View(dokter);
        }


        //===========GET DELETE=========================
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (_dokterService == null)
            {
                return NotFound();
            }

            var dokter = await _dokterService.SelectById(id);


            if (dokter == null)
            {
                return NotFound();
            }
            return View(dokter);
        }

        //============POST DELETE=========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteC(int id)
        {
            await _dokterService.Delete(id);
            await Task.Delay(1000);
            return RedirectToAction(nameof(Index));
        }
    }
}
