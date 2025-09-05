namespace ubuntu_health_api.Exceptions
{
  public class ConflictException : Exception
  {
    public ConflictException() : base()
    {
    }

    public ConflictException(string message) : base(message)
    {
    }

    public ConflictException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ConflictException(string resource, string identifier) : base($"{resource} with {identifier} already exists")
    {
    }
  }
}
