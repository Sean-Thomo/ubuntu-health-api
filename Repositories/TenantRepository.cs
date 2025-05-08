using ubuntu_health_api.Data;
using ubuntu_health_api.Models;
using Microsoft.EntityFrameworkCore;


namespace ubuntu_health_api.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant> GetTenantByIdAsync(int id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public async Task<IEnumerable<Tenant>> GetAllTenantsAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task AddTenantAsync(Tenant Tenant)
        {
            await _context.Tenants.AddAsync(Tenant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTenantAsync(Tenant Tenant)
        {
            _context.Tenants.Update(Tenant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTenantAsync(int id)
        {
            var Tenant = await GetTenantByIdAsync(id);
            if (Tenant != null)
            {
                _context.Tenants.Remove(Tenant);
                await _context.SaveChangesAsync();
            }
        }

    public Task<Tenant> CreateTenantAsync(Tenant tenant)
    {
      throw new NotImplementedException();
    }

    Task<bool> ITenantRepository.UpdateTenantAsync(Tenant tenant)
    {
      throw new NotImplementedException();
    }

    Task<bool> ITenantRepository.DeleteTenantAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}