using System.Collections.Generic;
using System.Threading.Task;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly AppDbContext _context;

        public PrescriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _context.Prescription.ToListAsync();
        }

        public async Task<Prescription> GetPrescrip
    }
}