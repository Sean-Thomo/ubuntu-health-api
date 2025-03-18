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

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescription.FindAsync(id);
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            await _context.Prescription.AddAsync(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescription.Remove(prescription);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            _context.Prescription.Update(prescription);
            await _context.SaveChangesAsync();
        }
    }
}