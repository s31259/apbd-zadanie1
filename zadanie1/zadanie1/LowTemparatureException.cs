namespace zadanie1;

public class LowTemparatureException : Exception
{
    public LowTemparatureException()
    {
    }

    public LowTemparatureException(string message)
        : base(message)
    {
    }

    public LowTemparatureException(string message, Exception inner)
        : base(message, inner)
    {
    }
}