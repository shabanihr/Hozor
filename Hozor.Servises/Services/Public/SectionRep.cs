using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hozor.DataLayer.Models;
using Hozor.Servises.Repositoryes.Public;
using Microsoft.EntityFrameworkCore;

namespace Hozor.Servises.Services.Public
{
    public class SectionRep:ISection
    {
        private readonly Hozor_DBContext _db;
        public SectionRep(Hozor_DBContext db)
        {
            _db = db;
        }

        public async Task<List<CSections>> GetAllSections()
        {
            return await _db.CSections.OrderByDescending(c => c.Id).ToListAsync();
        }

        public async Task<CSections> GetSectionById(int sectionId)
        {
            return await _db.CSections.FindAsync(sectionId);
        }

        public async Task<int> GetTopSectionId()
        {
            return await _db.CSections.Select(r => r.Id).LastOrDefaultAsync();
        }

        public async Task<bool> IsSectionInEmployee(int sectionId)
        {
            var section = await GetSectionById(sectionId);
            return await _db.CEmployees.AnyAsync(e => e.Section == section.Name);
        }

        public async Task<bool> IsSectionByName(string name)
        {
            return await _db.CSections.AnyAsync(s=>s.Name==name);
        }

        public async Task<bool> IsSectionByIdAndName(int id,string name)
        {
            return await _db.CSections.AnyAsync(s => s.Id != id && s.Name==name);
        }

        public async Task InsertSection(CSections section)
        {
            await _db.CSections.AddAsync(section);
        }

        public async Task UpdateSection(CSections section)
        {
            _db.Entry(section).State = EntityState.Modified;
        }

        public async Task DeleteSection(int sectionId)
        {
            var section = await GetSectionById(sectionId);
            _db.Entry(section).State = EntityState.Deleted;
        }

        public bool SectionExists(int sectionId)
        {
            return _db.CSections.Any(s => s.Id == sectionId);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
