using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.TrafficEmployee;
using Hozor.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Hozor.Servises.Services.TrafficEmployee
{
    public class EmployeeRep:IEmployee
    {
        private readonly Hozor_DBContext _db;
        public EmployeeRep(Hozor_DBContext db)
        {
            _db = db;
        }

        public async Task<List<CEmployees>> GetAllEmployees()
        {
            return await _db.CEmployees.OrderBy(e => e.PersonalId).ToListAsync();
        }

        public async Task<CEmployees> GetEmployeeById(int employeeId)
        {
            return await _db.CEmployees.FindAsync(employeeId);
        }

        public async Task<List<CSections>> GetAllSection()
        {
            return  await _db.CSections.ToListAsync();
        }

        public async Task<List<CSections>> GetAllSectionAddRecord()
        {
            List<CSections> selectList = new List<CSections>();
            selectList.Add(new CSections()
            {
                Id = 0,
                Name = "انتخاب همه"
            });
            selectList.AddRange(_db.CSections);
            return selectList;
        }


        public async Task<bool> IsEmployeeByPersonalId(int personalId)
        {
            return await _db.CEmployees.AnyAsync(e => e.PersonalId == personalId);
        }

        public async Task<bool> IsEmployeeByIdAndPersonalId(int id, int personalId)
        {
            return await _db.CEmployees.AnyAsync(e => e.Id != id && e.PersonalId == personalId);
        }

        public async Task InsertEmployee(CEmployees employees)
        {
            await _db.CEmployees.AddAsync(employees);
        }

        public async Task UpdateEmployee(CEmployees employee)
        {
           // _db.Entry(employee).State = EntityState.Modified;
           _db.CEmployees.Update(employee);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await GetEmployeeById(employeeId);
            _db.CEmployees.Remove(employee);
        }

        public async Task<List<CEmployees>> FilterEmployee(string section, string category,
                                bool isActive, string startDateFrom, string startDateThan,
                                string endDateFrom, string endDateThan)
        {
            IQueryable<CEmployees> list = _db.CEmployees;

            list = list.Where(u => u.IsActive == isActive);

            if (section != "انتخاب همه")
            {
                list = list.Where(u => u.Section.Contains(section));
            }

            if (category != "انتخاب همه")
            {
                list = list.Where(u => u.Category.Contains(category));
            }

            if (startDateFrom != null)
            {
                DateTime date = startDateFrom.ToGregorian();
                list = list.Where(u => u.StartDate >= date);
            }

            if (startDateThan != null)
            {
                DateTime date = startDateThan.ToGregorian();
                list = list.Where(u => u.StartDate <= date);
            }

            if (endDateFrom != null)
            {
                DateTime date = endDateFrom.ToGregorian();
                list = list.Where(u => u.EndDate >= date);
            }

            if (endDateThan != null)
            {
                DateTime date = endDateThan.ToGregorian();
                list = list.Where(u => u.EndDate <= date);
            }

            return await list.ToListAsync();
        }

        public bool EmployeeExists(int employeeId)
        {
            return _db.CEmployees.Any(s => s.Id == employeeId);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
