using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;

namespace Hozor.Servises.Repositoryes.TrafficEmployee
{
    public interface IEmployee
    {
        Task<List<CEmployees>> GetAllEmployees();
        Task<CEmployees> GetEmployeeById(int employeeId);
        Task<List<CSections>> GetAllSection();
        Task<List<CSections>> GetAllSectionAddRecord();
        Task<bool> IsEmployeeByPersonalId(int personalId);
        Task<bool> IsEmployeeByIdAndPersonalId(int id, int personalId);
        Task InsertEmployee(CEmployees employee);
        Task UpdateEmployee(CEmployees employee);
        Task DeleteEmployee(int employeeId);
        Task<List<CEmployees>> FilterEmployee(string section,string category, bool isActive,
                                            string startDateFrom,string startDateThan,
                                            string endDateFrom, string endDateThan);
        bool EmployeeExists(int employeeId);
        Task Save();
    }
}
