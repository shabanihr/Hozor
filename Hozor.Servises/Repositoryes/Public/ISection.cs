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
        Task InsertSection(CSections section);
        Task UpdateSection(CSections section);
        Task DeleteSection(int sectionId);
        bool SectionExists(int userId);
        Task Save();
    }
}
