﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;

namespace Hozor.Web.Controllers.Public
{
    [DisplayName("واحدهاي سازماني")]
    public class CSectionsController : BaseController
    {
        private readonly ISection _sectionRep;

        public CSectionsController(ISection sectionRep)
        {
            _sectionRep = sectionRep;
        }


        [DisplayName("ليست واحدهاي سازماني")]
        // GET: CSections
        public async Task<IActionResult> Index()
        {
            return View(await _sectionRep.GetAllSections());
        }


        [DisplayName("افزودن واحد سازماني")]
        // GET: CSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CSections cSections)
        {
            if (ModelState.IsValid)
            {
                if (!await _sectionRep.IsSectionByName(cSections.Name))
                {
                    int id = await _sectionRep.GetTopSectionId();
                    id++;
                    cSections.Id = id;
                    await _sectionRep.InsertSection(cSections);
                    await _sectionRep.Save();
                    Success();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Name", " اين واحد سازماني قبلاً در سيستم ثبت شده است");

            }
            return View(cSections);
        }

        [DisplayName("ويرايش واحد سازماني")]
        // GET: CSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSections = await _sectionRep.GetSectionById(id.Value);
            if (cSections == null)
            {
                return NotFound();
            }
            return View(cSections);
        }

        // POST: CSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CSections cSections)
        {
            if (id != cSections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!await _sectionRep.IsSectionByIdAndName(id,cSections.Name))
                    {
                        await _sectionRep.UpdateSection(cSections);
                        await _sectionRep.Save();
                        Success();
                    }
                    ModelState.AddModelError("Name", " اين واحد سازماني قبلاً در سيستم ثبت شده است");
                    return View(cSections);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CSectionsExists(cSections.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cSections);
        }

        [DisplayName("حذف واحد سازماني")]
        // POST: CSections/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _sectionRep.IsSectionInEmployee(id);
            if (result)
            {
                return Json(new { success = false });

            }

            await _sectionRep.DeleteSection(id);
            await _sectionRep.Save();
            return Json(new { success = true });
        }

        private bool CSectionsExists(int id)
        {
            return _sectionRep.SectionExists(id);
        }
    }
}
