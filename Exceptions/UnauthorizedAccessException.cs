namespace ubuntu_health_api.Exceptions
{
  public class UnauthorizedAccessException : Exception
  {
    public UnauthorizedAccessException() : base()
    {
    }

    public UnauthorizedAccessException(string message) : base(message)
    {
    }

    public UnauthorizedAccessException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public UnauthorizedAccessException(string resource, string action) : base($"Unauthorized access to {action} {resource}")
    {
    }
  }
}
