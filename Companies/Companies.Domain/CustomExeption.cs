namespace Companies.Domain
{
    public class CustomExeption : Exception
    {
        public CustomExeption(string message, Exception? exception = null) : base(message, exception)
        { }
    }
}
