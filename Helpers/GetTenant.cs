namespace ubuntu_health_api.Helpers;
public class TenantHelper
{
  public static string? GetTenantId(HttpContext context)
  {
    return context.User?.FindFirst("TenantId")?.Value;
  }
}