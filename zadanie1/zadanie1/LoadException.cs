namespace zadanie1;

public class LoadException : Exception
{
    public LoadException()
    {
    }

    public LoadException(string message)
        : base(message)
    {
    }

    public LoadException(string message, Exception inner)
        : base(message, inner)
    {
    }
}