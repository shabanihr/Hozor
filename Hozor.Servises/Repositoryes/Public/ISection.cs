using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.ViewModels.Public;

namespace Hozor.Servises.Repositoryes.Public
{
    public interface ISection
    {
        Task<List<CSections>> GetAllSections();
        Task<CSections> GetSectionById(int sectionId);
        Task<int> GetTopSectionId();
        Task<bool> IsSectionInEmployee(int sectionId);
        Task<bool> IsSectionByName(string name);
        Task<bool> IsSectionByIdAndName(int id, string name);
        Task InsertSection(CSections section);
        Task UpdateSection(CSections section);
        Task DeleteSection(int sectionId);
        bool SectionExists(int sectionId);
        Task Save();
    }
}
