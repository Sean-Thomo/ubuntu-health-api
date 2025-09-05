namespace ubuntu_health_api.Exceptions
{
  public class ValidationException : Exception
  {
    public Dictionary<string, string[]> Errors { get; }

    public ValidationException() : base()
    {
      Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(string message) : base(message)
    {
      Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
      Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(Dictionary<string, string[]> errors) : base("One or more validation errors occurred.")
    {
      Errors = errors;
    }

    public ValidationException(string message, Dictionary<string, string[]> errors) : base(message)
    {
      Errors = errors;
    }
  }
}
