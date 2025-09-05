namespace ubuntu_health_api.Exceptions
{
  public class NotFoundException : Exception
  {
    public NotFoundException() : base()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public NotFoundException(string entityName, int id) : base($"{entityName} with ID {id} was not found.")
    {
    }

    public NotFoundException(string entityName, int id, string tenantId) : base($"{entityName} with ID {id} and Tenant ID {tenantId} was not found.")
    {
    }
  }
}
