using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.TrafficEmployee;
using Hozor.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Internal;

namespace Hozor.Web.Controllers.TrafficEmployee
{
    [DisplayName("پرسنل")]
    public class CEmployeesController : BaseController
    {
        private readonly IEmployee _employeeRep;

        public CEmployeesController(IEmployee employeeRep)
        {
            _employeeRep = employeeRep;
        }


        // GET: CEmployees
        [DisplayName("ليست پرسنل")]
        public async Task<IActionResult> Index()
        {
            ViewBag.isActive = false;
            ViewBag.ShowFilter = false;
            ViewBag.section = new SelectList(await _employeeRep.GetAllSectionAddRecord(), "Name", "Name");
            return View(await _employeeRep.GetAllEmployees());
        }

        // GET: CEmployees/Details/5
        [DisplayName("جزئيات پرسنل")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cEmployees = await _employeeRep.GetEmployeeById(id.Value);
            if (cEmployees == null)
            {
                return NotFound();
            }

            return View(cEmployees);
        }

        // GET: CEmployees/Create
        [DisplayName("افزودن پرسنل")]
        public async Task<IActionResult> Create()
        {
            ViewData["Sections"] = new SelectList(await _employeeRep.GetAllSection(), "Name", "Name");
            return View();
        }

        // POST: CEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonalId,Name,Family,Job,Category,Image,IsActive,ImageNumber,FerstName,StartDate,EndDate,Section,ImageName")] CEmployees cEmployees, IFormFile imgUp, string StartDate, string EndDate)
        {
            if (ModelState.IsValid)
            {
                if (!await _employeeRep.IsEmployeeByPersonalId(cEmployees.PersonalId))
                {
                    if (imgUp != null)
                    {
                        cEmployees.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/Images/Employee", cEmployees.ImageName
                        );

                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await imgUp.CopyToAsync(stream);
                        }
                    }

                    cEmployees.StartDate = StartDate.ToGregorian();
                    cEmployees.EndDate = EndDate.ToGregorian();
                    await _employeeRep.InsertEmployee(cEmployees);
                    await _employeeRep.Save();
                    Success();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("PersonalId", " اين شماره پرسنلي قبلاً در سيستم ثبت شده است");
                ViewData["Sections"] = new SelectList(await _employeeRep.GetAllSection(), "Name", "Name");
            }

            return View(cEmployees);
        }

        // GET: CEmployees/Edit/5
        [DisplayName("ويرايش پرسنل")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["Sections"] = new SelectList(await _employeeRep.GetAllSection(), "Name", "Name");
            var cEmployees = await _employeeRep.GetEmployeeById(id.Value);
            if (cEmployees == null)
            {
                return NotFound();
            }
            return View(cEmployees);
        }

        // POST: CEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonalId,Name,Family,Job,Category,Image,IsActive,ImageNumber,FerstName,StartDate,EndDate,Section,ImageName")] CEmployees cEmployees, IFormFile imgUp, string StartDate, string EndDate)
        {
            if (id != cEmployees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!await _employeeRep.IsEmployeeByIdAndPersonalId(id, cEmployees.PersonalId))
                    {
                        if (imgUp != null)
                        {

                            if (cEmployees.ImageName == null)
                            {
                                cEmployees.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                            }
                            else
                            {
                                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Employee", cEmployees.ImageName);
                                if (System.IO.File.Exists(imagePath))
                                {
                                    System.IO.File.Delete(imagePath);
                                }
                            }
                            string savePath = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot/Images/Employee", cEmployees.ImageName
                            );
                            using (var stream = new FileStream(savePath, FileMode.Create))
                            {
                                await imgUp.CopyToAsync(stream);
                            }

                        }

                        cEmployees.StartDate = StartDate.ToGregorian();
                        cEmployees.EndDate = EndDate.ToGregorian();
                        await _employeeRep.UpdateEmployee(cEmployees);
                        await _employeeRep.Save();
                        Success();
                        return RedirectToAction(nameof(Index));
                    }
                    ViewData["Sections"] = new SelectList(await _employeeRep.GetAllSection(), "Name", "Name");
                    ModelState.AddModelError("PersonalId", " اين شماره پرسنلي قبلاً در سيستم ثبت شده است");
                     return View(cEmployees);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CEmployeesExists(cEmployees.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return View(cEmployees);
        }

        // GET: CEmployees/Delete/5
        [DisplayName("حذف پرسنل")]
        public async Task<IActionResult> Delete(int id)
        {

            return RedirectToAction(nameof(Index));
        }

        [DisplayName("فيلتر پرسنل")]
        public async Task<IActionResult> Filter(string section, string category,
            bool isActive, string startDateFrom, string startDateThan,
            string endDateFrom, string endDateThan)
        {
            ViewBag.section = section;
            ViewBag.section = new SelectList(await _employeeRep.GetAllSectionAddRecord(), "Name", "Name");
            
            ViewBag.category = category;
            ViewBag.isActive = isActive;
            ViewBag.startDateFrom = startDateFrom;
            ViewBag.startDateThan = startDateThan;
            ViewBag.endDateFrom = endDateFrom;
            ViewBag.endDateThan = endDateThan;
            ViewBag.ShowFilter = true;
            return View("Index", await _employeeRep.FilterEmployee(section, category,isActive,
                startDateFrom, startDateThan, endDateFrom, endDateThan));
        }

        //void ViewBagSelect()
        //{
        //    List<CSections> selectList = new List<CSections>();
        //    selectList.Add(new CSections()
        //    {
        //        Id = 0,
        //        Name = "انتخاب همه"
        //    });
        //    selectList.AddRange(db.Users);
        //    ViewBag.userName = new SelectList(selectList, "Name", "Name");
        //}

        private bool CEmployeesExists(int id)
        {
            return _employeeRep.EmployeeExists(id);
        }
    }
}
