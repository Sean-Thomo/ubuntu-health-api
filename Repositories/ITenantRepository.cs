using ubuntu_health_api.Models;

namespace ubuntu_health_api.Repositories
{
  public interface ITenantRepository
  {
    Task<Tenant> GetTenantByIdAsync(int id);
    Task<IEnumerable<Tenant>> GetAllTenantsAsync();
    Task<Tenant> CreateTenantAsync(Tenant tenant);
    Task<bool> UpdateTenantAsync(Tenant tenant);
    Task<bool> DeleteTenantAsync(int id);
  }   
}