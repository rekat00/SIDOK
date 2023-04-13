using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIDOK.Data;
using SIDOK.Models;
using SIDOK.Models.DTO;
using SIDOK.Services;
using SIDOK.Services.Interfaces;

namespace SIDOK.Controllers
{
    public class JadwalController : Controller
    {
       
        private readonly IJadwalService _jadwalService;

        public JadwalController(IJadwalService jadwalService)
        {
     
            _jadwalService = jadwalService;
        }

        public async Task<IActionResult> Index()
        {
            var poli = await _jadwalService.SelectAll();
            return View(poli);
        }

        //==================GET DETAILS=======================
        public async Task<IActionResult> Details(int id)
        {
            var poli = await _jadwalService.SelectById(id);

            return View(poli);
        }

        //===================GET CREATE=====================
        public IActionResult Create()
        {

            return View();
        }

        //===================POST CREATE====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jadwal_jaga jadwal)
        {
            if (ModelState.IsValid)
            {
                await _jadwalService.Insert(jadwal);
                return RedirectToAction(nameof(Index));
            }
            return View(jadwal);
        }

        //============GET tambah=============================
        [HttpGet]
        public async Task<IActionResult> tambah(int id)
        {
            var jadwal = await _jadwalService.SelectById(id);

            if (jadwal == null)
            {
                return NotFound();
            }
            return View(jadwal);
        }


        //===========GET DELETE=========================
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (_jadwalService == null)
            {
                return NotFound();
            }

            var poli = await _jadwalService.SelectById(id);

            if (poli == null)
            {
                return NotFound();
            }
            return View(poli);
        }
        //===============POST TAMBAH===============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PoliDTO poli)
        {
            if (id != poli.IdDokter)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                await _jadwalService.Tambah(poli, id);

                return RedirectToAction(nameof(Index));
            }
            return View(poli);
        }

        //============POST DELETE=========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteC(int id)
        {
            
            await _jadwalService.Delete(id);
            await Task.Delay(1000);
            return RedirectToAction(nameof(Index));
        }
    }
}
