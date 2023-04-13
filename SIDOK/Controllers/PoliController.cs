using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIDOK.Data;
using SIDOK.Models;
using SIDOK.Services;
using SIDOK.Services.Interfaces;

namespace SIDOK.Controllers
{
    public class PoliController : Controller
    {
        private readonly IPoliServices _poliServices;
        private readonly IJadwalService _jadwalService;

        public PoliController(IPoliServices poliServices, IJadwalService jadwalService)
        {
            _poliServices = poliServices;
            _jadwalService = jadwalService;
        }

        // GET: Poli
        [HttpGet]
        public async Task<IActionResult> Index(string Search)
        {
            var poli = await _poliServices.SelectAll();

            if (!String.IsNullOrEmpty(Search))
            {
                poli = poli.Where(s => s.NamaPoli.ToLower()!.Contains(Search.ToLower()));
            }

            return View(poli);
        }

        //==================GET DETAILS=======================
        public async Task<IActionResult> Details(int id)
        {
            var poli = await _poliServices.SelectById(id);
            ViewData["Jadwal"] = await _jadwalService.SelectAllByPoliId(id);

            return View(poli);
        }

        //===================GET CREATE=====================
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Poli poli)
        {
            if (ModelState.IsValid)
            {
                await _poliServices.Insert(poli);
                return RedirectToAction(nameof(Index));
            }
            return View(poli);
        }

        //============GET EDIT=============================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var poli = await _poliServices.SelectById(id);

            if (poli == null)
            {
                return NotFound();
            }
            return View(poli);
        }

        //===============POST EDIT=========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Poli poli)
        {
            if (id != poli.IdPoli)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                await _poliServices.Update(poli, id);

                return RedirectToAction(nameof(Index));
            }
            return View(poli);
        }

        // GET: Poli/Delete/5
        //===========GET DELETE=========================
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (_poliServices == null)
            {
                return NotFound();
            }

            var poli = await _poliServices.SelectById(id);

            if (poli == null)
            {
                return NotFound();
            }
            return View(poli);
        }

        //============POST DELETE=========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteC(int id)
        {
            await _poliServices.Delete(id);

            await Task.Delay(1000);

            return RedirectToAction(nameof(Index));
        }
    }
}
