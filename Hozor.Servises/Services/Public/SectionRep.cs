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
